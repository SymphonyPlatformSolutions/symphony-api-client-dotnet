using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class UserPresence
    {
        [JsonProperty("category")]
        public string category { get; set; }

        [JsonProperty("userId")]
        public long userId { get; set; }

        [JsonProperty("timestamp")]
        public long timestamp { get; set; }

    }
}
