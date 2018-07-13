using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    class FlightRepository : IRepository<Flight>
    {
        public IEnumerable<Flight> GetEntities(IEnumerable<Guid> entityIds)
        {
            throw new NotImplementedException();
        }

        public Flight GetEntity(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public void AddEntity(Flight entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Flight entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Flight entity)
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
