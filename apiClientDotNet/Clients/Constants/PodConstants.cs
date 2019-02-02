using System;
using System.Collections.Generic;
using System.Text;

namespace apiClientDotNet.Clients.Constants
{
    public class PodConstants
    {
        public static String POD = "/pod";
        public static String GETUSERSV3 = POD+"/v3/users";
        public static String GETUSERV2 = POD+"/v2/user";
        public static String GETIM = POD+"/v1/im/create";
        public static String CREATEROOM = POD+"/v3/room/create";
        public static String ADDMEMBER = POD+"/v1/room/{id}/membership/add";
        public static String REMOVEMEMBER = POD+"/v1/room/{id}/membership/remove";
        public static String GETROOMINFO = POD+"/v3/room/{id}/info";
        public static String UPDATEROOMINFO = POD+"/v3/room/{id}/update";
        public static String GETSTREAMINFO = POD+"/v2/streams/{id}/info";
        public static String GETROOMMEMBERS = POD+"/v2/room/{id}/membership/list";
        public static String SETACTIVE = POD+"/v1/admin/room/{id}/setActive";
        public static String PROMOTEOWNER = POD+"/v1/room/{id}/membership/promoteOwner";
        public static String DEMOTEOWNER = POD+"/v1/room/{id}/membership/demoteOwner";
        public static String ACCEPTCONNECTION = POD+"/v1/connection/accept";
        public static String REJECTCONNECTION = POD+"/v1/connection/reject";
        public static String GETCONNECTIONSTATUS = POD+"/v1/connection/user/{userId}/info";
        public static String REMOVECONNECTION = POD+"/v1/connection/user/{userId}/remove";
        public static String GETCONNECTIONS = POD + "v1/connection/list";
        public static String SENDCONNECTIONREQUEST = POD+"/v1/connection/create";
        public static String GETMESSAGESTATUS =  POD+"/v1/message/{mid}/status";
        public static String GETUSERPRESENCE =  POD+"/v3/user/{uid}/presence";
        public static String SETPRESENCE =  POD+"/v2/user/presence";
        public static String REGISTERPRESENCEINTEREST =  POD+"/v1/user/presence/register";
        public static String SEARCHUSERS =  POD+"/v1/user/search";

        public static String SEARCHROOMS = POD+"/v3/room/search";
        public static String MESSAGESUPPRESS = POD+"/v1/admin/messagesuppression/{id}/suppress";
        public static String GETATTACHMENTTYPES = POD+ "/v1/files/allowedTypes";
        public static String ADMINCREATEIM = POD+ "/v1/admin/im/create";
        public static String LISTUSERSTREAMS = POD+"/v1/streams/list";
        public static String ENTERPRISESTREAMS = POD+"/v2/admin/streams/list";
        public static String GETUSERADMIN = POD+"/v2/admin/user/{uid}" ;
        public static String LISTUSERSADMIN = POD+"/v2/admin/user/list" ;
        public static String GETAVATARADMIN = POD+"/v1/admin/user/{uid}/avatar";
        public static String GETUSERSTATUSADMIN = POD+"/v1/admin/user/{uid}/status";
        public static String UPDATEUSERSTATUSADMIN = POD+"/v1/admin/user/{uid}/status/update";
        public static String PODFEATURESADMIN = POD+"/v1/admin/system/features/list";

        public static String GETUSERFEATURESADMIN = POD+ "/v1/admin/user/{uid}/features" ;
        public static String UPDATEUSERFEATURESADMIN = POD +"/v1/admin/user/{uid}/features/update";
        public static String GETUSERAPPLICATIONSADMIN = POD +"/v1/admin/user/{uid}/app/entitlement/list";
        public static String UPDATEUSERAPPLICATIONSADMIN = POD +"/v1/admin/user/{uid}/app/entitlement/list";
        public static String ADMINCREATEUSER =  POD +"/v2/admin/user/create";
        public static String ADMINUPDATEUSER = POD +"/v2/admin/user/{uid}/update";
        public static String ADMINUPDATEAVATAR = POD + "/v1/admin/user/{uid}/avatar/update";

    }
}
