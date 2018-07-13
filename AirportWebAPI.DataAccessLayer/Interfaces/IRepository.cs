using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebAPI.DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetEntities(IEnumerable<Guid> entityIds);
        TEntity GetEntity(Guid entityId);
        void AddEntity(TEntity entity);
        void UpdateEntity(TEntity entity);
        void DeleteEntity(TEntity entity);
        bool EntityExists(Guid entityId);
        bool Save();
    }
}
