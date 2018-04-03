using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class RoomUpdated
    {
        [JsonProperty("stream")]
        public Stream stream { get; set; }

        [JsonProperty("newRoomProperties")]
        public RoomProperties newRoomProperties { get; set; }
    }
}
