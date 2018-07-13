using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    class FlightRepository : IRepository<Flight>
    {
        private IAirportContext _context;

        public FlightRepository(IAirportContext context)
        {
            _context = context;
        }

        public IEnumerable<Flight> GetEntities(IEnumerable<Guid> entityIds)
        {
            return _context.Flights.Where(f => entityIds.Contains(f.Id))
                .OrderBy(f => f.DepartureTime)
                .ToList();
        }

        public Flight GetEntity(Guid entityId)
        {
            return _context.Flights.FirstOrDefault(f => f.Id == entityId);
        }

        public void AddEntity(Flight entity)
        {
            entity.Id = Guid.NewGuid();
            _context.Flights.Add(entity);

            if (entity.Tickets.Any())
            {
                foreach (var entityTicket in entity.Tickets)
                {
                    entityTicket.Id = Guid.NewGuid();
                }
            }
        }

        public void UpdateEntity(Flight entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Flight entity)
        {
            _context.Flights.Remove(entity);
        }

        public bool EntityExists(Guid entityId)
        {
            return _context.Flights.Any(f => f.Id == entityId);
        }

        // Tickets
        public void AddTicketForFlight(Guid flightId, Ticket ticket)
        {
            var flight = GetEntity(flightId);
            if (flight != null)
            {
                if (ticket.Id == Guid.Empty)
                {
                    ticket.Id = Guid.NewGuid();
                }
                flight.Tickets.Add(ticket);
            }
        }

        public void DeleteTicket(Ticket ticket)
        {
            _context.Tickets.Remove(ticket);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
