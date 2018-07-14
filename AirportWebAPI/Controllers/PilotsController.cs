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
    [Route("api/Pilots")]
    public class PilotsController : Controller
    {
        private readonly IService<PilotDto> _pilotService;

        public PilotsController(IService<PilotDto> pilotService)
        {
            _pilotService = pilotService;
        }

        // GET: api/Pilots
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Pilots/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Pilots
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Pilots/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
