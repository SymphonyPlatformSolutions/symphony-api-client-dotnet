using System;
using System.Collections.Generic;
using System.Text;
using apiClientDotNet.Models;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace apiClientDotNet.Utils
{
    public class RestRequestHandler
    {
        public X509CertificateCollection Certificates
        {
            get;
            protected set;
        }

        public void AddCert(string fileName, string password)
        {
            byte[] cert = File.ReadAllBytes(fileName);
            Certificates.Add(new X509Certificate2(cert, password));
        }

        public HttpWebResponse executeRequest(object data, String url, bool isAuth, string method, SymConfig symConfig, bool isAgent)
        {
            HttpWebResponse response = null;
            //If POST and not Auth set response to postApi
            if ( method == WebRequestMethods.Http.Post && isAuth != true)
            {
                response = postApi(symConfig, url, data, isAgent);
            }
            //If not create HttpWebRequest
            else {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            
                //Set Proxy
                if (symConfig.sessionProxyURL.Length > 0 && url.Contains("sessionauth"))
                {
                    WebProxy sessionProxy = new WebProxy();
                    Uri sessionProxyUri = new Uri(symConfig.sessionProxyURL);
                    sessionProxy.Address=sessionProxyUri;
                    sessionProxy.Credentials = new NetworkCredential(symConfig.sessionProxyUsername, symConfig.sessionProxyPassword);
                    req.Proxy = sessionProxy;
                } else if (symConfig.proxyURL.Length > 0 && (url.Contains("pod") || url.Contains("sessionauth") || url.EndsWith("/login/pubkey/authenticate")))
                {
                    WebProxy proxy = new WebProxy();
                    Uri proxyUri = new Uri(symConfig.proxyURL);
                    proxy.Address = proxyUri;
                    proxy.Credentials = new NetworkCredential(symConfig.proxyUsername, symConfig.proxyPassword);
                    req.Proxy = proxy;
                }

                req.Credentials = CredentialCache.DefaultCredentials;
                req.Method = method;

                //If Auth Call
                if (isAuth)
                {
                    //If RSAAuth
                    if (url.EndsWith("pubkey/authenticate"))
                    {
                        req.Credentials = null;
                        if (data != null)
                        {
                            var json = JsonConvert.SerializeObject(data);
                            var jsonBytes = Encoding.ASCII.GetBytes(json);
                            req.ContentLength = jsonBytes.Length;

                            using (var stream = req.GetRequestStream())
                            {
                                stream.Write(jsonBytes, 0, jsonBytes.Length);
                            }
                        }
                    }
                    else {
                        Certificates = new X509CertificateCollection();
                        byte[] cert = File.ReadAllBytes(symConfig.botCertPath + symConfig.botCertName + ".p12");
                        Certificates.Add(new X509Certificate2(cert, symConfig.botCertPassword));
                        req.ClientCertificates.AddRange(Certificates);
                        if (symConfig.authTokens != null)
                        {
                            req.Headers.Add("sessionToken", symConfig.authTokens.sessionToken);
                        }
                    }
                } else { //If not Auth call add sessionToken and if Agent keyManagerToken
                    req.Headers.Add("sessionToken", symConfig.authTokens.sessionToken);
                    if (isAgent) {
                        req.Headers.Add("keyManagerToken", symConfig.authTokens.keyManagerToken);
                    }
                } 

                //Make request and get response
                try
                {
    
                    response = (HttpWebResponse)req.GetResponse();
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        ErrorHandler errorHandler = new ErrorHandler();
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

        public string ReadResponse(HttpWebResponse resp)
        {
            StreamReader reader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            String responseString = reader.ReadToEnd();
            return responseString;
        }


        public HttpResponseMessage executePostFormRequest(object data, String url, SymConfig symConfig)
        {
            OutboundMessage message = (OutboundMessage)data;
            HttpContent stringContent = new StringContent(message.message);

            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(stringContent, "message", "message");
                if(message.attachments != null)
                {
                    foreach( FileStream attachment in message.attachments)
                    {
                        byte[] buffer = null;
                        buffer = new byte[attachment.Length];
                        attachment.Read(buffer, 0, (int)attachment.Length);
                        HttpContent byteArrayContent = new ByteArrayContent(buffer);

                        byteArrayContent.Headers.Add("Content-Type", "application/octet-stream");
                        String fileName = Path.GetFileName(attachment.Name);
                        formData.Add(byteArrayContent, "attachment", fileName);
                    }
                }
                        
                client.DefaultRequestHeaders.Add("sessionToken", symConfig.authTokens.sessionToken);
                if(symConfig.authTokens.keyManagerToken != null)
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
            System.Uri targetUri = new System.Uri(url);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(targetUri);
            request.Method = "Post";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            //request.Headers["Pragma"] = "no-cache";           
            var json = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(data, Formatting.Indented));
            if (isAgent)
            {
                request.Headers.Add("sessionToken", symConfig.authTokens.sessionToken);
                request.Headers.Add("keyManagerToken", symConfig.authTokens.keyManagerToken);
            }
            else if (!isAgent)
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

            var response = (HttpWebResponse)request.GetResponse();

            return response;
        }
    }
}
