using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    class AirplaneTypeRepository : IRepository<AirplaneType>
    {
        public IEnumerable<AirplaneType> GetEntities(IEnumerable<Guid> entityIds)
        {
            throw new NotImplementedException();
        }

        public AirplaneType GetEntity(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public void AddEntity(AirplaneType entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(AirplaneType entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(AirplaneType entity)
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
