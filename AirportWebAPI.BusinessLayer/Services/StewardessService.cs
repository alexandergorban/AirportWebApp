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

        public async Task<IEnumerable<StewardessDto>> GetEntities()
        {
            var data = await _repository.GetEntities();
            return _mapper.Map<IEnumerable<Stewardess>, IEnumerable<StewardessDto>>(data);
        }

        public async Task<StewardessDto> GetEntity(Guid entityId)
        {
            var data = await _repository.GetEntity(entityId);
            if (data == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<Stewardess, StewardessDto>(data);
        }

        public async Task<StewardessDto> AddEntity(StewardessDto entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<StewardessDto, Stewardess>(entity);
            await _repository.AddEntity(mapedEntity);

            if (!_repository.Save().Result)
            {
                throw new Exception("Adding Stewardess failed on save.");
            }

            return _mapper.Map<Stewardess, StewardessDto>(mapedEntity);
        }

        public async Task<StewardessDto> UpdateEntity(StewardessDto entity)
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

            var mapedEntity = _mapper.Map<StewardessDto, Stewardess>(entity);
            await _repository.UpdateEntity(mapedEntity);

            if (!_repository.Save().Result)
            {
                throw new Exception("Updating Stewardess failed on save.");
            }

            return _mapper.Map<Stewardess, StewardessDto>(mapedEntity);
        }

        public async Task DeleteEntity(Guid entityId)
        {
            var stewardessFromRepo = await _repository.GetEntity(entityId);
            if (stewardessFromRepo == null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteEntity(stewardessFromRepo);
            if (!_repository.Save().Result)
            {
                throw new Exception("Deleting Stewardess failed on save.");
            }
        }
    }
}
