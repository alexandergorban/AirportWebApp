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
    public class AirplaneService : IService<AirplaneDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Airplane> _repository;
        private readonly AbstractValidator<AirplaneDto> _validator;

        public AirplaneService(IMapper mapper,
            IRepository<Airplane> repository,
            AbstractValidator<AirplaneDto> validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public AirplaneDto AddEntity(AirplaneDto entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(AirplaneDto entity)
        {
            throw new NotImplementedException();
        }

        public List<AirplaneDto> GetEntities()
        {
            throw new NotImplementedException();
        }

        public AirplaneDto GetEntity(AirplaneDto entity)
        {
            throw new NotImplementedException();
        }

        public AirplaneDto UpdateEntity(AirplaneDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
