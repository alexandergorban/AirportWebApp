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
    public class PilotRepository : BaseRepository<Pilot>
    {
        private readonly AirportDbContext _context;

        public PilotRepository(AirportDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Pilot>> GetEntities()
        {
            return await _context.Pilots
                .OrderBy(p => p.Name)
                .OrderBy(p => p.Surname)
                .ToListAsync();
        }
    }
}
