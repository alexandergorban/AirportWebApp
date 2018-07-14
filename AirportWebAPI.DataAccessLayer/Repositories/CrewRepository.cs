using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    public class CrewRepository : IRepository<Crew>
    {
        private IAirportContext _context;

        public CrewRepository(IAirportContext context)
        {
            _context = context;
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
            throw new NotImplementedException();
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
