using System;
using System.Collections.Generic;

public class Person{}

namespace VersionA {
    public interface IPersonList {
        List<Person> GetPersons();
    }

    public class InMemoryPersonList : IPersonList {
        public List<Person> GetPersons(){
            return new List<Person>() {new Person(), new Person(), new Person()};
        }
    }

    public abstract class AbstractPersonRegistry {
        protected IPersonList _personList;
        public abstract void NotifyPersons();
    }

    public class PersonRegistry : AbstractPersonRegistry {
        public PersonRegistry( IPersonList PersonList) {
            _personList = PersonList;
        }
        public override void NotifyPersons() {
            foreach ( Person person in _personList.GetPersons() )
                Console.WriteLine( person );
        }
    }
}

namespace VersionB {
    public interface INotifier {
         void NotifyPersons(List<Person> personList);
    }

    public class ConsoleNotifier : INotifier {
        public void NotifyPersons(List<Person> personList){
            foreach ( Person person in personList )
                Console.WriteLine( person );
        }
    }

    public abstract class AbstractPersonRegistry {
        protected INotifier _notifier;
        public void NotifyPersons() {
            _notifier.NotifyPersons(GetPersonList());
        }
        public abstract List<Person> GetPersonList();
    }

    public class PersonRegistry : AbstractPersonRegistry {
        public PersonRegistry( INotifier Notifier) {
            _notifier = Notifier;
        }
        public override List<Person> GetPersonList() {
            return new List<Person>() {new Person(), new Person(), new Person()};
        }
    }
}
public class Client {
   public static void Main(){
        var pr1 = new VersionA.PersonRegistry(new VersionA.InMemoryPersonList());
        pr1.NotifyPersons();
        var pr2 = new VersionB.PersonRegistry(new VersionB.ConsoleNotifier());
        pr2.NotifyPersons();
   }
}
