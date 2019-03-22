using System;
using System.Collections.Generic;
using System.Text;
using apiClientDotNet.Models;
using Newtonsoft.Json.Linq;
using apiClientDotNet.Utils;
using System.Net;

namespace apiClientDotNet.Authentication
{
    public class SymOBOUserAuth : ISymAuth
    {
        AuthTokens authTokens;
        private String sessionToken;
        private SymConfig config;
        private long uid;
        private String username;
        private SymOBOAuth appAuth;

        public SymOBOUserAuth( SymConfig config, long uid, SymOBOAuth appAuth)
        {
            this.config = config;
            this.uid = uid;
            this.appAuth = appAuth;
            authTokens = config.authTokens;
        }

        public SymOBOUserAuth( SymConfig config, String username, SymOBOAuth appAuth)
        {
            this.config = config;
            this.username = username;
            this.appAuth = appAuth;
            authTokens = config.authTokens;
        }

        public void authenticate()
        {
            sessionAuthenticate();
        }

        public string getKmToken()
        {
            throw new NotImplementedException();
        }

        public string getSessionToken()
        {
            return sessionToken;
        }

        public void kmAuthenticate()
        {
            throw new NotImplementedException();
        }

        public void sessionAuthenticate()
        {
            if (uid != 0)
            {
                RestRequestHandler restRequestHandler = new RestRequestHandler();
                string url = "https://" + config.sessionAuthHost + ":" + config.sessionAuthPort + AuthEndpointConstants.OBOUSERAUTH.Replace("{uid}", uid.ToString());
                HttpWebResponse resp = restRequestHandler.executeRequest(null, url, true, WebRequestMethods.Http.Post, config, false);
                string body = restRequestHandler.ReadResponse(resp);
                resp.Close();
                JObject o = JObject.Parse(body);
                authTokens.sessionToken = (string)o["sessionToken"];
                sessionToken = authTokens.sessionToken;
            }
            else
            {
                RestRequestHandler restRequestHandler = new RestRequestHandler();
                string url = "https://" + config.sessionAuthHost + ":" + config.sessionAuthPort + AuthEndpointConstants.OBOUSERAUTHUSERNAME.Replace("{username}", username);
                HttpWebResponse resp = restRequestHandler.executeRequest(null, url, true, WebRequestMethods.Http.Post, config, false);
                string body = restRequestHandler.ReadResponse(resp);
                resp.Close();
                JObject o = JObject.Parse(body);
                authTokens.sessionToken = (string)o["sessionToken"];
                sessionToken = authTokens.sessionToken;

            }
        }

        public void setKmToken(string kmToken)
        {
            throw new NotImplementedException();
        }

        public void setSessionToken(string sessionToken)
        {

            this.sessionToken = sessionToken;
            this.authTokens.sessionToken = sessionToken;
        }

        public void logout()
        {
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = "https://" + config.sessionAuthHost + ":" + config.sessionAuthPort + AuthEndpointConstants.LOGOUTPATH;
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, true, WebRequestMethods.Http.Post, config, false);
            string body = restRequestHandler.ReadResponse(resp);
            resp.Close();
            JObject o = JObject.Parse(body);
            string message = (string)o["message"];
        }
    }
}
