using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    class DepartureRepository : IRepository<Departure>
    {
        private IAirportContext _context;

        public DepartureRepository(IAirportContext context)
        {
            _context = context;
        }

        public IEnumerable<Departure> GetEntities(IEnumerable<Guid> entityIds)
        {
            return _context.Departures.Where(d => entityIds.Contains(d.Id))
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
            throw new NotImplementedException();
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
