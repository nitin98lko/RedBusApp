using Microsoft.EntityFrameworkCore;
using RedBusApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedBusApi.Data
{
    public class RedBusContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; Database=RedBusDb; Integrated Security=SSPI");
        }

        public DbSet<Person>  Persons{ get; set; }

        public DbSet<Ticket>  Tickets { get; set; }
    }
}
