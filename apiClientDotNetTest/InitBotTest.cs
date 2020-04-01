using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using apiClientDotNet.Models;
using apiClientDotNet;
using apiClientDotNet.Listeners;
using apiClientDotNet.Services;
using apiClientDotNet.Models.Events;
using apiClientDotNet.Authentication;

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
        public void ForGivenRsaConfig_CanAuthenticateAndCreateDataFeed()
        {
            var symConfig = new SymConfig();
            var symConfigLoader = new SymConfigLoader();
            var configPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "config.json");
            symConfig = symConfigLoader.loadFromFile(configPath);
            var botAuth = new SymBotRSAAuth(symConfig);
            botAuth.authenticate();
            var botClient = SymBotClient.initBot(symConfig, botAuth);
            DatafeedEventsService datafeedEventsService = botClient.getDatafeedEventsService();
            Assert.IsNotNull(datafeedEventsService.datafeedId);
        }
    }
}
