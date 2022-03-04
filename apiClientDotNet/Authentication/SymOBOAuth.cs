using System;
using apiClientDotNet.Models;
using System.Net.Http;
using Newtonsoft.Json;


namespace apiClientDotNet.Authentication 
{

    public class SymOBOAuth : SymAuthBase
    {
        public string AppSessionToken
        { 
            get { return SessionToken; }
            set { SessionToken = value; }
        }
        
        public SymOBOAuth(SymConfig config) 
        {
            SymConfig = config;
        }
        public SymOBOUserAuth GetUserAuth(string username) 
        {
            SymOBOUserAuth userAuth = new SymOBOUserAuth(username, this);
            userAuth.Authenticate();
            return userAuth;
        }

        public SymOBOUserAuth GetUserAuth(long uid) 
        {
            SymOBOUserAuth userAuth = new SymOBOUserAuth(uid, this);
            userAuth.Authenticate();
            return userAuth;
        }

        public override void SessionAuthenticate() 
        {
            var response = GetCertificateOBOSessionAuthClient().PostAsync(AuthEndpointConstants.AppSessionAuthPath, null).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                SessionToken = JsonConvert.DeserializeObject<Token>(result).token;
            }
            else 
            {
                SessionToken = null;
            }
        }

        public HttpClient GetAppAuthClient() 
        {
            return GetOBOSessionAuthClient();
        }

        public override void Authenticate()
        {
            SessionAuthenticate();
        }

        public override void KeyManagerAuthenticate() {}
        public override string GetKeyManagerToken()
        {
            return null;
        }
        
        public override void SetKeyManagerToken(string kmToken) {}

        public override void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
