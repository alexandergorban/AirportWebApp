using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.Controllers;
using AirportWebAPI.DataAccessLayer.Entities;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Shared.Exceptions;

namespace AirportWebApi.Tests.ControllerTests
{
    [TestFixture]
    public class AirplaneTypesControllerTests
    {
        [Test]
        public async Task Get_When_All_Then_Return_200OK()
        {
            var airplaneTypeService = A.Fake<IService<AirplaneTypeDto>>();
            A.CallTo(() => airplaneTypeService.GetEntitiesAsync()).Returns(new List<AirplaneTypeDto>());

            var airplaneTypesController = new AirplaneTypesController(airplaneTypeService);
            var result = await airplaneTypesController.Get() as ObjectResult;

            Assert.NotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task Get_When_ById_Then_Return_200OK()
        {
            var airplaneTypeService = A.Fake<IService<AirplaneTypeDto>>();
            A.CallTo(() => airplaneTypeService.GetEntityAsync(Guid.NewGuid())).Returns(new AirplaneTypeDto());

            var airplaneTypesController = new AirplaneTypesController(airplaneTypeService);
            var result = await airplaneTypesController.Get(Guid.NewGuid()) as ObjectResult;

            Assert.NotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task Post_When_AirplaneTypeDto_Valid_Then_Return_201OK()
        {
            var airplaneTypeDtoValid = new AirplaneTypeDto()
            {
                Model = "Boeing-737",
                NumberOfSeats = 140,
                LoadCapacity = 52800
            };

            var airplaneTypeService = A.Fake<IService<AirplaneTypeDto>>();
            A.CallTo(() => airplaneTypeService.AddEntityAsync(airplaneTypeDtoValid))
                .Invokes(() => { airplaneTypeDtoValid.Id = Guid.NewGuid(); })
                .Returns(airplaneTypeDtoValid);

            var airplaneTypesController = new AirplaneTypesController(airplaneTypeService);
            var result = await airplaneTypesController.Post(airplaneTypeDtoValid) as ObjectResult;

            Assert.NotNull(result);
            Assert.AreEqual(201, result.StatusCode);
        }

        [Test]
        public async Task Post_When_AirplaneTypeDto_Invalid_Then_Return_400BadRequest()
        {
            var airplaneTypeDtoInvalid = new AirplaneTypeDto()
            {
                Model = "Boeing-737"
            };

            var airplaneTypeService = A.Fake<IService<AirplaneTypeDto>>();
            A.CallTo(() => airplaneTypeService.AddEntityAsync(airplaneTypeDtoInvalid)).Throws(new BadRequestException());

            var airplaneTypesController = new AirplaneTypesController(airplaneTypeService);
            var result = await airplaneTypesController.Post(airplaneTypeDtoInvalid) as StatusCodeResult;

            Assert.NotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public async Task Put_When_AirplaneTypeDto_Valid_Then_Return_204NoContent()
        {
            var airplaneTypeDtoValid = new AirplaneTypeDto()
            {
                Id = new Guid("45320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                Model = "Boeing-737",
                NumberOfSeats = 400,
                LoadCapacity = 52800
            };

            var airplaneTypeService = A.Fake<IService<AirplaneTypeDto>>();
            A.CallTo(() => airplaneTypeService.UpdateEntityAsync(airplaneTypeDtoValid)).Returns(airplaneTypeDtoValid);

            var airplaneTypesController = new AirplaneTypesController(airplaneTypeService);
            var result = await airplaneTypesController.Put(airplaneTypeDtoValid.Id, airplaneTypeDtoValid) as StatusCodeResult;

            Assert.NotNull(result);
            Assert.AreEqual(204, result.StatusCode);
        }

        [Test]
        public async Task Put_When_AirplaneTypeDto_Invalid_Then_Return_400BadRequest()
        {
            var airplaneTypeDtoInvalid = new AirplaneTypeDto()
            {
                Id = new Guid("45320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                Model = "Boeing-737"
            };

            var airplaneTypeService = A.Fake<IService<AirplaneTypeDto>>();
            A.CallTo(() => airplaneTypeService.UpdateEntityAsync(airplaneTypeDtoInvalid)).Throws(new BadRequestException());

            var airplaneTypesController = new AirplaneTypesController(airplaneTypeService);
            var result = await airplaneTypesController.Put(airplaneTypeDtoInvalid.Id, airplaneTypeDtoInvalid) as StatusCodeResult;

            Assert.NotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public async Task Delete_When_AirplaneTypeId_Exist_Then_Return_204NoContent()
        {
            var airplaneTypeDtoId = new Guid("45320c5e-f58a-4b1f-b63a-8ee07a840bdf");

            var airplaneTypeService = A.Fake<IService<AirplaneTypeDto>>();
            A.CallTo(() => airplaneTypeService.DeleteEntityAsync(airplaneTypeDtoId));

            var airplaneTypesController = new AirplaneTypesController(airplaneTypeService);
            var result = await airplaneTypesController.Delete(airplaneTypeDtoId) as StatusCodeResult;

            Assert.NotNull(result);
            Assert.AreEqual(204, result.StatusCode);
        }

        [Test]
        public async Task Delete_When_AirplaneTypeId_Absent_Then_Return_404NotFound()
        {
            var airplaneTypeDtoId = new Guid("45320c5e-f58a-4b1f-b63a-8ee07a840bdf");

            var airplaneTypeService = A.Fake<IService<AirplaneTypeDto>>();
            A.CallTo(() => airplaneTypeService.DeleteEntityAsync(airplaneTypeDtoId)).Throws(new NotFoundException());

            var airplaneTypesController = new AirplaneTypesController(airplaneTypeService);
            var result = await airplaneTypesController.Delete(airplaneTypeDtoId) as StatusCodeResult;

            Assert.NotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }
    }
}
