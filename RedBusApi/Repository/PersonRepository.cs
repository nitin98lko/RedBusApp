using RedBusApi.Data;
using RedBusApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedBusApi.Repository
{
    public class PersonRepository
    {
        RedBusContext db = null;
        public PersonRepository()
        {
            db = new RedBusContext();
        }

        public List<Person> GetAllDataAsync()
        {
            return db.Persons.ToList();
        }

        public bool CreateDataAsync(Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
            return true;
        }

        internal Person VerifyGuest(Person model)
        {
            Person person = db.Persons.Where(x => x.PersonName.Trim() == model.PersonName.Trim() && x.PersonPasswd.Trim() == model.PersonPasswd.Trim()).SingleOrDefault();

            if (person != null)
            {
                return person;
            }
            else
            {
                return null;
            }                     
        }
    }
}
