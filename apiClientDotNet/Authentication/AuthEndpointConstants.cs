using System;
using System.Collections.Generic;
using System.Text;

namespace apiClientDotNet.Authentication
{
    public class AuthEndpointConstants
    {
        public static String SESSIONAUTHPATH = "/sessionauth/v1/authenticate";
        public static String KEYAUTHPATH = "/keyauth/v1/authenticate";
        public static String HTTPSPREFIX = "https://";
        public static String LOGOUTPATH = "/sessionauth/v1/logout";
        public static String RSASESSIONAUTH = "/login/pubkey/authenticate";
        public static String RSAKMAUTH = "/relay/pubkey/authenticate";
        public static String SESSIONAPPAUTH = "/sessionauth/v1/app/authenticate";
        public static String OBOUSERAUTH = "/sessionauth/v1/app/user/{uid}/authenticate";
        public static String OBOUSERAUTHUSERNAME = "/sessionauth/v1/app/username/{username}/authenticate";
    }
}
