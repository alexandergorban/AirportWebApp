using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

        public override async Task<IEnumerable<Flight>> GetEntitiesAsync()
        {
            return await _context.Flights
                .Include(f => f.DeparturePoint)
                .Include(f => f.DestinationPoint)
                .OrderBy(f => f.DepartureTime)
                .ToListAsync();
        }

        public override async Task<Flight> GetEntityAsync(Guid entityId)
        {
            return await _context.Flights
                .Include(f => f.DeparturePoint)
                .Include(f => f.DestinationPoint)
                .Include(f => f.Tickets)
                .OrderBy(f => f.DepartureTime)
                .FirstOrDefaultAsync(f => f.Id == entityId);
        }

        public override async Task AddEntityAsync(Flight entity)
        {
            entity.Id = Guid.NewGuid();
            await _context.Flights.AddAsync(entity);

            if (entity.Tickets.Any())
            {
                foreach (var entityTicket in entity.Tickets)
                {
                    entityTicket.Id = Guid.NewGuid();
                    
                }
            }
        }

        // Tickets
        public async Task AddTicketForFlight(Guid flightId, Ticket ticket)
        {
            var flight = await GetEntityAsync(flightId);
            if (flight != null)
            {
                if (ticket.Id == Guid.Empty)
                {
                    ticket.Id = Guid.NewGuid();
                }
                flight.Tickets.Add(ticket);
            }
        }

        public Task<Flight> GetFlightWithDelay()
        {
            var taskCompletitionSource = new TaskCompletionSource<Flight>();
            var timer = new Timer()
            {
                Interval = 3000,
                Enabled = true
            };

            timer.Elapsed += (source, args) =>
            {
                try
                {
                    taskCompletitionSource.SetResult(_context.Flights.First());
                    timer.Enabled = false;
                }
                catch (Exception e)
                {
                    taskCompletitionSource.SetException(e);
                }
            };

            return taskCompletitionSource.Task;
        }
    }
}
