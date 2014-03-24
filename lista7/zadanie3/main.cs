using System;
using Gtk;
using Pango;

using Gtk;
using Cairo;
using System;
 
public class SharpApp : Window {
    public SharpApp() : base("Basic shapes")
    {
        SetDefaultSize(390, 240);
        SetPosition(WindowPosition.Center);
        DeleteEvent += delegate { Application.Quit(); };
        
        DrawingArea darea = new DrawingArea();
        darea.ExposeEvent += OnExpose;

        Add(darea);
        ShowAll();
    }

    void OnExpose(object sender, ExposeEventArgs args)
    {
        DrawingArea area = (DrawingArea) sender;
        Cairo.Context cc =  Gdk.CairoHelper.Create(area.GdkWindow);
                
        cc.SetSourceRGB(0.2, 0.23, 0.9);
        cc.LineWidth = 1;

        cc.Rectangle(20, 20, 120, 80);
        cc.Rectangle(180, 20, 80, 80);
        cc.StrokePreserve();
        cc.SetSourceRGB(1, 1, 1);
        cc.Fill();

        cc.SetSourceRGB(0.2, 0.23, 0.9);
        cc.Arc(330, 60, 40, 0, 2*Math.PI);
        cc.StrokePreserve();
        cc.SetSourceRGB(1, 1, 1);
        cc.Fill();

        cc.SetSourceRGB(0.2, 0.23, 0.9);
        cc.Arc(90, 160, 40, Math.PI/4, Math.PI);
        cc.ClosePath();
        cc.StrokePreserve();
        cc.SetSourceRGB(1, 1, 1);
        cc.Fill();

        cc.SetSourceRGB(0.2, 0.23, 0.9);
        cc.Translate(220, 180);
        cc.Scale(1, 0.7);        
        cc.Arc(0, 0, 50, 0, 2*Math.PI);
        cc.StrokePreserve();
        cc.SetSourceRGB(1, 1, 1);
        cc.Fill();          

        ((IDisposable) cc.Target).Dispose ();                                      
        ((IDisposable) cc).Dispose ();
    }

}
/*
class LayoutSample : DrawingArea
{
        Pango.Layout layout;
 
 
        LayoutSample ()
        {
                Window win = new Window ("Layout sample");
                win.SetDefaultSize (400, 300);
                win.DeleteEvent += OnWinDelete;
                this.Realized += OnRealized;
                this.ExposeEvent += OnExposed;
 
                win.Add (this);
                win.ShowAll ();
        }
 
        void OnExposed (object o, ExposeEventArgs args)
        {
                this.GdkWindow.DrawLayout (this.Style.TextGC (StateType.Normal), 100, 150, layout);
        }
 
        void OnRealized (object o, EventArgs args)
        {
                layout = new Pango.Layout (this.PangoContext);
                layout.Wrap = Pango.WrapMode.Word;
                layout.FontDescription = FontDescription.FromString ("Tahoma 16");
                layout.SetMarkup ("Hello Pango.Layout");
        }
 
        void OnWinDelete (object o, DeleteEventArgs args)
        {
                Application.Quit ();
        }
}
*/

public class Gui {
    public void Run() {
        Application.Init();
        new SharpApp(); 
        Application.Run();   
    }
}

public class GtkHelloWorld {
    public static void Main() {
        var g = new Gui();
        g.Run();
    }
}
