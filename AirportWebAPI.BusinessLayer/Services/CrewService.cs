﻿using System;
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

        public async Task<IEnumerable<CrewDto>> GetEntitiesAsync()
        {
            var data = await _repository.GetEntitiesAsync();
            return _mapper.Map<IEnumerable<Crew>, IEnumerable<CrewDto>>(data);
        }

        public async Task<CrewDto> GetEntityAsync(Guid entityId)
        {
            var data = await _repository.GetEntityAsync(entityId);
            if (data == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<Crew, CrewDto>(data);
        }

        public async Task<CrewDto> AddEntityAsync(CrewDto entity)
        {
            var validationResult = await _validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<CrewDto, Crew>(entity);
            await _repository.AddEntityAsync(mapedEntity);

            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Adding Crew failed on save.");
            }

            return _mapper.Map<Crew, CrewDto>(mapedEntity);
        }

        public async Task<CrewDto> UpdateEntityAsync(CrewDto entity)
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

            var mapedEntity = _mapper.Map<CrewDto, Crew>(entity);
            await _repository.UpdateEntityAsync(mapedEntity);

            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Updating Crew failed on save.");
            }

            return _mapper.Map<Crew, CrewDto>(mapedEntity);
        }

        public async Task DeleteEntityAsync(Guid entityId)
        {
            var crewFromRepo = await _repository.GetEntityAsync(entityId);
            if (crewFromRepo == null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteEntityAsync(crewFromRepo);
            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Deleting Crew failed on save.");
            }
        }
    }
}
