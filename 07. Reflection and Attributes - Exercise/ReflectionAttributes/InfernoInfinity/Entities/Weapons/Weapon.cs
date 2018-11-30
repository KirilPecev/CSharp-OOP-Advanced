namespace InfernoInfinity.Entities.Weapons
{
    using Contracts;
    using Gems.Contracts;
    using Enums;
    using System.Linq;

    public abstract class Weapon : IWeapon
    {
        private IGem[] gems;

        protected Weapon(WeaponRarity rarity, string name, int minDamage, int maxDamage, int numberOfSockets)
        {
            this.Rarity = rarity;
            this.Name = name;
            this.MinDamage = minDamage * (int)this.Rarity;
            this.MaxDamage = maxDamage * (int)this.Rarity;
            this.NumberOfSockets = numberOfSockets;
            this.gems = new IGem[numberOfSockets];
        }

        public string Name { get; private set; }

        public int MinDamage { get; private set; }

        public int MaxDamage { get; private set; }

        public int NumberOfSockets { get; private set; }

        public WeaponRarity Rarity { get; private set; }

        public int Strength => this.gems.Where(s => s != null).Sum(s => s.Strength);

        public int Agility => this.gems.Where(a => a != null).Sum(a => a.Agility);

        public int Vitality => this.gems.Where(v => v != null).Sum(v => v.Vitality);

        public void AddGem(IGem gem, int index)
        {
            if (index >= 0 && index < this.gems.Length)
            {
                this.gems[index] = gem;
            }
        }

        public void RemoveGem(int index)
        {
            if (index >= 0 && index < this.gems.Length)
            {
                this.gems[index] = null;
            }
        }

        public override string ToString()
        {
            int totalMinDmg = this.MinDamage + 2 * this.Strength + 1 * this.Agility;
            int totalMaxDmg = this.MaxDamage + 3 * this.Strength + 4 * this.Agility;

            return $"{this.Name}: {totalMinDmg}-{totalMaxDmg} Damage, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
        }
    }
}
