using System;

namespace CADBooster.SolidDna;

/// <summary>
/// Manages a subscription to a source event that is only active when there are subscribers.
/// Subscribes to the source when the first subscriber is added, unsubscribes when the last is removed.
/// Use in custom event accessors to avoid subscribing to source events when nobody is listening.
/// </summary>
/// <param name="subscribeInnerMethod">Action to subscribe to the source event.</param>
/// <param name="unsubscribeInnerMethod">Action to unsubscribe from the source event.</param>
internal struct LazyEvent(Action subscribeInnerMethod, Action unsubscribeInnerMethod)
{
    private event Action _storedUserEvents;
    private readonly LazyEventSubscription _subscription = new(subscribeInnerMethod, unsubscribeInnerMethod);

    /// <summary>
    /// Call when a subscriber is added. Subscribes to the source on the first subscriber.
    /// </summary>
    public void Subscribe(Action value)
    {
        _storedUserEvents += value;
        _subscription.OnSubscriberAdded();
    }

    /// <summary>
    /// Call when a subscriber is removed. Unsubscribes from the source when the last subscriber is gone.
    /// </summary>
    public void Unsubscribe(Action value)
    {
        _storedUserEvents -= value;
        _subscription.OnSubscriberRemoved();
    }

    /// <summary>
    /// Invokes all stored handlers. Call from the source event handler.
    /// </summary>
    public void Invoke() => _storedUserEvents?.Invoke();

    /// <summary>Unsubscribes from the source without changing subscriber count.</summary>
    public void ForceUnsubscribe() => _subscription.ForceUnsubscribe();

    /// <summary>Resubscribes to the source when there are subscribers.</summary>
    public void ResubscribeIfNeeded() => _subscription.ResubscribeIfNeeded();
}

/// <summary>
/// Manages a subscription to a source event that is only active when there are subscribers.
/// For events with one parameter. Subscribes to the source when the first subscriber is added,
/// unsubscribes when the last is removed.
/// </summary>
/// <param name="subscribeInnerMethod">Action to subscribe to the source event.</param>
/// <param name="unsubscribeInnerMethod">Action to unsubscribe from the source event.</param>
internal struct LazyEvent<T>(Action subscribeInnerMethod, Action unsubscribeInnerMethod)
{
    private event Action<T> _storedUserEvents;
    private readonly LazyEventSubscription _subscription = new(subscribeInnerMethod, unsubscribeInnerMethod);

    /// <summary>
    /// Call when a subscriber is added. Subscribes to the source on the first subscriber.
    /// </summary>
    public void Subscribe(Action<T> value)
    {
        _storedUserEvents += value;
        _subscription.OnSubscriberAdded();
    }

    /// <summary>
    /// Call when a subscriber is removed. Unsubscribes from the source when the last subscriber is gone.
    /// </summary>
    public void Unsubscribe(Action<T> value)
    {
        _storedUserEvents -= value;
        _subscription.OnSubscriberRemoved();
    }

    /// <summary>
    /// Invokes all stored handlers with the given argument. Call from the source event handler.
    /// </summary>
    public void Invoke(T arg) => _storedUserEvents?.Invoke(arg);

    /// <summary>Unsubscribes from the source without changing subscriber count.</summary>
    public void ForceUnsubscribe() => _subscription.ForceUnsubscribe();

    /// <summary>Resubscribes to the source when there are subscribers.</summary>
    public void ResubscribeIfNeeded() => _subscription.ResubscribeIfNeeded();
}

/// <summary>
/// Manages a subscription to a source event that is only active when there are subscribers.
/// For events with two parameters.
/// </summary>
/// <param name="subscribeInnerMethod">Action to subscribe to the source event.</param>
/// <param name="unsubscribeInnerMethod">Action to unsubscribe from the source event.</param>
internal struct LazyEvent<T1, T2>(Action subscribeInnerMethod, Action unsubscribeInnerMethod)
{
    private event Action<T1, T2> _storedUserEvents;
    private readonly LazyEventSubscription _subscription = new(subscribeInnerMethod, unsubscribeInnerMethod);

    public void Subscribe(Action<T1, T2> value)
    {
        _storedUserEvents += value;
        _subscription.OnSubscriberAdded();
    }

    public void Unsubscribe(Action<T1, T2> value)
    {
        _storedUserEvents -= value;
        _subscription.OnSubscriberRemoved();
    }

    public void Invoke(T1 arg1, T2 arg2) => _storedUserEvents?.Invoke(arg1, arg2);

    /// <summary>Unsubscribes from the source without changing subscriber count.</summary>
    public void ForceUnsubscribe() => _subscription.ForceUnsubscribe();

    /// <summary>Resubscribes to the source when there are subscribers.</summary>
    public void ResubscribeIfNeeded() => _subscription.ResubscribeIfNeeded();
}
