using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirportWebAPI.DataAccessLayer.Data;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Entities;
using AutoMapper;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    public class CrewRepository : IRepository<Crew>
    {
        private readonly DataSource _context;
        private readonly IMapper _mapper;

        public CrewRepository(DataSource context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Crew> GetEntities()
        {
            return _context.Crews
                .OrderBy(c => c.Id)
                .ToList();
        }

        public Crew GetEntity(Guid entityId)
        {
            return _context.Crews.FirstOrDefault(c => c.Id == entityId);
        }

        public void AddEntity(Crew entity)
        {
            entity.Id = Guid.NewGuid();
            _context.Crews.Add(entity);
        }

        public void UpdateEntity(Crew entity)
        {
            var crewFromRepo = _context.Crews.First(c => c.Id == entity.Id);
            _mapper.Map(entity, crewFromRepo);
        }

        public void DeleteEntity(Crew entity)
        {
            _context.Crews.Remove(entity);
        }

        public bool EntityExists(Guid entityId)
        {
            return _context.Crews.Any(c => c.Id == entityId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
