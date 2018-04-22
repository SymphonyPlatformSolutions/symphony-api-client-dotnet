using System;
using System.Collections.Generic;
using System.Text;

namespace apiClientDotNet.Clients.Constants
{
    public class PodConstants
    {
        public static string POD = "/pod";
        public static string GETUSERSV3 = POD+"/v3/users";
        public static string GETUSERV2 = POD+"/v2/user";
        public static string GETIM = POD+"/v1/im/create";
        public static string CREATEROOM = POD+"/v3/room/create";
        public static string ADDMEMBER = POD+"/v1/room/{id}/membership/add";
        public static string REMOVEMEMBER = POD+"/v1/room/{id}/membership/remove";
        public static string GETROOMINFO = POD+"/v3/room/{id}/info";
        public static string UPDATEROOMINFO = POD+"/v3/room/{id}/update";
        public static string GETSTREAMINFO = POD+"/v2/streams/{id}/info";
        public static string GETROOMMEMBERS = POD+"/v2/room/{id}/membership/list";
        public static string SETACTIVE = POD+"/v1/admin/room/{id}/setActive";
        public static string PROMOTEOWNER = POD+"/v1/room/{id}/membership/promoteOwner";
        public static string DEMOTEOWNER = POD+"/v1/room/{id}/membership/demoteOwner";
        public static string ACCEPTCONNECTION = POD+"/v1/connection/accept";
        public static string REJECTCONNECTION = POD+"/v1/connection/reject";
        public static string GETCONNECTIONSTATUS = POD+"/v1/connection/user/{userId}/info";
        public static string REMOVECONNECTION = POD+"/v1/connection/user/{userId}/remove";
        public static string GETCONNECTIONS = POD + "v1/connection/list";
        public static string SENDCONNECTIONREQUEST = POD+"/v1/connection/create";
        public static string GETMESSAGESTATUS =  POD+"/v1/message/{mid}/status";
        public static string GETUSERPRESENCE =  POD+"/v3/user/{uid}/presence";
        public static string SETPRESENCE =  POD+"/v2/user/presence";
        public static string REGISTERPRESENCEINTEREST =  POD+"/v1/user/presence/register";

    }
}
