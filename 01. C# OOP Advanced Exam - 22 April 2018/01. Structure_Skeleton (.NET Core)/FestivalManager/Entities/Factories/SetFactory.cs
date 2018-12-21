namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class SetFactory : ISetFactory
    {
        public ISet CreateSet(string name, string type)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type currentType = assembly.GetTypes().FirstOrDefault(t => t.Name == type);
            return (ISet)Activator.CreateInstance(currentType, new object[] { name });
        }
    }
}
