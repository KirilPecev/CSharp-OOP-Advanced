namespace Stack.Entities.Contracts
{
    using System.Collections.Generic;

    public interface ICustomStack<T> : IEnumerable<T>
    {
        void Push(params T[] elements);

        void Pop();

        int Count { get; }
    }
}
