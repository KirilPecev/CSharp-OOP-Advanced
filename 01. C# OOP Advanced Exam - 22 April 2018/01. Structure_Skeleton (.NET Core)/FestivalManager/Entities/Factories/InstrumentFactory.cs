namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class InstrumentFactory : IInstrumentFactory
    {
        public IInstrument CreateInstrument(string type)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type currentType = assembly.GetTypes().FirstOrDefault(t => t.Name == type);
            return (IInstrument)Activator.CreateInstance(currentType);
        }
    }
}