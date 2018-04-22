using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class RoomMember
    {
        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("owner")]
        public Boolean owner { get; set; }

        [JsonProperty("joinDate")]
        public long joinDate { get; set; }

    }
}
