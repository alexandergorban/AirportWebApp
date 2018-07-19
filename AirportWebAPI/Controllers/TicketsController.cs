using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Entities;
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
        public async Task<IActionResult> Get(Guid flightId)
        {
            try
            {
                var tickets = await _ticketService.GetEntities(flightId);
                return Ok(tickets);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // GET: api/v1/flights/{flightId}/tickets/5
        [HttpGet("{id}", Name = "GetTicket")]
        public async Task<IActionResult> Get(Guid flightId, Guid id)
        {
            try
            {
                var ticket = await _ticketService.GetEntity(flightId, id);
                return Ok(ticket);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/v1/flights/{flightId}/tickets
        [HttpPost]
        public async Task<IActionResult> Post(Guid flightId, [FromBody] TicketDto ticketDto)
        {
            try
            {
                ticketDto.FlightId = flightId;
                var ticketToReturn = await _ticketService.AddEntityAsync(ticketDto);
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
        public async Task<IActionResult> Put(Guid flightId, Guid id, [FromBody] TicketDto ticketDto)
        {
            try
            {
                ticketDto.Id = id;
                ticketDto.FlightId = flightId;
                await _ticketService.UpdateEntityAsync(ticketDto);
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
        public async Task<IActionResult> Delete(Guid flightId, Guid id)
        {
            try
            {
                await _ticketService.DeleteEntity(flightId, id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
