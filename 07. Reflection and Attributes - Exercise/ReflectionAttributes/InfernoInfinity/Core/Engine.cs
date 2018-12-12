namespace InfernoInfinity.Core
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        private Type type;
        private Object instance;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;

            this.type = Type.GetType("InfernoInfinity.Core.CommandInterpreter");
            this.instance = Activator.CreateInstance(type);
        }

        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputArgs = input.Split(";");

                Play(inputArgs);

                input = Console.ReadLine();
            }
        }

        private void Play(string[] inputArgs)
        {
            string command = inputArgs[0];

            MethodInfo[] methods = this.type.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            MethodInfo method = methods.FirstOrDefault(m => m.Name == command);

            method.Invoke(this.instance, new object[] { inputArgs.Skip(1).ToArray() });
        }
    }
}
