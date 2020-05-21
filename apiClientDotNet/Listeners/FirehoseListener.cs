namespace apiClientDotNet.Listeners
{
    public interface FirehoseListener : ConnectionListener, ElementsActionListener, IMListener, PresenceUpdateListener, RoomListener
    {
    }
}
