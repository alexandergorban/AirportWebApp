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
    public class FlightService : IService<FlightDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Flight> _repository;
        private readonly AbstractValidator<FlightDto> _validator;

        public FlightService(IMapper mapper,
            IRepository<Flight> repository,
            AbstractValidator<FlightDto> validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public IEnumerable<FlightDto> GetEntities()
        {
            var data = _repository.GetEntities();
            return _mapper.Map<IEnumerable<Flight>, IEnumerable<FlightDto>>(data);
        }

        public FlightDto GetEntity(Guid entityId)
        {
            var data = _repository.GetEntity(entityId);
            if (data == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<Flight, FlightDto>(data);
        }

        public FlightDto AddEntity(FlightDto entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<FlightDto, Flight>(entity);
            _repository.AddEntity(mapedEntity);

            if (!_repository.Save())
            {
                throw new Exception("Adding Flight failed on save.");
            }

            return _mapper.Map<Flight, FlightDto>(mapedEntity);
        }

        public FlightDto UpdateEntity(FlightDto entity)
        {
            if (!_repository.EntityExists(entity.Id))
            {
                throw new NotFoundException();
            }

            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<FlightDto, Flight>(entity);
            _repository.UpdateEntity(mapedEntity);

            if (!_repository.Save())
            {
                throw new Exception("Updating Flight failed on save.");
            }

            return _mapper.Map<Flight, FlightDto>(mapedEntity);
        }

        public void DeleteEntity(Guid entityId)
        {
            var flightFromRepo = _repository.GetEntity(entityId);
            if (flightFromRepo == null)
            {
                throw new NotFoundException();
            }

            _repository.DeleteEntity(flightFromRepo);
            if (!_repository.Save())
            {
                throw new Exception("Deleting Flight failed on save.");
            }
        }
    }
}
