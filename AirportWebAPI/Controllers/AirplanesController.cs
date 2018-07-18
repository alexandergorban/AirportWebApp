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
        public async Task<IActionResult> Get()
        {
            var airplanes = await _airplaneService.GetEntities();
            if (airplanes == null)
            {
                return NotFound();
            }

            return Ok(airplanes);
        }

        // GET: api/v1/airplanes/5
        [HttpGet("{id}", Name = "GetAirplane")]
        public async Task<IActionResult> Get(Guid id)
        {
            var airplane = await _airplaneService.GetEntity(id);
            if (airplane == null)
            {
                return NotFound();
            }

            return Ok(airplane);
        }

        // POST: api/v1/airplanes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AirplaneDto airplaneDto)
        {
            try
            {
                var airplaneToReturn = await _airplaneService.AddEntity(airplaneDto);
                return CreatedAtRoute("GetAirplane", new { id = airplaneToReturn.Id }, airplaneToReturn);
            }
            catch (BadRequestException)
            {
                return BadRequest();
            }
        }

        // PUT: api/v1/airplanes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] AirplaneDto airplaneDto)
        {
            try
            {
                airplaneDto.Id = id;
                await _airplaneService.UpdateEntity(airplaneDto);
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

        // DELETE: api/v1/airplanes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _airplaneService.DeleteEntity(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
