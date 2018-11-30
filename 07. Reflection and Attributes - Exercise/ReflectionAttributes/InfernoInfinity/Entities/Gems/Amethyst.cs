namespace InfernoInfinity.Entities.Gems
{
    using Enums;

    public class Amethyst : Gem
    {
        private const int defaultStrength = 2;
        private const int defaultAgility = 8;
        private const int defaultVitality = 4;

        public Amethyst(GemClarity clarity) : base(clarity, defaultStrength, defaultAgility, defaultVitality)
        {
        }
    }
}
