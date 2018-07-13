using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    class DepartureRepository : IRepository<Departure>
    {
        public IEnumerable<Departure> GetEntities(IEnumerable<Guid> entityIds)
        {
            throw new NotImplementedException();
        }

        public Departure GetEntity(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public void AddEntity(Departure entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Departure entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Departure entity)
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
