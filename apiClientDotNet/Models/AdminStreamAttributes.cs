using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace apiClientDotNet.Models
{
    public class AdminStreamAttributes
    {
        [JsonProperty("description")]
        public String description { get; set; }

        [JsonProperty("roomName")]
        public String roomName { get; set; }

        [JsonProperty("roomDescription")]
        public String roomDescription { get; set; }

        [JsonProperty("members")]
        public List<long> members { get; set; }

        [JsonProperty("createdByUserId")]
        public long createdByUserId { get; set; }

        [JsonProperty("createdDate")]
        public long createdDate { get; set; }

        [JsonProperty("lastModifiedDate")]
        public long lastModifiedDate { get; set; }

        [JsonProperty("originCompany")]
        public String originCompany { get; set; }

        [JsonProperty("originCompanyId")]
        public int originCompanyId { get; set; }

        [JsonProperty("membersCount")]
        public int membersCount { get; set; }

        [JsonProperty("lastMessageDate")]
        public long lastMessageDate { get; set; }

    }
}
