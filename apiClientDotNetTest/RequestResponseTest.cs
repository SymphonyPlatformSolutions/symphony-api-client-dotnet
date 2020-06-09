using apiClientDotNet;
using apiClientDotNet.Authentication;
using apiClientDotNet.Listeners;
using apiClientDotNet.Models;
using apiClientDotNet.Models.Events;
using apiClientDotNet.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace apiClientDotNetTest
{
    /// <summary>
    /// Simple integration test that allows to simulate reading messages from the data feed.
    /// The test registers one room and one direct chat listeners.
    /// On message received the BOt just sends back a message confirmation.
    /// 
    /// The test should be run manually, and to be stopped when testing is finished.
    /// </summary>
    [TestClass]
    public class RequestResponseTest
    {

        static SymBotClient symBotClient;

        [TestMethod]
        public void ChatBotTest()
        {
            var symConfigLoader = new SymConfigLoader();
            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "config.json");
            var symConfig = symConfigLoader.loadFromFile(configPath);
            var symBotRsaAuth = new SymBotRSAAuth(symConfig);
            symBotRsaAuth.authenticate();
            symBotClient = SymBotClient.initBot(symConfig, symBotRsaAuth);

            // create data feed for the BOT
            var datafeedEventsService = new DatafeedEventsService(symBotClient);
            var botRoomListener = new ChatRoomListener();
            var directChatListener = new DirectChatListener();
            datafeedEventsService.addRoomListener(botRoomListener);
            datafeedEventsService.addIMListener(directChatListener);

            // start reading the data feed
            datafeedEventsService.getEventsFromDatafeed();
        }

        public class ChatRoomListener : IRoomListener
        {

            public void onRoomMessage(Message message)
            {
                var text = "Hello from IRoomListener .NET SDK! You command is: " + HttpUtility.HtmlEncode(message.message);
                RequestResponseTest.SendMessageAsync(message.stream.streamId, text);
            }
            public void onRoomCreated(RoomCreated roomCreated) { }
            public void onRoomDeactivated(RoomDeactivated roomDeactivated) { }
            public void onRoomMemberDemotedFromOwner(RoomMemberDemotedFromOwner roomMemberDemotedFromOwner) { }
            public void onRoomMemberPromotedToOwner(RoomMemberPromotedToOwner roomMemberPromotedToOwner) { }
            public void onRoomReactivated(apiClientDotNet.Models.Stream stream) { }
            public void onRoomUpdated(RoomUpdated roomUpdated) { }
            public void onUserJoinedRoom(UserJoinedRoom userJoinedRoom) { }
            public void onUserLeftRoom(UserLeftRoom userLeftRoom) { }
        }
        public class DirectChatListener : apiClientDotNet.Listeners.IIMListener
        {
            public void onIMCreated(apiClientDotNet.Models.Stream stream) { }

            public void onIMMessage(Message message)
            {
                var text = "Hello from IIMListener .NET SDK! You command is: " + HttpUtility.HtmlEncode(message.message);
                RequestResponseTest.SendMessageAsync(message.stream.streamId, text);
            }
        }

        private static void SendMessageAsync(string streamId, string text)
        {
            var task = new Task(() =>
            {
                // Send to that stream a messages
                var message = new OutboundMessage
                {
                    message = "<messageML>" + text + "</messageML>"
                };
                var stream = new apiClientDotNet.Models.Stream
                {
                    streamId = streamId
                };
                var messageClient = new MessageClient(symBotClient);
                messageClient.sendMessage(stream.streamId, message, false);
            }, TaskCreationOptions.AttachedToParent);

            task.Start();
        }
    }
}
