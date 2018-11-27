namespace PetClinic.Entities.Pets.Contracts
{
    public interface IPet
    {
        string Name { get; }

        int Age { get; }

        string Kind { get; }
    }
}
