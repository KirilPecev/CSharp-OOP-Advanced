namespace CustomList.Core.Contracts
{
    public interface ICommandInterpreter 
    {
        void Add(string element);
        string Remove(int index);
        bool Contains(string element);
        void Swap(int index1, int index2);
        int Greater(string element);
        string Max();
        string Min();
        void Print();
        void Sort();
    }
}
