﻿using System;
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

        public IEnumerable<AirplaneDto> GetEntities()
        {
            var data = _repository.GetEntities();
            return _mapper.Map<IEnumerable<Airplane>, IEnumerable<AirplaneDto>>(data);
        }

        public AirplaneDto GetEntity(Guid entityId)
        {
            var data = _repository.GetEntity(entityId);
            return _mapper.Map<Airplane, AirplaneDto>(data);
        }

        public AirplaneDto UpdateEntity(AirplaneDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
