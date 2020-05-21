using apiClientDotNet.Models;


namespace apiClientDotNet.Listeners
{
    public interface IMListener
    {
        void onIMMessage(Message message);
        void onIMCreated(Stream stream);
    }
}
