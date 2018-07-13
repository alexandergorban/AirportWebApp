using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    class CrewRepository : IRepository<Crew>
    {
        public IEnumerable<Crew> GetEntities(IEnumerable<Guid> entityIds)
        {
            throw new NotImplementedException();
        }

        public Crew GetEntity(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public void AddEntity(Crew entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Crew entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Crew entity)
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
