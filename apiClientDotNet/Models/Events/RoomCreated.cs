using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class RoomCreated
    {
        [JsonProperty("stream")]
        public Stream stream { get; set; }

        [JsonProperty("roomProperties")]
        public RoomProperties roomProperties { get; set; }
    }
}
