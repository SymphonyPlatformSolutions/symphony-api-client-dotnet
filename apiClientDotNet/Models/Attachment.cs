using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class Attachment
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("size")]
        public long size { get; set; }

        [JsonProperty("image")]
        public ImageInfo image { get; set; }
    }
}
