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

        // GET: api/v1/airplanetypes
        [HttpGet]
        public IActionResult Get()
        {
            return BadRequest();
        }

        // GET: api/v1/airplanetypes/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return BadRequest();
        }

        // POST: api/v1/airplanetypes
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return BadRequest();
        }

        // PUT: api/v1/airplanetypes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return BadRequest();
        }

        // DELETE: api/v1/airplanetypes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return BadRequest();
        }
    }
}
