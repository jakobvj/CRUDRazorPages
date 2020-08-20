using System;
using System.Collections.Generic;
using System.Linq;
using CRUDExample.Data;
using CRUDExample.Models;

namespace CRUD.Data
{
    public class Repository : IRepository
    {
        private List<Person> people;
        public Repository()
        {
            people = new List<Person>
            {
                new Person{ Id=1, Name="Helle"},
                new Person{ Id=2, Name="Christian"}
            };
        }

        public void Insert(Person person)
        {
            person.Id = people.Max(p => p.Id);
            ++person.Id;
            people.Add(person);
        }

        public void Update(Person person)
        {
            int index = people.FindIndex(p => p.Id == person.Id);
            people[index].Name = person.Name;
        }

        public List<Person> GetAll()
        {
            return people;
        }

        public Person GetItemById(int? id)
        {
            return people.SingleOrDefault(p => p.Id == id);
        }

        public void Remove(int id)
        {          
            people.Remove(GetItemById(id));
        }
    }
}
