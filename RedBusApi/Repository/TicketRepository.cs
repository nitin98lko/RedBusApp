using RedBusApi.Data;
using RedBusApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedBusApi.Repository
{
    public class TicketRepository
    {
        RedBusContext db = null;
        public TicketRepository()
        {
            db = new RedBusContext();
        }

        public List<Ticket> GetAllDataAsync()
        {
            return db.Tickets.ToList();
        }

        public bool CreateDataAsync(Ticket ticket)
        {
            db.Tickets.Add(ticket);
            db.SaveChanges();
            return true;
        }
    }
}
