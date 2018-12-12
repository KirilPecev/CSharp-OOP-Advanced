namespace CLinkedListTests.Tests
{
    using CustomLinkedList;
    using NUnit.Framework;
    using System;

    public class DynamicListTests
    {
        private DynamicList<string> dynamicList;

        [SetUp]
        public void InitializeList()
        {
            this.dynamicList = new DynamicList<string>();
        }

        [Test]
        public void AddMethodShouldAddItem()
        {
            this.dynamicList.Add("Item");
            this.dynamicList.Add("Item1");
            this.dynamicList.Add("Item2");

            int expectedCount = 3;

            Assert.That(this.dynamicList.Count, Is.EqualTo(expectedCount), "Add method failed!");
        }

        [Test]
        public void RemoveAtMethodShouldRemoveItemAtIndex()
        {
            this.dynamicList.Add("Item");
            this.dynamicList.Add("Item1");
            this.dynamicList.Add("Item2");

            int index = 1;
            int expectedCount = 2;

            this.dynamicList.RemoveAt(index);

            Assert.That(this.dynamicList.Count, Is.EqualTo(expectedCount), "RemoveAt method failed!");
        }

        [Test]
        public void RemoveAtMethodShouldThrowException()
        {
            int index = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() => this.dynamicList.RemoveAt(index), "RemoveAt method doesn't throw ArgumentOutOfRangeException!");
        }

        [Test]
        public void RemoveMethodShouldRemoveItem()
        {
            this.dynamicList.Add("Item");
            this.dynamicList.Add("Item1");
            this.dynamicList.Add("Item2");
            int expectedCount = 2;

            this.dynamicList.Remove("Item1");

            Assert.That(this.dynamicList.Count, Is.EqualTo(expectedCount), "Remove method failed!");
        }

        [Test]
        public void IndexOfMethodShouldReturnIndexOfElement()
        {
            this.dynamicList.Add("Item");
            this.dynamicList.Add("Item1");
            this.dynamicList.Add("Item2");
            int expectedIndex = 1;

            var index = this.dynamicList.IndexOf("Item1");

            Assert.That(index, Is.EqualTo(expectedIndex), "IndexOf method failed!");
        }

        [Test]
        public void ContainsMethodShouldReturnTrue()
        {
            this.dynamicList.Add("Item");
            this.dynamicList.Add("Item1");
            this.dynamicList.Add("Item2");

            var expectedValue = true;

            var hasItem = this.dynamicList.Contains("Item1");

            Assert.That(hasItem, Is.EqualTo(expectedValue), "Contains method failed!");
        }

        [Test]
        public void ContainsMethodShouldReturnFalse()
        {
            this.dynamicList.Add("Item");
            this.dynamicList.Add("Item1");
            this.dynamicList.Add("Item2");

            var expectedValue = false;

            var hasItem = this.dynamicList.Contains("Item5");

            Assert.That(hasItem, Is.EqualTo(expectedValue), "Contains method failed!");
        }

        [Test]
        public void IndexerGetMethodShouldReturnItem()
        {
            this.dynamicList.Add("Item");
            this.dynamicList.Add("Item1");
            this.dynamicList.Add("Item2");

            var expectedValue = "Item";

            var item = this.dynamicList[0];

            Assert.That(item, Is.EqualTo(expectedValue), "Indexer method failed!");
        }

        [Test]
        public void IndexerGetMethodShouldThrowArgumentOutOfRangeException()
        {
            this.dynamicList.Add("Item");
            this.dynamicList.Add("Item1");
            this.dynamicList.Add("Item2");
            int index = 3;
            var expectedMessage = "Invalid index: " + index;
            var actualMessage = String.Empty;

            try
            {
                actualMessage = this.dynamicList[index];
            }
            catch (ArgumentOutOfRangeException ax)
            {
                actualMessage = ax.ParamName;
            }

            Assert.That(actualMessage, Is.EqualTo(expectedMessage), "Indexer doesn't throw ArgumentOutOfRangeException!");
        }

        [Test]
        public void IndexerSetMethodShouldSetItem()
        {
            this.dynamicList.Add("Item");
            this.dynamicList.Add("Item1");
            this.dynamicList.Add("Item2");

            var expectedValue = "item_4";

            this.dynamicList[1] = "item_4";

            var actualValue = this.dynamicList[1];

            Assert.That(actualValue, Is.EqualTo(expectedValue), "Indexer set method failed!");
        }

        [Test]
        public void IndexerSetMethodShouldThrowArgumentOutOfRangeException()
        {
            this.dynamicList.Add("Item");
            this.dynamicList.Add("Item1");
            this.dynamicList.Add("Item2");
            int index = 3;
            var expectedMessage = "Invalid index: " + index;
            var actualMessage = String.Empty;

            try
            {
                this.dynamicList[index] = "item_4";
            }
            catch (ArgumentOutOfRangeException ax)
            {
                actualMessage = ax.ParamName;
            }

            Assert.That(actualMessage, Is.EqualTo(expectedMessage), "Indexer set method doesn't throw ArgumentOutOfRangeException!");
        }
    }
}
