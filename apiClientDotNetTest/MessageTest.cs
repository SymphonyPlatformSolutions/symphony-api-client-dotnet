using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using apiClientDotNet.Models;
using apiClientDotNet;
using apiClientDotNet.Listeners;
using apiClientDotNet.Services;
using apiClientDotNet.Models.Events;
using System.Net;
using apiClientDotNet.Authentication;
using apiClientDotNet.Clients;

namespace apiClientDotNetTest
{
    [TestClass]
    public class MessageTest
    {
        [TestMethod]
        public void MessageRoomTest()
        {
            SymConfig symConfig = new SymConfig();
            SymConfigLoader symConfigLoader = new SymConfigLoader();
            symConfig = symConfigLoader.loadFromFile("C:/Users/Michael/Documents/Visual Studio 2017/Projects/apiClientDotNet/apiClientDotNetTest/Resources/testConfig.json");
            SymBotAuth botAuth = new SymBotAuth(symConfig);
            botAuth.authenticate();
            SymBotClient botClient = SymBotClient.initBot(symConfig, botAuth);
            OutboundMessage message = new OutboundMessage();
            message.message = "<messageML>Hello world!</messageML>";

            
            FileStream fileStream = File.OpenRead("C:/Users/Michael/Documents/Visual Studio 2017/Projects/apiClientDotNet/apiClientDotNetTest/Resources/AttachmentTest.txt");
            List<FileStream> attachments = new List<FileStream>();
            attachments.Add(fileStream);
            message.attachments = attachments;
            apiClientDotNet.Models.Stream stream = new apiClientDotNet.Models.Stream();
            stream.streamId = "fu1cJFoklnYlR9vu1AOZ5X___pzXDKPXdA";

            MessageClient messageClient = new MessageClient(botClient);
            InboundMessage resp = messageClient.sendMessage(stream.streamId, message, false);

            Assert.IsTrue(resp.messageId != null);
        }

        [TestMethod]
        public void SearchRoom()
        {
            SymConfig symConfig = new SymConfig();
            SymConfigLoader symConfigLoader = new SymConfigLoader();
            symConfig = symConfigLoader.loadFromFile("C:/Users/Michael/Documents/Visual Studio 2017/Projects/apiClientDotNet/apiClientDotNetTest/Resources/testConfig.json");
            SymBotAuth botAuth = new SymBotAuth(symConfig);
            botAuth.authenticate();
            SymBotClient botClient = SymBotClient.initBot(symConfig, botAuth);

            StreamClient streamClient = botClient.getStreamsClient();
            RoomSearchQuery roomSearchQuery = new RoomSearchQuery();
            roomSearchQuery.query = "APITestRoom";
            roomSearchQuery.active = true;
            roomSearchQuery.isPrivate = true;
            RoomSearchResult result = streamClient.searchRooms(roomSearchQuery, 0, 0);
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void GetUserIDFromUserNameTest()
        {
            SymConfig symConfig = new SymConfig();
            SymConfigLoader symConfigLoader = new SymConfigLoader();
            symConfig = symConfigLoader.loadFromFile("C:/Users/Michael/Documents/Visual Studio 2017/Projects/apiClientDotNet/apiClientDotNetTest/Resources/testConfig.json");
            SymBotAuth botAuth = new SymBotAuth(symConfig);
            botAuth.authenticate();
            SymBotClient botClient = SymBotClient.initBot(symConfig, botAuth);

            UserClient userClient = botClient.getUsersClient();
            UserInfo user = userClient.getUserFromUsername("mikepreview");

            StreamClient streamClient = botClient.getStreamsClient();
            RoomSearchQuery roomSearchQuery = new RoomSearchQuery();
            roomSearchQuery.query = "APITestRoom";
            roomSearchQuery.active = true;
            roomSearchQuery.isPrivate = true;
            NumericId id = new NumericId();
            id.id = user.id;
            roomSearchQuery.member = id;
            RoomSearchResult result = streamClient.searchRooms(roomSearchQuery, 0, 0);

            Assert.IsTrue(user != null);
        }

        [TestMethod]
        public void UserListStreams()
        {
            SymConfig symConfig = new SymConfig();
            SymConfigLoader symConfigLoader = new SymConfigLoader();
            symConfig = symConfigLoader.loadFromFile("C:/Users/Michael/Documents/Visual Studio 2017/Projects/apiClientDotNet/apiClientDotNetTest/Resources/testConfig.json");
            SymBotAuth botAuth = new SymBotAuth(symConfig);
            botAuth.authenticate();
            SymBotClient botClient = SymBotClient.initBot(symConfig, botAuth);

            StreamClient streamClient = botClient.getStreamsClient();
            List<string> streamTypes = new List<string>();
            streamTypes.Add("IM");
            streamTypes.Add("ROOM");
            List<StreamListItem> result = streamClient.getUserStreams(streamTypes,false);
            Assert.IsTrue(result != null);
        }
    }
}
