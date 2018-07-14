using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirportWebAPI.DataAccessLayer.Data;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Entities;
using AutoMapper;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    public class AirplaneRepository : IRepository<Airplane>
    {
        private readonly AirportDbContext _context;
        private readonly IMapper _mapper;

        public AirplaneRepository(AirportDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Airplane> GetEntities()
        {
            return _context.Airplanes
                .OrderBy(a => a.Name)
                .ToList();
        }

        public Airplane GetEntity(Guid entityId)
        {
            return _context.Airplanes.FirstOrDefault(a => a.Id == entityId);
        }

        public void AddEntity(Airplane entity)
        {
            entity.Id = Guid.NewGuid();
            _context.Airplanes.Add(entity);
        }

        public void UpdateEntity(Airplane entity)
        {
            var airplaneFromRepo = _context.Airplanes.First(a => a.Id == entity.Id);
            _mapper.Map(entity, airplaneFromRepo);
        }

        public void DeleteEntity(Airplane entity)
        {
            _context.Airplanes.Remove(entity);
        }

        public bool EntityExists(Guid entityId)
        {
            return _context.Airplanes.Any(a => a.Id == entityId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
