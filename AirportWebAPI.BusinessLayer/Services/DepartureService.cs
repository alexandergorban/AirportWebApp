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

        public List<DepartureDto> GetEntities()
        {
            throw new NotImplementedException();
        }

        public DepartureDto GetEntity(DepartureDto entity)
        {
            throw new NotImplementedException();
        }

        public DepartureDto AddEntity(DepartureDto entity)
        {
            throw new NotImplementedException();
        }

        public DepartureDto UpdateEntity(DepartureDto entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(DepartureDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
