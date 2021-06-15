using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedBusApi.Model
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public String TicketName { get; set; }
        public String TicketType { get; set; }
    }
}
