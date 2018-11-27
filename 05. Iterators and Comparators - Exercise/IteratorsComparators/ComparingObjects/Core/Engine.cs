namespace ComparingObjects.Core
{
    using ComparingObjects.Entities;
    using ComparingObjects.Entities.Contracts;
    using Contracts;
    using System;
    using System.Collections.Generic;

    public class Engine : IEngine
    {
        private List<IPerson> persons;

        public Engine()
        {
            this.persons = new List<IPerson>();
        }

        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input.Split();

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                IPerson newPerson = new Person(name, age, town);

                this.persons.Add(newPerson);

                input = Console.ReadLine();
            }

            int n = int.Parse(Console.ReadLine());

            IPerson currentPerson = this.persons[n - 1];

            int equalPersons = 0;
            foreach (var person in this.persons)
            {
                if (currentPerson.CompareTo(person) == 0)
                {
                    equalPersons++;
                }
            }

            if (equalPersons == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPersons} {this.persons.Count - equalPersons} {this.persons.Count}");
            }
        }
    }
}
