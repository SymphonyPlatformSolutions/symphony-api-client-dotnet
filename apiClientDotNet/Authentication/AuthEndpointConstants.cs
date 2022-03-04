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
        public const string HttpsPrefix = "https://";
        public const string SessionAuthPath = "/sessionauth/v1/authenticate";
        public const string KeyAuthPath = "/keyauth/v1/authenticate";
        public const string LogoutPath = "/sessionauth/v1/logout";
        public const string RsaSessionAuthPath = "/login/pubkey/authenticate";
        public const string RsaKeyManagerAuthPath = "/relay/pubkey/authenticate";
        public const string AppSessionAuthPath = "/sessionauth/v1/app/authenticate";
        public const string OboUserAuthByIdPath = "/login/pubkey/app/user/{uid}/authenticate";
        public const string OboUserAuthByUsernamePath = "/login/pubkey/app/username/{username}/authenticate";
    }
}
