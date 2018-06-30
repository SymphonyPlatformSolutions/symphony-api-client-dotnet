using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class FileAttachment
    {
        [JsonProperty("fileContent")]
        public byte[] fileContent { get; set; }

        [JsonProperty("fileName")]
        public string fileName { get; set; }

        [JsonProperty("size")]
        public long size { get; set; }

    }
}
