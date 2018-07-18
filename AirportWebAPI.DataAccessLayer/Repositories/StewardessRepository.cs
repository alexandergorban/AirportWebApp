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
    public class StewardessRepository : BaseRepository<Stewardess>
    {
        private readonly AirportDbContext _context;

        public StewardessRepository(AirportDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Stewardess>> GetEntities()
        {
            return await _context.Stewardesses
                .OrderBy(s => s.Name)
                .OrderBy(s => s.Surname)
                .ToListAsync();
        }
    }
}
