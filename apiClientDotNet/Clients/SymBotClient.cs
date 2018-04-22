using System;
using System.Collections.Generic;
using System.Text;
using apiClientDotNet.Services;
using apiClientDotNet.Models;

namespace apiClientDotNet
{
    public class SymBotClient
    {
        public SymConfig initBot(String dir)
        {
            SymBotAuth symBotAuth = new SymBotAuth();
            SymConfigLoader symConfigLoader = new SymConfigLoader();
            SymConfig symConfig = symConfigLoader.loadFromFile(dir);
            AuthTokens authTokens = symBotAuth.authenticate(symConfig);
            symConfig.authTokens = authTokens;

            return symConfig;
        }
    }
}
