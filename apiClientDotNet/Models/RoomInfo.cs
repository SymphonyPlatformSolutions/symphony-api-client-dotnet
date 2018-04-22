using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class RoomInfo
    {
        [JsonProperty("roomAttributes")]
        public Room roomAttributes { get; set; }

        [JsonProperty("roomSystemInfo")]
        public RoomSystemInfo roomSystemInfo { get; set; }

    }
}
