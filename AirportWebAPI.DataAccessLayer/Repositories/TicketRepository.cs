using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    class TicketRepository : IRepository<Ticket>
    {
        public IEnumerable<Ticket> GetEntities(IEnumerable<Guid> entityIds)
        {
            throw new NotImplementedException();
        }

        public Ticket GetEntity(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public void AddEntity(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Ticket entity)
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
