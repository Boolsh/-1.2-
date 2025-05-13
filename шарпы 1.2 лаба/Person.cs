using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSolution
{
    public class Person : IComparable<Person>
    {
        public string Name { get; private set; }
        public byte Age { get; private set; }

        public Person() { }
        public Person(string name, byte age) { Name = name; Age = age; }
        public Person(string info)
        {
            string[] arrInfo = info.Split(' ');
            Name = arrInfo[0];
            Age = byte.Parse(arrInfo[1]);
        }

        public override string ToString() => Name + " : " + Age.ToString();

        public int CompareTo(Person other)
        {
            if (other == null) return 1;

            int nameComparison = string.Compare(Name, other.Name,
                                                 StringComparison.OrdinalIgnoreCase);
            if (nameComparison != 0)
                return nameComparison;

            return Age.CompareTo(other.Age);
        }

        public static Person operator ++(Person person)
        {
            return new Person(person.Name, person.Age++);
        }
    }
}
