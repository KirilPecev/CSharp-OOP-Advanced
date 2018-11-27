namespace PetClinic.Core
{
    using Contracts;
    using Entities.Clinic;
    using Entities.Clinic.Contracts;
    using Entities.Pets;
    using Entities.Pets.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine : IEngine
    {
        private List<IClinik> cliniks;
        private List<IPet> pets;

        public Engine()
        {
            this.cliniks = new List<IClinik>();
            this.pets = new List<IPet>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();

                try
                {
                    Play(inputArgs);
                }
                catch (InvalidOperationException iox)
                {
                    Console.WriteLine(iox.Message);
                }
            }
        }

        private void Play(string[] inputArgs)
        {
            string output = string.Empty;
            string command = inputArgs[0];

            switch (command)
            {
                case "Create":

                    string name = inputArgs[2];
                    int ageOrRooms = int.Parse(inputArgs[3]);

                    if (inputArgs[1] == "Pet")
                    {
                        string kind = inputArgs[4];

                        IPet pet = new Pet(name, ageOrRooms, kind);
                        this.pets.Add(pet);
                        break;
                    }

                    IClinik clinik = new Clinik(name, ageOrRooms);
                    this.cliniks.Add(clinik);
                    break;

                case "Add":

                    string petName = inputArgs[1];
                    string clinikName = inputArgs[2];

                    IPet currentPet = this.pets.FirstOrDefault(p => p.Name == petName);
                    IClinik currentClinik = this.cliniks.FirstOrDefault(p => p.Name == clinikName);

                    output = currentClinik.AddPet(currentPet).ToString();
                    break;

                case "Release":

                    clinikName = inputArgs[1];
                    currentClinik = this.cliniks.FirstOrDefault(p => p.Name == clinikName);
                    output = currentClinik.Realese().ToString();
                    break;

                case "HasEmptyRooms":

                    clinikName = inputArgs[1];
                    currentClinik = this.cliniks.FirstOrDefault(p => p.Name == clinikName);
                    output = currentClinik.HasEmptyRooms().ToString();
                    break;

                case "Print":

                    clinikName = inputArgs[1];
                    currentClinik = this.cliniks.FirstOrDefault(p => p.Name == clinikName);
                    if (inputArgs.Length == 3)
                    {
                        int room = int.Parse(inputArgs[2]);
                        currentClinik.PrintRoom(room);
                        break;
                    }

                    currentClinik.Print();
                    break;
            }

            if (output!=string.Empty)
            {
                Console.WriteLine(output);
            }
        }
    }
}
