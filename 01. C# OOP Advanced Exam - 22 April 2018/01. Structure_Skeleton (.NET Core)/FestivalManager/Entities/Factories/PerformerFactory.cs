namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class PerformerFactory : IPerformerFactory
    {
        private const string DefaultType = "Performer";

        public IPerformer CreatePerformer(string name, int age)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type currentType = assembly.GetTypes().FirstOrDefault(t => t.Name == DefaultType);
            return (IPerformer)Activator.CreateInstance(currentType, new object[] { name, age });
        }
    }
}