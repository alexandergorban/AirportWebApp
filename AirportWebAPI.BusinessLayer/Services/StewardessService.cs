using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;
using AutoMapper;
using FluentValidation;

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

        public List<StewardessDto> GetEntities()
        {
            throw new NotImplementedException();
        }

        public StewardessDto GetEntity(StewardessDto entity)
        {
            throw new NotImplementedException();
        }

        public StewardessDto AddEntity(StewardessDto entity)
        {
            throw new NotImplementedException();
        }

        public StewardessDto UpdateEntity(StewardessDto entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(StewardessDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
