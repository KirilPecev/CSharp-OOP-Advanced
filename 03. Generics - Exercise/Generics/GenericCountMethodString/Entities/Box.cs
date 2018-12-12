namespace GenericCountMethodString.Entities
{
    using System;

    public class Box<T> : IComparable<T>
        where T: IComparable<T>
    {
        private readonly T item;

        public Box(T item)
        {
            this.item = item;
        }

        public int CompareTo(T other)
        {
            return this.item.CompareTo(other);
        }

        public override string ToString()
        {
            return $"System.{item.GetType().Name}" + ": " + $"{this.item}";
        }
    }
}
