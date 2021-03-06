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
    public class StewardessService : IService<StewardessDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Stewardess> _repository;
        private readonly AbstractValidator<StewardessDto> _validator;

        public StewardessService(IMapper mapper,
            IRepository<Stewardess> repository,
            AbstractValidator<StewardessDto> validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<StewardessDto>> GetEntitiesAsync()
        {
            var data = await _repository.GetEntitiesAsync();
            return _mapper.Map<IEnumerable<Stewardess>, IEnumerable<StewardessDto>>(data);
        }

        public async Task<StewardessDto> GetEntityAsync(Guid entityId)
        {
            var data = await _repository.GetEntityAsync(entityId);
            if (data == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<Stewardess, StewardessDto>(data);
        }

        public async Task<StewardessDto> AddEntityAsync(StewardessDto entity)
        {
            var validationResult = await _validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<StewardessDto, Stewardess>(entity);
            await _repository.AddEntityAsync(mapedEntity);

            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Adding Stewardess failed on save.");
            }

            return _mapper.Map<Stewardess, StewardessDto>(mapedEntity);
        }

        public async Task<StewardessDto> UpdateEntityAsync(StewardessDto entity)
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

            var mapedEntity = _mapper.Map<StewardessDto, Stewardess>(entity);
            await _repository.UpdateEntityAsync(mapedEntity);

            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Updating Stewardess failed on save.");
            }

            return _mapper.Map<Stewardess, StewardessDto>(mapedEntity);
        }

        public async Task DeleteEntityAsync(Guid entityId)
        {
            var stewardessFromRepo = await _repository.GetEntityAsync(entityId);
            if (stewardessFromRepo == null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteEntityAsync(stewardessFromRepo);
            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Deleting Stewardess failed on save.");
            }
        }
    }
}
