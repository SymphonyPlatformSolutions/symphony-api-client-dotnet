using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class UserInfoList
    {
        [JsonProperty("users")]
        public List<UserInfo> users { get; set; }

    }
}
