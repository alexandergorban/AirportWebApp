using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;

namespace AirportWebAPI.DataAccessLayer.Abstractions
{
    abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        public IEnumerable<TEntity> GetEntities()
        {
            throw new NotImplementedException();
        }

        public TEntity GetEntity(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public void AddEntity(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool EntityExists(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
