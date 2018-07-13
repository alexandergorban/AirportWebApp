using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;
using Shared.Interfaces;

namespace AirportWebAPI.BusinessLayer.Interfaces
{
    interface IService<TEntity> where TEntity : IModelDto
    {
        List<TEntity> GetEntities();
        TEntity GetEntity(TEntity entity);
        TEntity AddEntity(TEntity entity);
        TEntity UpdateEntity(TEntity entity);
        void DeleteEntity(TEntity entity);
    }
}
