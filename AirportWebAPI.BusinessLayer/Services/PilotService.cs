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

        public async Task<IEnumerable<PilotDto>> GetEntities()
        {
            var data = await _repository.GetEntitiesAsync();
            return _mapper.Map<IEnumerable<Pilot>, IEnumerable<PilotDto>>(data);
        }

        public async Task<PilotDto> GetEntity(Guid entityId)
        {
            var data = await _repository.GetEntityAsync(entityId);
            if (data == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<Pilot, PilotDto>(data);
        }

        public async Task<PilotDto> AddEntity(PilotDto entity)
        {
            var validationResult = await _validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<PilotDto, Pilot>(entity);
            await _repository.AddEntityAsync(mapedEntity);

            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Adding Pilot failed on save.");
            }

            return _mapper.Map<Pilot, PilotDto>(mapedEntity);
        }

        public async Task<PilotDto> UpdateEntity(PilotDto entity)
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

            var mapedEntity = _mapper.Map<PilotDto, Pilot>(entity);
            await _repository.UpdateEntityAsync(mapedEntity);

            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Updating Pilot failed on save.");
            }

            return _mapper.Map<Pilot, PilotDto>(mapedEntity);
        }

        public async Task DeleteEntity(Guid entityId)
        {
            var pilotFromRepo = await _repository.GetEntityAsync(entityId);
            if (pilotFromRepo == null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteEntityAsync(pilotFromRepo);
            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Deleting Pilot failed on save.");
            }
        }
    }
}
