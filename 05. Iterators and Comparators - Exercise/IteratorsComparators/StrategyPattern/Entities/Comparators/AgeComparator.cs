namespace StrategyPattern.Entities.Comparators
{
    using StrategyPattern.Entities.Persons.Contracts;
    using System.Collections.Generic;

    public class AgeComparator : IComparer<IPerson>
    {
        public int Compare(IPerson x, IPerson y)
        {
            var result = x.Age.CompareTo(y.Age);

            return result;
        }
    }
}
