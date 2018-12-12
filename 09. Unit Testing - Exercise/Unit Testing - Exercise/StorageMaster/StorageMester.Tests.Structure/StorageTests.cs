namespace StorageMester.Tests.Structure
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Storage;
    using StorageMaster.Entities.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class StorageTests
    {
        private Type storageType;
        private Type automatedWarehouseType;
        private Type distributionCenterType;
        private Type warehouseType;

        [SetUp]
        public void Initialize()
        {
            this.storageType = typeof(Storage);
            this.automatedWarehouseType = typeof(AutomatedWarehouse);
            this.distributionCenterType = typeof(DistributionCenter);
            this.warehouseType = typeof(Warehouse);
        }

        [Test]
        public void StorageShouldContainsProtectedConstructor()
        {
            Type[] types = new Type[] { typeof(string), typeof(int), typeof(int), typeof(IEnumerable<Vehicle>) };

            var constructor = this.storageType.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, types, null);

            bool modifier = constructor.IsFamily;

            Assert.That(modifier, Is.EqualTo(true),"Storage constructor is not found!");
        }

        [Test]
        public void AutomatedWarehouseShouldContainsPublicConstructor()
        {
            Type[] types = new Type[] { typeof(string) };

            var constructor = this.automatedWarehouseType.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, types, null);

            bool modifier = constructor.IsPublic;

            Assert.That(modifier, Is.EqualTo(true), "AutomatedWarehouse constructor is not found!");
        }

        [Test]
        public void DistributionCenterShouldContainsPublicConstructor()
        {
            Type[] types = new Type[] { typeof(string) };

            var constructor = this.distributionCenterType.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, types, null);

            bool modifier = constructor.IsPublic;

            Assert.That(modifier, Is.EqualTo(true), "DistributionCenter constructor is not found!");
        }

        [Test]
        public void WarehouseShouldContainsPublicConstructor()
        {
            Type[] types = new Type[] { typeof(string) };

            var constructor = this.warehouseType.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, types, null);

            bool modifier = constructor.IsPublic;

            Assert.That(modifier, Is.EqualTo(true), "Warehouse constructor is not found!");
        }

        [Test]
        public void StorageShouldContainsPrivateFieldGarage()
        {
            var field = this.storageType.GetField("garage", BindingFlags.Instance | BindingFlags.NonPublic);

            var fieldReturedType = field.FieldType.Name;

            Assert.That(field, Is.Not.Null, "Garage field is not found!");

            Assert.That(fieldReturedType, Is.EqualTo(typeof(Vehicle[]).Name), "Incorrect garage field type!");
        }

        [Test]
        public void StorageShouldContainsPrivateFieldProducts()
        {
            var field = this.storageType.GetField("products", BindingFlags.Instance | BindingFlags.NonPublic);

            var fieldReturedType = field.FieldType.Name;

            Assert.That(field, Is.Not.Null, "Products field is not found!");

            Assert.That(fieldReturedType, Is.EqualTo(typeof(List<Product>).Name), "Incorrect product field type!");
        }

        [Test]
        public void StorageShouldContainsPublicGetMethodName()
        {
            var method = this.storageType.GetMethod("get_Name", BindingFlags.Instance | BindingFlags.Public);
            var modifier = method.ReturnType;

            Assert.That(method, Is.Not.Null, "Name is not found!");
            Assert.That(modifier, Is.EqualTo(typeof(string)), "Invalid name return type!");
        }

        [Test]
        public void StorageShouldContainsPublicGetMethodCapacity()
        {
            var method = this.storageType.GetMethod("get_Capacity", BindingFlags.Instance | BindingFlags.Public);

            var modifier = method.ReturnType;

            Assert.That(method, Is.Not.Null, "Capacity is not found!");
            Assert.That(modifier, Is.EqualTo(typeof(int)),"Invalid capacity return type!");
        }

        [Test]
        public void StorageShouldContainsPublicGetMethodGarageSlots()
        {
            var method = this.storageType.GetMethod("get_GarageSlots", BindingFlags.Instance | BindingFlags.Public);
            var modifier = method.ReturnType;

            Assert.That(method, Is.Not.Null, "GarageSlots is not found!");
            Assert.That(modifier, Is.EqualTo(typeof(int)), "Invalid garareSlots return type!");
        }

        [Test]
        public void StorageShouldContainsPublicGetMethodGarage()
        {
            var method = this.storageType.GetMethod("get_Garage", BindingFlags.Instance | BindingFlags.Public);
            var modifier = method.ReturnType;

            Assert.That(method, Is.Not.Null, "Garage is not found!");
            Assert.That(modifier, Is.EqualTo(typeof(IReadOnlyCollection<Vehicle>)), "Invalid garage return type!");
        }

        [Test]
        public void StorageShouldContainsPublicGetMethodProducts()
        {
            var method = this.storageType.GetMethod("get_Products", BindingFlags.Instance | BindingFlags.Public);
            var modifier = method.ReturnType;

            Assert.That(method, Is.Not.Null, "Products is not found!");
            Assert.That(modifier, Is.EqualTo(typeof(IReadOnlyCollection<Product>)), "Invalid products return type!");
        }

        [Test]
        public void StorageShouldContainsPublicMethodSendVehicleTo()
        {
            var method = this.storageType.GetMethod("SendVehicleTo", BindingFlags.Instance | BindingFlags.Public);
            var modifier = method.ReturnType;

            Assert.That(method, Is.Not.Null, "SendVehicleTo is not found!");
            Assert.That(modifier, Is.EqualTo(typeof(int)), "Invalid SendVehicleTo return type!");
        }

        [Test]
        public void StorageShouldContainsPublicMethodGetVehicle()
        {
            var method = this.storageType.GetMethod("GetVehicle", BindingFlags.Instance | BindingFlags.Public);
            var modifier = method.ReturnType;

            Assert.That(method, Is.Not.Null, "GetVehicle is not found!");
            Assert.That(modifier, Is.EqualTo(typeof(Vehicle)), "Invalid GetVehicle return type!");
        }

        [Test]
        public void StorageShouldContainsPublicMethodUnloadVehicle()
        {
            var method = this.storageType.GetMethod("UnloadVehicle", BindingFlags.Instance | BindingFlags.Public);
            var modifier = method.ReturnType;

            Assert.That(method, Is.Not.Null, "UnloadVehicle is not found!");
            Assert.That(modifier, Is.EqualTo(typeof(int)), "Invalid UnloadVehicle return type!");
        }
    }
}
