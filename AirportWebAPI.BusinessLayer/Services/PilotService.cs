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
    public class PilotService : IService<PilotDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Pilot> _repository;
        private readonly AbstractValidator<PilotDto> _validator;

        public PilotService(IMapper mapper,
            IRepository<Pilot> repository,
            AbstractValidator<PilotDto> validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public IEnumerable<PilotDto> GetEntities()
        {
            var data = _repository.GetEntities();
            return _mapper.Map<IEnumerable<Pilot>, IEnumerable<PilotDto>>(data);
        }

        public PilotDto GetEntity(Guid entityId)
        {
            var data = _repository.GetEntity(entityId);
            return _mapper.Map<Pilot, PilotDto>(data);
        }

        public PilotDto AddEntity(PilotDto entity)
        {
            throw new NotImplementedException();
        }

        public PilotDto UpdateEntity(PilotDto entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(PilotDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
