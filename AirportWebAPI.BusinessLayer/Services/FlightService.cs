using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Entities;
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

        public async Task<IEnumerable<FlightDto>> GetEntities()
        {
            var data = await _repository.GetEntities();
            return _mapper.Map<IEnumerable<Flight>, IEnumerable<FlightDto>>(data);
        }

        public async Task<FlightDto> GetEntity(Guid entityId)
        {
            var data = await _repository.GetEntity(entityId);
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
            await _repository.AddEntity(mapedEntity);

            if (!_repository.Save().Result)
            {
                throw new Exception("Adding Flight failed on save.");
            }

            return _mapper.Map<Flight, FlightDto>(mapedEntity);
        }

        public async Task<FlightDto> UpdateEntity(FlightDto entity)
        {
            if (!_repository.EntityExists(entity.Id).Result)
            {
                throw new NotFoundException();
            }

            var validationResult = await _validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<FlightDto, Flight>(entity);
            await _repository.UpdateEntity(mapedEntity);

            if (!_repository.Save().Result)
            {
                throw new Exception("Updating Flight failed on save.");
            }

            return _mapper.Map<Flight, FlightDto>(mapedEntity);
        }

        public async Task DeleteEntity(Guid entityId)
        {
            var flightFromRepo = await _repository.GetEntity(entityId);
            if (flightFromRepo == null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteEntity(flightFromRepo);
            if (!_repository.Save().Result)
            {
                throw new Exception("Deleting Flight failed on save.");
            }
        }
    }
}
