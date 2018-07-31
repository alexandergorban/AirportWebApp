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
    [Route("api/v1/departures")]
    public class DeparturesController : Controller
    {
        private readonly IService<DepartureDto> _departureService;

        public DeparturesController(IService<DepartureDto> departureService)
        {
            _departureService = departureService;
        }

        // GET: api/v1/departures
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var departures = await _departureService.GetEntitiesAsync();
            if (departures == null)
            {
                return NotFound();
            }

            return Ok(departures);
        }

        // GET: api/v1/departures/5
        [HttpGet("{id}", Name = "GetDeparture")]
        public async Task<IActionResult> Get(Guid id)
        {
            var departure = await _departureService.GetEntityAsync(id);
            if (departure == null)
            {
                return NotFound();
            }

            return Ok(departure);
        }

        // POST: api/v1/departures
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DepartureDto departureDto)
        {
            try
            {
                var departureToReturn = await _departureService.AddEntityAsync(departureDto);
                return CreatedAtRoute("GetDeparture", new { id = departureToReturn.Id }, departureToReturn);
            }
            catch (BadRequestException)
            {
                return BadRequest();
            }
        }

        // PUT: api/v1/departures/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] DepartureDto departureDto)
        {
            try
            {
                departureDto.Id = id;
                await _departureService.UpdateEntityAsync(departureDto);
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

        // DELETE: api/v1/departures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _departureService.DeleteEntityAsync(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
