namespace CustomList.Core
{
    using CustomList.Core.Contracts;
    using System;

    public class Engine
    {
        private readonly ICommandInterpreter command;

        public Engine(ICommandInterpreter commandInterpretator)
        {
            this.command = commandInterpretator;
        }

        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input.Split();

                Play(tokens);

                input = Console.ReadLine();
            }
        }

        private void Play(string[] tokens)
        {
            switch (tokens[0])
            {
                case "Add":
                    this.command.Add(tokens[1]);
                    break;
                case "Remove":
                    this.command.Remove(int.Parse(tokens[1]));
                    break;
                case "Contains":
                    Console.WriteLine(this.command.Contains(tokens[1]));
                    break;
                case "Swap":
                    this.command.Swap(int.Parse(tokens[1]), int.Parse(tokens[2]));
                    break;
                case "Greater":
                    Console.WriteLine(this.command.Greater(tokens[1]));
                    break;
                case "Max":
                    Console.WriteLine(this.command.Max());
                    break;
                case "Min":
                    Console.WriteLine(this.command.Min());
                    break;
                case "Print":
                    this.command.Print();
                    break;
                case "Sort":
                    this.command.Sort();
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
