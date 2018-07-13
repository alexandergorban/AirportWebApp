using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebAPI.DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        List<T> GetEntities();
        T GetEntity();
        bool CreateEntity(T entity);
        bool UpdateEntity(int id, T entity);
        bool DeleteEntity(int id, T entity);
    }
}
