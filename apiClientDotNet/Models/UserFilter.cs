using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class UserFilter
    {
        [JsonProperty("title")]
        private String title { get; set; }

        [JsonProperty("location")]
        private String location { get; set; }

        [JsonProperty("company")]
        private String company { get; set; }

    }
}
