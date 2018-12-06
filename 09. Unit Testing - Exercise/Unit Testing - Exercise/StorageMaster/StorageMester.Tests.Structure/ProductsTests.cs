namespace StorageMester.Tests.Structure
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using System;
    using System.Reflection;

    public class ProductsTests
    {
        private Type productType;
        private Type gpuType;
        private Type hardDriveType;
        private Type ramType;
        private Type solidStateDriveType;

        [SetUp]
        public void Initialize()
        {
            this.productType = typeof(Product);
            this.gpuType = typeof(Gpu);
            this.hardDriveType = typeof(HardDrive);
            this.ramType = typeof(Ram);
            this.solidStateDriveType = typeof(SolidStateDrive);
        }

        [Test]
        public void ProductShouldHaveProtectedConstructor()
        {
            Type[] types = new Type[] { typeof(double), typeof(double) };

            var constructor = this.productType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, types, null);

            bool accesModifier = constructor.IsFamily;

            Assert.That(accesModifier, Is.EqualTo(true), "Product protected constructor not found!");
        }

        [Test]
        public void GpuShouldHavePublicConstructor()
        {
            Type[] types = new Type[] { typeof(double) };

            var constructor = this.gpuType.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, types, null);

            bool accesModifier = constructor.IsPublic;

            Assert.That(accesModifier, Is.EqualTo(true), "Gpu public constructor not found!");
        }

        [Test]
        public void HardDriveShouldHavePublicConstructor()
        {
            Type[] types = new Type[] { typeof(double) };

            var constructor = this.hardDriveType.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, types, null);

            bool accesModifier = constructor.IsPublic;

            Assert.That(accesModifier, Is.EqualTo(true), "HardDrive public constructor not found!");
        }

        [Test]
        public void RamShouldHavePublicConstructor()
        {
            Type[] types = new Type[] { typeof(double) };

            var constructor = this.ramType.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, types, null);

            bool accesModifier = constructor.IsPublic;

            Assert.That(accesModifier, Is.EqualTo(true), "Ram public constructor not found!");
        }

        [Test]
        public void SolidStateDriveShouldHavePublicConstructor()
        {
            Type[] types = new Type[] { typeof(double) };

            var constructor = this.solidStateDriveType.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, types, null);

            bool accesModifier = constructor.IsPublic;

            Assert.That(accesModifier, Is.EqualTo(true), "SolidStateDrive public constructor not found!");
        }

        [Test]
        public void ProductShouldHavePrivateFieldPrice()
        {
            var field = this.productType.GetField("price", BindingFlags.Instance | BindingFlags.NonPublic);

            var returnedType = field.FieldType.Name;

            Assert.That(field, Is.Not.Null, "Private field price not found!");

            Assert.That(returnedType, Is.EqualTo("Double"), "Private price field invalid type!");
        }

        [Test]
        public void ProductShouldHavePublicGetMethodPrice()
        {
            Type[] types = new Type[] { typeof(double), typeof(double) };

            var method = this.productType.GetMethod("get_Price", BindingFlags.Instance | BindingFlags.Public);

            var returnedType = method.ReturnType;

            Assert.That(method, Is.Not.Null, "Public price get method not found!");

            Assert.That(returnedType, Is.EqualTo(typeof(double)), "Public price get method invalid type!");
        }

        [Test]
        public void ProductShouldHavePrivateSetMethodPrice()
        {
            Type[] types = new Type[] { typeof(double), typeof(double) };

            var method = this.productType.GetMethod("set_Price", BindingFlags.Instance | BindingFlags.NonPublic);

            var returnedType = method.ReturnType;

            Assert.That(method, Is.Not.Null, "Private price set method not found!");

            Assert.That(returnedType, Is.EqualTo(typeof(void)), "Public price set method invalid type!");
        }

        [Test]
        public void ProductShouldHavePublicGetMethodWeight()
        {
            Type[] types = new Type[] { typeof(double), typeof(double) };

            var method = this.productType.GetMethod("get_Weight", BindingFlags.Instance | BindingFlags.Public);

            var returnedType = method.ReturnType;

            Assert.That(method, Is.Not.Null, "Public weight get method not found!");

            Assert.That(returnedType, Is.EqualTo(typeof(double)), "Public weight get method invalid type!");
        }
    }
}
