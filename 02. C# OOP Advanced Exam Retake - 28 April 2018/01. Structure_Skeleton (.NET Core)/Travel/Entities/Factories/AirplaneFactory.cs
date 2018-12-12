namespace Travel.Entities.Factories
{
    using Airplanes.Contracts;
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class AirplaneFactory : IAirplaneFactory
    {
        public IAirplane CreateAirplane(string type)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            Type currentType = assembly.GetTypes().FirstOrDefault(t => t.Name == type);

            var instance = Activator.CreateInstance(currentType);

            return (IAirplane)instance;    
        }
    }
}