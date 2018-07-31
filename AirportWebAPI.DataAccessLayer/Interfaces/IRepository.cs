using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirportWebAPI.DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<IEnumerable<TEntity>> GetEntitiesAsync();
        Task<TEntity> GetEntityAsync(Guid entityId);
        Task AddEntityAsync(TEntity entity);
        Task UpdateEntityAsync(TEntity entity);
        Task DeleteEntityAsync(TEntity entity);
        Task<bool> EntityExistsAsync(Guid entityId);
        Task<bool> SaveAsync();
    }
}
