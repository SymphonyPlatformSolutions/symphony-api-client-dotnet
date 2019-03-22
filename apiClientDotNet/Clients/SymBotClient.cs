using System;
using System.Collections.Generic;
using System.Text;
using apiClientDotNet.Services;
using apiClientDotNet.Models;
using apiClientDotNet.Clients;
using apiClientDotNet.Authentication;
using System.Net;

namespace apiClientDotNet
{
    public class SymBotClient : ISymClient
    {
        private static SymBotClient botClient;
        private SymConfig config;
        private ISymAuth symBotAuth;
        private DatafeedEventsService datafeedEventsService;
        private MessageClient messagesClient;
        private StreamClient streamClient;
        private PresenceClient presenceClient;
        private UserClient userClient;
        private ConnectionsClient connectionsClient;
        private SignalsClient signalsClient;
        private UserInfo botUserInfo;

        public static SymBotClient initBot(SymConfig config, ISymAuth symBotAuth)
        {
            ServicePointManager.DefaultConnectionLimit = 10;
            if (botClient == null)
            {
                botClient = new SymBotClient(config, symBotAuth);
                return botClient;
            }
            return botClient;
        }

        private SymBotClient(SymConfig config, ISymAuth symBotAuth)
        {
            this.config = config;
            this.symBotAuth = symBotAuth;
        }

        private SymBotClient(SymConfig config, SymBotAuth symBotAuth)//, ClientConfig podClientConfig, ClientConfig agentClientConfig)
        {
            this.config = config;
            this.symBotAuth = symBotAuth;
            //this.podClient = ClientBuilder.newClient(podClientConfig);
            //this.agentClient = ClientBuilder.newClient(agentClientConfig);
            
        }
        public DatafeedEventsService getDatafeedEventsService()
        {
            if (datafeedEventsService == null)
            {
               datafeedEventsService = new DatafeedEventsService(this);
            }
            return datafeedEventsService;
        }

        public SymConfig getConfig()
        {
            return config;
        }

        public ISymAuth getSymAuth()
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

        public StreamClient getStreamsClient()
        {
            if (streamClient == null)
            {
                streamClient = new StreamClient(this);
            }
            return streamClient;
        }

        public PresenceClient getPresenceClient()
        {
            if (presenceClient == null)
            {
                presenceClient = new PresenceClient(this);
            }
            return presenceClient;
        }

        public UserClient getUsersClient()
        {
            if (userClient == null)
            {
                userClient = new UserClient(this);
            }
            return userClient;
        }

        public ConnectionsClient getConnectionsClient()
        {
            if (connectionsClient == null)
            {
                connectionsClient = new ConnectionsClient(this);
            }
            return connectionsClient;
        }

        public SignalsClient getSignalsClient()
        {
            if (signalsClient == null)
            {
                signalsClient = new SignalsClient(this);
            }
            return signalsClient;
        }

        public UserInfo getBotUserInfo(){
            if (botUserInfo == null)
            {
                botUserInfo = botClient.getUsersClient().getSessionUser();
            }
            return botUserInfo;
        }
    }
}
