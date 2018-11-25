namespace CustomList.Core
{
    using CustomList.Core.Contracts;
    using CustomList.Entities;
    using CustomList.Entities.Contracts;
    using System;

    public class CommandInterpreter : ICommandInterpreter
    {
        private ICustomList<string> customLists;

        public CommandInterpreter()
        {
            this.customLists = new CustomList<string>();
        }

        public void Add(string element)
        {
            this.customLists.Add(element);
        }

        public bool Contains(string element)
        {
            return this.customLists.Contains(element);
        }

        public int Greater(string element)
        {
            return this.customLists.CountGreaterThan(element);
        }

        public string Max()
        {
            return this.customLists.Max();
        }

        public string Min()
        {
            return this.customLists.Min();
        }

        public void Print()
        {
            foreach (var item in this.customLists)
            {
                Console.WriteLine(item);
            }
        }

        public string Remove(int index)
        {
            return this.customLists.Remove(index);
        }

        public void Swap(int index1, int index2)
        {
            this.customLists.Swap(index1, index2);
        }

        public void Sort()
        {
            this.customLists.Sort();
        }
    }
}
