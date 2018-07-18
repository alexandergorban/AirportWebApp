using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirportWebApi.Tests.Data;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.BusinessLayer.Services;
using AirportWebAPI.BusinessLayer.Validators;
using AirportWebAPI.DataAccessLayer.Data;
using AirportWebAPI.DataAccessLayer.Entities;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Repositories;
using AutoMapper;
using FluentValidation;
using NUnit.Framework;

namespace AirportWebApi.Tests.IntegrationTests
{
    [TestFixture]
    public class AirplaneTypesIntegrationTests
    {
        private IMapper _mapper;
        private AirportDbContext _context;
        private IRepository<AirplaneType> _repository;
        private AbstractValidator<AirplaneTypeDto> _validator;
        private IService<AirplaneTypeDto> _service;

        [SetUp]
        public void InitTest()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AirplaneTypeDto, AirplaneType>();
                cfg.CreateMap<AirplaneType, AirplaneType>();
            });

            _mapper = new Mapper(mapperConfig);
            _context = new AirportDbContext();
            _repository = new AirplaneTypeRepository(_context, _mapper);
            _validator = new AirplaneTypeDtoValidator();
            _service = new AirplaneTypeService(_mapper, _repository, _validator);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            // Ensure seed data for context
            var airplaneTypes = DataSourceStub.Instance.AirplaneTypes;

            _context.AirplaneTypes.AddRange(airplaneTypes);
            _context.SaveChanges();
        }

        [TearDown]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
        }

        [Test]
        public void GetEntities_When_AirplaneTypeDtoExist_Then_Return_List_AirplaneTypeDto()
        {
            var airplaneTypeDtos = _service.GetEntities().ToList();

            Assert.NotNull(airplaneTypeDtos);
            Assert.That(airplaneTypeDtos.Count == 4);
        }

        [Test]
        public void GetEntity_When_AirplaneTypeDtoExist_Then_Return_AirplaneTypeDto()
        {
            var entity = _context.AirplaneTypes.First();
            var airplaneTypeDto = _service.GetEntity(entity.Id);

            Assert.NotNull(airplaneTypeDto);
            Assert.AreEqual(entity.Id, airplaneTypeDto.Id);
        }
    }
}
