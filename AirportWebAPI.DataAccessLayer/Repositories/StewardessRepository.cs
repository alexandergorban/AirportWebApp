using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    class StewardessRepository : IRepository<Stewardess>
    {
        public IEnumerable<Stewardess> GetEntities(IEnumerable<Guid> entityIds)
        {
            throw new NotImplementedException();
        }

        public Stewardess GetEntity(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public void AddEntity(Stewardess entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Stewardess entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Stewardess entity)
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
