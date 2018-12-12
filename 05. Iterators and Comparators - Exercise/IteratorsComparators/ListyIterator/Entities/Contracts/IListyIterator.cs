namespace ListyIterator.Entities.Contracts
{
    using System.Collections.Generic;

    public interface IListyIterator<T> : IEnumerable<T>
    {
        bool Move();

        bool HasNext();

        void Print();
    }
}
