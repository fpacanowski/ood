using System.IO;
using System.Collections.Generic;

public class Context {
    Dictionary<string, bool> variables;
    public Context() {
        variables = new Dictionary<string, bool>();
    }
    public bool GetValue( string VariableName ) {
        return variables[VariableName];
    }
    public bool SetValue( string VariableName, bool Value ) {
        variables[VariableName] = Value;
        return Value;
    }
}

public abstract class AbstractExpression {
    public abstract bool Interpret( Context context );
}

public abstract class BinaryExpression : AbstractExpression {
    protected AbstractExpression Arg1, Arg2;
    public BinaryExpression(AbstractExpression arg1, AbstractExpression arg2) {
        Arg1 = arg1; Arg2 = arg2;
    }
}

public class Constant : AbstractExpression {
    bool Value;
    public Constant( bool val ) {
        Value = val;
    }
    public override bool Interpret( Context context ) {
        return Value;
    }
}

public class Variable : AbstractExpression {
    string Name;
    public Variable( string name ) {
        Name = name;
    }
    public override bool Interpret( Context context ) {
        return context.GetValue( Name );
    }
}

public class Negation : AbstractExpression {
    AbstractExpression Arg;
    public Negation(AbstractExpression arg) {
        Arg = arg;
    }
    public override bool Interpret( Context context ) {
        return !Arg.Interpret( context );
    }
}

public class Conjunction : BinaryExpression {
    public Conjunction(AbstractExpression arg1, AbstractExpression arg2) : base(arg1,arg2) {}
    public override bool Interpret( Context context ) {
        return Arg1.Interpret(context) && Arg2.Interpret(context);
    }
}

public class Disjunction : BinaryExpression {
    public Disjunction(AbstractExpression arg1, AbstractExpression arg2) : base(arg1,arg2) {}
    public override bool Interpret( Context context ) {
        return Arg1.Interpret(context) || Arg2.Interpret(context);
    }
}
