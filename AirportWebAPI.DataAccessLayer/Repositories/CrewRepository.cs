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
    public class CrewRepository : BaseRepository<Crew>
    {
        private readonly AirportDbContext _context;

        public CrewRepository(AirportDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Crew>> GetEntities()
        {
            return await _context.Crews
                .Include(c => c.Pilot)
                .Include(c => c.Stewardesses)
                .ToListAsync();
        }
    }
}
