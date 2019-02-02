using System;
using System.Collections.Generic;
using System.Text;

namespace apiClientDotNet.Authentication
{
    public interface ISymAuth
    {

        void authenticate();

        void sessionAuthenticate();

        void kmAuthenticate();

        String getSessionToken();

        void setSessionToken(String sessionToken);

        String getKmToken();

        void setKmToken(String kmToken);

        void logout();
    }
}
