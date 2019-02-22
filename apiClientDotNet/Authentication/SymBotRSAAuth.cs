using System;
using System.Collections.Generic;
using System.Text;
using apiClientDotNet.Models;
using System.Net;
using Newtonsoft.Json.Linq;
using apiClientDotNet.Utils;

namespace apiClientDotNet.Authentication
{
    public class SymBotRSAAuth : ISymAuth
    {

        AuthTokens authTokens;
        private String sessionToken;
        private String kmToken;
        private SymConfig symConfig;
        private String jwt;

        public SymBotRSAAuth(SymConfig config) {
            this.symConfig = config;
            this.authTokens = new AuthTokens();
        }
        
        public void authenticate() {
            JWTHandler jwtHandler = new JWTHandler();
            jwt = jwtHandler.generateJWT(symConfig);
            sessionAuthenticate();
            kmAuthenticate();
            symConfig.authTokens = authTokens;
        }
        
        public void sessionAuthenticate() {

            Dictionary<String, String> token = new Dictionary<string, string>();
            token.Add("token", jwt);
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = "https://" + symConfig.sessionAuthHost + ":" + symConfig.sessionAuthPort + AuthEndpointConstants.RSASESSIONAUTH;
            HttpWebResponse resp = restRequestHandler.executeRequest(token, url, true, WebRequestMethods.Http.Post, symConfig, false);
            string body = restRequestHandler.ReadResponse(resp);
            JObject o = JObject.Parse(body);
            authTokens.sessionToken = (string) o.SelectToken("token");
            sessionToken = authTokens.sessionToken;    
        }

        public void kmAuthenticate() {

            Dictionary<String, String> token = new Dictionary<string, string>();
            token.Add("token", jwt);
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = "https://" + symConfig.keyAuthHost + ":" + symConfig.keyAuthPort + AuthEndpointConstants.RSAKMAUTH;
            HttpWebResponse resp = restRequestHandler.executeRequest(token, url, true, WebRequestMethods.Http.Post, symConfig, false);
            string body = restRequestHandler.ReadResponse(resp);
            JObject o = JObject.Parse(body);
            authTokens.keyManagerToken = (string) o.SelectToken("token");
            kmToken = authTokens.keyManagerToken;
        }

        public String getSessionToken() {
            return sessionToken;
        }

        public void setSessionToken(String sessionToken) {
            this.sessionToken = sessionToken;
        }

        public String getKmToken() {
            return kmToken;
        }

        public void setKmToken(String kmToken) {
            this.kmToken = kmToken;
        }

        public void logout() {
            //Add Logout
        }
    }
}
