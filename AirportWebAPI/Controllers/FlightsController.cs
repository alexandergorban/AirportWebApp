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
            return BadRequest();
        }

        // GET: api/v1/flights/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return BadRequest();
        }

        // POST: api/v1/flights
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return BadRequest();
        }

        // PUT: api/v1/flights/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return BadRequest();
        }

        // DELETE: api/v1/flights/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return BadRequest();
        }
    }
}
