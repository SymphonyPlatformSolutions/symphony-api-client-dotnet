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
            var configPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "config.json");
            var symConfig = symConfigLoader.loadFromFile(configPath);
            Assert.IsNotNull(symConfig);
            Assert.IsNotNull(symConfig.agentHost);
            Assert.IsNotNull(symConfig.keyAuthHost);
            Assert.IsNotNull(symConfig.podHost);
            Assert.IsNotNull(symConfig.botEmailAddress);
            Assert.IsNotNull(symConfig.botPrivateKeyName);
            Assert.IsNotNull(symConfig.botUsername);
        }
    }
}
