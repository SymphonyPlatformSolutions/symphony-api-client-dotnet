using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using apiClientDotNet.Models.Events;

namespace apiClientDotNet.Models
{
    public class EventPayload
    {
        [JsonProperty("messageSent")]
        public MessageSent messageSent { get; set; }

        [JsonProperty("sharedPost")]
        public SharedPost sharedPost { get; set; }

        [JsonProperty("instantMessageCreated")]
        public IMCreated instantMessageCreated { get; set; }

        [JsonProperty("roomCreated")]
        public RoomCreated roomCreated { get; set; }

        [JsonProperty("roomUpdated")]
        public RoomUpdated roomUpdated { get; set; }

        [JsonProperty("roomDeactivated")]
        public RoomDeactivated roomDeactivated { get; set; }

        [JsonProperty("roomReactivated")]
        public RoomReactivated roomReactivated { get; set; }

        [JsonProperty("userJoinedRoom")]
        public UserJoinedRoom userJoinedRoom { get; set; }

        [JsonProperty("userLeftRoom")]
        public UserLeftRoom userLeftRoom { get; set; }

        [JsonProperty("roomMemberPromotedToOwner")]
        public RoomMemberPromotedToOwner roomMemberPromotedToOwner { get; set; }

        [JsonProperty("roomMemberDemotedFromOwner")]
        public RoomMemberDemotedFromOwner roomMemberDemotedFromOwner { get; set; }

        [JsonProperty("connectionRequested")]
        public ConnectionRequested connectionRequested { get; set; }

        [JsonProperty("connectionAccepted")]
        public ConnectionAccepted connectionAccepted { get; set; }

        [JsonProperty("messageSuppressed")]
        public MessageSuppressed messageSuppressed { get; set; }

	[JsonProperty("symphonyElementsAction")]
	public SymphonyElementsAction symphonyElementsAction { get; set; }
    }
}
