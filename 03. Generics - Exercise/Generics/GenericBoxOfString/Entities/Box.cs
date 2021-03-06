﻿namespace GenericBoxOfString.Entities
{
    using System.Collections.Generic;

    public class Box<T>
    {
        private readonly T item;

        public Box(T item)
        {
            this.item = item;
        }

        public override string ToString()
        {
            return $"System.{item.GetType().Name}" + ": " + $"{this.item}";
        }
    }
}
