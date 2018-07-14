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
    public class DepartureRepository : IRepository<Departure>
    {
        private readonly AirportDbContext _context;
        private readonly IMapper _mapper;

        public DepartureRepository(AirportDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Departure> GetEntities()
        {
            return _context.Departures
                .OrderBy(d => d.DepartureTime)
                .ToList();
        }

        public Departure GetEntity(Guid entityId)
        {
            return _context.Departures.FirstOrDefault(d => d.Id == entityId);
        }

        public void AddEntity(Departure entity)
        {
            entity.Id = Guid.NewGuid();
            _context.Departures.Add(entity);
        }

        public void UpdateEntity(Departure entity)
        {
            var departureFromRepo = _context.Departures.First(d => d.Id == entity.Id);
            _mapper.Map(entity, departureFromRepo);

        }

        public void DeleteEntity(Departure entity)
        {
            _context.Departures.Remove(entity);
        }

        public bool EntityExists(Guid entityId)
        {
            return _context.Departures.Any(d => d.Id == entityId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
