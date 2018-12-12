namespace StrategyPattern.Core
{
    using Contracts;
    using Entities.Comparators;
    using Entities.Persons;
    using Entities.Persons.Contracts;
    using System;
    using System.Collections.Generic;

    public class Engine : IEngine
    {
        public void Run()
        {
            var nameComparedSet = new SortedSet<IPerson>(new NameComparator());
            var ageComparedSet = new SortedSet<IPerson>(new AgeComparator());

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);

                IPerson person = new Person(name, age);
                nameComparedSet.Add(person);
                ageComparedSet.Add(person);
            }

            Print(nameComparedSet);
            Print(ageComparedSet);
        }

        private static void Print(SortedSet<IPerson> comparedSet)
        {
            foreach (var person in comparedSet)
            {
                Console.WriteLine(person);
            }
        }
    }
}
