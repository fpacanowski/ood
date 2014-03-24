using System;
using System.Collections.Generic;

public class Plane{}

public class AirportPool {
    private static List<Plane> Planes = new List<Plane>();
    static AirportPool() {
        Planes.Add(new Plane());
        Planes.Add(new Plane());
        Planes.Add(new Plane());
    }
    public int NumberOfPlanesLeft {
        get { return Planes.Count; }
    }
    public Plane AcquirePlane(){
        if(NumberOfPlanesLeft == 0){
            throw new System.ApplicationException("No more planes");
        }
        Plane p = Planes[0];
        Planes.RemoveAt(0);
        return p;
    }
    public void ReleasePlane(Plane p){
        Planes.Add(p);
    }
}

public class AirportProxy {
    private AirportPool airport;
    private readonly Func<DateTime> _nowProvider;
    public AirportProxy(Func<DateTime> nowProvider) {
        _nowProvider = nowProvider;
        airport = new AirportPool();
    }
    private void CheckAccess() {
        DateTime time = _nowProvider();
        if(time.Hour < 8 || time.Hour > 22)
            throw new System.ApplicationException("Method accessible only at 8-22");
    }
    public int NumberOfPlanesLeft {
        get { return airport.NumberOfPlanesLeft; }
    }
    public Plane AcquirePlane(){
        CheckAccess();
        return airport.AcquirePlane();
    }
    public void ReleasePlane(Plane p){
        CheckAccess();
        airport.ReleasePlane(p);
    }
}
