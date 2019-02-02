using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class AdminStreamInfo
    {
        [JsonProperty("streamTypes")]
        private String id { get; set; }

        [JsonProperty("isExternal")]
        private Boolean isExternal { get; set; }

        [JsonProperty("isActive")]
        private Boolean isActive { get; set; }

        [JsonProperty("isPublic")]
        private Boolean isPublic { get; set; }

        [JsonProperty("type")]
        private String type { get; set; }

        [JsonProperty("crossPod")]
        private Boolean crossPod { get; set; }

        [JsonProperty("origin")]
        private String origin { get; set; }

        [JsonProperty("attributes")]
        private AdminStreamAttributes attributes { get; set; }
    }
}
