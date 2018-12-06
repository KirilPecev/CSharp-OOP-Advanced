namespace StorageMester.Tests.Structure
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Vehicles;
    using System;
    using System.Reflection;

    public class VehicleTests
    {
        private Type vehicleType;
        private Type semiType;
        private Type truckType;
        private Type vanType;

        [SetUp]
        public void Initialize()
        {
            this.vehicleType = typeof(Vehicle);
            this.semiType = typeof(Semi);
            this.truckType = typeof(Truck);
            this.vanType = typeof(Van);
        }

        [Test]
        public void VanShouldContainsPublicConstructor()
        {
            var constructor = this.vanType.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new Type[] { }, null);

            bool modifier = constructor.IsPublic;

            Assert.That(modifier, Is.EqualTo(true), "Van public constructor not found!");
        }

        [Test]
        public void TruckShouldContainsPublicConstructor()
        {
            var constructor = this.truckType.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new Type[] { }, null);

            bool modifier = constructor.IsPublic;

            Assert.That(modifier, Is.EqualTo(true), "Truck public constructor not found!");
        }

        [Test]
        public void SemiShouldContainsPublicConstructor()
        {
            var constructor = this.semiType.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new Type[] { }, null);

            bool modifier = constructor.IsPublic;

            Assert.That(modifier, Is.EqualTo(true), "Semi public constructor not found!");
        }

        [Test]
        public void VehicleShouldContainsProtectedConstructor()
        {
            Type[] types = new Type[1];
            types[0] = typeof(int);

            var constructor = this.vehicleType.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, types, null);

            bool modifier = constructor.IsFamily;

            Assert.That(modifier, Is.EqualTo(true), "Vehicle protected constructor not found!");
        }

        [Test]
        public void VehicleShouldContainsPrivateFieldTruck()
        {
            var trunkField = this.vehicleType.GetField("trunk", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.That(trunkField, Is.Not.Null, "Truck private field not found!");
        }

        [Test]
        public void VehicleShouldContainsPublicGetMethodCapacity()
        {
            var capacityMethod = this.vehicleType.GetMethod("get_Capacity", BindingFlags.Public | BindingFlags.Instance);

            Assert.That(capacityMethod, Is.Not.Null, "Capacity public get method not found!");
        }

        [Test]
        public void VehicleShouldContainsPublicTrunk()
        {
            var method = this.vehicleType.GetMethod("get_Trunk", BindingFlags.Public | BindingFlags.Instance);

            Assert.That(method, Is.Not.Null, "Trunk public get method not found!");
        }

        [Test]
        public void VehicleShouldContainsPublicIsFull()
        {
            var method = this.vehicleType.GetMethod("get_IsFull", BindingFlags.Public | BindingFlags.Instance);

            Assert.That(method, Is.Not.Null, "Public get method IsFull not found!");
        }

        [Test]
        public void VehicleShouldContainsPublicIsEmpty()
        {
            var method = this.vehicleType.GetMethod("get_IsEmpty", BindingFlags.Public | BindingFlags.Instance);

            Assert.That(method, Is.Not.Null, "Public get method IsEmpty not found!");
        }

        [Test]
        public void VehicleShouldContainsPublicLoadProduct()
        {
            var trunkMethod = this.vehicleType.GetMethod("LoadProduct", BindingFlags.Public | BindingFlags.Instance);

            var trunkReturnedType = trunkMethod.ReturnType;

            Assert.That(trunkMethod, Is.Not.Null, "Public method LoadProduct not found!");
            Assert.That(trunkReturnedType, Is.EqualTo(typeof(void)), "Invalid returned type of LoadProduct!");
        }

        [Test]
        public void VehicleShouldContainsPublicUnload()
        {
            var trunkMethod = this.vehicleType.GetMethod("Unload", BindingFlags.Public | BindingFlags.Instance);

            var trunkReturned = trunkMethod.ReturnType;

            Assert.That(trunkMethod, Is.Not.Null, "Public method Unload not found!");
            Assert.That(trunkReturned, Is.EqualTo(typeof(Product)), "Invalid returned type of Unload!");
        }
    }
}
