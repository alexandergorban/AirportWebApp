using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirportWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/flights/{flightId}/tickets")]
    public class TicketsController : Controller
    {
        private readonly IService<TicketDto> _ticketService;

        public TicketsController(IService<TicketDto> ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: api/v1/flights/{flightId}/tickets
        [HttpGet]
        public IActionResult Get(Guid flightId)
        {
            var tickets = _ticketService.GetEntities();
            if (tickets == null)
            {
                return NotFound();
            }

            return Ok(tickets);
        }

        // GET: api/v1/flights/{flightId}/tickets/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid flightId, Guid id)
        {
            return BadRequest();
        }

        // POST: api/v1/flights/{flightId}/tickets
        [HttpPost]
        public IActionResult Post(Guid flightId, [FromBody] TicketDto ticketDto)
        {
            return BadRequest();
        }

        // PUT: api/v1/flights/{flightId}/tickets/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid flightId, Guid id, [FromBody] TicketDto ticketDto)
        {
            return BadRequest();
        }

        // DELETE: api/v1/flights/{flightId}/tickets/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid flightId, Guid id)
        {
            return BadRequest();
        }
    }
}
