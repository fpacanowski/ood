using System;
using System.Threading;
using System.Collections.Generic;

public class GenericFactory {
    private Dictionary<Type, object> Singletons = new Dictionary<Type, object>();
    public object CreateObject( string TypeName, bool IsSingleton, params object[] Parameters ) {
        Type t = Type.GetType(TypeName);

        if( !IsSingleton) {
            return Activator.CreateInstance(t, Parameters);
        } else {
            if(!Singletons.ContainsKey(t)) {
                Singletons[t] = Activator.CreateInstance(t, Parameters);
            }
            return Singletons[t];
        }
    }
}
