namespace Froggy.Entities
{
    using System.Collections;
    using System.Collections.Generic;
    using Contracts;

    public class Lake : ILake
    {
        public Lake(params int[] nums)
        {
            this.Nums = new List<int>(nums);
        }

        public List<int> Nums { get; private set; }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.Nums.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return this.Nums[i];
                }
            }

            for (int i = this.Nums.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return this.Nums[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
