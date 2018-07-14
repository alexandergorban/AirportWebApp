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
    [Route("api/v1/flights")]
    public class FlightsController : Controller
    {
        private readonly IService<FlightDto> _flightService;

        public FlightsController(IService<FlightDto> flightService)
        {
            _flightService = flightService;
        }

        // GET: api/v1/flights
        [HttpGet]
        public IActionResult Get()
        {
            var flights = _flightService.GetEntities();
            if (flights == null)
            {
                return NotFound();
            }

            return Ok(flights);
        }

        // GET: api/v1/flights/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return BadRequest();
        }

        // POST: api/v1/flights
        [HttpPost]
        public IActionResult Post([FromBody] FlightDto flightDto)
        {
            return BadRequest();
        }

        // PUT: api/v1/flights/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] FlightDto flightDto)
        {
            return BadRequest();
        }

        // DELETE: api/v1/flights/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return BadRequest();
        }
    }
}
