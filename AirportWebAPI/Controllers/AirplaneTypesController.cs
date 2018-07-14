using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;
using Shared.Exceptions;

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
            var airplaneTypes = _airplaneTypeService.GetEntities();
            if (airplaneTypes == null)
            {
                return NotFound();
            }

            return Ok(airplaneTypes);
        }

        // GET: api/v1/airplanetypes/5
        [HttpGet("{id}", Name = "GetAirplaneType")]
        public IActionResult Get(Guid id)
        {
            var airplaneType = _airplaneTypeService.GetEntity(id);
            if (airplaneType == null)
            {
                return NotFound();
            }

            return Ok(airplaneType);
        }

        // POST: api/v1/airplanetypes
        [HttpPost]
        public IActionResult Post([FromBody] AirplaneTypeDto airplaneTypeDto)
        {
            try
            {
                var airplaneTypeToReturn = _airplaneTypeService.AddEntity(airplaneTypeDto);
                return CreatedAtRoute("GetAirplaneType", new { id = airplaneTypeToReturn.Id }, airplaneTypeToReturn);
            }
            catch (BadRequestException)
            {
                return BadRequest();
            }
        }

        // PUT: api/v1/airplanetypes/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id)
        {
            return BadRequest();
        }

        // DELETE: api/v1/airplanetypes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _airplaneTypeService.DeleteEntity(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
