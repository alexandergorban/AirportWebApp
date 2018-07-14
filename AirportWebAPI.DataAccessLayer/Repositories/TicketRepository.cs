using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirportWebAPI.DataAccessLayer.Data;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;
using AutoMapper;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly DataSource _context;
        private readonly IMapper _mapper;

        public TicketRepository(DataSource context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Ticket> GetEntities()
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
            var ticketFromRepo = _context.Tickets.First(t => t.Id == entity.Id);
            _mapper.Map(entity, ticketFromRepo);
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
