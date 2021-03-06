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

        public async Task<IEnumerable<AirplaneTypeDto>> GetEntitiesAsync()
        {
            var data = await _repository.GetEntitiesAsync();
            return _mapper.Map<IEnumerable<AirplaneType>, IEnumerable<AirplaneTypeDto>>(data);
        }

        public async Task<AirplaneTypeDto> GetEntityAsync(Guid entityId)
        {
            var data = await _repository.GetEntityAsync(entityId);
            if (data == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<AirplaneType, AirplaneTypeDto>(data);
        }

        public async Task<AirplaneTypeDto> AddEntityAsync(AirplaneTypeDto entity)
        {
            var validationResult = await _validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<AirplaneTypeDto, AirplaneType>(entity);
            await _repository.AddEntityAsync(mapedEntity);

            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Adding AirplaneType failed on save.");
            }

            return _mapper.Map<AirplaneType, AirplaneTypeDto>(mapedEntity);
        }

        public async Task<AirplaneTypeDto> UpdateEntityAsync(AirplaneTypeDto entity)
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

            var mapedEntity = _mapper.Map<AirplaneTypeDto, AirplaneType>(entity);
            await _repository.UpdateEntityAsync(mapedEntity);

            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Updating AirplaneType failed on save.");
            }

            return _mapper.Map<AirplaneType, AirplaneTypeDto>(mapedEntity);
        }

        public async Task DeleteEntityAsync(Guid entityId)
        {
            var airplaneTypeFromRepo = await _repository.GetEntityAsync(entityId);
            if (airplaneTypeFromRepo == null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteEntityAsync(airplaneTypeFromRepo);
            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Deleting AirplaneType failed on save.");
            }
        }
    }
}
