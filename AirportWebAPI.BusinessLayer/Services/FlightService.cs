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
    public class FlightService : IService<FlightDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Flight> _repository;
        private readonly AbstractValidator<FlightDto> _validator;

        public FlightService(IMapper mapper,
            IRepository<Flight> repository,
            AbstractValidator<FlightDto> validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public List<FlightDto> GetEntities()
        {
            throw new NotImplementedException();
        }

        public FlightDto GetEntity(FlightDto entity)
        {
            throw new NotImplementedException();
        }

        public FlightDto AddEntity(FlightDto entity)
        {
            throw new NotImplementedException();
        }

        public FlightDto UpdateEntity(FlightDto entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(FlightDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
