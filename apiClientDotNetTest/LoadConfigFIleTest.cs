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
        public void LoadConfigTest()
        {
            SymConfigLoader symConfigLoader = new SymConfigLoader();
            SymConfig symConfigPoco = symConfigLoader.loadFromFile("C:/Users/Michael/Documents/Visual Studio 2017/Projects/apiClientDotNet/apiClientDotNetTest/Resources/testConfig.json");
            Assert.IsTrue(symConfigPoco.sessionAuthHost == "preview.symphony.com");
        }
    }
}
