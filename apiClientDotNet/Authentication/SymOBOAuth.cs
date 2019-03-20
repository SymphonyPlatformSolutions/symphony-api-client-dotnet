using System;
using System.Collections.Generic;
using System.Text;
using apiClientDotNet.Models;
using Newtonsoft.Json.Linq;
using apiClientDotNet.Utils;
using System.Net;

namespace apiClientDotNet.Authentication
{

    public class SymOBOAuth 
    {
        AuthTokens authTokens;
        private String sessionToken;
        private String kmToken;
        private SymConfig symConfig;

        public SymOBOAuth(SymConfig config)
        {
            symConfig = config;
            authTokens = new AuthTokens();
        }

        public SymOBOUserAuth getUserAuth(String username)
        {
            SymOBOUserAuth userAuth = new SymOBOUserAuth(symConfig, username, this);
            userAuth.authenticate();
            authTokens.sessionToken = userAuth.getSessionToken();
            sessionToken = userAuth.getSessionToken();
            return userAuth;
        }

        public SymOBOUserAuth getUserAuth(long uid)
        {
            SymOBOUserAuth userAuth = new SymOBOUserAuth(symConfig,
                    uid, this);
            userAuth.authenticate();
            return userAuth;
        }

        public void sessionAppAuthenticate()
        {
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = "https://" + symConfig.sessionAuthHost + ":" + symConfig.sessionAuthPort + AuthEndpointConstants.SESSIONAPPAUTH;
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, true, WebRequestMethods.Http.Post, symConfig, false);
            string body = restRequestHandler.ReadResponse(resp);
            resp.Close();
            JObject o = JObject.Parse(body);
            authTokens.sessionToken = (string)o["token"];
            sessionToken = authTokens.sessionToken;
            symConfig.authTokens = authTokens;
        }


    }
}
