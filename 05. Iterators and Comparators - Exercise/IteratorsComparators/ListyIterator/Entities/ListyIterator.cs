namespace ListyIterator.Entities
{
    using Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IListyIterator<T>
    {
        private List<T> items;
        private int index;

        public ListyIterator(params T[] items)
        {
            this.items = new List<T>(items);
            this.index = 0;
        }

        public bool HasNext()
        {
            return this.index + 1 < this.items.Count;
        }

        public bool Move()
        {
            if (this.index < this.items.Count - 1)
            {
                this.index++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.items[this.index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
