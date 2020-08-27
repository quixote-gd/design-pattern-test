using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class BasicPersonFactory
    {
        internal class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public abstract class IPersonFactory
        {
            public abstract Person CreatePerson(string name);
        }

        internal class  PersonFactory : IPersonFactory   //not assecible outside this class
        {
            public List<Person> people = new List<Person>();

            public override Person CreatePerson(string name)
            {
                people.Add(new Person()
                {
                    Id = people.Count,
                    Name = name
                });

             return people.SingleOrDefault(p => p.Name == name && p.Id == people.Count-1);
            }
        }

        static void Main(string[] args)
        {
            var personFactory = new PersonFactory();
            var george = personFactory.CreatePerson("george");
            Console.WriteLine($"this is the person {george.Id}, {george.Name}");
         
            var gabe = personFactory.CreatePerson("Gabriel");
            Console.WriteLine($"this is the person {gabe.Id}, {gabe.Name}");


        }
    }
}
