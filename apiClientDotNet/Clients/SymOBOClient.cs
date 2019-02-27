using System;
using System.Collections.Generic;
using System.Text;
using apiClientDotNet.Services;
using apiClientDotNet.Models;
using apiClientDotNet.Clients;
using apiClientDotNet.Authentication;
namespace apiClientDotNet.Clients
{
    public class SymOBOClient : ISymClient
    {
        private static SymOBOClient botClient;
        private SymConfig config;
        private ISymAuth symBotAuth;
        private DatafeedEventsService datafeedEventsService;
        private MessageClient messagesClient;
        private StreamClient streamClient;
        private PresenceClient presenceClient;
        private UserClient userClient;
        private ConnectionsClient connectionsClient;
        private SignalsClient signalsClient;

        public static SymOBOClient initOBOClient(SymConfig config, ISymAuth symBotAuth)
        {
            botClient = new SymOBOClient(config, symBotAuth);
            return botClient;
        }

        private SymOBOClient(SymConfig config, ISymAuth symBotAuth)
        {
            this.symBotAuth = symBotAuth;
            this.config = config;
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
    }
}
