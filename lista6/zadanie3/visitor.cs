using System.IO;
using System.Collections.Generic;

public interface TreeVisitor {
    int VisitNode(Node node);
    int VisitLeaf(Leaf leaf);
}

public abstract class BinaryTree {
    public abstract int Accept(TreeVisitor visitor);
}

public class Leaf : BinaryTree {
    public override int Accept(TreeVisitor visitor) {
        return visitor.VisitLeaf( this );
    }
}

public class Node : BinaryTree {
    public BinaryTree Left, Right;
    public Node(BinaryTree left, BinaryTree right) {
        Left = left; Right = right;
    }
    public override int Accept(TreeVisitor visitor) {
        return visitor.VisitNode( this );
    }
}

public class DepthVisitor : TreeVisitor {
    public int VisitNode(Node node) {
        int leftDepth = node.Left.Accept( this );
        int rightDepth = node.Right.Accept( this );
        return Max(leftDepth, rightDepth) + 1;
    }
    public int VisitLeaf(Leaf leaf) {
        return 0;
    }
    int Max(int a, int b) {
        return b > a ? b : a;
    }
}
