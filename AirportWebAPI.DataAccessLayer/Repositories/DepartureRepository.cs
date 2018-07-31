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
    public class DepartureRepository : BaseRepository<Departure>
    {
        private readonly AirportDbContext _context;

        public DepartureRepository(AirportDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Departure>> GetEntitiesAsync()
        {
            return await _context.Departures
                .Include(d => d.Flight)
                .Include(d => d.Crew)
                .Include(d => d.Crew.Pilot)
                .Include(d => d.Crew.Stewardesses)
                .Include(d => d.Airplane)
                .Include(d => d.Airplane.AirplaneType)
                .OrderBy(d => d.DepartureTime)
                .ToListAsync();
        }
    }
}
