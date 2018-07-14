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

        public AirplaneDto AddEntity(AirplaneDto entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<AirplaneDto, Airplane>(entity);
            _repository.AddEntity(mapedEntity);

            if (!_repository.Save())
            {
                throw new Exception("Adding Airplane failed on save.");
            }

            return _mapper.Map<Airplane, AirplaneDto>(mapedEntity);
        }

        public AirplaneDto UpdateEntity(AirplaneDto entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<AirplaneDto, Airplane>(entity);
            _repository.UpdateEntity(mapedEntity);

            if (!_repository.Save())
            {
                throw new Exception("Updating Airplane failed on save.");
            }

            return _mapper.Map<Airplane, AirplaneDto>(mapedEntity);
        }

        public void DeleteEntity(Guid entityId)
        {
            var airplaneFromRepo = _repository.GetEntity(entityId);
            if (airplaneFromRepo == null)
            {
                throw new NotFoundException();
            }

            _repository.DeleteEntity(airplaneFromRepo);
            if (!_repository.Save())
            {
                throw new Exception("Deleting Airplane failed on save.");
            }
        }
    }
}
