using System.Text;
using System.IO;
using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class Memento
{
    Core app;
    [SetUp]
    public void CreateApp() {
        app = new Core();
    }
    [Test]
    public void AddingShape() {
        app.AddRectangle(20, 30);
        Assert.AreEqual(1, app.Shapes.Count);
    }
    [Test]
    public void RemovingShape() {
        app.AddRectangle(20, 30);
        app.AddSquare(20, 30);
        Assert.AreEqual(2, app.Shapes.Count);
        app.RemoveShapeAt(10,10);
        Assert.AreEqual(2, app.Shapes.Count);
        app.RemoveShapeAt(25,35);
        Assert.AreEqual(1, app.Shapes.Count);
        Assert.That(app.Shapes[0] is Rectangle);
    }
}
