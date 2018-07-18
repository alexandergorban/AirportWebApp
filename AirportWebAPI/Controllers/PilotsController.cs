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
    [Route("api/v1/crews/pilots")]
    public class PilotsController : Controller
    {
        private readonly IService<PilotDto> _pilotService;

        public PilotsController(IService<PilotDto> pilotService)
        {
            _pilotService = pilotService;
        }

        // GET: api/v1/crews/pilots
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pilots = await _pilotService.GetEntities();
            if (pilots == null)
            {
                return NotFound();
            }

            return Ok(pilots);
        }

        // GET: api/v1/crews/pilots/5
        [HttpGet("{id}", Name = "GetPilot")]
        public async Task<IActionResult> Get(Guid id)
        {
            var pilot = await _pilotService.GetEntity(id);
            if (pilot == null)
            {
                return NotFound();
            }

            return Ok(pilot);
        }

        // POST: api/v1/crews/pilots
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PilotDto pilotDto)
        {
            try
            {
                var pilotToReturn = await _pilotService.AddEntity(pilotDto);
                return CreatedAtRoute("GetPilot", new { id = pilotToReturn.Id }, pilotToReturn);
            }
            catch (BadRequestException)
            {
                return BadRequest();
            }
        }

        // PUT: api/v1/crews/pilots/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PilotDto pilotDto)
        {
            try
            {
                pilotDto.Id = id;
                await _pilotService.UpdateEntity(pilotDto);
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

        // DELETE: api/v1/crews/pilots/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _pilotService.DeleteEntity(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
