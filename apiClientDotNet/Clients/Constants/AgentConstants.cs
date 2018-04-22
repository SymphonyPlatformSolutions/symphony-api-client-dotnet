using System;
using System.Collections.Generic;
using System.Text;

namespace apiClientDotNet.Clients.Constants
{
    public class AgentConstants
    {
        public static string CREATEDATAFEED = "/agent/v4/datafeed/create";
        public static string READDATAFEED = "/agent/v4/datafeed/{id}/read";
        public static string CREATEMESSAGE = "/agent/v4/stream/{sid}/message/create";
        public static string GETMESSAGES = "/agent/v4/stream/{sid}/message";
        public static string GETATTACHMENT = "/v1/stream/{sid}/attachment";

    }
}
