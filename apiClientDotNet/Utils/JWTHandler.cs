using System;
using System.Collections.Generic;

using apiClientDotNet.Models;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Crypto.Parameters;
using System.IO;
using System.Text;
using System.Security.Claims;
using Jose;
using System.IdentityModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace apiClientDotNet.Utils
{
    public class JWTHandler
    {
        /*
        public string generateJWT(SymConfig config)
        {
            string jwt = "";
            DateTime otherTime = DateTime.Now.AddMinutes(4);
            
            var payload = new JwtPayload
            {
                { "sub", config.botUsername },
                { "exp", ToUtcSeconds(otherTime) }
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var certificate = new X509Certificate2(config.botPrivateKeyPath + config.botPrivateKeyName);
            var securityKey = new Microsoft.IdentityModel.Tokens.X509SecurityKey(certificate);
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, SecurityAlgorithms.RsaSha512);
            var header = new JwtHeader(credentials);
            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            var tokenString = handler.WriteToken(secToken);

            return tokenString;
        
        }
        */

        public string generateJWT(SymConfig config)
        {
            string jwt = "";

            AsymmetricKeyParameter secret = parseSecret(config);

            DateTime otherTime = DateTime.Now.AddMinutes(4);

            var payload = new JwtPayload
            {
                { "sub", config.botUsername },
                { "exp", ToUtcSeconds(otherTime) }
            };



            RSAParameters rsaParams = DotNetUtilities.ToRSAParameters(secret as RsaPrivateCrtKeyParameters);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaParams);
                jwt = Jose.JWT.Encode(payload, rsa, Jose.JwsAlgorithm.RS512);
            }

            return jwt;

        }

        private AsymmetricKeyParameter parseSecret(SymConfig config)
        {
            AsymmetricCipherKeyPair keyPair;

            using (var reader = File.OpenText(config.botPrivateKeyPath + config.botPrivateKeyName)) // file containing RSA PKCS1 private key
                keyPair = (AsymmetricCipherKeyPair)new PemReader(reader).ReadObject();

            AsymmetricKeyParameter privateKey = keyPair.Private;

            return privateKey;
        }



        private static long ToUtcSeconds(DateTime dt)
        {
            return (dt.ToUniversalTime().Ticks - new DateTime(1970, 1, 1).Ticks) / TimeSpan.TicksPerSecond;
        }
    }
}
