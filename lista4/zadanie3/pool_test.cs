using System;
using NUnit.Framework;
using System.Threading;

[TestFixture]
public class AirportTest
{
    AirportPool airport;
    [SetUp]
    public void CreateAirport(){
        airport = new AirportPool();
    }
    [Test]
    public void AcquireAndReleasePlane(){
        Assert.AreEqual(airport.NumberOfPlanesLeft, 3);
        Plane p = airport.AcquirePlane();
        Assert.AreEqual(airport.NumberOfPlanesLeft, 2);
        airport.ReleasePlane(p);
        Assert.AreEqual(airport.NumberOfPlanesLeft, 3);
    }
    [Test]
    [ExpectedException]
    public void EmptyAirport(){
        airport.AcquirePlane();
        airport.AcquirePlane();
        airport.AcquirePlane();
        airport.AcquirePlane();
    }
}
