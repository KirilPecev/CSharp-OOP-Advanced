namespace ExtendDatabase.Tests
{
    using Extended_Database.Entities;
    using Extended_Database.Entities.Contracts;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class DataTests
    {
        private const long id = 123456789106;
        private const string username = "Pesho";

        private IDatabase database;

        [SetUp]
        public void InitializeDatabase()
        {
            this.database = new Database();
        }

        [Test]
        public void AddPersonMethodShouldAddPerson()
        {
            Mock<IPerson> fakePerson = new Mock<IPerson>();
            fakePerson.Setup(p => p.Id).Returns(id);
            fakePerson.Setup(p => p.Username).Returns(username);

            this.database.Add(fakePerson.Object);

            IPerson actualValue = this.database.DatabaseInfo.Last();

            Assert.That(actualValue, Is.EqualTo(fakePerson.Object),"Add method doesn't add person!");
        }

        [Test]
        public void AddPersonMethodShouldThrowInvalidOperationException()
        {
            Mock<IPerson> fakePerson = new Mock<IPerson>();
            fakePerson.Setup(p => p.Id).Returns(id);
            fakePerson.Setup(p => p.Username).Returns(username);

            this.database.Add(fakePerson.Object);

            Assert.Throws<InvalidOperationException>(() => this.database.Add(fakePerson.Object),"Add method doesn't throw exception!");
        }

        [Test]
        public void AddPersonMethodShouldThrowInvalidOperationExceptionByUsername()
        {
            Mock<IPerson> fakePerson = new Mock<IPerson>();
            fakePerson.Setup(p => p.Id).Returns(id);
            fakePerson.Setup(p => p.Username).Returns(username);

            Mock<IPerson> secondFakePerson = new Mock<IPerson>();
            secondFakePerson.Setup(p => p.Id).Returns(id + 10);
            secondFakePerson.Setup(p => p.Username).Returns(username);

            this.database.Add(fakePerson.Object);

            Assert.Throws<InvalidOperationException>(() => this.database.Add(secondFakePerson.Object),"Add method doesn't throw exception!");           
        }

        [Test]
        public void AddPersonMethodShouldThrowInvalidOperationExceptionById()
        {
            Mock<IPerson> fakePerson = new Mock<IPerson>();
            fakePerson.Setup(p => p.Id).Returns(id);
            fakePerson.Setup(p => p.Username).Returns(username);

            Mock<IPerson> secondFakePerson = new Mock<IPerson>();
            secondFakePerson.Setup(p => p.Id).Returns(id);
            secondFakePerson.Setup(p => p.Username).Returns("Gosho");

            this.database.Add(fakePerson.Object);

            Assert.Throws<InvalidOperationException>(() => this.database.Add(secondFakePerson.Object), "Add method doesn't throw exception!");
        }

        [Test]
        public void FindByIdMethodShoulReturnPerson()
        {
            Mock<IPerson> fakePerson = new Mock<IPerson>();
            fakePerson.Setup(p => p.Id).Returns(id);
            fakePerson.Setup(p => p.Username).Returns(username);

            Mock<IPerson> secondFakePerson = new Mock<IPerson>();
            secondFakePerson.Setup(p => p.Id).Returns(id+10);
            secondFakePerson.Setup(p => p.Username).Returns("Gosho");

            this.database.Add(fakePerson.Object);
            this.database.Add(secondFakePerson.Object);

            IPerson person = this.database.FindById(fakePerson.Object.Id);

            Assert.That(person, Is.EqualTo(fakePerson.Object), "Find by id doesn't work!");
        }

        [Test]
        public void FindByIdMethodShoulThrowInvalidOperationException()
        {
            int id = 10;
            Assert.Throws<InvalidOperationException>(() => this.database.FindById(id), "Find by id doesn't throw InvalidOperationException!");
        }

        [Test]
        public void FindByIdMethodShoulArgumentOutOfRangeException()
        {
            int id = -10;
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(id), "Find by id doesn't throw ArgumentOutOfRangeException!");
        }

        [Test]
        public void FindByUsernameMethodShoulReturnPerson()
        {
            Mock<IPerson> fakePerson = new Mock<IPerson>();
            fakePerson.Setup(p => p.Id).Returns(id);
            fakePerson.Setup(p => p.Username).Returns(username);

            Mock<IPerson> secondFakePerson = new Mock<IPerson>();
            secondFakePerson.Setup(p => p.Id).Returns(id + 10);
            secondFakePerson.Setup(p => p.Username).Returns("Gosho");

            this.database.Add(fakePerson.Object);
            this.database.Add(secondFakePerson.Object);

            IPerson person = this.database.FindByUsername(fakePerson.Object.Username);

            Assert.That(person, Is.EqualTo(fakePerson.Object), "Find by username doesn't work!");
        }

        [Test]
        public void FindByUsernameMethodShoulThrowInvalidOPerationException()
        {
            string username = "Ivan";
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername(username), "Find by username doesn't throw InvalidOperationException!");
        }

        [Test]
        public void FindByUsernameMethodShoulThrowArgumentNullException()
        {
            string username = null;
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(username), "Find by username doesn't throw ArgumentNullException!");
        }

        [Test]
        public void FindByUsernameMethodShoulThrowInvalidOPerationExceptionByCaseSensitive()
        {
            string caseSensitiveUsername = "pesho";

            Mock<IPerson> fakePerson = new Mock<IPerson>();
            fakePerson.Setup(p => p.Id).Returns(id);
            fakePerson.Setup(p => p.Username).Returns(username);

            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername(caseSensitiveUsername), "Find by username doesn't throw InvalidOperationException!");
        }

        [Test]
        public void RemoveMethodShouldRemovePerson()
        {
            Mock<IPerson> fakePerson = new Mock<IPerson>();
            fakePerson.Setup(p => p.Id).Returns(id);
            fakePerson.Setup(p => p.Username).Returns(username);

            Mock<IPerson> secondFakePerson = new Mock<IPerson>();
            secondFakePerson.Setup(p => p.Id).Returns(id + 10);
            secondFakePerson.Setup(p => p.Username).Returns("Gosho");

            this.database.Add(fakePerson.Object);
            this.database.Add(secondFakePerson.Object);
            this.database.Remove(fakePerson.Object);

            Assert.That(this.database.DatabaseInfo.Count, Is.EqualTo(1), "Remove method doesn't work!");
        }
    }
}
