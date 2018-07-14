using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;
using AutoMapper;
using FluentValidation;
using Shared.Exceptions;

namespace AirportWebAPI.BusinessLayer.Services
{
    public class AirplaneTypeService : IService<AirplaneTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AirplaneType> _repository;
        private readonly AbstractValidator<AirplaneTypeDto> _validator;

        public AirplaneTypeService(IMapper mapper, 
            IRepository<AirplaneType> repository, 
            AbstractValidator<AirplaneTypeDto> validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public IEnumerable<AirplaneTypeDto> GetEntities()
        {
            var data = _repository.GetEntities();
            return _mapper.Map<IEnumerable<AirplaneType>, IEnumerable<AirplaneTypeDto>>(data);
        }

        public AirplaneTypeDto GetEntity(Guid entityId)
        {
            var data = _repository.GetEntity(entityId);
            return _mapper.Map<AirplaneType, AirplaneTypeDto>(data);
        }

        public AirplaneTypeDto AddEntity(AirplaneTypeDto entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<AirplaneTypeDto, AirplaneType>(entity);
            _repository.AddEntity(mapedEntity);

            if (!_repository.Save())
            {
                throw new Exception("Adding AirplaneType failed on save.");
            }

            return _mapper.Map<AirplaneType, AirplaneTypeDto>(mapedEntity);
        }

        public AirplaneTypeDto UpdateEntity(AirplaneTypeDto entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(AirplaneTypeDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
