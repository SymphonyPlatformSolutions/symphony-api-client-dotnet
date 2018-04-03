using System;
using System.Collections.Generic;
using System.Text;
using apiClientDotNet.Models;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net;

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
            if (data is Message && method == WebRequestMethods.Http.Post)
            {
                Message message = (Message)data;
                req.ContentType = "multipart/form-data";
                var postData = "message=" + message.message;
                var formData = Encoding.ASCII.GetBytes(postData);
                req.ContentLength = formData.Length;

                using (var reqStream = req.GetRequestStream())
                {
                    reqStream.Write(formData, 0, formData.Length);
                }
            }
                

            //req.Proxy = Proxy;

            HttpWebResponse resp = null;
            try
            {
                return (HttpWebResponse)req.GetResponse();
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
    }
}
