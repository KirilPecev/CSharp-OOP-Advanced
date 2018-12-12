namespace Froggy
{
    using Froggy.Core;
    using Froggy.Core.Contracts;

    class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
