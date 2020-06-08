using apiClientDotNet.Models;
using System;

namespace apiClientDotNet.Listeners
{
    public interface IConnectionListener
    {
        void onConnectionAccepted(User user);
        void onConnectionRequested(User user);
    }

    [Obsolete("Please instead use directly IConnectionListener")]
    public abstract class ConnectionListener : IConnectionListener
    {
        public virtual void onConnectionAccepted(User user) { }
        public virtual void onConnectionRequested(User user) { }
    }
}
