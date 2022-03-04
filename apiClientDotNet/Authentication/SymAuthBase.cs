using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using apiClientDotNet.Models;
using apiClientDotNet.Utils;

namespace apiClientDotNet.Authentication
{
    public abstract class SymAuthBase : ISymAuth
    {
        protected string SessionToken;
        protected string KeyManagerToken;
        protected SymConfig SymConfig;
        private HttpClient SessionAuthClient;
        private HttpClient KeyAuthClient;
        private HttpClient CertificateSessionAuthClient;
        private HttpClient CertificateKeyAuthClient;
        private HttpClient CertificateOBOSessionAuthClient;

        protected HttpClient GetCertificateSessionAuthClient() {
            if (CertificateSessionAuthClient == null) {
                if (SymConfig.botCertPath != "" && SymConfig.botCertName != "") {
                    string botCertificatePath = SymConfig.botCertPath + SymConfig.botCertName;
                    if (!File.Exists(botCertificatePath) && File.Exists(botCertificatePath + ".p12")) {
                        botCertificatePath = botCertificatePath + ".p12";
                    }
                    else  {
                        throw new FileNotFoundException("File not found: " + botCertificatePath);
                    }
                    CertificateSessionAuthClient = CreateHttpClient(SymConfig.sessionAuthHost, SymConfig.sessionAuthPort, SymConfig.sessionProxyURL, SymConfig.sessionProxyUsername, SymConfig.sessionProxyPassword, botCertificatePath, SymConfig.botCertPassword);
                }
                else {
                    throw new MissingFieldException("botCertPath and botCertName not specified");
                }
            }
            return CertificateSessionAuthClient;
        }

        protected HttpClient GetSessionAuthClient() {
            if (SessionAuthClient == null) {
                SessionAuthClient = CreateHttpClient(SymConfig.podHost, SymConfig.podPort, SymConfig.podProxyURL, SymConfig.podProxyUsername, SymConfig.podProxyPassword, null, null);
            }
            return SessionAuthClient;
        }

        protected HttpClient GetCertificateKeyAuthClient(){
            if (CertificateKeyAuthClient == null) {
                if (SymConfig.botCertPath != "" && SymConfig.botCertName != "") {
                    string botCertificatePath = SymConfig.botCertPath + SymConfig.botCertName;
                    if (!File.Exists(botCertificatePath) && File.Exists(botCertificatePath + ".p12")) {
                        botCertificatePath = botCertificatePath + ".p12";
                    }
                    else  {
                        throw new FileNotFoundException("File not found: " + botCertificatePath);
                    }
                    CertificateKeyAuthClient = CreateHttpClient(SymConfig.keyAuthHost, SymConfig.keyAuthPort, SymConfig.keyManagerProxyURL, SymConfig.keyManagerProxyUsername, SymConfig.keyManagerProxyPassword, botCertificatePath, SymConfig.botCertPassword);
                }
                else {
                    throw new MissingFieldException("botCertPath and botCertName not specified");
                }
            }
            return CertificateKeyAuthClient;
        }

        protected HttpClient GetKeyAuthClient() {
            if (KeyAuthClient == null) {
                KeyAuthClient = CreateHttpClient(SymConfig.keyAuthHost, SymConfig.keyAuthPort, SymConfig.keyManagerProxyURL, SymConfig.keyManagerProxyUsername, SymConfig.keyManagerProxyPassword, null, null);
            }
            return KeyAuthClient;
        }

        protected HttpClient GetCertificateOBOSessionAuthClient(){
            if (CertificateOBOSessionAuthClient == null) {
                if (SymConfig.appCertPath != "" && SymConfig.appCertName != "") {
                    string appCertificatePath = SymConfig.appCertPath + SymConfig.appCertName;
                    if (!File.Exists(appCertificatePath) && File.Exists(appCertificatePath + ".p12")) {
                        appCertificatePath = SymConfig.appCertPath + SymConfig.appCertName + ".p12";
                    }
                    else  {
                        throw new FileNotFoundException("File not found: " + appCertificatePath);
                    }
                    CertificateOBOSessionAuthClient = CreateHttpClient(SymConfig.sessionAuthHost, SymConfig.sessionAuthPort, SymConfig.sessionProxyURL, SymConfig.sessionProxyUsername, SymConfig.sessionProxyPassword, appCertificatePath, SymConfig.appCertPassword);
                }
                else {
                    throw new MissingFieldException("appCertPath and appCertName not specified");
                }
            }
            return CertificateOBOSessionAuthClient;
        }
        
        protected HttpClient GetOBOSessionAuthClient() {
            return GetSessionAuthClient();
        }

        private HttpClient CreateHttpClient(string authUrl, int authPort, string proxyUrl, string proxyUsername, string proxyPassword, string certificatePath, string certificatePassword) {
            var requestHandler = new HttpClientHandler();
            if (!string.IsNullOrEmpty(proxyUrl)) {
                requestHandler.Proxy = RequestProxyBuilder.CreateWebProxy(proxyUrl, proxyUsername, proxyPassword);
            }
            else if (!string.IsNullOrEmpty(SymConfig.proxyURL)) {
                requestHandler.Proxy = RequestProxyBuilder.CreateWebProxy(SymConfig.proxyURL, SymConfig.proxyUsername, SymConfig.proxyPassword);
            }
            if (certificatePath != null) {
                var certificate = File.ReadAllBytes(certificatePath);
                requestHandler.ClientCertificates.Add(new X509Certificate2(certificate, certificatePassword));
            }
            var httpClient = new HttpClient(requestHandler);
            httpClient.BaseAddress = new UriBuilder("https", authUrl, authPort).Uri;
            return httpClient;
        }

        public virtual string GetSessionToken() 
        {
            return SessionToken;
        }

        public string getSessionToken(){
            return GetSessionToken();
        }

        public virtual void SetSessionToken(string sessionToken) 
        {
            SessionToken = sessionToken;
        }

        public void setSessionToken(string sessionToken){
            SetSessionToken(sessionToken);
        }

        public abstract void Authenticate();
        public void authenticate(){
            Authenticate();
        }
        public abstract void SessionAuthenticate();
        public void sessionAuthenticate(){
            SessionAuthenticate();
        }
        public abstract void KeyManagerAuthenticate();
        public void kmAuthenticate(){
            KeyManagerAuthenticate();
        }
        public abstract string GetKeyManagerToken();
        public string getKmToken(){
            return GetKeyManagerToken();
        }
        public abstract void SetKeyManagerToken(string kmToken);
        public void setKmToken(string kmToken){
            SetKeyManagerToken (kmToken);
        }
        public abstract void Logout();
        public void logout(){
            Logout();
        }

        public SymConfig GetSymConfig() {
            return SymConfig;
        }
    }
}