using System.Text;
using System.IO;
using NUnit.Framework;

[TestFixture]
public class CaesarTest
{
    [Test]
    public void Caesar() {
        System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
        byte[] str = encoding.GetBytes("loremipsum");

        MemoryStream ms = new MemoryStream(); 
        CaesarStream cs = new CaesarStream(ms, 5);
        cs.Write(str, 0, 10);

        byte[] buf = new byte[10];
        ms.Seek(0, SeekOrigin.Begin);
        ms.Read(buf, 0, 10);
        ms.Seek(0, SeekOrigin.Begin);
        Assert.AreEqual("qtwjrnuxzr", encoding.GetString(buf));

        cs = new CaesarStream(ms, -5);
        cs.Read(buf, 0, 10);
        Assert.AreEqual("loremipsum", encoding.GetString(buf));
    }
}
