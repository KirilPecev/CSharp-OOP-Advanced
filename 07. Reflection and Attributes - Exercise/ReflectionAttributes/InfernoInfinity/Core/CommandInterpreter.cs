namespace InfernoInfinity.Core
{
    using Contracts;
    using Entities.Weapons.Contracts;
    using Entities.Weapons.Factories;
    using Entities.Gems.Contracts;
    using Entities.Gems.Factories;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class CommandInterpreter : ICommandInterpreter
    {
        private List<IWeapon> weapons;
        private WeaponFactory weaponFactory;
        private GemFactory gemFactory;

        public CommandInterpreter()
        {
            this.weapons = new List<IWeapon>();
            this.weaponFactory = new WeaponFactory();
            this.gemFactory = new GemFactory();
        }

        public void Add(string[] data)
        {
            string name = data[0];
            int index = int.Parse(data[1]);

            string[] gemInfo = data[2].Split();
            string clarity = gemInfo[0];
            string type = gemInfo[1];

            IGem gem = gemFactory.CreateGem(clarity, type);

            IWeapon weapon = this.weapons.FirstOrDefault(w => w.Name == name);

            weapon.AddGem(gem, index);
        }

        public void Create(string[] data)
        {
            string[] weapon = data[0].Split();

            string rarity = weapon[0];
            string type = weapon[1];
            string name = data[1];

            IWeapon currentWeapon = this.weaponFactory.CreateWeapon(rarity, type, name);

            this.weapons.Add(currentWeapon);
        }

        public void Print(string[] data)
        {
            string name = data[0];
            IWeapon weapon = this.weapons.FirstOrDefault(w => w.Name == name);

            Console.WriteLine(weapon);
        }

        public void Remove(string[] data)
        {
            string name = data[0];
            int index = int.Parse(data[1]);

            IWeapon weapon = this.weapons.FirstOrDefault(w => w.Name == name);

            weapon.RemoveGem(index);
        }
    }
}
