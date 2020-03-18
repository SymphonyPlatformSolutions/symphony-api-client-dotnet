using System;
using System.Collections.Generic;
using System.Text;
using apiClientDotNet.Models;
using apiClientDotNet.Models.Events;

namespace apiClientDotNet.Listeners
{
    public abstract class ElementsActionListener
    {
        public virtual void onElementsAction(User initiator, SymphonyElementsAction action) { }

        public virtual void onFormMessage(User initiator, String fstreamid, SymphonyElementsAction fform) { }
    }
}
