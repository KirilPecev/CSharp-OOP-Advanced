namespace LinkedListTraversal.Entities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Contracts;

    public class MyLinkedList<T> : IMyLinkedList<T>
        where T : IComparable<T>
    {
        private Node Head { get; set; }
        private Node Tail { get; set; }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (Count == 0)
            {
                Head = Tail = new Node(item);
            }
            else
            {
                var oldTail = this.Tail;
                oldTail.Next = this.Tail = new Node(item);
            }

            this.Count++;
        }

        public bool Remove(T item)
        {
            if (this.Count == 0)
            {
                return false;
            }

            if (this.Head.Value.CompareTo(item) == 0)
            {
                this.Head = this.Head.Next;
                this.Count--;
                return true;
            }

            Node previous = this.Head;
            var current = this.Head.Next;

            while (current != null)
            {
                if (current.Value.CompareTo(item) == 0)
                {
                    previous.Next = current.Next;
                    Count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.Head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }
            public Node Next { get; set; }
        }
    }
}
