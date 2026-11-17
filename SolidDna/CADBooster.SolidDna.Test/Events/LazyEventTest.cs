using NUnit.Framework;

namespace CADBooster.SolidDna.Test;

[TestFixture]
internal class LazyEventTest
{
    private int _subscribeCount;
    private int _unsubscribeCount;

    [SetUp]
    public void Setup()
    {
        _subscribeCount = 0;
        _unsubscribeCount = 0;
    }

    private void InnerSubscribe() => _subscribeCount++;
    private void InnerUnsubscribe() => _unsubscribeCount++;

    #region LazyEvent

    [Test]
    public void LazyEvent_TwoSubscribers_SubscribesInnerOnceAndInvokesEachHandlerOnce()
    {
        var lazyEvent = new LazyEvent(InnerSubscribe, InnerUnsubscribe);
        var firstCalls = 0;
        var secondCalls = 0;

        lazyEvent.Subscribe(() => firstCalls++);
        lazyEvent.Subscribe(() => secondCalls++);
        lazyEvent.Invoke();

        Assert.That(_subscribeCount, Is.EqualTo(1));
        Assert.That(firstCalls, Is.EqualTo(1));
        Assert.That(secondCalls, Is.EqualTo(1));
    }

    [Test]
    public void LazyEvent_RemoveBothSubscribers_UnsubscribesInnerOnce()
    {
        var lazyEvent = new LazyEvent(InnerSubscribe, InnerUnsubscribe);
        void First() { }
        void Second() { }

        lazyEvent.Subscribe(First);
        lazyEvent.Subscribe(Second);
        lazyEvent.Unsubscribe(First);
        Assert.That(_unsubscribeCount, Is.EqualTo(0));
        lazyEvent.Unsubscribe(Second);

        Assert.That(_unsubscribeCount, Is.EqualTo(1));
    }

    [Test]
    public void LazyEvent_ForceUnsubscribeThenResubscribe_UnhooksAndRehooksInnerOnce()
    {
        var lazyEvent = new LazyEvent(InnerSubscribe, InnerUnsubscribe);
        lazyEvent.Subscribe(() => { });
        lazyEvent.Subscribe(() => { });

        lazyEvent.ForceUnsubscribe();
        lazyEvent.ResubscribeIfNeeded();

        Assert.That(_unsubscribeCount, Is.EqualTo(1));
        Assert.That(_subscribeCount, Is.EqualTo(2));
    }

    [Test]
    public void LazyEvent_ForceUnsubscribeWithoutSubscribers_DoesNotCallInner()
    {
        var lazyEvent = new LazyEvent(InnerSubscribe, InnerUnsubscribe);

        lazyEvent.ForceUnsubscribe();
        lazyEvent.ResubscribeIfNeeded();

        Assert.That(_unsubscribeCount, Is.EqualTo(0));
        Assert.That(_subscribeCount, Is.EqualTo(0));
    }

    #endregion

    #region LazyEvent<T>

    [Test]
    public void LazyEventOfT_TwoSubscribers_SubscribesInnerOnceAndInvokesEachHandlerOnce()
    {
        var lazyEvent = new LazyEvent<string>(InnerSubscribe, InnerUnsubscribe);
        var firstCalls = 0;
        var secondCalls = 0;

        lazyEvent.Subscribe(_ => firstCalls++);
        lazyEvent.Subscribe(_ => secondCalls++);
        lazyEvent.Invoke("path");

        Assert.That(_subscribeCount, Is.EqualTo(1));
        Assert.That(firstCalls, Is.EqualTo(1));
        Assert.That(secondCalls, Is.EqualTo(1));
    }

    [Test]
    public void LazyEventOfT_RemoveBothSubscribers_UnsubscribesInnerOnce()
    {
        var lazyEvent = new LazyEvent<string>(InnerSubscribe, InnerUnsubscribe);
        void First(string _) { }
        void Second(string _) { }

        lazyEvent.Subscribe(First);
        lazyEvent.Subscribe(Second);
        lazyEvent.Unsubscribe(First);
        Assert.That(_unsubscribeCount, Is.EqualTo(0));
        lazyEvent.Unsubscribe(Second);

        Assert.That(_unsubscribeCount, Is.EqualTo(1));
    }

