namespace Logger.Core
{
    using Contracts;
    using System;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandIterpreter;

        public Engine(ICommandInterpreter commandIterpreter)
        {
            this.commandIterpreter = commandIterpreter;
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();

                this.commandIterpreter.AddAppender(inputArgs);
            }

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputArgs = input.Split('|');

                this.commandIterpreter.AddMessage(inputArgs);

                input = Console.ReadLine();
            }

            this.commandIterpreter.PrintInfo();
        }
    }
}
