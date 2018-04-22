using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class RoomSystemInfo
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("creationDate")]
        public long creationDate { get; set; }

        [JsonProperty("createdByUserId")]
        public long createdByUserId { get; set; }

        [JsonProperty("active")]
        public Boolean active { get; set; }
    }
}
