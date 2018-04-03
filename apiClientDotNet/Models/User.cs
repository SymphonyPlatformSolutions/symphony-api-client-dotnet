using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class User
    {
        [JsonProperty("userId")]
        public long userId { get; set; }

        [JsonProperty("firstName")]
        public string firstName { get; set; }

        [JsonProperty("lastName")]
        public string lastName { get; set; }

        [JsonProperty("displayName")]
        public string displayName { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("username")]
        public string username { get; set; }
    }
}
