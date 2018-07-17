using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirportWebAPI.DataAccessLayer.Abstractions;
using AirportWebAPI.DataAccessLayer.Data;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Entities;
using AutoMapper;

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

        public override IEnumerable<Ticket> GetEntities()
        {
            return _context.Tickets
                .OrderBy(t => t.Number)
                .ToList();
        }

        public IEnumerable<Ticket> GetEntities(Guid flightId)
        {
            return _context.Tickets
                .Where(t => t.FlightId == flightId)
                .OrderBy(t => t.Number)
                .ToList();
        }

        public override Ticket GetEntity(Guid entityId)
        {
            return _context.Tickets.FirstOrDefault(t => t.Id == entityId);
        }

        public override void AddEntity(Ticket entity)
        {
            entity.Id = Guid.NewGuid();
            _context.Tickets.Add(entity);
        }
    }
}
