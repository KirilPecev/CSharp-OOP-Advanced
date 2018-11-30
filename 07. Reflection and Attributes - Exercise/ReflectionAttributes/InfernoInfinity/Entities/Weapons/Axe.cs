namespace InfernoInfinity.Entities.Weapons
{
    using Enums;

    public class Axe : Weapon
    {
        private const int defautMinDamage = 5;
        private const int defautMaxDamage = 10;
        private const int defautSockets = 4;

        public Axe(WeaponRarity rarity, string name) : base(rarity, name, defautMinDamage, defautMaxDamage, defautSockets)
        {
        }
    }
}
