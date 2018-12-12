namespace Database.Entities.Contracts
{
    public interface IDatabase
    {
        void Add(int num);

        int[] Fetch();

        int Remove();
    }
}