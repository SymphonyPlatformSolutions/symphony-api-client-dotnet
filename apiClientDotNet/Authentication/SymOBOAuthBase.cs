using System;
using apiClientDotNet.Models;
using System.Net.Http;
using Newtonsoft.Json;


namespace apiClientDotNet.Authentication 
{

    public abstract class SymOBOAuthBase : SymAuthBase
    {
        public string AppSessionToken
        { 
            get { return SessionToken; }
            set { SessionToken = value; }
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
