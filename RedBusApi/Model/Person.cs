using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedBusApi.Model
{
    public class Person
    {

        [Key]
        public int PersonId { get; set; }
       
        public string PersonName { get; set; }
        
        public string PersonPasswd { get; set; }

        public string Role { get; set; }
    }
}
