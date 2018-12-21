namespace TheTankGame.Core
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IBattleOperator battle;

        private readonly Type type;
        private readonly Object instance;

        public CommandInterpreter(IBattleOperator battle)
        {
            this.battle = battle;

            var assembly = Assembly.GetCallingAssembly();
            this.type = assembly.GetTypes().FirstOrDefault(t => t.Name == "TankManager");
            this.instance = Activator.CreateInstance(type, new object[] { this.battle });
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];
            inputParameters.RemoveAt(0);

            string result = string.Empty;

            var method = type.GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(m => m.Name.EndsWith(command));

            result = (string)method.Invoke(instance, new object[] { inputParameters });

            return result;
        }
    }
}