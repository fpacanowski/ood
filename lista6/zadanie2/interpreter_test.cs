using System.Text;
using System.IO;
using NUnit.Framework;

[TestFixture]
public class ContextTest
{
    [Test]
    public void SettingVariable() {
        Context ctx = new Context();
        ctx.SetValue( "x", false );
        ctx.SetValue( "y", true );
        Assert.IsFalse( ctx.GetValue("x") );
        Assert.IsTrue( ctx.GetValue("y") );
    }
    [Test]
    [ExpectedException]
    public void NotAssignedVariable() {
        Context ctx = new Context();
        ctx.GetValue("z");
    }
}

[TestFixture]
public class InterpreterTest
{
    Context ctx;
    AbstractExpression v1, v2;
    [SetUp]
    public void CreateContext(){
        ctx = new Context();
        ctx.SetValue( "x", false );
        ctx.SetValue( "y", true );
        v1 = new Variable("x");
        v2 = new Variable("y");
    }
    [Test]
    public void Constant() {
        var trueConst = new Constant(true);
        var falseConst = new Constant(false);
        Assert.IsTrue(trueConst.Interpret(ctx));
        Assert.IsFalse(falseConst.Interpret(ctx));
    }
    [Test]
    public void BoundVariable() {
        Assert.IsTrue(v2.Interpret(ctx));
        Assert.IsFalse(v1.Interpret(ctx));
    }
    [Test]
    [ExpectedException]
    public void UnboundVariable() {
        var v = new Variable("foo");
        v.Interpret(ctx);
    }
    [Test]
    public void Negation() {
        var exp1 = new Negation(v1);
        var exp2 = new Negation(v2);
        Assert.IsTrue( exp1.Interpret(ctx) );
        Assert.IsFalse( exp2.Interpret(ctx) );
    }
    [Test]
    public void Conjunction() {
        var exp = new Conjunction(v1, v2);
        Assert.IsFalse( exp.Interpret(ctx) );
    }
    [Test]
    public void Disjunction() {
        var exp = new Disjunction(v1, v2);
        Assert.IsTrue( exp.Interpret(ctx) );
    }
    [Test]
    [ExpectedException]
    public void ExpressionWithUnboundVariable() {
        var exp = new Disjunction(v1, new Variable("z"));
        exp.Interpret( ctx );
    }
}
