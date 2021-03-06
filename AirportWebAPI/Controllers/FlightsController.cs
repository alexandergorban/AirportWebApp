﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.BusinessLayer.Services;
using AirportWebAPI.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Exceptions;

namespace AirportWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/flights")]
    public class FlightsController : Controller
    {
        private readonly FlightService _flightService;

        public FlightsController(FlightService flightService)
        {
            _flightService = flightService;
        }

        // GET: api/v1/flights
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var flights = await _flightService.GetEntitiesAsync();
            if (flights == null)
            {
                return NotFound();
            }

            return Ok(flights);
        }

        // GET: api/v1/flights/5
        [HttpGet("{id}", Name = "GetFlight")]
        public async Task<IActionResult> Get(Guid id)
        {
            var flight = await _flightService.GetEntityAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            return Ok(flight);
        }

        // POST: api/v1/flights
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FlightDto flightDto)
        {
            try
            {
                var flightToReturn = await _flightService.AddEntityAsync(flightDto);
                return CreatedAtRoute("GetFlight", new { id = flightToReturn.Id }, flightToReturn);
            }
            catch (BadRequestException)
            {
                return BadRequest();
            }
        }

        // PUT: api/v1/flights/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] FlightDto flightDto)
        {
            try
            {
                flightDto.Id = id;
                await _flightService.UpdateEntityAsync(flightDto);
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

        // DELETE: api/v1/flights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _flightService.DeleteEntityAsync(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("withdelay")]
        public async Task<IActionResult> GetWithDelay()
        {
            var flights = await _flightService.GetFlightWithDelay();
            if (flights == null)
            {
                return NotFound();
            }

            return Ok(flights);
        }
    }
}
