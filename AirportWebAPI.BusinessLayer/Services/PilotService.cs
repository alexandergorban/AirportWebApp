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
            if (data == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<Pilot, PilotDto>(data);
        }

        public PilotDto AddEntity(PilotDto entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<PilotDto, Pilot>(entity);
            _repository.AddEntity(mapedEntity);

            if (!_repository.Save())
            {
                throw new Exception("Adding Pilot failed on save.");
            }

            return _mapper.Map<Pilot, PilotDto>(mapedEntity);
        }

        public PilotDto UpdateEntity(PilotDto entity)
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

            var mapedEntity = _mapper.Map<PilotDto, Pilot>(entity);
            _repository.UpdateEntity(mapedEntity);

            if (!_repository.Save())
            {
                throw new Exception("Updating Pilot failed on save.");
            }

            return _mapper.Map<Pilot, PilotDto>(mapedEntity);
        }

        public void DeleteEntity(Guid entityId)
        {
            var pilotFromRepo = _repository.GetEntity(entityId);
            if (pilotFromRepo == null)
            {
                throw new NotFoundException();
            }

            _repository.DeleteEntity(pilotFromRepo);
            if (!_repository.Save())
            {
                throw new Exception("Deleting Pilot failed on save.");
            }
        }
    }
}
