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

        public List<PilotDto> GetEntities()
        {
            throw new NotImplementedException();
        }

        public PilotDto GetEntity(PilotDto entity)
        {
            throw new NotImplementedException();
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
