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
    [Route("api/v1/airplanes")]
    public class AirplanesController : Controller
    {
        private readonly IService<AirplaneDto> _airplaneService;

        public AirplanesController(IService<AirplaneDto> airplaneService)
        {
            _airplaneService = airplaneService;
        }

        // GET: api/v1/airplanes
        [HttpGet]
        public IActionResult Get()
        {
            var airplanes = _airplaneService.GetEntities();
            if (airplanes == null)
            {
                return NotFound();
            }

            return Ok(airplanes);
        }

        // GET: api/v1/airplanes/5
        [HttpGet("{id}", Name = "GetAirplane")]
        public IActionResult Get(Guid id)
        {
            var airplane = _airplaneService.GetEntity(id);
            if (airplane == null)
            {
                return NotFound();
            }

            return Ok(airplane);
        }

        // POST: api/v1/airplanes
        [HttpPost]
        public IActionResult Post([FromBody] AirplaneDto airplaneDto)
        {
            try
            {
                var airplaneToReturn = _airplaneService.AddEntity(airplaneDto);
                return CreatedAtRoute("GetAirplane", new { id = airplaneToReturn.Id }, airplaneToReturn);
            }
            catch (BadRequestException)
            {
                return BadRequest();
            }
        }

        // PUT: api/v1/airplanes/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] AirplaneDto airplaneDto)
        {
            return BadRequest();
        }

        // DELETE: api/v1/airplanes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _airplaneService.DeleteEntity(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
