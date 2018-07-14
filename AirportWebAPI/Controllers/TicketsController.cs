using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Exceptions;

namespace AirportWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/flights/{flightId}/tickets")]
    public class TicketsController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: api/v1/flights/{flightId}/tickets
        [HttpGet]
        public IActionResult Get(Guid flightId)
        {
            try
            {
                var tickets = _ticketService.GetEntities(flightId);
                return Ok(tickets);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // GET: api/v1/flights/{flightId}/tickets/5
        [HttpGet("{id}", Name = "GetTicket")]
        public IActionResult Get(Guid flightId, Guid id)
        {
            try
            {
                var ticket = _ticketService.GetEntity(flightId, id);
                return Ok(ticket);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/v1/flights/{flightId}/tickets
        [HttpPost]
        public IActionResult Post(Guid flightId, [FromBody] TicketDto ticketDto)
        {
            try
            {
                ticketDto.FlightId = flightId;
                var ticketToReturn = _ticketService.AddEntity(ticketDto);
                return CreatedAtRoute("GetTicket", 
                    new { flightId = ticketToReturn.FlightId, id = ticketToReturn.Id }, 
                    ticketToReturn);
            }
            catch (BadRequestException)
            {
                return BadRequest();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/v1/flights/{flightId}/tickets/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid flightId, Guid id, [FromBody] TicketDto ticketDto)
        {
            try
            {
                ticketDto.Id = id;
                ticketDto.FlightId = flightId;
                _ticketService.UpdateEntity(ticketDto);
                return NoContent();
            }
            catch (BadRequestException)
            {
                return BadRequest();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/v1/flights/{flightId}/tickets/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid flightId, Guid id)
        {
            try
            {
                _ticketService.DeleteEntity(flightId, id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
