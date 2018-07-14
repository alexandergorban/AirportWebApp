using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.BusinessLayer.Interfaces
{
    public interface ITicketService : IService<TicketDto>
    {
        IEnumerable<TicketDto> GetEntities(Guid flightId);
        TicketDto GetEntity(Guid flightId, Guid entityId);
        TicketDto AddEntity(Guid flightId, TicketDto entity);
        void DeleteEntity(Guid flightId, Guid entityId);
    }
}
