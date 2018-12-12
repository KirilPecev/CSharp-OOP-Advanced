namespace InfernoInfinity.Entities.Gems.Contracts
{
    using Enums;

    public interface IGem
    {
        int Strength { get; }

        int Agility { get; }

        int Vitality { get; }

        GemClarity Clarity { get; }
    }
}
