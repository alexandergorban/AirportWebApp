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
    [Route("api/v1/crews/stewardesses")]
    public class StewardessesController : Controller
    {
        private readonly IService<StewardessDto> _stewardessService;

        public StewardessesController(IService<StewardessDto> stewardessService)
        {
            _stewardessService = stewardessService;
        }

        // GET: api/v1/crews/stewardesses
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var stewardesses = await _stewardessService.GetEntitiesAsync();
            if (stewardesses == null)
            {
                return NotFound();
            }

            return Ok(stewardesses);
        }

        // GET: api/v1/crews/stewardesses/5
        [HttpGet("{id}", Name = "GetStewardess")]
        public async Task<IActionResult> Get(Guid id)
        {
            var stewardess = await _stewardessService.GetEntityAsync(id);
            if (stewardess == null)
            {
                return NotFound();
            }

            return Ok(stewardess);
        }

        // POST: api/v1/crews/stewardesses
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StewardessDto stewardessDto)
        {
            try
            {
                var stewardessToReturn = await _stewardessService.AddEntityAsync(stewardessDto);
                return CreatedAtRoute("GetStewardess", new { id = stewardessToReturn.Id }, stewardessToReturn);
            }
            catch (BadRequestException)
            {
                return BadRequest();
            }
        }

        // PUT: api/v1/crews/stewardesses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] StewardessDto stewardessDto)
        {
            try
            {
                stewardessDto.Id = id;
                await _stewardessService.UpdateEntityAsync(stewardessDto);
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

        // DELETE: api/v1/crews/stewardesses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _stewardessService.DeleteEntityAsync(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
