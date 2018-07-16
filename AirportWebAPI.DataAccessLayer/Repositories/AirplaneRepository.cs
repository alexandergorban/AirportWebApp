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
    public class AirplaneRepository : BaseRepository<Airplane>
    {
        private readonly AirportDbContext _context;

        public AirplaneRepository(AirportDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
        }

        public override IEnumerable<Airplane> GetEntities()
        {
            return _context.Airplanes
                .Include(a => a.AirplaneType);
        }
    }
}
