namespace Froggy.Entities.Contracts
{
    using System.Collections.Generic;

    public interface ILake : IEnumerable<int>
    {
        List<int> Nums { get; }
    }
}
