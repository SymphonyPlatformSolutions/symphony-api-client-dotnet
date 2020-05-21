using apiClientDotNet.Models;

namespace apiClientDotNet.Listeners
{
    public interface ConnectionListener
    {
        void onConnectionAccepted(User user);
        void onConnectionRequested(User user);
    }
}
