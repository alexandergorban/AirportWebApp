using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebAPI.DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> GetEntities(IEnumerable<Guid> entityIds);
        T GetEntity(Guid entityId);
        void AddEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);
        bool EntityExists(Guid entityId);
        bool Save();
    }
}
