using System;
using NUnit.Framework;
using System.Threading;

[TestFixture]
public class FactoryTest
{
    GenericFactory factory;
    [SetUp]
    public void CreateFactory() {
        factory = new GenericFactory();
    }
    [Test]
    public void BuildingObject() {
        var obj = (System.Collections.ArrayList) factory.CreateObject( "System.Collections.ArrayList", false );
        obj.Add(7);
        var obj2 = (System.Collections.ArrayList) factory.CreateObject( "System.Collections.ArrayList", false );
        Assert.AreEqual(obj2.Count, 0);
    }
    [Test]
    public void BuildingSingletonObject() {
        var obj = (System.Collections.ArrayList) factory.CreateObject( "System.Collections.ArrayList", true );
        obj.Add(7);
        var obj2 = (System.Collections.ArrayList) factory.CreateObject( "System.Collections.ArrayList", true );
        Assert.AreEqual(obj2.Count, 1);
    }
    [Test]
    public void BuildingObjectWithParams() {
        var str = (String) factory.CreateObject( "System.String", false,  new char[] { 'u', 'w', 'r' } );
        Assert.AreEqual(str, "uwr");
    }
}
