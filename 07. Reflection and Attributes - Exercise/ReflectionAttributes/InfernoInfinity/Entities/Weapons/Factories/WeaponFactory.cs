namespace InfernoInfinity.Entities.Weapons.Factories
{
    using Contracts;
    using InfernoInfinity.Entities.Enums;
    using System;

    public class WeaponFactory
    {
        public IWeapon CreateWeapon(string rarity, string type, string name)
        {
            Type currentWeapon = Type.GetType("InfernoInfinity.Entities.Weapons." + type);

            WeaponRarity weaponRarity;

            if(!Enum.TryParse<WeaponRarity>(rarity, out weaponRarity))
            {
                throw new ArgumentException("Invalid rarity type!");
            }

            IWeapon instance = (IWeapon)Activator.CreateInstance(currentWeapon, new object[] { weaponRarity, name});

            return instance;
        }
    }
}
