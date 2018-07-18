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
    public class DepartureService : IService<DepartureDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Departure> _repository;
        private readonly AbstractValidator<DepartureDto> _validator;

        public DepartureService(IMapper mapper,
            IRepository<Departure> repository,
            AbstractValidator<DepartureDto> validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<DepartureDto>> GetEntities()
        {
            var data = await _repository.GetEntities();
            return _mapper.Map<IEnumerable<Departure>, IEnumerable<DepartureDto>>(data);
        }

        public async Task<DepartureDto> GetEntity(Guid entityId)
        {
            var data = await _repository.GetEntity(entityId);
            if (data == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<Departure, DepartureDto>(data);
        }

        public async Task<DepartureDto> AddEntity(DepartureDto entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<DepartureDto, Departure>(entity);
            await _repository.AddEntity(mapedEntity);

            if (!_repository.Save().Result)
            {
                throw new Exception("Adding Departure failed on save.");
            }

            return _mapper.Map<Departure, DepartureDto>(mapedEntity);
        }

        public async Task<DepartureDto> UpdateEntity(DepartureDto entity)
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

            var mapedEntity = _mapper.Map<DepartureDto, Departure>(entity);
            await _repository.UpdateEntity(mapedEntity);

            if (!_repository.Save().Result)
            {
                throw new Exception("Updating Departure failed on save.");
            }

            return _mapper.Map<Departure, DepartureDto>(mapedEntity);
        }

        public async Task DeleteEntity(Guid entityId)
        {
            var departureFromRepo = await _repository.GetEntity(entityId);
            if (departureFromRepo == null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteEntity(departureFromRepo);
            if (!_repository.Save().Result)
            {
                throw new Exception("Deleting Departure failed on save.");
            }
        }
    }
}
