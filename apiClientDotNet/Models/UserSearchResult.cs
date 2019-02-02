using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class UserSearchResult
    {
        [JsonProperty("count")]
        private int count { get; set; }

        [JsonProperty("skip")]
        private int skip { get; set; }

        [JsonProperty("query")]
        private String query { get; set; }

        [JsonProperty("filters")]
        private Dictionary<String, String> filters { get; set; }

        [JsonProperty("users")]
        private List<UserInfo> users { get; set; }

        [JsonProperty("limit")]
        private int limit { get; set; }

    }
}
