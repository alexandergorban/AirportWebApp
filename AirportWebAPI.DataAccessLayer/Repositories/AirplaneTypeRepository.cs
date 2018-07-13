using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    class AirplaneTypeRepository : IRepository<AirplaneType>
    {
        private IAirportContext _context;

        public AirplaneTypeRepository(IAirportContext context)
        {
            _context = context;
        }

        public IEnumerable<AirplaneType> GetEntities(IEnumerable<Guid> entityIds)
        {
            return _context.AirplaneTypes.Where(t => entityIds.Contains(t.Id))
                .OrderBy(t => t.Model)
                .ToList();
        }

        public AirplaneType GetEntity(Guid entityId)
        {
            return _context.AirplaneTypes.FirstOrDefault(t => t.Id == entityId);
        }

        public void AddEntity(AirplaneType entity)
        {
            entity.Id = Guid.NewGuid();
            _context.AirplaneTypes.Add(entity);
        }

        public void UpdateEntity(AirplaneType entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(AirplaneType entity)
        {
            _context.AirplaneTypes.Remove(entity);
        }

        public bool EntityExists(Guid entityId)
        {
            return _context.AirplaneTypes.Any(t => t.Id == entityId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
