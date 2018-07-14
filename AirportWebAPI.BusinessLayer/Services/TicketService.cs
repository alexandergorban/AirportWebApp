using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;
using AutoMapper;
using FluentValidation;

namespace AirportWebAPI.BusinessLayer.Services
{
    public class TicketService : IService<TicketDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Ticket> _repository;
        private readonly AbstractValidator<TicketDto> _validator;

        public TicketService(IMapper mapper,
            IRepository<Ticket> repository,
            AbstractValidator<TicketDto> validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public IEnumerable<TicketDto> GetEntities()
        {
            var data = _repository.GetEntities();
            return _mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDto>>(data);
        }

        public TicketDto GetEntity(Guid entityId)
        {
            var data = _repository.GetEntity(entityId);
            return _mapper.Map<Ticket, TicketDto>(data);
        }

        public TicketDto AddEntity(TicketDto entity)
        {
            throw new NotImplementedException();
        }

        public TicketDto UpdateEntity(TicketDto entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(TicketDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
