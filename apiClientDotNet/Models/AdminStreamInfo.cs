using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class AdminStreamInfo
    {
        [JsonProperty("streamTypes")]
        public String id { get; set; }

        [JsonProperty("isExternal")]
        public Boolean isExternal { get; set; }

        [JsonProperty("isActive")]
        public Boolean isActive { get; set; }

        [JsonProperty("isPublic")]
        public Boolean isPublic { get; set; }

        [JsonProperty("type")]
        public String type { get; set; }

        [JsonProperty("crossPod")]
        public Boolean crossPod { get; set; }

        [JsonProperty("origin")]
        public String origin { get; set; }

        [JsonProperty("attributes")]
        public AdminStreamAttributes attributes { get; set; }
    }
}
