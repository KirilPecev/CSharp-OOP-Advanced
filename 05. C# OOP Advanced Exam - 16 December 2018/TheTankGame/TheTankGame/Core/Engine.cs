namespace TheTankGame.Core
{
    using Contracts;
    using IO.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader,
            IWriter writer,
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string input = this.reader.ReadLine();
            string result = string.Empty;

            while (true)
            {
                List<string> tokens = input.Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();

                try
                {
                    result = this.commandInterpreter.ProcessInput(tokens);
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }

                this.writer.WriteLine(result);

                if (input == "Terminate")
                {
                    break;
                }

                input = this.reader.ReadLine().Trim();
            }
        }
    }
}