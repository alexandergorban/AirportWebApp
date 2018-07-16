using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirportWebAPI.DataAccessLayer.Data;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AutoMapper;

namespace AirportWebAPI.DataAccessLayer.Abstractions
{
    abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly AirportDbContext _context;
        private readonly IMapper _mapper;

        protected BaseRepository(AirportDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual IEnumerable<TEntity> GetEntities()
        {
            return _context.Set<TEntity>()
                .OrderBy(e => e.Id)
                .ToList();
        }

        public virtual TEntity GetEntity(Guid entityId)
        {
            return _context.Set<TEntity>().FirstOrDefault(e => e.Id == entityId);
        }

        public virtual void AddEntity(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            _context.Set<TEntity>().Add(entity);
        }

        public virtual void UpdateEntity(TEntity entity)
        {
            var entiryFromRepo = _context.Set<TEntity>().First(e => e.Id == entity.Id);
            _mapper.Map(entity, entiryFromRepo);
        }

        public virtual void DeleteEntity(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public bool EntityExists(Guid entityId)
        {
            return _context.Set<TEntity>().Any(c => c.Id == entityId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
