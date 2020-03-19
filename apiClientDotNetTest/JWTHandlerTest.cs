using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using apiClientDotNet;
using apiClientDotNet.Utils;

namespace apiClientDotNetTest
{
    [TestClass]
    public class JWTHandlerTest
    {
        [TestMethod]
        public void ForGivenRsaConfig_CanReadConfigAndCreateJwt()
        {
            var symConfigLoader = new SymConfigLoader();
            var configPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "testConfigPsdev.json");
            var symConfig = symConfigLoader.loadFromFile(configPath);
            var jwtHandler = new JWTHandler();
            var jwt = jwtHandler.generateJWT(symConfig);
            Assert.IsNotNull(jwt);
        }
    }
}
