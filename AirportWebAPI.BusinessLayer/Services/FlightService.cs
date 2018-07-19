using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Entities;
using AirportWebAPI.DataAccessLayer.Repositories;
using AutoMapper;
using FluentValidation;
using Shared.Exceptions;

namespace AirportWebAPI.BusinessLayer.Services
{
    public class FlightService : IService<FlightDto>
    {
        private readonly IMapper _mapper;
        private readonly FlightRepository _repository;
        private readonly AbstractValidator<FlightDto> _validator;

        public FlightService(IMapper mapper,
            FlightRepository repository,
            AbstractValidator<FlightDto> validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<FlightDto>> GetEntities()
        {
            var data = await _repository.GetEntitiesAsync();
            return _mapper.Map<IEnumerable<Flight>, IEnumerable<FlightDto>>(data);
        }

        public async Task<FlightDto> GetEntity(Guid entityId)
        {
            var data = await _repository.GetEntityAsync(entityId);
            if (data == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<Flight, FlightDto>(data);
        }

        public async Task<FlightDto> AddEntity(FlightDto entity)
        {
            var validationResult = await _validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<FlightDto, Flight>(entity);
            await _repository.AddEntityAsync(mapedEntity);

            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Adding Flight failed on save.");
            }

            return _mapper.Map<Flight, FlightDto>(mapedEntity);
        }

        public async Task<FlightDto> UpdateEntity(FlightDto entity)
        {
            if (!_repository.EntityExistsAsync(entity.Id).Result)
            {
                throw new NotFoundException();
            }

            var validationResult = await _validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<FlightDto, Flight>(entity);
            await _repository.UpdateEntityAsync(mapedEntity);

            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Updating Flight failed on save.");
            }

            return _mapper.Map<Flight, FlightDto>(mapedEntity);
        }

        public async Task DeleteEntity(Guid entityId)
        {
            var flightFromRepo = await _repository.GetEntityAsync(entityId);
            if (flightFromRepo == null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteEntityAsync(flightFromRepo);
            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Deleting Flight failed on save.");
            }
        }

        public async Task<Flight> GetFlightWithDelay()
        {
            return await _repository.GetFlightWithDelay();
        }
    }
}
