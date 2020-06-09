using apiClientDotNet.Models;
using apiClientDotNet.Models.Events;
using System;

namespace apiClientDotNet.Listeners
{
    public interface IRoomListener
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

    [Obsolete("Please instead use directly IRoomListener")]
    public interface RoomListener : IRoomListener
    {

    }
}
