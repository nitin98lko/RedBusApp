using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedBusApi.Model;
using RedBusApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedBusApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        PersonRepository repo = null;
        public PersonController()
        {
            repo = new PersonRepository();
        }

        [HttpGet]
        public ActionResult GetAllPerson()
        {
            List<Person> list = repo.GetAllDataAsync();
            return Ok(list);
        }

        
        [HttpPost]
        public ActionResult CreateNewPerson(Person person)
        {
           
                bool res =  repo.CreateDataAsync(person);
                if (res)
                {
                    return Ok(person.PersonName + "\t is created successfully");
                }
                else
                {
                    return BadRequest(person.PersonName + "\t not added");
                }           

        }
    }
}
