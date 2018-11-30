namespace InfernoInfinity.Entities.Gems.Factories
{
    using Contracts;
    using Enums;
    using System;

    public class GemFactory
    {
        public IGem CreateGem(string clarity, string type)
        {
            Type currentGem = Type.GetType("InfernoInfinity.Entities.Gems." + type);

            GemClarity currentClarity;

            if (!Enum.TryParse<GemClarity>(clarity, out currentClarity))
            {
                throw new ArgumentException("Invalid rarity type!");
            }

            IGem instance = (IGem)Activator.CreateInstance(currentGem, new object[] { currentClarity });

            return instance;
        }
    }
}
