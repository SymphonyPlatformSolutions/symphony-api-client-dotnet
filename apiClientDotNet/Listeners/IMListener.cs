using System;
using System.Collections.Generic;
using System.Text;
using apiClientDotNet.Models;

namespace apiClientDotNet.Listeners
{
    public abstract class IMListener
    {
        public virtual void onIMMessage(Message message) { }
        public virtual void onIMCreated(Stream stream) { }
    }
}
