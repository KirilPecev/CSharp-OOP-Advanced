namespace Travel.Entities.Airplanes
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Airplane : IAirplane
    {
        private List<IBag> bags;
        private List<IPassenger> passengers;

        protected Airplane(int seats, int baggageCompartments)
        {
            this.Seats = seats;
            this.BaggageCompartments = baggageCompartments;
            this.bags = new List<IBag>();
            this.passengers = new List<IPassenger>();
        }

        public int BaggageCompartments { get; private set; }

        public IReadOnlyCollection<IBag> BaggageCompartment => this.bags.AsReadOnly();

        public bool IsOverbooked => this.Passengers.Count > this.Seats;

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();

        public int Seats { get; private set; }

        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var passengerBags = this.bags
                .Where(b => b.Owner == passenger)
                .ToArray();

            foreach (var bag in passengerBags)
            {
                this.bags.Remove(bag);
            }

            return passengerBags;
        }

        public void LoadBag(IBag bag)
        {
            if (this.BaggageCompartment.Count >= this.BaggageCompartments)
            {
                throw new InvalidOperationException("No more bag room in {planeName}!");
            }

            this.bags.Add(bag);
        }

        public IPassenger RemovePassenger(int seat)
        {
            var passenger = this.passengers[seat];
            this.passengers.RemoveAt(seat);

            return passenger;
        }
    }
}