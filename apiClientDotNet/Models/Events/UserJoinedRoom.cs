using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class UserJoinedRoom
    {
        [JsonProperty("stream")]
        public Stream stream { get; set; }

        [JsonProperty("affectedUser")]
        public User affectedUser { get; set; }
    }
}
