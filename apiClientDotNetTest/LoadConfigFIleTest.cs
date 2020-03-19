using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using apiClientDotNet;
using apiClientDotNet.Models;


namespace apiClientDotNetTest
{
    [TestClass]
    public class LoadConfigFileTest
    {

        [TestMethod]
        public void ForGivenConfigFile_CorrectlyLoadsTheConfigurationProperties()
        {
            var symConfigLoader = new SymConfigLoader();
            var configPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "testConfigPsdev.json");
            var symConfig = symConfigLoader.loadFromFile(configPath);
            Assert.IsNotNull(symConfig);
            Assert.AreEqual("psdev.symphony.com", symConfig.agentHost);
            Assert.AreEqual(443, symConfig.agentPort);
            Assert.AreEqual("psdev.symphony.com", symConfig.keyAuthHost);
            Assert.AreEqual(443, symConfig.keyAuthPort);
            Assert.AreEqual("psdev.symphony.com", symConfig.podHost);
            Assert.AreEqual("bot.enterprise.integration.gitlab@bot.symphony.com", symConfig.botEmailAddress);
            Assert.AreEqual("privatekey.pem", symConfig.botPrivateKeyName);
            Assert.AreEqual("bot.enterprise.integration.gitlab", symConfig.botUsername);
        }
    }
}
