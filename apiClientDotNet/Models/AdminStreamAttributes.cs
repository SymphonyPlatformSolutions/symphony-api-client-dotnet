using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace apiClientDotNet.Models
{
    public class AdminStreamAttributes
    {
        [JsonProperty("description")]
        private String description { get; set; }

        [JsonProperty("roomName")]
        private String roomName { get; set; }

        [JsonProperty("roomDescription")]
        private String roomDescription { get; set; }

        [JsonProperty("members")]
        private List<long> members { get; set; }

        [JsonProperty("createdByUserId")]
        private long createdByUserId { get; set; }

        [JsonProperty("createdDate")]
        private long createdDate { get; set; }

        [JsonProperty("lastModifiedDate")]
        private long lastModifiedDate { get; set; }

        [JsonProperty("originCompany")]
        private String originCompany { get; set; }

        [JsonProperty("originCompanyId")]
        private int originCompanyId { get; set; }

        [JsonProperty("membersCount")]
        private int membersCount { get; set; }

        [JsonProperty("lastMessageDate")]
        private long lastMessageDate { get; set; }

    }
}
