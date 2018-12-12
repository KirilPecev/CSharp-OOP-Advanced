namespace EqualityLogic.Core
{
    using Contracts;
    using Entities.Persons;
    using Entities.Persons.Contracts;
    using System;
    using System.Collections.Generic;

    public class Engine : IEngine
    {
        private readonly SortedSet<IPerson> personsSortedSet;
        private readonly HashSet<IPerson> personsHashSet;

        public Engine()
        {
            this.personsSortedSet = new SortedSet<IPerson>();
            this.personsHashSet = new HashSet<IPerson>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);

                IPerson person = new Person(name, age);

                this.personsSortedSet.Add(person);
                this.personsHashSet.Add(person);
            }

            PrintLength(this.personsSortedSet);
            PrintLength(this.personsHashSet);
        }

        private void PrintLength(ICollection<IPerson> set)
        {
            Console.WriteLine(set.Count);
        }
    }
}
