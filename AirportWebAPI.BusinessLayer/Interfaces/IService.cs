using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AirportWebAPI.DataAccessLayer.Interfaces;
using Shared.Interfaces;

namespace AirportWebAPI.BusinessLayer.Interfaces
{
    public interface IService<TEntity> where TEntity : IModelDto
    {
        Task<IEnumerable<TEntity>> GetEntitiesAsync();
        Task<TEntity> GetEntityAsync(Guid entityId);
        Task<TEntity> AddEntityAsync(TEntity entity);
        Task<TEntity> UpdateEntityAsync(TEntity entity);
        Task DeleteEntityAsync(Guid entityId);
    }
}
