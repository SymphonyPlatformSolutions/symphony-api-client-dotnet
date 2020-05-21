using System;
using apiClientDotNet.Models;
using apiClientDotNet.Models.Events;

namespace apiClientDotNet.Listeners
{
    public interface ElementsActionListener
    {
        void onElementsAction(User initiator, SymphonyElementsAction action);

        void onFormMessage(User initiator, String fstreamid, SymphonyElementsAction form);
    }
}
