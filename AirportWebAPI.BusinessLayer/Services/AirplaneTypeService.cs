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

        public List<AirplaneTypeDto> GetEntities()
        {
            throw new NotImplementedException();
        }

        public AirplaneTypeDto GetEntity(AirplaneTypeDto entity)
        {
            throw new NotImplementedException();
        }

        public AirplaneTypeDto AddEntity(AirplaneTypeDto entity)
        {
            throw new NotImplementedException();
        }

        public AirplaneTypeDto UpdateEntity(AirplaneTypeDto entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(AirplaneTypeDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
