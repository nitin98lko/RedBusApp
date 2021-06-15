using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService.Model
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public String PersonName { get; set; }

        public String PersonPass { get; set; }

        public String Roles { get; set; }
    }
}
