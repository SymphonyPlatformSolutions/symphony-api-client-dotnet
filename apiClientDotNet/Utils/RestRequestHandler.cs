using System;
using System.Text;
using apiClientDotNet.Models;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace apiClientDotNet.Utils
{
    public class RestRequestHandler
    {
        public X509CertificateCollection Certificates { get; protected set; }

        public void AddCert(string fileName, string password)
        {
            var cert = File.ReadAllBytes(fileName);
            Certificates.Add(new X509Certificate2(cert, password));
        }

        public HttpWebResponse executeRequest(object data, String url, bool isAuth, string method, SymConfig symConfig, bool isAgent)
        {
            HttpWebResponse response = null;
            //If POST and not Auth set response to postApi
            if (method == WebRequestMethods.Http.Post && isAuth != true)
            {
                response = postApi(symConfig, url, data, isAgent);
            }
            //If not create HttpWebRequest
            else
            {
                var request = (HttpWebRequest) WebRequest.Create(url);
                SetProxy(request, symConfig);

                request.Credentials = CredentialCache.DefaultCredentials;
                request.Method = method;

                //If Auth Call
                if (isAuth)
                {
                    //If RSAAuth
                    if (url.EndsWith("pubkey/authenticate"))
                    {
                        request.Credentials = null;
                        if (data != null)
                        {
                            var json = JsonConvert.SerializeObject(data);
                            var jsonBytes = Encoding.ASCII.GetBytes(json);
                            request.ContentLength = jsonBytes.Length;

                            using (var stream = request.GetRequestStream())
                            {
                                stream.Write(jsonBytes, 0, jsonBytes.Length);
                            }
                        }
                    }
                    else
                    {
                        Certificates = new X509CertificateCollection();
                        var cert = File.ReadAllBytes(symConfig.botCertPath + symConfig.botCertName + ".p12");
                        Certificates.Add(new X509Certificate2(cert, symConfig.botCertPassword));
                        request.ClientCertificates.AddRange(Certificates);
                        if (symConfig.authTokens != null)
                        {
                            request.Headers.Add("sessionToken", symConfig.authTokens.sessionToken);
                        }
                    }
                }
                else
                {
                    //If not Auth call add sessionToken and if Agent keyManagerToken
                    request.Headers.Add("sessionToken", symConfig.authTokens.sessionToken);
                    if (isAgent)
                    {
                        request.Headers.Add("keyManagerToken", symConfig.authTokens.keyManagerToken);
                    }
                }

                //Make request and get response
                try
                {
                    response = (HttpWebResponse) request.GetResponse();
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        var errorHandler = new ErrorHandler();
                        errorHandler.handleError(response);
                    }

                    return response;
                }
                catch (WebException we)
                {
                    response = we.Response as HttpWebResponse;
                    Console.Write(response);
                }

                response = null;
            }

            return response;
        }

        private void SetProxy(HttpWebRequest request, SymConfig symConfig)
        {
            string proxyUrl = null;
            string proxyUserName = null;
            string proxyPassword = null;

            // Find proxy
            var path = request.RequestUri.AbsolutePath;
            if (path.StartsWith("/login/") || path.StartsWith("/sessionauth/")) // Session
            {
                proxyUrl = symConfig.sessionProxyURL;
                proxyUserName = symConfig.sessionProxyUsername;
                proxyPassword = symConfig.sessionProxyPassword;
            }
            else if (path.StartsWith("/relay/")) // Key Manager
            {
                proxyUrl = symConfig.keyManagerProxyURL;
                proxyUserName = symConfig.keyManagerProxyUsername;
                proxyPassword = symConfig.keyManagerProxyPassword;
            }
            else if (path.StartsWith("/pod/")) // Pod
            {
                proxyUrl = symConfig.podProxyURL;
                proxyUserName = symConfig.podProxyUsername;
                proxyPassword = symConfig.podProxyPassword;
            }
            else if (path.Contains("/agent/")) // Agent
            {
                proxyUrl = symConfig.agentProxyURL;
                proxyUserName = symConfig.agentProxyUsername;
                proxyPassword = symConfig.agentProxyPassword;
            }

            // Defaulting on global proxy
            if (string.IsNullOrEmpty(proxyUrl))
            {
                proxyUrl = symConfig.proxyURL;
                proxyUserName = symConfig.proxyUsername;
                proxyPassword = symConfig.proxyPassword;
            }

            // Create and set proxy if any
            if (!string.IsNullOrEmpty(proxyUrl))
            {
                var sessionProxy = new WebProxy();
                var sessionProxyUri = new Uri(proxyUrl);
                sessionProxy.Address = sessionProxyUri;
                if (!string.IsNullOrEmpty(proxyUserName) && !string.IsNullOrEmpty(proxyPassword))
                    sessionProxy.Credentials = new NetworkCredential(proxyUserName, proxyPassword);
                else
                    sessionProxy.Credentials = CredentialCache.DefaultNetworkCredentials; // Credential from current account
                request.Proxy = sessionProxy;
            }
        }

        public string ReadResponse(HttpWebResponse resp)
        {
            var reader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            var responseString = reader.ReadToEnd();
            return responseString;
        }

        public HttpResponseMessage executePostFormRequest(object data, String url, SymConfig symConfig)
        {
            var message = (OutboundMessage) data;
            HttpContent stringContent = new StringContent(message.message);

            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(stringContent, "message", "message");
                if (message.attachments != null)
                {
                    foreach (var attachment in message.attachments)
                    {
                        byte[] buffer = null;
                        buffer = new byte[attachment.Length];
                        attachment.Read(buffer, 0, (int) attachment.Length);
                        HttpContent byteArrayContent = new ByteArrayContent(buffer);

                        byteArrayContent.Headers.Add("Content-Type", "application/octet-stream");
                        var fileName = Path.GetFileName(attachment.Name);
                        formData.Add(byteArrayContent, "attachment", fileName);
                    }
                }

                client.DefaultRequestHeaders.Add("sessionToken", symConfig.authTokens.sessionToken);
                if (symConfig.authTokens.keyManagerToken != null)
                {
                    client.DefaultRequestHeaders.Add("keyManagerToken", symConfig.authTokens.keyManagerToken);
                }

                var response = client.PostAsync(url, formData).Result;

                // ensure the request was a success
                if (!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(response.ToString());
                    return null;
                }

                return response;
            }
        }

        private HttpWebResponse postApi(SymConfig symConfig, string url, object data, bool isAgent)
        {
            var targetUri = new System.Uri(url);
            var request = (HttpWebRequest) WebRequest.Create(targetUri);
            SetProxy(request, symConfig);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            //request.Headers["Pragma"] = "no-cache";           
            var json = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(data, Formatting.Indented));
            if (isAgent)
            {
                request.Headers.Add("sessionToken", symConfig.authTokens.sessionToken);
                request.Headers.Add("keyManagerToken", symConfig.authTokens.keyManagerToken);
            }
            else 
            {
                request.Headers.Add("sessionToken", symConfig.authTokens.sessionToken);
            }

            request.Method = "POST";
            request.ContentType = "application/json";
            if (data != null)
            {
                request.ContentLength = json.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(json, 0, json.Length);
                }
            }

            var response = (HttpWebResponse) request.GetResponse();

            return response;
        }
    }
}