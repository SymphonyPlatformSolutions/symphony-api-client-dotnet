using apiClientDotNet.Models;

namespace apiClientDotNet.Listeners
{
    public abstract class ConnectionListener
    {
        public virtual void onConnectionAccepted(User user) { }
        public virtual void onConnectionRequested(User user) { }
    }
}
