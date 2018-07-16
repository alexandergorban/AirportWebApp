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
    public class AirplaneRepository : BaseRepository<Airplane>
    {
        public AirplaneRepository(AirportDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
