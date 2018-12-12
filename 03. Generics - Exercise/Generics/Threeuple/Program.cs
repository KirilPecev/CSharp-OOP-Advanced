using System;

namespace Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            var tuple1 = new Entities.Tuple<string, string, string>(input[0] + " " + input[1], input[2], input[3]);
            Console.WriteLine(tuple1);

            input = Console.ReadLine().Split();
            var tuple2 = new Entities.Tuple<string, int, bool>(input[0], int.Parse(input[1]), input[2] == "drunk" ? true : false);
            Console.WriteLine(tuple2);

            input = Console.ReadLine().Split();
            var tuple3 = new Entities.Tuple<string, double, string>(input[0], double.Parse(input[1]), input[2]);
            Console.WriteLine(tuple3);
        }
    }
}
