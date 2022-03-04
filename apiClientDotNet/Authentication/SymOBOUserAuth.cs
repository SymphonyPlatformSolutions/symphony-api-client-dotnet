using System;
using apiClientDotNet.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace apiClientDotNet.Authentication
{
    public class SymOBOUserAuth : SymAuthBase
    {
        public long UserId {get; private set;}
        public String UserName {get; private set;}
        private SymOBOAuth AppAuth;

        public SymOBOUserAuth(long uid, SymOBOAuth appAuth)
        {
            UserId = uid;
            AppAuth = appAuth;
            SymConfig = appAuth.GetSymConfig();
            SymConfig.authTokens = new AuthTokens();
        }

        public SymOBOUserAuth(string username, SymOBOAuth appAuth)
        {
            UserId = 0;
            UserName = username;
            AppAuth = appAuth;
            SymConfig = appAuth.GetSymConfig();
            SymConfig.authTokens = new AuthTokens();
        }

        public override void Authenticate(){
            SessionAuthenticate();
        }

        public override void SessionAuthenticate()
        {
            AppAuth.authenticate();
            string requestPath;
            if (UserId != 0) 
            {
                requestPath = AuthEndpointConstants.OboUserAuthByIdPath.Replace("{uid}", UserId.ToString());
            }
            else 
            {
                requestPath = AuthEndpointConstants.OboUserAuthByUsernamePath.Replace("{username}", UserName);
            }
            var request = new HttpRequestMessage() {
                RequestUri = new Uri( GetSessionAuthClient().BaseAddress + requestPath),
                Method = HttpMethod.Post
            };
            request.Headers.Add("sessionToken", AppAuth.GetSessionToken());
            var response = GetSessionAuthClient().SendAsync(request).Result;
            if (response.IsSuccessStatusCode) 
            {
                SessionToken = JsonConvert.DeserializeObject<Token>(response.Content.ReadAsStringAsync().Result).token;
                SymConfig.authTokens.sessionToken = SessionToken;
            }
            else 
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound) {
                    throw new Exception("User Not Found.");
                }
                else throw new Exception("Unable to Authenticate");
            }
        }

        public override void Logout()
        {
            var response = AppAuth.GetAppAuthClient().PostAsync(AuthEndpointConstants.LogoutPath, null).Result;
        }

        public override string GetKeyManagerToken(){
            return "";
        }

        public override void SetKeyManagerToken(string kmToken) {}
        public override void KeyManagerAuthenticate() {}
    }
}
