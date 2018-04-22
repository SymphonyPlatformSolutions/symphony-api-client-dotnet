using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class MessageStatusUser
    {
        [JsonProperty("read")]
        public string read { get; set; }

        [JsonProperty("firstName")]
        public string firstName { get; set; }

        [JsonProperty("lastName")]
        public string lastName { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("timestamp")]
        public long timestamp { get; set; }

    }
}
