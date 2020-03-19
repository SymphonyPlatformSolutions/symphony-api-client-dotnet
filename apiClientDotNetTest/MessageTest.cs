using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using apiClientDotNet.Models;
using apiClientDotNet;
using apiClientDotNet.Authentication;

namespace apiClientDotNetTest
{
    [TestClass]
    public class MessageTest
    {
        private static SymBotClient botClient = null;
        private static string attachmentTestPath = null;
        // to be moved to some integration tests config file
        private static readonly string testUserName = "vlado.kragujevski";
        private static readonly string testRoomName = "NETSDK";

        [ClassInitialize]
        public static void Setup(TestContext conext)
        {         
            var symConfigLoader = new SymConfigLoader();
            attachmentTestPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "AttachmentTest.txt");
            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "testConfigPsdev.json");
            var symConfig = symConfigLoader.loadFromFile(configPath);
            var botAuth = new SymBotRSAAuth(symConfig);
            botAuth.authenticate();
            botClient = SymBotClient.initBot(symConfig, botAuth);        
        }
     
        [TestMethod]
        public void SearchRoom()
        {
            var streamClient = botClient.getStreamsClient();
            var roomSearchQuery = new RoomSearchQuery
            {
                query = testRoomName,
                active = true,
                isPrivate = true
            };
            var result = streamClient.searchRooms(roomSearchQuery, 0, 0);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.count >= 1);
        }

        [TestMethod]
        public void GetUserIdByUserName()
        {
            var userClient = botClient.getUsersClient();
            var user = userClient.getUserFromUsername(testUserName);
            Assert.IsNotNull(user);
            Assert.AreEqual("Vlado Kragujevski", user.displayName);
        }

        [TestMethod]
        public void ListUserStreamsAndSendMessage()
        {
            var streamClient = botClient.getStreamsClient();
            var streamTypes = new List<string>
            {
                "IM",
                "ROOM"
            };
            var result = streamClient.getUserStreams(streamTypes,false);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count >= 1);

            MessageRoomTest(result[0].id);
        }

        public void MessageRoomTest(string streamId)
        {
            var fileStream = File.OpenRead(attachmentTestPath);
            var attachments = new List<FileStream>
            {
                fileStream
            };
            var message = new OutboundMessage
            {
                message = "<messageML>Hello world! From .NET SDK Integration Test.</messageML>"
            };
            message.attachments = attachments;
            var stream = new apiClientDotNet.Models.Stream
            {
                streamId = streamId
            };

            var messageClient = new MessageClient(botClient);
            var resp = messageClient.sendMessage(stream.streamId, message, false);
            Assert.IsNotNull(resp.messageId);
        }
    }
}
