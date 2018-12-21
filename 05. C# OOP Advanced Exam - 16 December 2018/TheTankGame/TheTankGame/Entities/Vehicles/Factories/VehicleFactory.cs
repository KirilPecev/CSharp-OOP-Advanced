namespace TheTankGame.Entities.Vehicles.Factories
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Vehicles.Contracts;

    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string vehicleType, string model, double weight, decimal price, int attack, int defense, int hitPoints)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == vehicleType);

            var instance = Activator.CreateInstance(type, new object[] { model, weight, price, attack, defense, hitPoints, new VehicleAssembler() });

            return (IVehicle)instance;
        }
    }
}