    [Test]
    public void LazyEventOfT_ForceUnsubscribeThenResubscribe_UnhooksAndRehooksInnerOnce()
    {
        var lazyEvent = new LazyEvent<string>(InnerSubscribe, InnerUnsubscribe);
        lazyEvent.Subscribe(_ => { });
        lazyEvent.Subscribe(_ => { });

        lazyEvent.ForceUnsubscribe();
        lazyEvent.ResubscribeIfNeeded();

        Assert.That(_unsubscribeCount, Is.EqualTo(1));
        Assert.That(_subscribeCount, Is.EqualTo(2));
    }

    [Test]
    public void LazyEventOfT_ForceUnsubscribeWithoutSubscribers_DoesNotCallInner()
    {
        var lazyEvent = new LazyEvent<string>(InnerSubscribe, InnerUnsubscribe);

        lazyEvent.ForceUnsubscribe();
        lazyEvent.ResubscribeIfNeeded();

        Assert.That(_unsubscribeCount, Is.EqualTo(0));
        Assert.That(_subscribeCount, Is.EqualTo(0));
    }

    #endregion

    #region LazyEvent<T1, T2>

    [Test]
    public void LazyEventOfT1T2_TwoSubscribers_SubscribesInnerOnceAndInvokesEachHandlerOnce()
    {
        var lazyEvent = new LazyEvent<int, string>(InnerSubscribe, InnerUnsubscribe);
        var firstCalls = 0;
        var secondCalls = 0;

        lazyEvent.Subscribe((_, _) => firstCalls++);
        lazyEvent.Subscribe((_, _) => secondCalls++);
        lazyEvent.Invoke(1, "item");

        Assert.That(_subscribeCount, Is.EqualTo(1));
        Assert.That(firstCalls, Is.EqualTo(1));
        Assert.That(secondCalls, Is.EqualTo(1));
    }

    [Test]
    public void LazyEventOfT1T2_RemoveBothSubscribers_UnsubscribesInnerOnce()
    {
        var lazyEvent = new LazyEvent<int, string>(InnerSubscribe, InnerUnsubscribe);
        void First(int _, string __) { }
        void Second(int _, string __) { }

        lazyEvent.Subscribe(First);
        lazyEvent.Subscribe(Second);
        lazyEvent.Unsubscribe(First);
        Assert.That(_unsubscribeCount, Is.EqualTo(0));
        lazyEvent.Unsubscribe(Second);

        Assert.That(_unsubscribeCount, Is.EqualTo(1));
    }

    [Test]
    public void LazyEventOfT1T2_ForceUnsubscribeThenResubscribe_UnhooksAndRehooksInnerOnce()
    {
        var lazyEvent = new LazyEvent<int, string>(InnerSubscribe, InnerUnsubscribe);
        lazyEvent.Subscribe((_, _) => { });
        lazyEvent.Subscribe((_, _) => { });

        lazyEvent.ForceUnsubscribe();
        lazyEvent.ResubscribeIfNeeded();

        Assert.That(_unsubscribeCount, Is.EqualTo(1));
        Assert.That(_subscribeCount, Is.EqualTo(2));
    }

    [Test]
    public void LazyEventOfT1T2_ForceUnsubscribeWithoutSubscribers_DoesNotCallInner()
    {
        var lazyEvent = new LazyEvent<int, string>(InnerSubscribe, InnerUnsubscribe);

        lazyEvent.ForceUnsubscribe();
        lazyEvent.ResubscribeIfNeeded();

        Assert.That(_unsubscribeCount, Is.EqualTo(0));
        Assert.That(_subscribeCount, Is.EqualTo(0));
    }

    #endregion
}
