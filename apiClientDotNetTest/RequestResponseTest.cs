using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using apiClientDotNet.Models;
using apiClientDotNet;
using apiClientDotNet.Listeners;
using apiClientDotNet.Services;
using apiClientDotNet.Models.Events;
using System.Threading.Tasks;

namespace apiClientDotNetTest
{
    [TestClass]
    public class RequestResponseTest
    {
        
        [TestMethod]
        public void ChatBotTest()
        {
            SymBotClient symBotClient = new SymBotClient();
            DatafeedEventsService datafeedEventsService = new DatafeedEventsService();
            SymConfig symConfig = symBotClient.initBot("C:/Users/Michael/Documents/Visual Studio 2017/Projects/apiClientDotNet/apiClientDotNetTest/Resources/testConfig.json");
            RoomListener botLogic = new BotLogic();
            DatafeedClient datafeedClient = datafeedEventsService.init(symConfig);
            Datafeed datafeed = datafeedEventsService.createDatafeed(symConfig, datafeedClient);
            datafeedEventsService.addRoomListener(botLogic);
            RunAsync().GetAwaiter();
            datafeedEventsService.getEventsFromDatafeed(symConfig, datafeed, datafeedClient);
        }

        static async Task<Boolean> RunAsync()
        {
            System.Threading.Thread.Sleep(5000);
            SymBotClient symBotClient = new SymBotClient();
            SymConfig symConfig = symBotClient.initBot("C:/Users/Michael/Documents/Visual Studio 2017/Projects/apiClientDotNet/apiClientDotNetTest/Resources/testConfig2.json");
            Message message = new Message();
            message.message = "<messageML>Hello world!</messageML>";

            Stream stream = new Stream();
            stream.streamId = "fu1cJFoklnYlR9vu1AOZ5X___pzXDKPXdA";

            MessageClient messageClient = new apiClientDotNet.MessageClient();
            messageClient.sendMessage(symConfig, message, stream);

            return true;
        }

        public class BotLogic : RoomListener
        {
            DatafeedEventsService datafeedEventsService = new DatafeedEventsService();
            public void onRoomMessage(Message message)
            {
                datafeedEventsService.stopGettingEventsFromDatafeed();
                Assert.IsTrue(message != null);
            }
            public void onRoomCreated(RoomCreated roomCreated) { }
            public void onRoomDeactivated(RoomDeactivated roomDeactivated) { }
            public void onRoomMemberDemotedFromOwner(RoomMemberDemotedFromOwner roomMemberDemotedFromOwner) { }
            public void onRoomMemberPromotedToOwner(RoomMemberPromotedToOwner roomMemberPromotedToOwner) { }
            public void onRoomReactivated(Stream stream) { }
            public void onRoomUpdated(RoomUpdated roomUpdated) { }
            public void onUserJoinedRoom(UserJoinedRoom userJoinedRoom) { }
            public void onUserLeftRoom(UserLeftRoom userLeftRoom) { }
        }


    }
}
