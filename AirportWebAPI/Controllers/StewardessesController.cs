using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;
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
        public IActionResult Get()
        {
            var stewardesses = _stewardessService.GetEntities();
            if (stewardesses == null)
            {
                return NotFound();
            }

            return Ok(stewardesses);
        }

        // GET: api/v1/crews/stewardesses/5
        [HttpGet("{id}", Name = "GetStewardess")]
        public IActionResult Get(Guid id)
        {
            var stewardess = _stewardessService.GetEntity(id);
            if (stewardess == null)
            {
                return NotFound();
            }

            return Ok(stewardess);
        }

        // POST: api/v1/crews/stewardesses
        [HttpPost]
        public IActionResult Post([FromBody] StewardessDto stewardessDto)
        {
            try
            {
                var stewardessToReturn = _stewardessService.AddEntity(stewardessDto);
                return CreatedAtRoute("GetStewardess", new { id = stewardessToReturn.Id }, stewardessToReturn);
            }
            catch (BadRequestException)
            {
                return BadRequest();
            }
        }

        // PUT: api/v1/crews/stewardesses/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] StewardessDto stewardessDto)
        {
            try
            {
                stewardessDto.Id = id;
                _stewardessService.UpdateEntity(stewardessDto);
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
        public IActionResult Delete(Guid id)
        {
            try
            {
                _stewardessService.DeleteEntity(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
