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
        public IActionResult Get()
        {
            var departures = _departureService.GetEntities();
            if (departures == null)
            {
                return NotFound();
            }

            return Ok(departures);
        }

        // GET: api/v1/departures/5
        [HttpGet("{id}", Name = "GetDeparture")]
        public IActionResult Get(Guid id)
        {
            var departure = _departureService.GetEntity(id);
            if (departure == null)
            {
                return NotFound();
            }

            return Ok(departure);
        }

        // POST: api/v1/departures
        [HttpPost]
        public IActionResult Post([FromBody] DepartureDto departureDto)
        {
            try
            {
                var departureToReturn = _departureService.AddEntity(departureDto);
                return CreatedAtRoute("GetDeparture", new { id = departureToReturn.Id }, departureToReturn);
            }
            catch (BadRequestException)
            {
                return BadRequest();
            }
        }

        // PUT: api/v1/departures/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] DepartureDto departureDto)
        {
            try
            {
                departureDto.Id = id;
                _departureService.UpdateEntity(departureDto);
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
        public IActionResult Delete(Guid id)
        {
            try
            {
                _departureService.DeleteEntity(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
