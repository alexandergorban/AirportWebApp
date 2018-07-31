using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.BusinessLayer.Services;
using AirportWebAPI.BusinessLayer.Validators;
using AirportWebAPI.DataAccessLayer.Entities;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AutoMapper;
using FakeItEasy;
using FluentValidation;
using NUnit.Framework;
using Shared.Exceptions;

namespace AirportWebApi.Tests.ServiceTests
{
    [TestFixture]
    class AirplaneTypeServiceTests
    {
        private IMapper _mapper;
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
            _validator = new AirplaneTypeDtoValidator();

            _repository = A.Fake<IRepository<AirplaneType>>();
            A.CallTo(() => _repository.GetEntitiesAsync()).Returns(new List<AirplaneType>()
            {
                new AirplaneType()
                {
                    Id = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    Model = "Airbus A310",
                    NumberOfSeats = 183,
                    LoadCapacity = 164000
                },
                new AirplaneType()
                {
                    Id = new Guid("35320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    Model = "Airbus A320",
                    NumberOfSeats = 149,
                    LoadCapacity = 73500
                }
            });
            A.CallTo(() => _repository.GetEntityAsync(new Guid("15320c5e-f58a-4b1f-b63a-8ee07a840bdf")))
                .Returns(new AirplaneType()
                {
                    Id = new Guid("15320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    Model = "SSJ 100/95",
                    NumberOfSeats = 86,
                    LoadCapacity = 42500
                });
            A.CallTo(() => _repository.AddEntityAsync(A<AirplaneType>._));
            A.CallTo(() => _repository.UpdateEntityAsync(A<AirplaneType>._));
            A.CallTo(() => _repository.EntityExistsAsync(Guid.NewGuid())).Returns(true);
            A.CallTo(() => _repository.SaveAsync()).Returns(true);

            _service = new AirplaneTypeService(_mapper, _repository, _validator);
        }

        [Test]
        public async Task GetEntities_When_AirplaneTypeDtoExist_Then_Return_List_AirplaneTypeDto()
        {
            var airplaneTypeDtos = await _service.GetEntitiesAsync();

            Assert.That(airplaneTypeDtos.Count() == 2);
        }

        [Test]
        public void GetEntity_When_AirplaneTypeDtoExist_Then_Return_AirplaneTypeDto()
        {
            var airplaneTypeDto = _service.GetEntityAsync(new Guid("15320c5e-f58a-4b1f-b63a-8ee07a840bdf"));

            Assert.AreEqual(new Guid("15320c5e-f58a-4b1f-b63a-8ee07a840bdf"), airplaneTypeDto.Id);
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

            var result = await _service.AddEntityAsync(validAirplaneTypeDto);

            Assert.AreEqual(validAirplaneTypeDto.NumberOfSeats, result.NumberOfSeats);
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
    }
}
