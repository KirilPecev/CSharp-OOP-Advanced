namespace Extended_Database.Entities
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Database : IDatabase
    {
        private List<IPerson> database;

        public Database()
        {
            this.database = new List<IPerson>();
        }

        public List<IPerson> DatabaseInfo => this.database;

        public void Add(IPerson person)
        {
            if (this.database.Contains(person))
            {
                throw new InvalidOperationException("User is already added!");
            }

            if (this.database.Any(p => p.Username == person.Username))
            {
                throw new InvalidOperationException("Username is already added!");
            }

            if (this.database.Any(p => p.Id == person.Id))
            {
                throw new InvalidOperationException("User Id is already added!");
            }

            this.database.Add(person);
        }

        public IPerson FindById(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be negative or zero!");
            }

            var currentPerson = this.database.FirstOrDefault(p => p.Id == id);

            if (currentPerson == null)
            {
                throw new InvalidOperationException("User not found!");
            }

            return currentPerson;
        }

        public IPerson FindByUsername(string username)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException("Username cannot be null!");
            }

            var currentPerson = this.database.FirstOrDefault(p => p.Username == username);

            if (currentPerson == null)
            {
                throw new InvalidOperationException("User not found!");
            }

            return currentPerson;
        }

        public void Remove(IPerson person)
        {
            this.database.Remove(person);
        }
    }
}
