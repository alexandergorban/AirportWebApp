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

        // GET: api/Crews
        [HttpGet]
        public IActionResult Get()
        {
            return BadRequest();
        }

        // GET: api/Crews/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return BadRequest();
        }
        
        // POST: api/Crews
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return BadRequest();
        }
        
        // PUT: api/Crews/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return BadRequest();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return BadRequest();
        }
    }
}
