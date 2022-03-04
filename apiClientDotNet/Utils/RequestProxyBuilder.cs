using System;
using System.Net;

namespace apiClientDotNet.Utils
{
     public static class RequestProxyBuilder
     {
        public static WebProxy CreateWebProxy(string proxyUrl, string proxyUsername, string proxyPassword) 
        {
            var webProxy = new WebProxy();
            var webProxyUri = new Uri(proxyUrl);
            webProxy.Address = webProxyUri;
            if (!string.IsNullOrEmpty(proxyUsername) && !string.IsNullOrEmpty(proxyPassword)) 
            {
                webProxy.Credentials = new NetworkCredential(proxyUsername, proxyPassword);
            }
            else 
            {
                webProxy.Credentials = CredentialCache.DefaultNetworkCredentials; // Credential from current account
            }
            return webProxy;
        }
     }
 }