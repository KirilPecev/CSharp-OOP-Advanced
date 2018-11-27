namespace PetClinic.Entities.Pets
{
    using Contracts;

    public class Pet : IPet
    {
        public Pet(string name, int age, string kind)
        {
            this.Name = name;
            this.Age = age;
            this.Kind = kind;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Kind { get; private set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Kind}";
        }
    }
}
