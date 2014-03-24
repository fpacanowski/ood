using System.Text;
using System.IO;
using NUnit.Framework;

[TestFixture]
public class VisitorTest
{
    [Test]
    public void Depth() {
        var visitor = new DepthVisitor();
        var root = new Node(
                       new Node(
                           new Node(
                               new Leaf(),
                               new Leaf()
                            ),
                            new Leaf()),
                       new Node(
                           new Leaf(),
                           new Leaf()
                           )
                      );
        int depth = root.Accept(visitor);
        Assert.AreEqual(3, depth);
    }
}
