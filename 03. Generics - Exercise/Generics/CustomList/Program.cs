namespace CustomList
{
    using CustomList.Core;
    using CustomList.Core.Contracts;
    using CustomList.Entities;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            Engine engine = new Engine(commandInterpreter);
            engine.Run();           
        }
    }
}
