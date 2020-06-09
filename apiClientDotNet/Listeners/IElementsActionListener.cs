using apiClientDotNet.Models;
using apiClientDotNet.Models.Events;
using System;

namespace apiClientDotNet.Listeners
{
    public interface IElementsActionListener
    {
        void onElementsAction(User initiator, SymphonyElementsAction action);
        void onFormMessage(User initiator, String fstreamid, SymphonyElementsAction fform);
    }

    [Obsolete("Please instead use directly IElementsActionListener")]
    public abstract class ElementsActionListener : IElementsActionListener
    {
        public virtual void onElementsAction(User initiator, SymphonyElementsAction action) { }

        public virtual void onFormMessage(User initiator, String fstreamid, SymphonyElementsAction fform) { }
    }
}
