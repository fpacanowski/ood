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

