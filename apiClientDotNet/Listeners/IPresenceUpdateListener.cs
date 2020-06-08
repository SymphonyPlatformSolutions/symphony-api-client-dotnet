using System;

namespace apiClientDotNet.Listeners
{
    public interface IPresenceUpdateListener
    {
    }

    [Obsolete("Please instead use directly IPresenceUpdateListener")]
    public interface PresenceUpdateListener : IPresenceUpdateListener
    {
    }
}
