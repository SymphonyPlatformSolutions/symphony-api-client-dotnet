using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using apiClientDotNet.Models;
using apiClientDotNet;
using apiClientDotNet.Listeners;
using apiClientDotNet.Services;
using apiClientDotNet.Models.Events;

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
            datafeedEventsService.getEventsFromDatafeed(symConfig, datafeed, datafeedClient);
        }

        public class BotLogic : RoomListener
        {
            public void onRoomMessage(Message message)
            {
                SymBotClient symBotClient = new SymBotClient();
                SymConfig symConfig = symBotClient.initBot("C:/Users/Michael/Documents/Visual Studio 2017/Projects/apiClientDotNet/apiClientDotNetTest/Resources/testConfig.json");
                Message message2 = new Message();
                message2.message = "<messageML>Hello world!</messageML>";
                MessageClient messageClient = new apiClientDotNet.MessageClient();
                messageClient.sendMessage(symConfig, message2, message.stream);

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
