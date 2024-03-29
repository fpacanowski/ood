using System;
using System.IO;
using System.Xml;
using System.Data;
using Mono.Data.Sqlite;

public abstract class DataAccessHandler {
    public void Execute() {
        Connect();
        GetData();
        ProcessData();
        Disconnect();
    }
    public abstract void Connect();
    public abstract void GetData();
    public abstract void ProcessData();
    public abstract void Disconnect();
}

public class XmlHandler : DataAccessHandler {
    public string Result = "";
    FileStream file;
    XmlReader reader;
    public override void Connect() {
        file = File.Open("test.xml", FileMode.Open);
    }
    public override void GetData() {
        reader = XmlReader.Create(file);
    }
    public override void ProcessData() {
        while (reader.Read()) {
            string name = reader.Name;
            if(name.Length > Result.Length)
                Result = name;
        }
    }
    public override void Disconnect() {
        file.Close();
    }
}

public class SqlHandler : DataAccessHandler {
    public int Result = 0;
    IDataReader reader;
    IDbConnection dbcon;
    IDbCommand dbcmd;
    public override void Connect() {
        dbcon = (IDbConnection) new SqliteConnection("URI=file:test.db");
        dbcon.Open();
    }
    public override void GetData() {
        dbcmd = dbcon.CreateCommand();
        dbcmd.CommandText = "SELECT area FROM countries";
        reader = dbcmd.ExecuteReader();
    }
    public override void ProcessData() {
        while (reader.Read()) {
            var data = reader.GetInt32 (0);
            Result += data;
        }
    }
    public override void Disconnect() {
        reader.Close();
        dbcmd.Dispose();
        dbcon.Close();
    }
}
public static class Client {
    public static void Main() {
        var xml = new XmlHandler();
        xml.Execute();
        Console.WriteLine("Longest name in XML file: {0}", xml.Result);
        var db = new SqlHandler();
        db.Execute();
        Console.WriteLine("Sum of values in area column: {0}", db.Result);
    }
}
