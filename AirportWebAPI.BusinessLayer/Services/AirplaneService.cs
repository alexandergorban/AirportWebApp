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
    public class AirplaneService : IService<AirplaneDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Airplane> _repository;
        private readonly AbstractValidator<AirplaneDto> _validator;

        public AirplaneService(IMapper mapper,
            IRepository<Airplane> repository,
            AbstractValidator<AirplaneDto> validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<AirplaneDto>> GetEntities()
        {
            var data = await _repository.GetEntities();
            return _mapper.Map<IEnumerable<Airplane>, IEnumerable<AirplaneDto>>(data);
        }

        public async Task<AirplaneDto> GetEntity(Guid entityId)
        {
            var data = await _repository.GetEntity(entityId);
            if (data == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<Airplane, AirplaneDto>(data);
        }

        public async Task<AirplaneDto> AddEntity(AirplaneDto entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<AirplaneDto, Airplane>(entity);
            await _repository.AddEntity(mapedEntity);

            if (!_repository.Save().Result)
            {
                throw new Exception("Adding Airplane failed on save.");
            }

            return _mapper.Map<Airplane, AirplaneDto>(mapedEntity);
        }

        public async Task<AirplaneDto> UpdateEntity(AirplaneDto entity)
        {
            if (!_repository.EntityExists(entity.Id).Result)
            {
                throw new NotFoundException();
            }

            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<AirplaneDto, Airplane>(entity);
            await _repository.UpdateEntity(mapedEntity);

            if (!_repository.Save().Result)
            {
                throw new Exception("Updating Airplane failed on save.");
            }

            return _mapper.Map<Airplane, AirplaneDto>(mapedEntity);
        }

        public async Task DeleteEntity(Guid entityId)
        {
            var airplaneFromRepo = await _repository.GetEntity(entityId);
            if (airplaneFromRepo == null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteEntity(airplaneFromRepo);
            if (!_repository.Save().Result)
            {
                throw new Exception("Deleting Airplane failed on save.");
            }
        }
    }
}
