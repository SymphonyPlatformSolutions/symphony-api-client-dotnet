using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class Room
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("membersCanInvite")]
        public Boolean membersCanInvite { get; set; }

        [JsonProperty("discoverable")]
        public Boolean discoverable { get; set; }

        [JsonProperty("public")]
        public Boolean isPublic { get; set; }

        [JsonProperty("readOnly")]
        public Boolean readOnly { get; set; }

        [JsonProperty("copyProtected")]
        public Boolean copyProtected { get; set; }

        [JsonProperty("crossPod")]
        public Boolean crossPod { get; set; }

        [JsonProperty("viewHistory")]
        public Boolean viewHistory { get; set; }

        [JsonIgnore]
        [Obsolete("Please instead of multiLateralRoom use MultiLateralRoom")]
        public Boolean multiLateralRoom
        {
            get { return MultiLateralRoom.HasValue ? MultiLateralRoom.Value : default(Boolean); }
            set { MultiLateralRoom = value; }
        }

        [JsonProperty("multiLateralRoom")]
        public Boolean? MultiLateralRoom { get; set; }

        [JsonProperty("keywords")]
        public List<Keyword> keywords { get; set; }

    }
}
