namespace Stack.Entities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Stack.Entities.Contracts;

    public class CustomStack<T> : ICustomStack<T>
    {
        private List<T> elements;

        public CustomStack()
        {
            this.elements = new List<T>();
        }

        public int Count { get; private set; }

        public void Pop()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("No elements");
            }

            this.elements.RemoveAt(--this.Count);
        }

        public void Push(params T[] elements)
        {
            this.elements.AddRange(elements);

            this.Count += elements.Length;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
