namespace Stack.Core
{
    using Contracts;
    using Entities;
    using Entities.Contracts;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        ICustomStack<string> stack;

        public Engine()
        {
            this.stack = new CustomStack<string>();
        }

        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    Play(tokens);
                }
                catch (ArgumentException ax)
                {
                    Console.WriteLine(ax.Message);
                }

                input = Console.ReadLine();
            }

            Print();
            Print();
        }

        private void Print()
        {
            foreach (var item in this.stack)
            {
                Console.WriteLine(item);
            }
        }

        private void Play(string[] tokens)
        {
            string command = tokens[0];

            switch (command)
            {
                case "Push":
                    this.stack.Push(tokens.Skip(1).ToArray());
                    break;
                case "Pop":
                    this.stack.Pop();
                    break;
            }
        }
    }
}
