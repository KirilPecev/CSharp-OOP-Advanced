namespace FestivalManager.Core
{
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IFestivalController festivalCоntroller;
        private readonly ISetController setCоntroller;

        public Engine(IFestivalController festivalCоntroller, ISetController setCоntroller, IReader reader, IWriter writer)
        {
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            var input = reader.ReadLine();

            string result = string.Empty;
            while (input != "END")
            {
                try
                {
                    result = this.ProcessCommand(input);
                }
                catch (Exception ix)
                {
                    result = "ERROR: " + ix.InnerException.Message;
                }

                this.writer.WriteLine(result);

                input = reader.ReadLine();
            }

            var endResult = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(endResult);
        }

        public string ProcessCommand(string input)
        {
            var inputArguments = input.Split(" ".ToCharArray().First());

            var command = inputArguments.First();
            var parameters = inputArguments.Skip(1).ToArray();

            if (command == "LetsRock")
            {
                var sets = this.setCоntroller.PerformSets();
                return sets;
            }

            var festivalControlFunction = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == command);

            string result;

            try
            {
                result = (string)festivalControlFunction.Invoke(this.festivalCоntroller, new object[] { parameters });
            }
            catch (TargetInvocationException ip)
            {
                throw ip;
            }

            return result;
        }
    }
}