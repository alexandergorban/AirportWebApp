using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AirportWebAPI.DataAccessLayer.Entities;

namespace AirportWebAPI.DataAccessLayer.Interfaces
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Task<IEnumerable<Ticket>> GetEntities(Guid flightId);
    }
}
