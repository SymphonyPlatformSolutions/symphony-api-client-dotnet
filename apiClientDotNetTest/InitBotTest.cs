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
            SymConfig symConfig = new SymConfig();
            SymConfigLoader symConfigLoader = new SymConfigLoader();
            symConfig = symConfigLoader.loadFromFile("C:/Users/Michael/Documents/Visual Studio 2017/Projects/apiClientDotNet/apiClientDotNetTest/Resources/testConfig.json");
            apiClientDotNet.Authentication.SymBotAuth botAuth = new apiClientDotNet.Authentication.SymBotAuth(symConfig);
            botAuth.authenticate();
            SymBotClient botClient = SymBotClient.initBot(symConfig, botAuth);
            DatafeedEventsService datafeedEventsService = botClient.getDatafeedEventsService();

            //datafeedEventsService.getEventsFromDatafeed();

            //Assert.IsTrue(datafeedEventsService.datafeedId != null);
        }
    }
}
