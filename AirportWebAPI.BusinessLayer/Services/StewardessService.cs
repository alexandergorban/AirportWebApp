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

        public IEnumerable<StewardessDto> GetEntities()
        {
            var data = _repository.GetEntities();
            return _mapper.Map<IEnumerable<Stewardess>, IEnumerable<StewardessDto>>(data);
        }

        public StewardessDto GetEntity(Guid entityId)
        {
            var data = _repository.GetEntity(entityId);
            if (data == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<Stewardess, StewardessDto>(data);
        }

        public StewardessDto AddEntity(StewardessDto entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<StewardessDto, Stewardess>(entity);
            _repository.AddEntity(mapedEntity);

            if (!_repository.Save())
            {
                throw new Exception("Adding Stewardess failed on save.");
            }

            return _mapper.Map<Stewardess, StewardessDto>(mapedEntity);
        }

        public StewardessDto UpdateEntity(StewardessDto entity)
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

            var mapedEntity = _mapper.Map<StewardessDto, Stewardess>(entity);
            _repository.UpdateEntity(mapedEntity);

            if (!_repository.Save())
            {
                throw new Exception("Updating Stewardess failed on save.");
            }

            return _mapper.Map<Stewardess, StewardessDto>(mapedEntity);
        }

        public void DeleteEntity(Guid entityId)
        {
            var stewardessFromRepo = _repository.GetEntity(entityId);
            if (stewardessFromRepo == null)
            {
                throw new NotFoundException();
            }

            _repository.DeleteEntity(stewardessFromRepo);
            if (!_repository.Save())
            {
                throw new Exception("Deleting Stewardess failed on save.");
            }
        }
    }
}
