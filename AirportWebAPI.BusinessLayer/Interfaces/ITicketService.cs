using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AirportWebAPI.DataAccessLayer.Entities;

namespace AirportWebAPI.BusinessLayer.Interfaces
{
    public interface ITicketService : IService<TicketDto>
    {
        Task<IEnumerable<TicketDto>> GetEntitiesAsync(Guid flightId);
        Task<TicketDto> GetEntityAsync(Guid flightId, Guid entityId);
        Task<TicketDto> AddEntityAsync(Guid flightId, TicketDto entity);
        Task DeleteEntityAsync(Guid flightId, Guid entityId);
    }
}
