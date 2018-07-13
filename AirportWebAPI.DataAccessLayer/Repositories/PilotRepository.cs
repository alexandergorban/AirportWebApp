using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    class PilotRepository : IRepository<Pilot>
    {
        public IEnumerable<Pilot> GetEntities(IEnumerable<Guid> entityIds)
        {
            throw new NotImplementedException();
        }

        public Pilot GetEntity(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public void AddEntity(Pilot entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Pilot entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Pilot entity)
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
