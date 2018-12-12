namespace Froggy.Core
{
    using Froggy.Core.Contracts;
    using Froggy.Entities;
    using Froggy.Entities.Contracts;
    using System;
    using System.Linq;
    using System.Text;

    public class Engine : IEngine
    {
        private ILake lake;

        public void Run()
        {
            int[] nums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            this.lake = new Lake(nums);

            var sb = new StringBuilder();
            foreach (var num in this.lake)
            {
                sb.Append($"{num}, ");
            }

            Console.WriteLine(sb.ToString().TrimEnd(' ',','));
        }
    }
}
