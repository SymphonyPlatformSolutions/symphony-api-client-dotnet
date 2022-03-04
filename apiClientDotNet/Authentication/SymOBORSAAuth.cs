using System.Net.Http;
using Newtonsoft.Json;
using apiClientDotNet.Utils;
using apiClientDotNet.Models;

namespace apiClientDotNet.Authentication 
{

    public class SymOBORSAAuth : SymOBOAuthBase
    {
        
        public SymOBORSAAuth(SymConfig config) 
        {
            SymConfig = config;
        }

        public override void SessionAuthenticate() 
        {
            JWTHandler jwtHandler = new JWTHandler();
            var token = new 
            {
                token = jwtHandler.generateJWT(SymConfig.appId, SymConfig.appPrivateKeyPath + SymConfig.appPrivateKeyName)
            };
            var response = GetSessionAuthClient().PostAsync(AuthEndpointConstants.OBOAppSessionRSAAuthPath, new StringContent(JsonConvert.SerializeObject(token))).Result;
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
