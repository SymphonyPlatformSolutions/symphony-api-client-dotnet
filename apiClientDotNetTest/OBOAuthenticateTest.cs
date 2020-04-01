using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using apiClientDotNet.Models;
using apiClientDotNet;
using apiClientDotNet.Authentication;
using apiClientDotNet.Clients;
using System.Collections.Generic;
using System.IO;

namespace apiClientDotNetTest
{
    [TestClass]
    public class OBOAuthenticateTest
    {
        private static SymConfig symConfig = null;

        [ClassInitialize]
        public static void Setup(TestContext conext)
        {
            var symConfigLoader = new SymConfigLoader();
            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "config.json");
            symConfig = symConfigLoader.loadFromFile(configPath);
        }

        [TestMethod]
        public void OBOAuth()
        {

            SymOBOAuth oboAuth = new SymOBOAuth(symConfig);
            oboAuth.sessionAppAuthenticate();
            SymOBOUserAuth auth = oboAuth.getUserAuth("mike.scannell@symphony.com");

           // auth.setSessionToken("eyJhbGciOiJSUzUxMiJ9.eyJzdWIiOiJzdGlzaGxlciIsImlzcyI6InN5bXBob255IiwiYXBwUGVybWlzc2lvbnMiOlsiQUNUX0FTX1VTRVIiLCJHRVRfQkFTSUNfQ09OVEFDVF9JTkZPIiwiR0VUX1BSRVNFTkNFIiwiTElTVF9VU0VSX1NUUkVBTVMiLCJNQU5BR0VfUk9PTVMiLCJTRU5EX01FU1NBR0VTIl0sImFwcEdyb3VwSWQiOiJhZG55LXcxNDYiLCJzZXNzaW9uSWQiOiJiNGI3N2NjMWUyYzg4ODAxMWNmNWI3MWI5YmQwYTZhNjJlNDI0MTMzMzJlMGRkNDk1NWQzYzk3ZjViNjE4MWMyNWE2MTVmYThkMjNmNjM2YmNmNDJiNTMxOGI4ZDlkNDgwMDAwMDE2NjhjZTIyOGNjMDAwMDUyYjAwMDAwMDAxOSIsInVzZXJJZCI6IjkwOTE1ODY3NzIxNzUzIn0.hSsZOBEH-OlUzOjDl_NhoxVTrlbJSEaxnmV0s5VQO92VgYaTBc0eUbcHaCYzmRtafil8dy_4_pOSMSR9VupDayklL9igT2cRHZGKvryR4_2hNDym3Xs-uYCxC83O1l9CTm2ISrSVgVabzVOznN23sZLQ6IoIj2EORS6B8eemGlGTWjZge1iav464kFosQ5glSDSecY4mTcbh4sYE3mwINlCEML5VqpEbc0Pdu1ZOesLMBHsa3KzlGuIUEjtigP4NZeYPc31G-rzxSKHWeMo3Mqwwk_0dSL6voQgw-29fly0uIGTF7wCSngk3g9n4Lv_0m4Yh5xDcyQ0h4RRxny-Sgg");
           // symConfig.agentHost = "alphadyne.symphony.com";
            SymOBOClient client = SymOBOClient.initOBOClient(symConfig, auth);

            OutboundMessage message = new OutboundMessage();
            message.message = "<messageML>Hello it is mike fron NET 2</messageML>";

            apiClientDotNet.Models.Stream stream = new apiClientDotNet.Models.Stream();
            stream.streamId = "IzgD3nNbpoaNJ6_To7Ds0n___pmCBYMrdA";
            //stream.streamId = "AQpEsS9DJM1ZRrGF7Kb7i3___pui0wKcdA";
            
            MessageClient messageClient = new MessageClient(client);
            InboundMessage resp = messageClient.sendMessage(stream.streamId, message, false);


            Assert.IsTrue(resp.message != null);
        }

        [TestMethod]
        public void OBOLogoutTest()
        {
            SymOBOAuth oboAuth = new SymOBOAuth(symConfig);
            oboAuth.sessionAppAuthenticate();
            SymOBOUserAuth auth = oboAuth.getUserAuth("mike.scannell@symphony.com");
            SymOBOClient client = SymOBOClient.initOBOClient(symConfig, auth);

            OutboundMessage message = new OutboundMessage();
            message.message = "<messageML>Hello Alexa</messageML>";

            apiClientDotNet.Models.Stream stream = new apiClientDotNet.Models.Stream();
            stream.streamId = "IzgD3nNbpoaNJ6_To7Ds0n___pmCBYMrdA";

            MessageClient messageClient = new MessageClient(client);
            InboundMessage resp = messageClient.sendMessage(stream.streamId, message, false);

            auth.logout();


            //Assert.IsTrue(resp.message != null);
        }

        [TestMethod]
        public void OBOUserAndRoomSeaerch()
        {
            SymOBOAuth oboAuth = new SymOBOAuth(symConfig);
            oboAuth.sessionAppAuthenticate();
            SymOBOUserAuth auth = oboAuth.getUserAuth("mike.scannell@symphony.com");
            SymOBOClient client = SymOBOClient.initOBOClient(symConfig, auth);

            UserClient userClient = client.getUsersClient();
            UserInfo user = userClient.getUserFromUsername("mike.scannell@symphony.com");

            StreamClient streamClient = client.getStreamsClient();
            List<string> streamTypes = new List<string>();
            streamTypes.Add("IM");
            streamTypes.Add("ROOM");
            List<StreamListItem> result = streamClient.getUserStreams(streamTypes, false);

            Assert.IsTrue(user != null);
        }

        [TestMethod]
        public void OBOUserLookUpTest()
        {
            SymOBOAuth oboAuth = new SymOBOAuth(symConfig);
            oboAuth.sessionAppAuthenticate();
            SymOBOUserAuth auth = oboAuth.getUserAuth("mike.scannell@symphony.com");
            SymOBOClient client = SymOBOClient.initOBOClient(symConfig, auth);

            UserClient userClient = client.getUsersClient();
            UserInfo user = userClient.getUserFromUsername("mike.scannell@symphony.com");

            Assert.IsTrue(user != null);
        }

        [TestMethod]
        public void OBOIMCreateTest()
        {
            SymOBOAuth oboAuth = new SymOBOAuth(symConfig);
            oboAuth.sessionAppAuthenticate();
            SymOBOUserAuth auth = oboAuth.getUserAuth("mike.scannell@symphony.com");
            SymOBOClient client = SymOBOClient.initOBOClient(symConfig, auth);

            UserClient userClient = client.getUsersClient();
            UserInfo user = userClient.getUserFromUsername("joanne.mann@symphony.com");

            StreamClient streamClient = new StreamClient(client);

            List<long> userids = new List<long>();
            userids.Add(user.id);
            String streamid = streamClient.getUserListIM(userids);

            Assert.IsTrue(streamid != null);
        }

    }
}
