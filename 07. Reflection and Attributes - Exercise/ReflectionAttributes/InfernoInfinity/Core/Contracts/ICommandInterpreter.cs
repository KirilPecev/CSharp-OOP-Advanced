namespace InfernoInfinity.Core.Contracts
{
    public interface ICommandInterpreter
    {
        void Create(string[] data);

        void Add(string[] data);

        void Remove(string[] data);

        void Print(string[] data);
    }
}
