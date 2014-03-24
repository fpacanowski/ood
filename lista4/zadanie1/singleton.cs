using System;
using System.Threading;

public class Singleton {
    private static Singleton _instance;
    private Singleton() {}
    public static Singleton Instance {
        get {
            if(_instance == null){
                _instance = new Singleton();
            }
            return _instance;
        }
    }
}


public class ThreadSingleton {
    [ThreadStatic]
    private static ThreadSingleton _instance;
    private ThreadSingleton() {}
    public static ThreadSingleton Instance {
        get {
            if(_instance == null){
                _instance = new ThreadSingleton();
            }
            return _instance;
        }
    }
}

public class TimedSingleton {
    private static TimeSpan LifeTime = new TimeSpan(0, 0, 5);
    private static DateTime CreationTime;
    private static TimedSingleton _instance;
    private TimedSingleton() {}
    public static TimedSingleton Instance {
        get {
            if(_instance == null || DateTime.Now - CreationTime > LifeTime){
                _instance = new TimedSingleton();
                CreationTime = DateTime.Now;
            }
            return _instance;
        }
    }
}
