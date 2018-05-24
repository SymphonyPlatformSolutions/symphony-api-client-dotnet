using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using apiClientDotNet;
using apiClientDotNet.Models;


namespace apiClientDotNetTest
{
    [TestClass]
    public class AuthenticateTest
    {
        SymConfig symConfig = new SymConfig();

        [TestMethod]
        public void SessionAuthenticateTest()
        {
            SymConfigLoader symConfigLoader = new SymConfigLoader();
            symConfig = symConfigLoader.loadFromFile("C:/Users/Michael/Documents/Visual Studio 2017/Projects/apiClientDotNet/apiClientDotNetTest/Resources/testConfig.json");
            SymBotAuth symBotAuth = new SymBotAuth();
            AuthTokens authTokens = symBotAuth.authenticate(symConfig);
            Assert.IsTrue(authTokens.sessionToken != null && authTokens.keyManagerToken != null);
        }
    }
}
