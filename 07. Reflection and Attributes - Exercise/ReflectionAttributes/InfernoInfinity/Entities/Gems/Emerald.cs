namespace InfernoInfinity.Entities.Gems
{
    using Enums;

    public class Emerald : Gem
    {
        private const int defaultStrength = 1;
        private const int defaultAgility = 4;
        private const int defaultVitality = 9;

        public Emerald(GemClarity clarity) : base(clarity, defaultStrength, defaultAgility, defaultVitality)
        {
        }
    }
}
