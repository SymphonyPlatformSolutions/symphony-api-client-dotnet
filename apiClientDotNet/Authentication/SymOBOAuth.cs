using System;
using apiClientDotNet.Models;
using System.Net.Http;
using Newtonsoft.Json;


namespace apiClientDotNet.Authentication 
{

    public class SymOBOAuth : SymOBOAuthBase
    {
        
        public SymOBOAuth(SymConfig config) 
        {
            SymConfig = config;
        }

        public override void SessionAuthenticate() 
        {
            var response = GetCertificateOBOSessionAuthClient().PostAsync(AuthEndpointConstants.OBOAppSessionAuthPath, null).Result;
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
    }
}
