using System;
using System.Collections.Generic;
using System.Text;
using apiClientDotNet.Models;
using apiClientDotNet.Authentication;

namespace apiClientDotNet.Clients
{
    public interface ISymClient
    {
        SymConfig getConfig();

        ISymAuth getSymAuth();

        MessageClient getMessagesClient();

        StreamClient getStreamsClient();

        PresenceClient getPresenceClient();

        UserClient getUsersClient();

        ConnectionsClient getConnectionsClient();

        /*public Client getPodClient();

        public Client getAgentClient();

        public void setPodClient(Client podClient);

        public void setAgentClient(Client agentClient);*/
    }
}
