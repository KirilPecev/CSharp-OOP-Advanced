namespace Tuple
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            var tuple1 = new Entities.Tuple<string, string>(input[0] + " " + input[1], input[2]);
            Console.WriteLine(tuple1);

            input = Console.ReadLine().Split();
            var tuple2 = new Entities.Tuple<string, int>(input[0], int.Parse(input[1]));
            Console.WriteLine(tuple2);

            input = Console.ReadLine().Split();
            Entities.Tuple<int, double> tuple3 = new Entities.Tuple<int, double>(int.Parse(input[0]), double.Parse(input[1]));
            Console.WriteLine(tuple3);
        }
    }
}
