namespace TheTankGame.Entities.Vehicles
{
    using Miscellaneous.Contracts;

    public class Vanguard : BaseVehicle
    {
        public Vanguard(string model, double weight, decimal price, int attack, int defense, int hitPoints, IAssembler assembler)
            : base(model, weight, price, attack, defense, hitPoints, assembler)
        {
        }
    }
}
