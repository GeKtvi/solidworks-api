using System;

namespace CADBooster.SolidDna;

/// <summary>
/// Manages subscription state: subscriber count and when to call subscribe/unsubscribe on the source.
/// Subscribes when the first subscriber is added, unsubscribes when the last is removed.
/// </summary>
internal struct LazyEventSubscription
{
    private readonly Action _subscribe;
    private readonly Action _unsubscribe;
    private int _subscriberCount;

    public LazyEventSubscription(Action subscribe, Action unsubscribe)
    {
        _subscribe = subscribe ?? throw new ArgumentNullException(nameof(subscribe));
        _unsubscribe = unsubscribe ?? throw new ArgumentNullException(nameof(unsubscribe));
    }

    /// <summary>
    /// Call when a subscriber is added. Subscribes to the source on the first subscriber.
    /// </summary>
    public void OnSubscriberAdded()
    {
        if (++_subscriberCount == 1)
            _subscribe.Invoke();
    }

    /// <summary>
    /// Call when a subscriber is removed. Unsubscribes from the source when the last subscriber is gone.
    /// </summary>
    public void OnSubscriberRemoved()
    {
        if (_subscriberCount > 0 && --_subscriberCount == 0)
            _unsubscribe.Invoke();
    }

    public void ForceUnsubscribe()
    {
        if (_subscriberCount > 0)
            _unsubscribe.Invoke();
    }

    public void ResubscribeIfNeeded()
    {
        if (_subscriberCount > 0)
            _subscribe.Invoke();
    }
}
