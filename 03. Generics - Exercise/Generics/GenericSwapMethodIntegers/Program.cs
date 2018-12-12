namespace GenericSwapMethodIntegers
{
    using GenericSwapMethodIntegers.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<Items<int>> items = new List<Items<int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                Items<int> item = new Items<int>(num);
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
