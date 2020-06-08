using apiClientDotNet.Clients;
using apiClientDotNet.Models;
using apiClientDotNet.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace apiClientDotNetTest
{
    [TestClass]
    public class ConnectionsClientUnitTest
    {

        static readonly String jsonWithMissingValues = @"{
                          'userId': 7078106169577,
                          'status': 'ACCEPTED'
                        }";

        static readonly String jsonWithNullValues = @"{
                          'userId': 7078106169577,
                          'status': 'ACCEPTED',
                          'firstRequestedAt': null,
                          'updatedAt': null,
                          'requestCounter': null
                        }";

        static readonly String jsonWithAllValues = @"{
                          'userId': 7078106169577,
                          'status': 'ACCEPTED',
                          'firstRequestedAt': 1471046357339,
                          'updatedAt': 1471046517684,
                          'requestCounter': 1
                        }";

        #region FAKE Connections Clients 
        class FakeConnectionsClient : ConnectionsClient
        {
            protected Mock<RestRequestHandler> moqRestRequestHandler;
            protected Mock<HttpWebResponse> moqHttpWebResponse;

            public FakeConnectionsClient(ISymClient client) : base(client)
            {
                moqRestRequestHandler = new Mock<RestRequestHandler>();
                moqHttpWebResponse = new Mock<HttpWebResponse>();
                moqRestRequestHandler.Setup(x => x.executeRequest(It.IsAny<object>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<SymConfig>(), It.IsAny<bool>()))
                                     .Returns(moqHttpWebResponse.Object);
            }
        }
        class FakeConnectionsClientWithMissingValues : FakeConnectionsClient
        {
            public FakeConnectionsClientWithMissingValues(ISymClient client) : base(client) { }
            protected override RestRequestHandler CreateRestHadnler()
            {
                moqRestRequestHandler.Setup(x => x.ReadResponse(It.IsAny<HttpWebResponse>())).Returns(jsonWithMissingValues);
                return moqRestRequestHandler.Object;
            }
        }

        class FakeConnectionsClientWithNullValues : FakeConnectionsClient
        {
            public FakeConnectionsClientWithNullValues(ISymClient client) : base(client) { }
            protected override RestRequestHandler CreateRestHadnler()
            {
                moqRestRequestHandler.Setup(x => x.ReadResponse(It.IsAny<HttpWebResponse>())).Returns(jsonWithNullValues);
                return moqRestRequestHandler.Object;
            }
        }

        class FakeConnectionsClientWithAllValues : FakeConnectionsClient
        {
            public FakeConnectionsClientWithAllValues(ISymClient client) : base(client) { }
            protected override RestRequestHandler CreateRestHadnler()
            {
                moqRestRequestHandler.Setup(x => x.ReadResponse(It.IsAny<HttpWebResponse>())).Returns(jsonWithAllValues);
                return moqRestRequestHandler.Object;
            }
        }
        #endregion

        Mock<ISymClient> symClient;
        readonly long USER_ID = 7078106169577;

        [TestInitialize]
        public void Init()
        {
            symClient = new Mock<ISymClient>();
            var config = new SymConfig
            {
                podHost = "POD",
                podPort = 443
            };
            symClient.Setup(x => x.getConfig()).Returns(config);
        }
        #region AcceptConnectionRequest
        [TestMethod]
        public void AcceptConnectionRequest_ForJsonWithMissingValues_ConnectionRequestCreated()
        {
            var sut = new FakeConnectionsClientWithMissingValues(symClient.Object);
            InboundConnectionRequest result = sut.acceptConnectionRequest(USER_ID);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AcceptConnectionRequest_ForJsonWithAllValues_ConnectionRequestCreated()
        {
            var sut = new FakeConnectionsClientWithAllValues(symClient.Object);
            InboundConnectionRequest result = sut.acceptConnectionRequest(USER_ID);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AcceptConnectionRequest_ForJsonWithNullValues_ConnectionRequestCreated()
        {
            var sut = new FakeConnectionsClientWithNullValues(symClient.Object);
            InboundConnectionRequest result = sut.acceptConnectionRequest(USER_ID);
            Assert.IsNotNull(result);
        }

        #endregion

        #region RejectConnectionRequest
        [TestMethod]
        public void RejectConnectionRequest_ForJsonWithMissingValues_ConnectionRequestCreated()
        {
            var sut = new FakeConnectionsClientWithMissingValues(symClient.Object);
            InboundConnectionRequest result = sut.rejectConnectionRequest(USER_ID);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RejectConnectionRequest_ForJsonWithAllValues_ConnectionRequestCreated()
        {
            var sut = new FakeConnectionsClientWithAllValues(symClient.Object);
            InboundConnectionRequest result = sut.rejectConnectionRequest(USER_ID);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RejectConnectionRequest_ForJsonWithNullValues_ConnectionRequestCreated()
        {
            var sut = new FakeConnectionsClientWithNullValues(symClient.Object);
            InboundConnectionRequest result = sut.rejectConnectionRequest(USER_ID);
            Assert.IsNotNull(result);
        }

        #endregion

        #region SendConnectionRequest
        [TestMethod]
        public void SendConnectionRequest_ForJsonWithMissingValues_ConnectionRequestCreated()
        {
            var sut = new FakeConnectionsClientWithMissingValues(symClient.Object);
            InboundConnectionRequest result = sut.sendConnectionRequest(USER_ID);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SendConnectionRequest_ForJsonWithAllValues_ConnectionRequestCreated()
        {
            var sut = new FakeConnectionsClientWithAllValues(symClient.Object);
            InboundConnectionRequest result = sut.sendConnectionRequest(USER_ID);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SendConnectionRequest_ForJsonWithNullValues_ConnectionRequestCreated()
        {
            var sut = new FakeConnectionsClientWithNullValues(symClient.Object);
            InboundConnectionRequest result = sut.sendConnectionRequest(USER_ID);
            Assert.IsNotNull(result);
        }

        #endregion
    }
}
