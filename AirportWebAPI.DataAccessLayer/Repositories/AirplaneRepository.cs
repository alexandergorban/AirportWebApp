using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    class AirplaneRepository : IRepository<Airplane>
    {
        public IEnumerable<Airplane> GetEntities(IEnumerable<Guid> entityIds)
        {
            throw new NotImplementedException();
        }

        public Airplane GetEntity(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public void AddEntity(Airplane entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Airplane entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Airplane entity)
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
