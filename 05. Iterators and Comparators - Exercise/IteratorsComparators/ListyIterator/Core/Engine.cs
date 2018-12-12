namespace ListyIterator.Core
{
    using Core.Contracts;
    using Entities.Contracts;
    using Entities;
    using System;
    using System.Linq;
    using System.Text;

    public class Engine : IEngine
    {
        IListyIterator<string> listyIterator;

        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input.Split();

                try
                {
                    Play(tokens);
                }
                catch (InvalidOperationException ix)
                {
                    Console.WriteLine(ix.Message);
                }

                input = Console.ReadLine();
            }
        }

        private void Play(string[] tokens)
        {
            string command = tokens[0];
            string output = string.Empty;
            var sb = new StringBuilder();

            switch (command)
            {
                case "Create":
                    this.listyIterator = new ListyIterator<string>(tokens.Skip(1).ToArray());
                    break;
                case "Move":
                    Console.WriteLine(this.listyIterator.Move().ToString());
                    break;
                case "Print":
                    this.listyIterator.Print();
                    break;
                case "HasNext":
                    Console.WriteLine(this.listyIterator.HasNext().ToString());
                    break;
                case "PrintAll":
                    foreach (var item in this.listyIterator)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                    break;
            }
        }
    }
}
