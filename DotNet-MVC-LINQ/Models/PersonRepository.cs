using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNet_MVC_LINQ.Models
{
    public class PersonRepository
    {
        PersonDbDataContext context = new PersonDbDataContext();
        public List<Person> GetAll()
        {
            var list = context.Persons.ToList();
            return list;
        }

        public Person Details(int id)
        {
            var person = context.Persons.SingleOrDefault(x => x.id == id);
            return person;
        }

        public Person Edit(Person p)
        {
            var person = context.Persons.SingleOrDefault(x => x.id == p.id);
            person.name = p.name;
            person.email = p.email;
            context.SubmitChanges();
            return p;
        }

        public Person Create(Person p)
        {
            context.Persons.InsertOnSubmit(p);
            context.SubmitChanges();
            //int id = p.id;
            return p;
        }

        public Person Delete(Person p)
        {
            var person = context.Persons.SingleOrDefault(x => x.id == p.id);
            context.Persons.DeleteOnSubmit(person);
            context.SubmitChanges();
            return p;
        }
    }
}