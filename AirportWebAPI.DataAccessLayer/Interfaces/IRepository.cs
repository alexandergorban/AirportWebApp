using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirportWebAPI.DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<IEnumerable<TEntity>> GetEntities();
        Task<TEntity> GetEntity(Guid entityId);
        Task AddEntity(TEntity entity);
        Task UpdateEntity(TEntity entity);
        Task DeleteEntity(TEntity entity);
        Task<bool> EntityExists(Guid entityId);
        Task<bool> Save();
    }
}
