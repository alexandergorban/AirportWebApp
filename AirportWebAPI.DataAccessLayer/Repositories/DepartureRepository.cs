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
    public class DepartureRepository : BaseRepository<Departure>
    {
        private readonly AirportDbContext _context;

        public DepartureRepository(AirportDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
        }

        public override IEnumerable<Departure> GetEntities()
        {
            return _context.Departures
                .OrderBy(d => d.DepartureTime)
                .ToList();
        }
    }
}
