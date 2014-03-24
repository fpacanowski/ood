using System.Collections;
using System;
using System.Linq.Expressions;

class Program {
    static void Main( string[] args ) {
        Expression<Func<int, int>> exprTree = num => num * 5;
    }
}
