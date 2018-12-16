namespace TheTankGame.Entities.Vehicles.Factories.Contracts
{
    using TheTankGame.Entities.Vehicles.Contracts;

    public interface IVehicleFactory
    {
        IVehicle CreateVehicle(string vehicleType, string model, double weight, decimal price, int attack, int defense, int hitPoints);
    }
}