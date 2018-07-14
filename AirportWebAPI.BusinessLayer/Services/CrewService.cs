using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Entities;
using AutoMapper;
using FluentValidation;
using Shared.Exceptions;

namespace AirportWebAPI.BusinessLayer.Services
{
    public class CrewService : IService<CrewDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Crew> _repository;
        private readonly AbstractValidator<CrewDto> _validator;

        public CrewService(IMapper mapper,
            IRepository<Crew> repository,
            AbstractValidator<CrewDto> validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public IEnumerable<CrewDto> GetEntities()
        {
            var data = _repository.GetEntities();
            return _mapper.Map<IEnumerable<Crew>, IEnumerable<CrewDto>>(data);
        }

        public CrewDto GetEntity(Guid entityId)
        {
            var data = _repository.GetEntity(entityId);
            if (data == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<Crew, CrewDto>(data);
        }

        public CrewDto AddEntity(CrewDto entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<CrewDto, Crew>(entity);
            _repository.AddEntity(mapedEntity);

            if (!_repository.Save())
            {
                throw new Exception("Adding Crew failed on save.");
            }

            return _mapper.Map<Crew, CrewDto>(mapedEntity);
        }

        public CrewDto UpdateEntity(CrewDto entity)
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

            var mapedEntity = _mapper.Map<CrewDto, Crew>(entity);
            _repository.UpdateEntity(mapedEntity);

            if (!_repository.Save())
            {
                throw new Exception("Updating Crew failed on save.");
            }

            return _mapper.Map<Crew, CrewDto>(mapedEntity);
        }

        public void DeleteEntity(Guid entityId)
        {
            var crewFromRepo = _repository.GetEntity(entityId);
            if (crewFromRepo == null)
            {
                throw new NotFoundException();
            }

            _repository.DeleteEntity(crewFromRepo);
            if (!_repository.Save())
            {
                throw new Exception("Deleting Crew failed on save.");
            }
        }
    }
}
