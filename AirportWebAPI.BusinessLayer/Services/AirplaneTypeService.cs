using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;
using AutoMapper;

namespace AirportWebAPI.BusinessLayer.Services
{
    public class AirplaneTypeService : IService<AirplaneTypeDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AirplaneTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
