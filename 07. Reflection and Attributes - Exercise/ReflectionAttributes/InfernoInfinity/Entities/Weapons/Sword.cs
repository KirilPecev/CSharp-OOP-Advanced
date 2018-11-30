namespace InfernoInfinity.Entities.Weapons
{
    using Enums;

    public class Sword : Weapon
    {
        private const int defautMinDamage = 4;
        private const int defautMaxDamage = 6;
        private const int defautSockets = 3;

        public Sword(WeaponRarity rarity, string name) : base(rarity, name, defautMinDamage, defautMaxDamage, defautSockets)
        {
        }
    }
}
