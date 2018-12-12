namespace GenericSwapMethodString
{
    using GenericSwapMethodString.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<Items<string>> items = new List<Items<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var currentString = Console.ReadLine();
                var item = new Items<string>(currentString);
                items.Add(item);
            }

            int[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Swap(items, indexes[0], indexes[1]);

            foreach (var item in items)
            {
                Console.WriteLine(item.ToString()); 
            }
        }

        public static void Swap<T>(List<T> list, int firstIndex, int secondIndex)
        {
            T tmp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = tmp;
        }
    }
}
