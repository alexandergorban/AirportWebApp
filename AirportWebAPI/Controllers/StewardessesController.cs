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
    [Route("api/Stewardesses")]
    public class StewardessesController : Controller
    {
        private readonly IService<StewardessDto> _stewardessService;

        public StewardessesController(IService<StewardessDto> stewardessService)
        {
            _stewardessService = stewardessService;
        }

        // GET: api/Stewardesses
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Stewardesses/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Stewardesses
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Stewardesses/5
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
