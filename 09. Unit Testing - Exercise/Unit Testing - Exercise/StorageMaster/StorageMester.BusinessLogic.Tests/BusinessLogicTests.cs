namespace StorageMester.BusinessLogic.Tests
{
    using NUnit.Framework;
    using StorageMaster.Core;
    using System;
    using System.Reflection;

    public class BusinessLogicTests
    {
        private Type master;
        private Object instance;

        [SetUp]
        public void Initiliaze()
        {
            this.master = typeof(StorageMaster);
            this.instance = Activator.CreateInstance(this.master);
        }

        [Test]
        public void AddProductMethodShouldAddProduct()
        {
            Object[] parameters = new object[] { "Gpu", 5.6d };

            var method = this.master.GetMethod("AddProduct", BindingFlags.Instance | BindingFlags.Public);

            var answer = method.Invoke(this.instance, parameters);

            Assert.That(method, Is.Not.Null, "Cannot found AddProduct method!");

            Assert.That(answer.ToString(), Is.EqualTo($"Added Gpu to pool"));
        }

        [Test]
        public void RegisterStorageMethodShouldRegisterStorage()
        {
            Object[] parameters = new object[] { "Warehouse", "Warehouse" };

            var method = this.master.GetMethod("RegisterStorage", BindingFlags.Instance | BindingFlags.Public);

            var answer = method.Invoke(this.instance, parameters);

            Assert.That(method, Is.Not.Null, "Cannot found RegisterStorage method!");

            Assert.That(answer.ToString(), Is.EqualTo($"Registered Warehouse"), "Cannot register storage!");
        }

        [Test]
        public void SelectVehicleMethodShouldSelectVehicle()
        {
            Object[] parameters = new object[] { "Warehouse", 1 };

            RegisterStorageMethodShouldRegisterStorage();

            var method = this.master.GetMethod("SelectVehicle", BindingFlags.Instance | BindingFlags.Public);

            var answer = method.Invoke(this.instance, parameters);

            Assert.That(method, Is.Not.Null, "Cannot found SelectVehicle method!");

            Assert.That(answer.ToString().Split()[0].ToString(), Is.EqualTo($"Selected"), "Cannot select vehicle!");
        }

        [Test]
        public void LoadVehicleMethodShouldLoadVehicle()
        {
            Object[] parameters = new object[] { new string[] { "Gpu" } };

            AddProductMethodShouldAddProduct();

            SelectVehicleMethodShouldSelectVehicle();

            RegisterStorageMethodShouldRegisterStorage();

            var method = this.master.GetMethod("LoadVehicle", BindingFlags.Instance | BindingFlags.Public);

            var answer = method.Invoke(this.instance, parameters);

            Assert.That(method, Is.Not.Null, "Cannot found LoadVehicle method!");

            Assert.That(answer.ToString().Split()[0].ToString(), Is.EqualTo($"Loaded"), "Cannot load vehicle!");
        }

        [Test]
        public void SendVehicleToMethodShouldSendVehicleTo()
        {
            Object[] parameters = new object[] { "Warehouse", 1, "DistributionCenter" };

            Object[] destionationStorage = new object[] { "DistributionCenter", "DistributionCenter" };

            var destionationStorageMethod = this.master.GetMethod("RegisterStorage", BindingFlags.Instance | BindingFlags.Public);

            destionationStorageMethod.Invoke(this.instance, destionationStorage);

            RegisterStorageMethodShouldRegisterStorage();

            SelectVehicleMethodShouldSelectVehicle();

            var method = this.master.GetMethod("SendVehicleTo", BindingFlags.Instance | BindingFlags.Public);

            var answer = method.Invoke(this.instance, parameters);

            Assert.That(method, Is.Not.Null, "Cannot found SendVehicleTo method!");

            Assert.That(answer.ToString().Split()[0].ToString(), Is.EqualTo($"Sent"), "Cannot send vehicle!");
        }

        [Test]
        public void UnloadVehicleMethodShouldUnloadVehicle()
        {
            Object[] parameters = new object[] { "Warehouse", 1 };

            RegisterStorageMethodShouldRegisterStorage();

            LoadVehicleMethodShouldLoadVehicle();

            SelectVehicleMethodShouldSelectVehicle();

            var method = this.master.GetMethod("UnloadVehicle", BindingFlags.Instance | BindingFlags.Public);

            var answer = method.Invoke(this.instance, parameters);

            Assert.That(method, Is.Not.Null, "Cannot found UnloadVehicle method!");

            Assert.That(answer.ToString().Split()[0].ToString(), Is.EqualTo($"Unloaded"), "Cannot unload vehicle!");
        }

        [Test]
        public void GetStorageStatusMethodShouldGetStorageStatus()
        {
            Object[] parameters = new object[] { "Warehouse" };

            RegisterStorageMethodShouldRegisterStorage();

            var method = this.master.GetMethod("GetStorageStatus", BindingFlags.Instance | BindingFlags.Public);

            var answer = method.Invoke(this.instance, parameters);

            Assert.That(method, Is.Not.Null, "Cannot found GetStorageStatus method!");

            Assert.That(answer.ToString().Split()[0].ToString(), Is.EqualTo($"Stock"), "Cannot get vehicle status!");
        }

        [Test]
        public void GetSummaryMethodShouldGetSummary()
        {
            Object[] parameters = new object[] { };

            RegisterStorageMethodShouldRegisterStorage();

            var method = this.master.GetMethod("GetSummary", BindingFlags.Instance | BindingFlags.Public);

            var answer = method.Invoke(this.instance, parameters);

            Assert.That(method, Is.Not.Null, "Cannot found GetSummary method!");
            Assert.That(answer.ToString().Split()[0].ToString(), Is.EqualTo($"Warehouse:"), "Cannot get summary!");
        }
    }
}
