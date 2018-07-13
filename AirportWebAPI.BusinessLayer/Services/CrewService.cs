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
    public class CrewService : IService<CrewDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Crew> _repository;
        private readonly AbstractValidator<CrewDto> _validator;

        public CrewService(IMapper mapper,
            IRepository<Crew> repository,
            AbstractValidator<CrewDto> validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public List<CrewDto> GetEntities()
        {
            throw new NotImplementedException();
        }

        public CrewDto GetEntity(CrewDto entity)
        {
            throw new NotImplementedException();
        }

        public CrewDto AddEntity(CrewDto entity)
        {
            throw new NotImplementedException();
        }

        public CrewDto UpdateEntity(CrewDto entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(CrewDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
