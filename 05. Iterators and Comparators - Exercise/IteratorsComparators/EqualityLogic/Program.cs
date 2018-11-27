namespace EqualityLogic
{
    using EqualityLogic.Core;
    using EqualityLogic.Core.Contracts;

    class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
