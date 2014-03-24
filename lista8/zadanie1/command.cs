using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Threading;

public abstract class Command {
    protected string source;
    protected string filename;
    public abstract void Execute();
}

public class RandomWriter {
    public void WriteToFile(string filename, int length) {
        byte[] data = new byte[length];
        Random rng = new Random();
        rng.NextBytes(data);
        File.WriteAllBytes(filename, data);
    }
}

public class HttpDownloadCommand : Command {
    public HttpDownloadCommand (string s, string f) {
        source = s; filename = f;
    }
    public override void Execute() {
        WebClient Client = new WebClient();
        Console.WriteLine("HTTP: Downloading file to {0}...", filename);
        Client.DownloadFile(source, filename);
        Console.WriteLine("HTTP download complete");
    }
}

public class FtpDownloadCommand : Command {
    public FtpDownloadCommand (string s, string f) {
        source = s; filename = f;
    }
    public override void Execute() {
        Console.WriteLine("FTP: Downloading file to {0}...", filename);
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(source);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential ("anonymous","janeDoe@contoso.com");

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
    
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
//            Console.WriteLine(reader.ReadToEnd());

            System.IO.StreamWriter file = new System.IO.StreamWriter(filename);
            file.Write(reader.ReadToEnd());
            file.Close();

            Console.WriteLine("FTP download Complete, status {0}", response.StatusDescription);
    
            reader.Close();
            response.Close();  
    }
}

public class RandomFileCommand : Command {
    public RandomFileCommand (string s, string f) {
        source = s; filename = f;
    }
    public override void Execute() {
        Console.WriteLine("Creating randomfile {0}", filename);
        var writer = new RandomWriter();
        writer.WriteToFile(filename, 1024);
    }
}

public class CopyFileCommand : Command {
    public CopyFileCommand (string s, string f) {
        source = s; filename = f;
    }
    public override void Execute() {
        Console.WriteLine("Copying {0} to {1}", source, filename);
        File.Copy(source, filename);
    }
}

public class CommandInvoker {
    List<Command> commands;
    Queue<Command> queue;
    public CommandInvoker(List<Command> cmds) {
        commands = cmds;
        queue = new Queue<Command>();
    }

    public void Start() {
        Thread t1 = new Thread(new ThreadStart(this.EnqueueCommands));
        Thread t2 = new Thread(new ThreadStart(this.Execute));
        Thread t3 = new Thread(new ThreadStart(this.Execute));
        t1.Start();
        Thread.Sleep(100);
        t2.Start();
        t3.Start();
        t1.Join();
        t2.Join();
        t3.Join();
    }

    public void EnqueueCommands() {
        foreach(var cmd in commands) {
            Console.WriteLine(cmd);
            queue.Enqueue(cmd);
        }
    }

    public void Execute() {
        while(queue.Count > 0) {
            Command cmd = queue.Dequeue();
            cmd.Execute();
        }
    }
}

public static class Client {
    public static void Main() {
        var commands = new List<Command>();
        commands.Add( new HttpDownloadCommand("http://www.google.pl/images/srpr/logo4w.png", "test/logo.png") );
        commands.Add( new FtpDownloadCommand("ftp://kernel.org/pub/README_ABOUT_BZ2_FILES", "test/test.txt") );
        commands.Add( new RandomFileCommand("", "test/random") );
        commands.Add( new CopyFileCommand("test.txt", "test/test_copy.txt") );
        var invoker = new CommandInvoker(commands);
        invoker.Start();
    }
}
