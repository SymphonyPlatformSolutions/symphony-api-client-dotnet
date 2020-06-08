using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class StreamInfo
    {

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("crossPod")]
        public Boolean crossPod { get; set; }

        [JsonProperty("origin")]
        public string origin { get; set; }
        
        [JsonProperty("active")]
        public Boolean active { get; set; }

        [JsonProperty("lastMessageDate")]
        public long lastMessageDate { get; set; }

        [JsonProperty("streamType")]
        public StreamType StreamType { get; set; }

        [JsonIgnore]
        [Obsolete("Please instead of streamType use StreamType")]
        public string streamType
        { 
            get
            {
                return StreamType?.type;
            }
            set
            {
                StreamType = new StreamType
                {
                    type = value
                };
            }
        }

        [JsonProperty("streamAttributes")]
        public StreamAttributes streamAttributes { get; set; }

        [JsonProperty("roomAttributes")]
        public RoomName roomAttributes { get; set; }
    }
}
