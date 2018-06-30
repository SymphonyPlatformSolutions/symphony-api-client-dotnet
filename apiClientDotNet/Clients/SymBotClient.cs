using System;
using System.Collections.Generic;
using System.Text;
using apiClientDotNet.Services;
using apiClientDotNet.Models;

namespace apiClientDotNet
{
    public class SymBotClient
    {
        private static SymBotClient botClient;
        private SymConfig config;
        private SymBotAuth symBotAuth;
        private DatafeedClient datafeedClient;
        private MessageClient messagesClient;

        public static SymBotClient initBot(String dir)
        {
            if (botClient == null)
            {
                SymBotAuth symBotAuth = new SymBotAuth();
                SymConfigLoader symConfigLoader = new SymConfigLoader();
                SymConfig symConfig = symConfigLoader.loadFromFile(dir);
                AuthTokens authTokens = symBotAuth.authenticate(symConfig);
                symConfig.authTokens = authTokens;
            }

            return botClient;
        }

        private SymBotClient(SymConfig config, SymBotAuth symBotAuth)//, ClientConfig podClientConfig, ClientConfig agentClientConfig)
        {
            this.config = config;
            this.symBotAuth = symBotAuth;
            //this.podClient = ClientBuilder.newClient(podClientConfig);
            //this.agentClient = ClientBuilder.newClient(agentClientConfig);
            
        }
        public DatafeedClient getDatafeedClient()
        {
            if (datafeedClient == null)
            {
               // datafeedClient = new DatafeedClient(this);
            }
            return datafeedClient;
        }

        public SymConfig getConfig()
        {
            return config;
        }

        public SymBotAuth getSymAuth()
        {
            return symBotAuth;
        }

        public MessageClient getMessagesClient()
        {
            if (messagesClient == null)
            {
                messagesClient = new MessageClient(this);
            }
            return messagesClient;
        }
    }
}
