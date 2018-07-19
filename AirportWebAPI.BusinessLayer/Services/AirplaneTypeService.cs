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

        public async Task<IEnumerable<AirplaneTypeDto>> GetEntities()
        {
            var data = await _repository.GetEntities();
            return _mapper.Map<IEnumerable<AirplaneType>, IEnumerable<AirplaneTypeDto>>(data);
        }

        public async Task<AirplaneTypeDto> GetEntity(Guid entityId)
        {
            var data = await _repository.GetEntity(entityId);
            if (data == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<AirplaneType, AirplaneTypeDto>(data);
        }

        public async Task<AirplaneTypeDto> AddEntity(AirplaneTypeDto entity)
        {
            var validationResult = await _validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<AirplaneTypeDto, AirplaneType>(entity);
            await _repository.AddEntity(mapedEntity);

            if (!_repository.Save().Result)
            {
                throw new Exception("Adding AirplaneType failed on save.");
            }

            return _mapper.Map<AirplaneType, AirplaneTypeDto>(mapedEntity);
        }

        public async Task<AirplaneTypeDto> UpdateEntity(AirplaneTypeDto entity)
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

            var mapedEntity = _mapper.Map<AirplaneTypeDto, AirplaneType>(entity);
            await _repository.UpdateEntity(mapedEntity);

            if (!_repository.Save().Result)
            {
                throw new Exception("Updating AirplaneType failed on save.");
            }

            return _mapper.Map<AirplaneType, AirplaneTypeDto>(mapedEntity);
        }

        public async Task DeleteEntity(Guid entityId)
        {
            var airplaneTypeFromRepo = await _repository.GetEntity(entityId);
            if (airplaneTypeFromRepo == null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteEntity(airplaneTypeFromRepo);
            if (!_repository.Save().Result)
            {
                throw new Exception("Deleting AirplaneType failed on save.");
            }
        }
    }
}
