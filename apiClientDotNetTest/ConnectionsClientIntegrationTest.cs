using apiClientDotNet;
using apiClientDotNet.Authentication;
using apiClientDotNet.Clients;
using apiClientDotNet.Clients.Constants;
using apiClientDotNet.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace apiClientDotNetTest
{
    [TestClass]
    public class ConnectionsClientIntegrationTest
    {
        private static SymBotClient symBotClient;
        private static IConfigurationRoot config;
        private static UserInfo userReceiver;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            // Load integration test settings
            var integrationConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "integration.parameters.json");
            config = new ConfigurationBuilder().AddJsonFile(integrationConfigPath).Build();

            // Create SymBotClient
            var symConfig = new SymConfig();
            var symConfigLoader = new SymConfigLoader();
            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "config.json");
            symConfig = symConfigLoader.loadFromFile(configPath);
            var botAuth = new SymBotRSAAuth(symConfig);
            botAuth.authenticate();
            symBotClient = SymBotClient.initBot(symConfig, botAuth);
           
            var userReceiverEmail = config.GetSection(typeof(ConnectionsClientIntegrationTest).Name).GetSection("test_email_address_user_receiver").Value;

            UserClient userClient = new UserClient(symBotClient);
            userReceiver = userClient.getUserFromEmail(userReceiverEmail, false)[0];
        }

        [TestMethod]
        public void getAllConnections_forGivenUser_correctlyReturnsConnections()
        {
            var sut = new ConnectionsClient(symBotClient);
            var ids = new List<long>() { userReceiver.id };
            List<InboundConnectionRequest> connections = sut.getAllConnections();
            Assert.IsNotNull(connections);
        }

        [TestMethod]
        public void GetAcceptedConnections_forGivenUser_correctlyReturnsConnections()
        {
            var sut = new ConnectionsClient(symBotClient);
            var ids = new List<long>() { userReceiver.id };
            List<InboundConnectionRequest> connections = sut.getAcceptedConnections();
            Assert.IsNotNull(connections);
        }

        [TestMethod]
        public void GetRejectedConnections_forGivenUser_correctlyReturnsConnections()
        {
            var sut = new ConnectionsClient(symBotClient);
            var ids = new List<long>() { userReceiver.id };
            List<InboundConnectionRequest> connections = sut.getRejectedConnections();
            Assert.IsNotNull(connections);
        }

        [TestMethod]
        public void GetPendingConnections_forGivenUser_correctlyReturnsConnections()
        {
            var sut = new ConnectionsClient(symBotClient);
            var ids = new List<long>() { userReceiver.id };
            List<InboundConnectionRequest> connections = sut.getPendingConnections();
            Assert.IsNotNull(connections);
        }

        [TestMethod]
        public void GetConnections_forGivenUser_correctlyReturnsConnections()
        {
            var sut = new ConnectionsClient(symBotClient);
            var ids = new List<long>() { userReceiver.id };
            List<InboundConnectionRequest> connections = sut.getConnections(ConnectionStatus.ALL, ids);
            Assert.IsNotNull(connections);
        }

        [TestMethod]
        public void SendConnectionRequest_forGivenUser_correctlyReturnsConnections()
        {
            var sut = new ConnectionsClient(symBotClient);
            InboundConnectionRequest connectionRequest = sut.sendConnectionRequest(userReceiver.id);
            Assert.IsNotNull(connectionRequest);
            Assert.AreEqual(userReceiver.id, connectionRequest.userId);
        }
    }
}
