using System.Text;
using System.IO;
using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class Chain
{
    [Test]
    public void ProcessMail() {
        var mailBox = new MailBox();
        var h1 = new ArchiverHandler(mailBox);
        var h2 = new RecommendationHandler(mailBox);
        var h3 = new ComplaintHandler(mailBox);
        var h4 = new OrderHandler(mailBox);
        var h5 = new RestHandler(mailBox);
        var h6 = new NullHandler();
        h1.next = h2; h2.next = h3; h3.next = h4;
        h4.next = h5; h5.next = h6;

        var mails = new List<Mail>{
            new Mail("R foo"),
            new Mail("C foo"),
            new Mail("C foo"),
            new Mail("O foo"),
            new Mail("O foo"),
            new Mail("O foo"),
            new Mail("foobar")
        };

        foreach( var m in mails ) {
            h1.ProcessMail( m );
        }

        Assert.AreEqual(7, mailBox.Archive.Count);
        Assert.AreEqual(1, mailBox.President.Count);
        Assert.AreEqual(2, mailBox.LawDept.Count);
        Assert.AreEqual(3, mailBox.SalesDept.Count);
        Assert.AreEqual(1, mailBox.MarketingDept.Count);
    }
}
