using System;
using apiClientDotNet.Models;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using apiClientDotNet.Utils;



namespace apiClientDotNet.Authentication
{   
 
    public class SymBotAuth : ISymAuth
    {

        AuthTokens authTokens;
        private String sessionToken;
        private String kmToken;
        private SymConfig symConfig;
        //private Client sessionAuthClient;
        //private Client kmAuthClient;

        public SymBotAuth(SymConfig config)
        {
            symConfig = config;
        }

            public void authenticate()
        {
            authTokens = new AuthTokens();
            sessionAuthenticate();
            kmAuthenticate();
            symConfig.authTokens = authTokens;
        }

        public void sessionAuthenticate()
        {
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = "https://" + symConfig.sessionAuthHost + ":" + symConfig.sessionAuthPort + "/sessionauth/v1/authenticate";
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, true, WebRequestMethods.Http.Post, symConfig, false);
            string body = restRequestHandler.ReadResponse(resp);
            JObject o = JObject.Parse(body);
            authTokens.sessionToken = (string)o["token"];
            sessionToken = authTokens.sessionToken;
          
        }

        public void kmAuthenticate()
        {
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = "https://" + symConfig.keyAuthHost + ":" + symConfig.keyAuthPort + "/keyauth/v1/authenticate";
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, true, WebRequestMethods.Http.Post, symConfig, false);
            string body = restRequestHandler.ReadResponse(resp);
            JObject o = JObject.Parse(body);
            authTokens.keyManagerToken = (string)o["token"];
            kmToken = authTokens.keyManagerToken;

        }

        public String getSessionToken()
        {
            return sessionToken;

        }

        public void setSessionToken(String sessionToken)
        {

        }

        public String getKmToken()
        {
            return kmToken;
        }

        public void setKmToken(String kmToken)
        {

        }

        public void logout()
        {

        }
    }
}
