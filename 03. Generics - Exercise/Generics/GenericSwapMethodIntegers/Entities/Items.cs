namespace GenericSwapMethodIntegers.Entities
{
    public class Items<T>
    {
        private readonly T item;

        public Items(T item)
        {
            this.item = item;
        }

        public override string ToString()
        {
            return $"System.{item.GetType().Name}" + ": " + $"{this.item}";
        }
    }
}
