using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class UserSearchResult
    {
        [JsonProperty("count")]
        public int count { get; set; }

        [JsonProperty("skip")]
        public int skip { get; set; }

        [JsonProperty("query")]
        public String query { get; set; }

        [JsonProperty("filters")]
        public Dictionary<String, String> filters { get; set; }

        [JsonProperty("users")]
        public List<UserInfo> users { get; set; }

        [JsonProperty("limit")]
        public int limit { get; set; }

    }
}
