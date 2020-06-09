using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class UserInfo
    {
        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("firstName")]
        public string firstName { get; set; }

        [JsonProperty("lastName")]
        public string lastName { get; set; }

        [JsonProperty("displayName")]
        public string displayName { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("company")]
        public string company { get; set; }

        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("location")]
        public string location { get; set; }

        [JsonProperty("workPhoneNumber")]
        public string workPhoneNumber { get; set; }

        [JsonProperty("mobilePhoneNumber")]
        public string mobilePhoneNumber { get; set; }

        [JsonProperty("jobFunction")]
        public string jobFunction { get; set; }

        [JsonProperty("department")]
        public string department { get; set; }

        [JsonProperty("division")]
        public string division { get; set; }

        [JsonProperty("avatars")]
        public List<Avatar> avatars { get; set; }

        [JsonProperty("emailAddress")]
        public string emailAddress { get; set; }

    }
}
