namespace StrategyPattern.Entities.Comparators
{
    using Persons.Contracts;
    using System.Collections.Generic;

    public class NameComparator : IComparer<IPerson>
    {
        public int Compare(IPerson x, IPerson y)
        {
            var result = x.Name.Length.CompareTo(y.Name.Length);
            if (result == 0)
            {
                result = x.Name[0].ToString().ToLower().CompareTo(y.Name[0].ToString().ToLower());
            }

            return result;
        }
    }
}
