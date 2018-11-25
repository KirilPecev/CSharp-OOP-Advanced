namespace CustomList.Entities
{
    using CustomList.Entities.Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomList<T> : ICustomList<T>
        where T : IComparable<T>
    {
        private readonly List<T> list;

        public CustomList()
        {
            this.list = new List<T>();
        }

        public CustomList(IEnumerable<T> items)
        {
            this.list = new List<T>(items);
        }

        public int Count => this.list.Count();

        public T this[int index]
        {
            get => this.list[index];
            private set => this.list[index] = value;
        }

        public void Add(T element)
        {
            this.list.Add(element);
        }

        public bool Contains(T element)
        {
            return this.list.Contains(element);
        }

        public int CountGreaterThan(T element)
        {
            return this.list.Count(e => e.CompareTo(element) > 0);
        }

        public T Max()
        {
            return this.list.Max();
        }

        public T Min()
        {
            return this.list.Min();
        }

        public T Remove(int index)
        {
            T item = this.list[index];
            this.list.RemoveAt(index);
            return item;
        }

        public void Sort()
        {
            this.list.Sort();
        }

        public void Swap(int index1, int index2)
        {
            T tmp = this.list[index1];
            this.list[index1] = this.list[index2];
            this.list[index2] = tmp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in this.list)
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
