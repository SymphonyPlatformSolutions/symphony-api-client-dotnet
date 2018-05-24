using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using apiClientDotNet.Models;
using apiClientDotNet;
using apiClientDotNet.Listeners;
using apiClientDotNet.Services;
using apiClientDotNet.Models.Events;


namespace apiClientDotNetTest
{

    public class BotLogic : RoomListener
    {
        public void onRoomMessage(Message message)
         {
            Console.Write(message.message);
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

    [TestClass]
    public class InitBotTest
    {
        [TestMethod]
        public void DatafeedCreateTest()
        {
            SymBotClient symBotClient = new SymBotClient();
            DatafeedEventsService datafeedEventsService = new DatafeedEventsService();
            SymConfig symConfig = symBotClient.initBot("C:/Users/Michael/Documents/Visual Studio 2017/Projects/apiClientDotNet/apiClientDotNetTest/Resources/testConfig.json");
            RoomListener botLogic = new BotLogic();
            DatafeedClient datafeedClient = datafeedEventsService.init(symConfig);
            Datafeed datafeed = datafeedEventsService.createDatafeed(symConfig, datafeedClient);

            Assert.IsTrue(datafeed.datafeedID != null);
        }
    }
}
