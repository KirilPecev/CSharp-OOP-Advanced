namespace Travel.Tests
{
    using NUnit.Framework;
    using Travel.Core.Controllers;
    using Travel.Core.Controllers.Contracts;
    using Travel.Entities;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Airplanes.Contracts;
    using Travel.Entities.Contracts;
    using Travel.Entities.Items;

    [TestFixture]
    public class FlightControllerTests
    {
        private const string SourceTrip = "Sofia";
        private const string FirstDestinationTrip = "London";
        private const string SecondDestinationTrip = "Dubai";

        [Test]
        public void ValidateTakeOfMethod()
        {
            var passengers = new[]
             {
                new Passenger("Pesho"),
                new Passenger("Gosho"),
                new Passenger("Kiro"),
                new Passenger("Stamat"),
                new Passenger("Ivan"),
                new Passenger("Peshoslav"),
            };

            IAirport airport = new Airport();

            IAirplane airplane = new LightAirplane();

            foreach (var passenger in passengers)
            {
                airplane.AddPassenger(passenger);
            }

            ITrip trip = new Trip(SourceTrip, FirstDestinationTrip, airplane);
            airport.AddTrip(trip);

            IFlightController flightController = new FlightController(airport);

            IBag bag = new Bag(passengers[1], new[] { new Colombian() });

            passengers[1].Bags.Add(bag);

            ITrip completedTrip = new Trip(SourceTrip, SecondDestinationTrip, new LightAirplane());
            completedTrip.Complete();

            airport.AddTrip(completedTrip);

            string actualResult = flightController.TakeOff();

            string expectedResult = @"SofiaLondon1:
Overbooked! Ejected Gosho
Confiscated 1 bags ($50000)
Successfully transported 5 passengers from Sofia to London.
Confiscated bags: 1 (1 items) => $50000";

            Assert.That(actualResult, Is.EqualTo(expectedResult).NoClip);
            Assert.That(trip.IsCompleted, Is.True);
        }
    }
}
