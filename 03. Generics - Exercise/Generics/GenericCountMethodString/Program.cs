using GenericCountMethodString.Entities;
using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Box<string>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string currentString = Console.ReadLine();
                Box<string> item = new Box<string>(currentString);
                list.Add(item);
            }

            string valueForCompare = Console.ReadLine();

            int output = CompareValues<string>(list, valueForCompare);

            Console.WriteLine(output);
        }

        public static int CompareValues<T>(List<Box<string>> list, string compareWithThis)
        {
            int counter = 0;
            foreach (var item in list)
            {
                var resultFromCompare = item.CompareTo(compareWithThis);
                if (resultFromCompare == 1)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
