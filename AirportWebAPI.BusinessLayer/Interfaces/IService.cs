using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;
using Shared.Interfaces;

namespace AirportWebAPI.BusinessLayer.Interfaces
{
    public interface IService<TEntity> where TEntity : IModelDto
    {
        IEnumerable<TEntity> GetEntities();
        TEntity GetEntity(Guid entityId);
        TEntity AddEntity(TEntity entity);
        TEntity UpdateEntity(TEntity entity);
        void DeleteEntity(TEntity entity);
    }
}
