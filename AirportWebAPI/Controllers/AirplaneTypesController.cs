using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/airplanetypes")]
    public class AirplaneTypesController : Controller
    {
        private readonly IService<AirplaneTypeDto> _airplaneTypeService;

        public AirplaneTypesController(IService<AirplaneTypeDto> airplaneTypeService)
        {
            _airplaneTypeService = airplaneTypeService;
        }

        // GET: api/AirplaneTypes
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AirplaneTypes/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/AirplaneTypes
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/AirplaneTypes/5
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
