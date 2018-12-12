namespace InfernoInfinity.Entities.Weapons
{
    using Enums;

    public class Knife : Weapon
    {
        private const int defautMinDamage = 3;
        private const int defautMaxDamage = 4;
        private const int defautSockets = 2;

        public Knife(WeaponRarity rarity, string name) : base(rarity, name, defautMinDamage, defautMaxDamage, defautSockets)
        {
        }
    }
}
