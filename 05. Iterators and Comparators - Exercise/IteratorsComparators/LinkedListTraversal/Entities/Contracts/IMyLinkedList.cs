namespace LinkedListTraversal.Entities.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IMyLinkedList<T> : IEnumerable<T>
        where T: IComparable<T>
    {
        int Count { get; }

        void Add(T item);

        bool Remove(T item);
    }
}
