namespace InfernoInfinity.Entities.Weapons.Contracts
{
    using Enums;
    using InfernoInfinity.Entities.Gems.Contracts;

    public interface IWeapon
    {
        string Name { get; }

        int MinDamage { get; }

        int MaxDamage { get; }

        int NumberOfSockets { get; }

        WeaponRarity Rarity { get; }

        void AddGem(IGem gem, int index);

        void RemoveGem(int index);
    }
}
