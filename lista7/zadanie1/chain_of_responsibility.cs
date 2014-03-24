using System;
using System.Collections.Generic;

public abstract class Handler {
    public Handler next;
    public MailBox mailBox;
    public abstract void ProcessMail(Mail mail);
}

public class Mail {
    public string Content;
    public Mail(string c){
        Content = c;
    }
}

public class ArchiverHandler : Handler {
    public ArchiverHandler(MailBox mb) {
        mailBox = mb;
    }
    public override void ProcessMail(Mail mail) {
        mailBox.Archive.Add(mail);
        next.ProcessMail(mail);
    }
}

public class RecommendationHandler : Handler {
    public RecommendationHandler(MailBox mb) {
        mailBox = mb;
    }
    public override void ProcessMail(Mail mail) {
        if(mail.Content[0] == 'R')
            mailBox.President.Add(mail);
        else
            next.ProcessMail(mail);
    }
}

public class ComplaintHandler : Handler {
    public ComplaintHandler(MailBox mb) {
        mailBox = mb;
    }
    public override void ProcessMail(Mail mail) {
        if(mail.Content[0] == 'C')
            mailBox.LawDept.Add(mail);
        else
            next.ProcessMail(mail);
    }
}

public class OrderHandler : Handler {
    public OrderHandler(MailBox mb) {
        mailBox = mb;
    }
    public override void ProcessMail(Mail mail) {
        if(mail.Content[0] == 'O')
            mailBox.SalesDept.Add(mail);
        else
            next.ProcessMail(mail);
    }
}

public class RestHandler : Handler {
    public RestHandler(MailBox mb) {
        mailBox = mb;
    }
    public override void ProcessMail(Mail mail) {
        mailBox.MarketingDept.Add(mail);
        next.ProcessMail(mail);
    }
}

public class NullHandler : Handler {
    public override void ProcessMail(Mail mail) {}
}

public class MailBox {
    public List<Mail> Archive = new List<Mail>();
    public List<Mail> LawDept = new List<Mail>();
    public List<Mail> President = new List<Mail>();
    public List<Mail> MarketingDept = new List<Mail>();
    public List<Mail> SalesDept = new List<Mail>();
}
