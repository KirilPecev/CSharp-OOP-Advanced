﻿namespace ListyIterator
{
    using Core;
    using Core.Contracts;

    class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
