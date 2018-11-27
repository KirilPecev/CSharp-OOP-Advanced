namespace PetClinic.Entities.Clinic.Contracts
{
    using Pets.Contracts;

    public interface IClinik
    {
        string Name { get; }

        IPet[] Rooms { get; }

        bool AddPet(IPet pet);

        bool Realese();

        bool HasEmptyRooms();

        void Print();

        void PrintRoom(int room);
    }
}
