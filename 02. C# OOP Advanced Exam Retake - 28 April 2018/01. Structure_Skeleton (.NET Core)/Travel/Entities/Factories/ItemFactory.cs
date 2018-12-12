namespace Travel.Entities.Factories
{
    using Contracts;
    using Items;
    using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
            Assembly assembly = Assembly.GetCallingAssembly();

            Type currentType = assembly.GetTypes().FirstOrDefault(t => t.Name == type);

            var instance = Activator.CreateInstance(currentType);

            return (IItem)instance;
		}
	}
}
