namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Vehicles;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test]
        public void BaseVehicleShouldAddArsenalPart()
        {
            var assembler = new VehicleAssembler();
            var vehicle = new Revenger("SA-203", 1000.0, 235m, 100, 100, 96, assembler);
            var arsenalPart = new ArsenalPart("Arsenal", 10.0, 23m, 25);
            var shellPart = new ShellPart("Shel", 20.0, 12m,50);
            var endurancePart = new EndurancePart("Endurance", 12.0, 23m, 25);

            vehicle.AddArsenalPart(arsenalPart);
            vehicle.AddShellPart(shellPart);
            vehicle.AddEndurancePart(endurancePart);

            var expectedResult = vehicle.ToString();
            var actual = "Revenger - SA-203\r\nTotal Weight: 1042.000\r\nTotal Price: 293.000\r\nAttack: 125\r\nDefense: 150\r\nHitPoints: 121\r\nParts: Arsenal, Shel, Endurance";
            Assert.AreEqual(expectedResult, actual);
        }

        [Test]
        public void BaseVehicleShouldPrintNone()
        {
            var assembler = new VehicleAssembler();
            var vehicle = new Revenger("SA-203", 1000.0, 235m, 100, 100, 96, assembler);

            var arsenalPart = new ArsenalPart("Arsenal", 10.0, 23m, 25);
            var shellPart = new ShellPart("Shel", 20.0, 12m, 50);
            var endurancePart = new EndurancePart("Endurance", 12.0, 23m, 25);

            var expectedResult = vehicle.ToString();
            var actual = "Revenger - SA-203\r\nTotal Weight: 1000.000\r\nTotal Price: 235.000\r\nAttack: 100\r\nDefense: 100\r\nHitPoints: 96\r\nParts: None";
            Assert.AreEqual(expectedResult, actual);
        }
    }
}