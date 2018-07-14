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
    public class AirplaneTypeRepository : IRepository<AirplaneType>
    {
        private readonly DataSource _context;
        private readonly IMapper _mapper;

        public AirplaneTypeRepository(DataSource context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<AirplaneType> GetEntities()
        {
            return _context.AirplaneTypes
                .OrderBy(t => t.Model)
                .ToList();
        }

        public AirplaneType GetEntity(Guid entityId)
        {
            return _context.AirplaneTypes.FirstOrDefault(t => t.Id == entityId);
        }

        public void AddEntity(AirplaneType entity)
        {
            entity.Id = Guid.NewGuid();
            _context.AirplaneTypes.Add(entity);
        }

        public void UpdateEntity(AirplaneType entity)
        {
            var airplaneTypeFromRepo = _context.AirplaneTypes.First(a => a.Id == entity.Id);
            _mapper.Map(entity, airplaneTypeFromRepo);

        }

        public void DeleteEntity(AirplaneType entity)
        {
            _context.AirplaneTypes.Remove(entity);
        }

        public bool EntityExists(Guid entityId)
        {
            return _context.AirplaneTypes.Any(t => t.Id == entityId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
