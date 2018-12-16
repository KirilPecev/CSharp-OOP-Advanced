namespace TheTankGame.Entities.Vehicles
{
    using Contracts;
    using Miscellaneous.Contracts;
    using Parts.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class BaseVehicle : IVehicle
    {
        private double weight;
        private decimal price;
        private int attack;
        private int defense;
        private int hitPoints;
        private string model;

        private readonly IAssembler assembler;
        private readonly IList<string> orderedParts;

        protected BaseVehicle(string model, double weight, decimal price, int attack, int defense, int hitPoints, IAssembler assembler)
        {
            this.Model = model;
            this.Weight = weight;
            this.Price = price;
            this.Attack = attack;
            this.Defense = defense;
            this.HitPoints = hitPoints;
            this.assembler = assembler;
            this.orderedParts = new List<string>();
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model cannot be null or white space!");
                }

                this.model = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Weight cannot be less or equal to zero!");
                }

                this.weight = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero!");
                }

                this.price = value;
            }
        }

        public int Attack
        {
            get
            {
                return this.attack;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Attack cannot be less than zero!");
                }

                this.attack = value;
            }
        }

        public int Defense
        {
            get
            {
                return this.defense;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Defense cannot be less than zero!");
                }

                this.defense = value;
            }
        }

        public int HitPoints
        {
            get
            {
                return this.hitPoints;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("HitPoints cannot be less than zero!");
                }

                this.hitPoints = value;
            }
        }

        public double TotalWeight
            => this.weight + this.assembler.TotalWeight;

        public decimal TotalPrice
            => this.price + this.assembler.TotalPrice;

        public long TotalAttack
            => this.attack + this.assembler.TotalAttackModification;

        public long TotalDefense
            => this.defense + this.assembler.TotalDefenseModification;

        public long TotalHitPoints
            => this.hitPoints + this.assembler.TotalHitPointModification;

        public void AddArsenalPart(IPart arsenalPart)
        {
            this.orderedParts.Add(arsenalPart.Model);
            this.assembler.AddArsenalPart(arsenalPart);
        }

        public void AddShellPart(IPart shellPart)
        {
            this.orderedParts.Add(shellPart.Model);
            this.assembler.AddShellPart(shellPart);
        }

        public void AddEndurancePart(IPart endurancePart)
        {
            this.orderedParts.Add(endurancePart.Model);
            this.assembler.AddEndurancePart(endurancePart);
        }

        public IEnumerable<IPart> Parts
        {
            get
            {
                List<IPart> parts = new List<IPart>();

                parts.AddRange(this.assembler.ArsenalParts);
                parts.AddRange(this.assembler.ShellParts);
                parts.AddRange(this.assembler.EnduranceParts);

                return parts;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.GetType().Name} - {this.Model}");
            result.AppendLine($"Total Weight: {this.TotalWeight:F3}");
            result.AppendLine($"Total Price: {this.TotalPrice:F3}");
            result.AppendLine($"Attack: {this.TotalAttack}");
            result.AppendLine($"Defense: {this.TotalDefense}");
            result.AppendLine($"HitPoints: {this.TotalHitPoints}");

            result.Append("Parts: ");

            StringBuilder partsString = new StringBuilder();

            this.orderedParts
                .ToList()
                .ForEach(x => partsString.Append(x).Append(", "));

            if (partsString.Length > 0)
            {
                string textToAppend = partsString.ToString()
                    .Substring(0, partsString.Length - 2);

                result.Append(textToAppend);
            }
            else
            {
                result.Append("None");
            }

            return result.ToString();
        }
    }
}