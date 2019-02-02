using System;
using System.Collections.Generic;
using System.Text;

namespace apiClientDotNet.Clients.Constants
{
    public class AgentConstants
    {
        public static String CREATEDATAFEED = "/agent/v4/datafeed/create";
        public static String READDATAFEED = "/agent/v4/datafeed/{id}/read";
        public static String CREATEMESSAGE = "/agent/v4/stream/{sid}/message/create";
        public static String GETMESSAGES = "/agent/v4/stream/{sid}/message";
        public static String GETATTACHMENT = "/v1/stream/{sid}/attachment";

        public static String SEARCHMESSAGES = "/agent/v1/message/search";
        public static String MESSAGEIMPORT = "/agent/v4/message/import" ;
        public static String SHARE = "/agent/v3/stream/{sid}/share";
        public static String LISTSIGNALS = "/agent/v1/signals/list";
        public static String GETSIGNAL = "/agent/v1/signals/{id}/get" ;
        public static String CREATESIGNAL = "/agent/v1/signals/create";
        public static String UPDATESIGNAL = "/agent/v1/signals/{id}/update";
        public static String DELETESIGNAL = "/agent/v1/signals/{id}/delete";
        public static String SUBSCRIBESIGNAL = "/agent/v1/signals/{id}/subscribe";
        public static String UNSUBSCRIBESIGNAL = "/agent/v1/signals/{id}/unsubscribe";
        public static String GETSUBSCRIBERS = "/v1/signals/{id}/subscribers";

    }
}
