namespace InfernoInfinity.Entities.Gems
{
    using Enums;

    public class Ruby : Gem
    {
        private const int defaultStrength = 7;
        private const int defaultAgility = 2;
        private const int defaultVitality = 5;

        public Ruby(GemClarity clarity) : base(clarity, defaultStrength, defaultAgility, defaultVitality)
        {
        }
    }
}
