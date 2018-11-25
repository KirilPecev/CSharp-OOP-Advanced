namespace GenericCountMethodDouble
{
    using GenericCountMethodDouble.Entities;
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Box<double>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double currentString = double.Parse(Console.ReadLine());
                Box<double> item = new Box<double>(currentString);
                list.Add(item);
            }

            double valueForCompare = double.Parse(Console.ReadLine());

            int output = CompareValues<double>(list, valueForCompare);

            Console.WriteLine(output);
        }

        public static int CompareValues<T>(List<Box<double>> list, double compareWithThis)
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
