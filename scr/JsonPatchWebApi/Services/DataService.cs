using JsonPatchWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JsonPatchWebApi.Services
{
    public class DataService : IDataService
    {
        public DataService()
        {
            _people.Add(new Person() { Id = Guid.NewGuid(), Name = "Orhan", Age = 30 });
            _people.Add(new Person() { Id = Guid.NewGuid(), Name = "Rabia", Age = 28 });
            _people.Add(new Person() { Id = Guid.NewGuid(), Name = "Irmak Masal", Age = 0 });
        }

        private List<Person> _people = new List<Person>();

        public Guid Add(Person person)
        {
            person.Id = Guid.NewGuid();
            _people.Add(person);
            return person.Id;
        }

        public Person GetBy(Guid id) => _people.Where(x => x.Id == id).FirstOrDefault();

        public List<Person> GetPeople() => _people;
    }
}