//public enum ShapeType { Triangle, Rectangle, S}
using System;
using System.Collections.Generic;

public abstract class Shape {
    public int X, Y;
    public abstract bool ContainsPoint(int x, int y);
}

public class Rectangle : Shape {
    public int Height{ get{return 20;} }
    public int Width{ get{return 40;} }
    public Rectangle(int x, int y) {
        X = x; Y = y;
    }
    public override bool ContainsPoint(int x, int y) {
        return  (X <= x) && (x <= X+Width) && (Y <= y) && (y <= Y+Height);
    }
}

public class Square : Shape {
    public int Height{ get{return 20;} }
    public int Width{ get{return 20;} }
    public Square(int x, int y) {
        X = x; Y = y;
    }
    public override bool ContainsPoint(int x, int y) {
        return  (X <= x) && (x <= X+Width) && (Y <= y) && (y <= Y+Height);
    }
}

public class Core {
    public List<Shape> Shapes = new List<Shape>();
    public void AddSquare(int x, int y) {
        Shapes.Add( new Square(x, y) );
    }
    public void AddRectangle(int x, int y) {
        Shapes.Add( new Rectangle(x, y) );
    }
    public void RemoveShape(Shape s) {
        Shapes.Remove(s);
    }
    public void RemoveShapeAt(int x, int y) {
//        Predicate<Shape> = delegate(Shape s){return s.ContainsPoint(x,y);};
        Shapes.Remove( Shapes.FindLast( delegate(Shape s){return s.ContainsPoint(x,y);} ) );
    }
}
