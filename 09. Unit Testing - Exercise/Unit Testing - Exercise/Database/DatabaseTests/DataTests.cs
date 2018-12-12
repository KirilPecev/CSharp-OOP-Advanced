namespace Database.Tests
{
    using Database.Entities;
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class DataTests
    {
        private int[] testArray = new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        private int[] testAddMethodArray = new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 16 };
        private int[] testArrayForException = new int[] { 1, 2, 3, 4, 5, 6, 7,8,9, 10, 11, 12, 13, 14, 15, 16};
        private int[] testArrayForConstructorException = new int[] { 1, 2, 3, 4, 5, 6, 7,8,9, 10, 11, 12, 13, 14, 15, 16, 17};

        [Test]
        public void DatabaseConstructorShouldInitializeArray()
        {
            Database database = new Database(testArray);

            Assert.That(database.Fetch, Is.EqualTo(testArray),"Constructor failed!");
        }

        [Test]
        public void DatabaseConstructorShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => new Database(testArrayForConstructorException), "Constructor doesn't throw InvalidOperationException!");
        }

        [Test]
        public void DatabaseAddMethodShouldAddNumber()
        {
            Database database = new Database(testArray);

            database.Add(16);

            Assert.That(database.Fetch(), Is.EqualTo(testAddMethodArray), "Add method failed!");
        }

        [Test]
        public void DatabaseAddMethodShouldThrowException()
        {
            int num = 10;
            Database database = new Database(testArrayForException);

            Assert.Throws<InvalidOperationException>(() => database.Add(num), "Add method doesn't throw InvalidOperationException!");
        }

        [Test]
        public void DatabaseRemoveMethodShouldRemoveNum()
        {
            Database database = new Database(testArray);

            Assert.That(database.Remove(), Is.EqualTo(testArray.Last()),"Remove method failed!");
        }

        [Test]
        public void DatabaseRemoveMethodShouldThrowException()
        {
            int[] array = new int[0];
            Database database = new Database(array);

            Assert.Throws<InvalidOperationException>(() => database.Remove(),"Remove method doesn't throw InvalidOperationException!");
        }

        [Test]
        public void DatabaseAllMethodsTest()
        {
            Database database = new Database(testArray);

            database.Add(10);
            database.Add(11);
            database.Remove();
            database.Add(9);

            int[] expectedResult = this.testArray.Concat(new int[] { 10, 9 }).ToArray();

            Assert.That(database.Fetch(), Is.EqualTo(expectedResult),"Database failed!");
        }
    }
}
