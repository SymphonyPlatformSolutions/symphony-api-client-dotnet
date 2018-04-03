using System;
using System.Collections.Generic;
using System.Text;
using apiClientDotNet.Models;
using apiClientDotNet.Models.Events;

namespace apiClientDotNet.Listeners
{
    public interface RoomListener
    {
        void onRoomMessage(Message message);
        void onRoomCreated(RoomCreated roomCreated);
        void onRoomDeactivated(RoomDeactivated roomDeactivated);
        void onRoomMemberDemotedFromOwner(RoomMemberDemotedFromOwner roomMemberDemotedFromOwner);
        void onRoomMemberPromotedToOwner(RoomMemberPromotedToOwner roomMemberPromotedToOwner);
        void onRoomReactivated(Stream stream);
        void onRoomUpdated(RoomUpdated roomUpdated);
        void onUserJoinedRoom(UserJoinedRoom userJoinedRoom);
        void onUserLeftRoom(UserLeftRoom userLeftRoom); 
    }
}
