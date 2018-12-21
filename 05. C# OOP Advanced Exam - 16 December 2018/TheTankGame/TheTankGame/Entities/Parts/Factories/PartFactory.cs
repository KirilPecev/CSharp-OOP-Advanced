namespace TheTankGame.Entities.Parts.Factories
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;
    using TheTankGame.Entities.Parts.Contracts;

    public class PartFactory : IPartFactory
    {
        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == partType+"Part");

            var instance = Activator.CreateInstance(type, new object[] { model, weight, price, additionalParameter });

            return (IPart)instance;
        }
    }
}
