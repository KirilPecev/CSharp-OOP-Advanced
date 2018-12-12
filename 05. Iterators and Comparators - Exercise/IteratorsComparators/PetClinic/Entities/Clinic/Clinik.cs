namespace PetClinic.Entities.Clinic
{
    using Contracts;
    using Pets;
    using Pets.Contracts;
    using System;
    using System.Linq;

    public class Clinik : IClinik
    {
        private IPet[] rooms;
        private int index;

        public Clinik(string name, int rooms)
        {
            this.Name = name;
            this.Rooms = new Pet[rooms];
            this.index = this.Rooms.Length / 2;
        }

        public string Name { get; private set; }

        public IPet[] Rooms
        {
            get
            {
                return this.rooms;
            }
            private set
            {
                if (value.Length % 2 == 0)
                {
                    throw new InvalidOperationException("Invalid Operation!");
                }

                this.rooms = value;
            }
        }

        public bool AddPet(IPet pet)
        {
            if (pet == null)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            for (int i = 0; i <= this.index; i++)
            {
                if (this.rooms[this.index - i] == null)
                {
                    rooms[this.index - i] = pet;
                    return true;
                }

                if (this.rooms[this.index + i] == null)
                {
                    rooms[this.index + i] = pet;
                    return true;
                }
            }

            return false;
        }

        public bool HasEmptyRooms()
        {
            return this.rooms.Any(r => r == null);
        }

        public void Print()
        {
            foreach (var pet in this.rooms)
            {
                if (pet == null)
                {
                    Console.WriteLine("Room empty");
                }
                else
                {
                    Console.WriteLine(pet);
                }
            }
        }

        public void PrintRoom(int room)
        {
            if (this.rooms[room - 1] != null)
            {
                Console.WriteLine(rooms[room - 1]);
            }
            else
            {
                Console.WriteLine("Room empty");
            }
        }

        public bool Realese()
        {
            for (int i = this.index; i < this.rooms.Length; i++)
            {
                if (this.rooms[i] != null)
                {
                    this.rooms[i] = null;
                    return true;
                }
            }

            for (int i = 0; i < this.index; i++)
            {
                if (this.rooms[i] != null)
                {
                    this.rooms[i] = null;
                    return true;
                }
            }

            return false;
        }
    }
}
