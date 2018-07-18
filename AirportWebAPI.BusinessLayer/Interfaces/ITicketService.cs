using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AirportWebAPI.DataAccessLayer.Entities;

namespace AirportWebAPI.BusinessLayer.Interfaces
{
    public interface ITicketService : IService<TicketDto>
    {
        Task<IEnumerable<TicketDto>> GetEntities(Guid flightId);
        Task<TicketDto> GetEntity(Guid flightId, Guid entityId);
        Task<TicketDto> AddEntity(Guid flightId, TicketDto entity);
        Task DeleteEntity(Guid flightId, Guid entityId);
    }
}
