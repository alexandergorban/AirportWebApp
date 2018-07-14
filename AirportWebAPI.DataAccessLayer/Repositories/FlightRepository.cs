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
    public class FlightRepository : IRepository<Flight>
    {
        private readonly AirportDbContext _context;
        private readonly IMapper _mapper;

        public FlightRepository(AirportDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Flight> GetEntities()
        {
            return _context.Flights
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
            var flightsFromRepo = _context.Flights.First(f => f.Id == entity.Id);
            _mapper.Map(entity, flightsFromRepo);
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
