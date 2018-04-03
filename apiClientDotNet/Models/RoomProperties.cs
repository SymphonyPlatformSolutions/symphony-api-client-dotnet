using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class RoomProperties
    {

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("creatorUser")]
        public User creatorUser { get; set; }

        [JsonProperty("createdDate")]
        public long createdDate { get; set; }

        [JsonProperty("external")]
        public bool external { get; set; }

        [JsonProperty("crossPod")]
        public bool crossPod { get; set; }

        [JsonProperty("isPublic")]
        public bool isPublic { get; set; }

        [JsonProperty("copyProtected")]
        public bool copyProtected { get; set; }

        [JsonProperty("readOnly")]
        public bool readOnly { get; set; }

        [JsonProperty("discoverable")]
        public bool discoverable { get; set; }

        [JsonProperty("membersCanInvite")]
        public bool copyPrmembersCanInviteotected { get; set; }

        [JsonProperty("keywords")]
        public List<keyword> keywords { get; set; }

        [JsonProperty("canViewHistory")]
        public bool canViewHistory { get; set; }

    }
}
