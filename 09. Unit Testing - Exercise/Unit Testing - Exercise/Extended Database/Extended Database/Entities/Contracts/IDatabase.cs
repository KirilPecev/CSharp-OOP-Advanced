namespace Extended_Database.Entities.Contracts
{
    using System.Collections.Generic;

    public interface IDatabase
    {
        List<IPerson> DatabaseInfo { get; }

        void Add(IPerson person);

        void Remove(IPerson person);

        IPerson FindById(long id);

        IPerson FindByUsername(string username);
    }
}
