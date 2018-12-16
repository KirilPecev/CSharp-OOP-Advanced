namespace TheTankGame.Entities.Parts.Factories.Contracts
{
    using TheTankGame.Entities.Parts.Contracts;

    public interface IPartFactory
    {
        IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter);
    }
}