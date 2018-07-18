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
        Task<IEnumerable<TEntity>> GetEntities();
        Task<TEntity> GetEntity(Guid entityId);
        Task<TEntity> AddEntity(TEntity entity);
        Task<TEntity> UpdateEntity(TEntity entity);
        Task DeleteEntity(Guid entityId);
    }
}
