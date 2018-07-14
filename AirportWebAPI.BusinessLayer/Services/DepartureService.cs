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

        public IEnumerable<DepartureDto> GetEntities()
        {
            var data = _repository.GetEntities();
            return _mapper.Map<IEnumerable<Departure>, IEnumerable<DepartureDto>>(data);
        }

        public DepartureDto GetEntity(Guid entityId)
        {
            var data = _repository.GetEntity(entityId);
            return _mapper.Map<Departure, DepartureDto>(data);
        }

        public DepartureDto AddEntity(DepartureDto entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<DepartureDto, Departure>(entity);
            _repository.AddEntity(mapedEntity);

            if (!_repository.Save())
            {
                throw new Exception("Adding Departure failed on save.");
            }

            return _mapper.Map<Departure, DepartureDto>(mapedEntity);
        }

        public DepartureDto UpdateEntity(DepartureDto entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Guid entityId)
        {
            var departureFromRepo = _repository.GetEntity(entityId);
            if (departureFromRepo == null)
            {
                throw new NotFoundException();
            }

            _repository.DeleteEntity(departureFromRepo);
            if (!_repository.Save())
            {
                throw new Exception("Deleting Departure failed on save.");
            }
        }
    }
}
