namespace Logger
{
    using Core.Contracts;
    using Core;

    class StartUp
    {
        static void Main(string[] args)
        {
            ICommandInterpreter commandIterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandIterpreter);
            engine.Run();
        }
    }
}
