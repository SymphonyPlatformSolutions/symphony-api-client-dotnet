using System;
using System.Collections.Generic;
using System.Text;
using apiClientDotNet.Models;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Collections.Specialized;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;

namespace apiClientDotNet.Utils
{
    class RestRequestHandler
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
            if (data is Message && method == WebRequestMethods.Http.Post)
            {
                postFormData(symConfig, url, data);
            }
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Credentials = CredentialCache.DefaultCredentials;
            req.Method = method;
            if (isAuth)
            {
                Certificates = new X509CertificateCollection();
                byte[] cert = File.ReadAllBytes(symConfig.botCertPath + symConfig.botCertName + ".p12");
                Certificates.Add(new X509Certificate2(cert, symConfig.botCertPassword));
                req.ClientCertificates.AddRange(Certificates);
            } else if (isAgent)
            {
                req.Headers.Add("sessionToken", symConfig.authTokens.sessionToken);
                req.Headers.Add("keyManagerToken", symConfig.authTokens.keyManagerToken);
            } else if (!isAgent)
            {
                req.Headers.Add("sessionToken", symConfig.authTokens.sessionToken);
            }
            
                

            //req.Proxy = Proxy;

            HttpWebResponse resp = null;
            try
            {
                resp = (HttpWebResponse)req.GetResponse();
                if (resp.StatusCode != HttpStatusCode.OK)
                {
                    ErrorHandler errorHandler = new ErrorHandler();
                    errorHandler.handleError(resp);
                }

                return resp;
            }
            catch (WebException we)
            {
                resp = we.Response as HttpWebResponse;
                Console.Write(resp);
            }
            return null;
        }

        public string ReadResponse(HttpWebResponse resp)
        {
            StreamReader reader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            String responseString = reader.ReadToEnd();
            return responseString;
        }

     

        private System.IO.Stream postFormData(SymConfig symConfig, string url, object data)
        {
            Message message = (Message)data;
            HttpContent stringContent = new StringContent(message.message);
            // examples of converting both Stream and byte [] to HttpContent objects
            // representing input type file
           // HttpContent fileStreamContent = new StreamContent(fileStream);
           // HttpContent bytesContent = new ByteArrayContent(fileBytes);

            // Submit the form using HttpClient and 
            // create form data as Multipart (enctype="multipart/form-data")

            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                // Add the HttpContent objects to the form data

                // <input type="text" name="filename" />
                formData.Add(stringContent, "message", "message");
                // <input type="file" name="file1" />
                //formData.Add(fileStreamContent, "file1", "file1");
                // <input type="file" name="file2" />
                //formData.Add(bytesContent, "file2", "file2");

                // Invoke the request to the server

                // equivalent to pressing the submit button on
                // a form with attributes (action="{url}" method="post")
                client.DefaultRequestHeaders.Add("sessionToken", symConfig.authTokens.sessionToken);
                client.DefaultRequestHeaders.Add("keyManagerToken", symConfig.authTokens.keyManagerToken);
                var response = client.PostAsync(url, formData).Result;

                // ensure the request was a success
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                return response.Content.ReadAsStreamAsync().Result;
            }
        }
    }
}
