namespace LinkedListTraversal.Core
{
    using Contracts;
    using Entities;
    using Entities.Contracts;
    using System;

    public class Engine : IEngine
    {
        public void Run()
        {
            IMyLinkedList<int> list = new MyLinkedList<int>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var tokens = Console.ReadLine().Split();

                string command = tokens[0];
                int number = int.Parse(tokens[1]);

                switch (command)
                {
                    case "Add":
                        list.Add(number);
                        break;
                    case "Remove":
                        list.Remove(number);
                        break;
                }
            }

            Console.WriteLine(list.Count);

            foreach (int number in list)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}
