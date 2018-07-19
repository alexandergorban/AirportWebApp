using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportWebAPI.DataAccessLayer.Abstractions;
using AirportWebAPI.DataAccessLayer.Data;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        private readonly AirportDbContext _context;
        private readonly IMapper _mapper;

        public TicketRepository(AirportDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<IEnumerable<Ticket>> GetEntitiesAsync()
        {
            return await _context.Tickets
                .OrderBy(t => t.Number)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetEntities(Guid flightId)
        {
            return await _context.Tickets
                .Where(t => t.FlightId == flightId)
                .OrderBy(t => t.Number)
                .ToListAsync();
        }

        public override async Task<Ticket> GetEntityAsync(Guid entityId)
        {
            return await _context.Tickets.FirstOrDefaultAsync(t => t.Id == entityId);
        }

        public override async Task AddEntityAsync(Ticket entity)
        {
            entity.Id = Guid.NewGuid();
            await _context.Tickets.AddAsync(entity);
        }
    }
}
