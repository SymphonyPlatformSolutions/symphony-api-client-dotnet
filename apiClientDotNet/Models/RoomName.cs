using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class RoomName
    {
        [JsonProperty("name")]
        public string name { get; set; }
    }
}
