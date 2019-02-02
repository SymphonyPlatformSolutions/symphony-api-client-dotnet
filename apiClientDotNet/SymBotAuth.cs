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



namespace apiClientDotNet
{   
 
    public class SymBotAuth
    {

        AuthTokens authTokens;

        public AuthTokens authenticate(SymConfig symConfig)
        {
            authTokens = new AuthTokens();
            sessionAuth(symConfig);
            keyManagerAuth(symConfig);
            symConfig.authTokens = authTokens;
            return authTokens;
        }

        private void sessionAuth(SymConfig symConfig)
        {
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = "https://" + symConfig.sessionAuthHost + ":" + symConfig.sessionAuthPort + "/sessionauth/v1/authenticate";
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, true, WebRequestMethods.Http.Post, symConfig, false);
            string body = restRequestHandler.ReadResponse(resp);
            JObject o = JObject.Parse(body);
            authTokens.sessionToken = (string)o["token"];
          
        }

        private void keyManagerAuth(SymConfig symConfig)
        {
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = "https://" + symConfig.keyAuthHost + ":" + symConfig.keyAuthPort + "/keyauth/v1/authenticate";
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, true, WebRequestMethods.Http.Post, symConfig, false);
            string body = restRequestHandler.ReadResponse(resp);
            JObject o = JObject.Parse(body);
            authTokens.keyManagerToken = (string)o["token"];

        }
    }
}
