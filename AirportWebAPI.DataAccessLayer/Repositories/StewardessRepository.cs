using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    public class StewardessRepository : IRepository<Stewardess>
    {
        private IAirportContext _context;

        public StewardessRepository(IAirportContext context)
        {
            _context = context;
        }

        public IEnumerable<Stewardess> GetEntities()
        {
            return _context.Stewardesses
                .OrderBy(s => s.DateOfBirth)
                .OrderBy(s => s.Surname)
                .ToList();
        }

        public Stewardess GetEntity(Guid entityId)
        {
            return _context.Stewardesses.FirstOrDefault(s => s.Id == entityId);
        }

        public void AddEntity(Stewardess entity)
        {
            entity.Id = Guid.NewGuid();
            _context.Stewardesses.Add(entity);
        }

        public void UpdateEntity(Stewardess entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Stewardess entity)
        {
            _context.Stewardesses.Remove(entity);
        }

        public bool EntityExists(Guid entityId)
        {
            return _context.Stewardesses.Any(s => s.Id == entityId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
