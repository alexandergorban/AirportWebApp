using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirportWebAPI.DataAccessLayer.Data;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;
using AutoMapper;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    public class PilotRepository : IRepository<Pilot>
    {
        private readonly DataSource _context;
        private readonly IMapper _mapper;

        public PilotRepository(DataSource context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Pilot> GetEntities()
        {
            return _context.Pilots
                .OrderBy(p => p.Name)
                .OrderBy(p => p.Surname)
                .ToList();
        }

        public Pilot GetEntity(Guid entityId)
        {
            return _context.Pilots.FirstOrDefault(p => p.Id == entityId);
        }

        public void AddEntity(Pilot entity)
        {
            entity.Id = Guid.NewGuid();
            _context.Pilots.Add(entity);
        }

        public void UpdateEntity(Pilot entity)
        {
            var pilotFromRepo = _context.Pilots.First(p => p.Id == entity.Id);
            _mapper.Map(entity, pilotFromRepo);
        }

        public void DeleteEntity(Pilot entity)
        {
            _context.Pilots.Remove(entity);
        }

        public bool EntityExists(Guid entityId)
        {
            return _context.Pilots.Any(p => p.Id == entityId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
