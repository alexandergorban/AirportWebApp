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

        public async Task<IEnumerable<CrewDto>> GetEntities()
        {
            var data = await _repository.GetEntities();
            return _mapper.Map<IEnumerable<Crew>, IEnumerable<CrewDto>>(data);
        }

        public async Task<CrewDto> GetEntity(Guid entityId)
        {
            var data = await _repository.GetEntity(entityId);
            if (data == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<Crew, CrewDto>(data);
        }

        public async Task<CrewDto> AddEntity(CrewDto entity)
        {
            var validationResult = await _validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<CrewDto, Crew>(entity);
            await _repository.AddEntity(mapedEntity);

            if (!_repository.Save().Result)
            {
                throw new Exception("Adding Crew failed on save.");
            }

            return _mapper.Map<Crew, CrewDto>(mapedEntity);
        }

        public async Task<CrewDto> UpdateEntity(CrewDto entity)
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

            var mapedEntity = _mapper.Map<CrewDto, Crew>(entity);
            await _repository.UpdateEntity(mapedEntity);

            if (!_repository.Save().Result)
            {
                throw new Exception("Updating Crew failed on save.");
            }

            return _mapper.Map<Crew, CrewDto>(mapedEntity);
        }

        public async Task DeleteEntity(Guid entityId)
        {
            var crewFromRepo = await _repository.GetEntity(entityId);
            if (crewFromRepo == null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteEntity(crewFromRepo);
            if (!_repository.Save().Result)
            {
                throw new Exception("Deleting Crew failed on save.");
            }
        }
    }
}
