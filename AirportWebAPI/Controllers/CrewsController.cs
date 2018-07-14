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
    [Route("api/v1/crews")]
    public class CrewsController : Controller
    {
        private readonly IService<CrewDto> _crewService;

        public CrewsController(IService<CrewDto> crewService)
        {
            _crewService = crewService;
        }

        // GET: api/v1/crews
        [HttpGet]
        public IActionResult Get()
        {
            var crews = _crewService.GetEntities();
            if (crews == null)
            {
                return NotFound();
            }

            return Ok(crews);
        }

        // GET: api/v1/crews/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var crew = _crewService.GetEntity(id);
            if (crew == null)
            {
                return NotFound();
            }

            return Ok(crew);
        }

        // POST: api/v1/crews
        [HttpPost]
        public IActionResult Post([FromBody] CrewDto crewDto)
        {
            return BadRequest();
        }

        // PUT: api/v1/crews/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] CrewDto crewDto)
        {
            return BadRequest();
        }

        // DELETE: api/v1/crews/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return BadRequest();
        }
    }
}
