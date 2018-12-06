namespace Database.Entities
{
    using System;
    using System.Linq;
    using Contracts;

    public class Database : IDatabase
    {
        private const int arrayLength = 16;

        private int[] database;
        private int index;

        public Database(params int[] nums)
        {
            if (nums.Length > arrayLength)
            {
                throw new InvalidOperationException("Array length must be below 16!");
            }

            this.database = new int[arrayLength];
            this.index = nums.Length;
            Array.Copy(nums, database, nums.Length);
        }

        public void Add(int num)
        {
            if (this.index == arrayLength)
            {
                throw new InvalidOperationException("Array length must be below 16!");
            }

            this.database[index++] = num;
        }

        public int Remove()
        {
            if (this.index == 0)
            {
                throw new InvalidOperationException("Empty array!");
            }

            return this.database[--this.index];
        }

        public int[] Fetch()
        {
            return this.database.Take(this.index).ToArray();
        }
    }
}
