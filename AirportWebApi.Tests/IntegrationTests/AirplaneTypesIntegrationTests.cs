﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Shared.Exceptions;

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
                cfg.CreateMap<AirplaneType, AirplaneTypeDto>();
                cfg.CreateMap<AirplaneType, AirplaneType>();
            });

            _mapper = new Mapper(mapperConfig);
            _context = new AirportDbContext();
            _repository = new AirplaneTypeRepository(_context, _mapper);
            _validator = new AirplaneTypeDtoValidator();
            _service = new AirplaneTypeService(_mapper, _repository, _validator);

//            _context.Database.EnsureDeleted();
//            _context.Database.EnsureCreated();

            // Ensure seed data for context
            var airplaneTypes = DataSourceStub.Instance.AirplaneTypes;

//            _context.AirplaneTypes.AddRange(airplaneTypes);
//            _context.SaveChanges();
        }

        [TearDown]
        public void Cleanup()
        {
//            _context.Database.EnsureDeleted();
        }

        [Test]
        public async Task GetEntities_When_AirplaneTypeDtoExist_Then_Return_List_AirplaneTypeDto()
        {
            var airplaneTypeDtos = await _service.GetEntitiesAsync();

            Assert.NotNull(airplaneTypeDtos);
            Assert.That(airplaneTypeDtos.Any());
        }

        [Test]
        public async void GetEntity_When_AirplaneTypeDtoExist_Then_Return_AirplaneTypeDto()
        {
            var entity = await _context.AirplaneTypes.FirstAsync();
            var airplaneTypeDto = await _service.GetEntityAsync(entity.Id);

            Assert.NotNull(airplaneTypeDto);
            Assert.AreEqual(entity.Id, airplaneTypeDto.Id);
        }

        [Test]
        public async Task AddEntity_When_ValidAirplaneTypeDto_Then_Return_AirplaneTypeDto()
        {
            var validAirplaneTypeDto = new AirplaneTypeDto()
            {
                Model = "Airbus A310",
                NumberOfSeats = 183,
                LoadCapacity = 164000
            };

            var airplaneTypeDto = await _service.AddEntityAsync(validAirplaneTypeDto);

            Assert.NotNull(airplaneTypeDto);
            Assert.AreEqual(validAirplaneTypeDto.NumberOfSeats, airplaneTypeDto.NumberOfSeats);
        }

        [Test]
        public void AddEntity_When_InvallidAirplaneTypeDto_Then_ReturnBadRequestException()
        {
            var invalidAirplaneTypeDto = new AirplaneTypeDto()
            {
                Model = "Airbus A310"
            };

            Assert.Throws<BadRequestException>(() => _service.AddEntityAsync(invalidAirplaneTypeDto));
        }

        [Test]
        public void UpdateEntity_When_ValidAirplaneTypeDto_Then_Return_AirplaneTypeDto()
        {
            var airplaneType = _context.AirplaneTypes.First();
            var airplaneTypeDto = new AirplaneTypeDto();
            _mapper.Map(airplaneType, airplaneTypeDto);
            airplaneTypeDto.Model = "Boeing-747";

            var entity = _service.UpdateEntityAsync(airplaneTypeDto);

            Assert.NotNull(entity);
            Assert.AreEqual(airplaneType.Id, entity.Id);
        }

        [Test]
        public void UpdateEntity_When_InvalidAirplaneTypeDto_Then_Return_AirplaneTypeDto()
        {
            var airplaneType = _context.AirplaneTypes.First();
            var invalidAirplaneTypeDto = new AirplaneTypeDto();
            _mapper.Map(airplaneType, invalidAirplaneTypeDto);
            invalidAirplaneTypeDto.NumberOfSeats = 1200;

            Assert.Throws<BadRequestException>(() => _service.UpdateEntityAsync(invalidAirplaneTypeDto));
        }

        [Test]
        public void DeleteEntity_When_ByValidId_Then_DoesNotThrow()
        {
            var airplaneType = _context.AirplaneTypes.First();

            Assert.DoesNotThrow(() => _service.DeleteEntityAsync(airplaneType.Id));
        }

        [Test]
        public void DeleteEntity_When_ByInvalidId_Then_Return_NotFoundException()
        {
            Assert.Throws<NotFoundException>(() => _service.DeleteEntityAsync(Guid.NewGuid()));
        }
    }
}
