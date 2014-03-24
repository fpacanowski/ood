using System;
using NUnit.Framework;
using System.Threading;

[TestFixture]
public class SingletonsTest
{
    [Test]
    public void SingletonTest()
    {
        Singleton a = Singleton.Instance;
        Singleton b = Singleton.Instance;
        
        Assert.IsNotNull(a);
        Assert.AreEqual(a, b);
    }

    class Helper{
        public ThreadSingleton a = null;
        public ThreadSingleton b = null;
        public void Thread1() {
            a = ThreadSingleton.Instance;
        }
        public void Thread2() {
            b = ThreadSingleton.Instance;
        }
    }
    [Test]
    public void ThreadSingletonTest()
    {
        Helper h = new Helper();
        Thread t1 = new Thread(new ThreadStart(h.Thread1));
        Thread t2 = new Thread(new ThreadStart(h.Thread2));
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
        Assert.IsNotNull(h.a);
        Assert.IsNotNull(h.b);
        Assert.AreNotEqual(h.a, h.b);
    }

    [Test]
    public void TimedSingletonTest()
    {
        TimedSingleton a = TimedSingleton.Instance;
        TimedSingleton b = TimedSingleton.Instance;
        Assert.IsNotNull(a);
        Assert.AreEqual(a, b);

        System.Threading.Thread.Sleep(5000);
        b = TimedSingleton.Instance;
        Assert.IsNotNull(b);
        Assert.AreNotEqual(a, b);
    }
}
