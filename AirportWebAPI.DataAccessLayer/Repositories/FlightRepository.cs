using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirportWebAPI.DataAccessLayer.Abstractions;
using AirportWebAPI.DataAccessLayer.Data;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    public class FlightRepository : BaseRepository<Flight>
    {
        private readonly AirportDbContext _context;

        public FlightRepository(AirportDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
        }

        public override IEnumerable<Flight> GetEntities()
        {
            return _context.Flights
                .Include(f => f.DeparturePoint)
                .Include(f => f.DestinationPoint)
                .OrderBy(f => f.DepartureTime)
                .ToList();
        }

        public override Flight GetEntity(Guid entityId)
        {
            return _context.Flights
                .Include(f => f.DeparturePoint)
                .Include(f => f.DestinationPoint)
                .Include(f => f.Tickets)
                .OrderBy(f => f.DepartureTime)
                .FirstOrDefault(f => f.Id == entityId);
        }

        public override void AddEntity(Flight entity)
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
    }
}
