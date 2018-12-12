namespace InfernoInfinity.Entities.Gems
{
    using Contracts;
    using Enums;

    public abstract class Gem : IGem
    {
        protected Gem(GemClarity clarity, int strength, int agility, int vitality)
        {
            this.Clarity = clarity;
            this.Strength = strength + (int)this.Clarity;
            this.Agility = agility + (int)this.Clarity;
            this.Vitality = vitality + (int)this.Clarity;
        }
         
        public int Strength { get; private set; }

        public int Agility { get; private set; }

        public int Vitality { get; private set; }

        public GemClarity Clarity { get; private set; }
    }
}
