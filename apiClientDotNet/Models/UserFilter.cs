using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class UserFilter
    {
        [JsonProperty("title")]
        public String title { get; set; }

        [JsonProperty("location")]
        public String location { get; set; }

        [JsonProperty("company")]
        public String company { get; set; }

    }
}
