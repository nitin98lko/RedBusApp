using Microsoft.AspNetCore.Authorization;
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
    public class TicketController : ControllerBase
    {
        TicketRepository repo = null;
        public TicketController()
        {
            repo = new TicketRepository();
        }
        [Authorize(Roles = RoleModel.user)]
        [HttpGet]
        public ActionResult GetAllTicket()
        {
            List<Ticket> list = repo.GetAllDataAsync();
            return Ok(list);
        }

        [Authorize(Roles = RoleModel.admin)]
        [HttpPost]
        public ActionResult CreateNewTicket(Ticket ticket)
        {

            bool res = repo.CreateDataAsync(ticket);
            if (res)
            {
                return Ok(ticket.TicketName + "\t is created successfully");
            }
            else
            {
                return BadRequest(ticket.TicketName + "\t not added");
            }

        }
    }
}
