using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    class TicketRepository : IRepository<Ticket>
    {
        private IAirportContext _context;

        public TicketRepository(IAirportContext context)
        {
            _context = context;
        }

        public IEnumerable<Ticket> GetEntities(IEnumerable<Guid> entityIds)
        {
            return _context.Tickets.Where(t => entityIds.Contains(t.Id))
                .OrderBy(t => t.Number)
                .ToList();
        }

        public Ticket GetEntity(Guid entityId)
        {
            return _context.Tickets.FirstOrDefault(t => t.Id == entityId);
        }

        public void AddEntity(Ticket entity)
        {
            entity.Id = Guid.NewGuid();
            _context.Tickets.Add(entity);
        }

        public void UpdateEntity(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Ticket entity)
        {
            _context.Tickets.Remove(entity);
        }

        public bool EntityExists(Guid entityId)
        {
            return _context.Tickets.Any(t => t.Id == entityId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
