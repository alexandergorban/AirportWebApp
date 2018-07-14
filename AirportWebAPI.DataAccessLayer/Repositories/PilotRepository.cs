using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirportWebAPI.DataAccessLayer.Data;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    public class PilotRepository : IRepository<Pilot>
    {
        private DataSource _context;

        public PilotRepository(DataSource context)
        {
            _context = context;
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
            throw new NotImplementedException();
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
