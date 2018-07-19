using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportWebAPI.BusinessLayer.DataServices;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Exceptions;

namespace AirportWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/crews")]
    public class CrewsController : Controller
    {
        private string resourceUrl = "http://5b128555d50a5c0014ef1204.mockapi.io/crew";

        private readonly IService<CrewDto> _crewService;
        private readonly CrewDataService _crewDataService;

        public CrewsController(IService<CrewDto> crewService, CrewDataService crewDataService)
        {
            _crewService = crewService;
            _crewDataService = crewDataService;
        }

        // GET: api/v1/crews
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var crews = await _crewService.GetEntities();
            if (crews == null)
            {
                return NotFound();
            }

            return Ok(crews);
        }

        // GET: api/v1/crews/5
        [HttpGet("{id}", Name = "GetCrew")]
        public async Task<IActionResult> Get(Guid id)
        {
            var crew = await _crewService.GetEntity(id);
            if (crew == null)
            {
                return NotFound();
            }

            return Ok(crew);
        }

        // POST: api/v1/crews
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CrewDto crewDto)
        {
            try
            {
                var crewToReturn = await _crewService.AddEntity(crewDto);
                return CreatedAtRoute("GetCrew", new { id = crewToReturn.Id }, crewToReturn);
            }
            catch (BadRequestException)
            {
                return BadRequest();
            }
        }

        // PUT: api/v1/crews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CrewDto crewDto)
        {
            try
            {
                crewDto.Id = id;
                await _crewService.UpdateEntity(crewDto);
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

        // DELETE: api/v1/crews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _crewService.DeleteEntity(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // GET: api/v1/crews/loaddata
        [HttpGet("loaddata")]
        public async Task<IActionResult> Load()
        {
            try
            {
                await _crewDataService.EntitiesLoadSaveToDbLog(resourceUrl);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
