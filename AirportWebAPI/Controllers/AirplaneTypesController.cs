using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Entities;
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
        public async Task<IActionResult> Get()
        {
            var airplaneTypes = await _airplaneTypeService.GetEntitiesAsync();
            if (airplaneTypes == null)
            {
                return NotFound();
            }

            return Ok(airplaneTypes);
        }

        // GET: api/v1/airplanetypes/5
        [HttpGet("{id}", Name = "GetAirplaneType")]
        public async Task<IActionResult> Get(Guid id)
        {
            var airplaneType = await _airplaneTypeService.GetEntityAsync(id);
            if (airplaneType == null)
            {
                return NotFound();
            }

            return Ok(airplaneType);
        }

        // POST: api/v1/airplanetypes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AirplaneTypeDto airplaneTypeDto)
        {
            try
            {
                var airplaneTypeToReturn = await _airplaneTypeService.AddEntityAsync(airplaneTypeDto);
                return CreatedAtRoute("GetAirplaneType", new { id = airplaneTypeToReturn.Id }, airplaneTypeToReturn);
            }
            catch (BadRequestException)
            {
                return BadRequest();
            }
        }

        // PUT: api/v1/airplanetypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] AirplaneTypeDto airplaneTypeDto)
        {
            try
            {
                airplaneTypeDto.Id = id;
                await _airplaneTypeService.UpdateEntityAsync(airplaneTypeDto);
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

        // DELETE: api/v1/airplanetypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _airplaneTypeService.DeleteEntityAsync(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
