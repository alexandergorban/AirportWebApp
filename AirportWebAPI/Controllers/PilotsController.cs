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
        public IActionResult Get()
        {
            var pilots = _pilotService.GetEntities();
            if (pilots == null)
            {
                return NotFound();
            }

            return Ok(pilots);
        }

        // GET: api/v1/crews/pilots/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            return BadRequest();
        }

        // POST: api/v1/crews/pilots
        [HttpPost]
        public IActionResult Post([FromBody] PilotDto pilotDto)
        {
            return BadRequest();
        }

        // PUT: api/v1/crews/pilots/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] PilotDto pilotDto)
        {
            return BadRequest();
        }

        // DELETE: api/v1/crews/pilots/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return BadRequest();
        }
    }
}
