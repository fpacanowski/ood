using System;
using NUnit.Framework;
using System.Threading;

[TestFixture]
public class AirportTest
{
    AirportProxy airport;
    private DateTime ValidTime() {
        return new DateTime(2013, 04, 22, 9, 00, 00);
    }
    private DateTime InvalidTime() {
        return new DateTime(2013, 04, 22, 7, 00, 00);
    }
    [SetUp]
    public void CreateAirport(){
        airport = new AirportProxy(ValidTime);
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
    [Test]
    [ExpectedException]
    public void AccessAtInvalidTime() {
        airport = new AirportProxy(InvalidTime);
        airport.AcquirePlane();
    }
}
