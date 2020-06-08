using apiClientDotNet.Models;
using System;

namespace apiClientDotNet.Listeners
{
    public interface IIMListener
    {
        void onIMMessage(Message message);
        void onIMCreated(Stream stream);
    }

    [Obsolete("Please instead use directly IIMListener")]
    public abstract class IMListener : IIMListener
    {
        public virtual void onIMMessage(Message message) { }
        public virtual void onIMCreated(Stream stream) { }
    }
}
