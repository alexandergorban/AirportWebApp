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
    public class AirplaneTypeRepository : BaseRepository<AirplaneType>
    {
        private readonly AirportDbContext _context;

        public AirplaneTypeRepository(AirportDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
        }

        public override IEnumerable<AirplaneType> GetEntities()
        {
            return _context.AirplaneTypes
                .OrderBy(t => t.Model)
                .ToList();
        }
    }
}
