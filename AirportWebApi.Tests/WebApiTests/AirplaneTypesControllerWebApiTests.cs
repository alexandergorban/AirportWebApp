using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using AirportWebApi.Tests.Data;
using AirportWebAPI.DataAccessLayer.Data;
using AirportWebAPI.DataAccessLayer.Entities;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AirportWebApi.Tests.WebApiTests
{
    [TestFixture]
    public class AirplaneTypesControllerWebApiTests
    {
        private string _airplaneTypeUrl = "http://localhost:32157/api/v1/airplanetypes";
        private AirportDbContext _context;
        private RESTMethods _restMethods;

        [SetUp]
        public void InitTest()
        {
            _context = new AirportDbContext();
            _restMethods = new RESTMethods();

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

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
        public void Get_When_Request_Then_Respons_200OK()
        {
            _restMethods.Get(_airplaneTypeUrl, out HttpWebResponse response);
            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);
            var result = JsonConvert
                .DeserializeObject<IEnumerable<AirplaneTypeDto>>(
                    reader.ReadToEnd()).ToList();

            Assert.NotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void Get_When_Request_ByValidId_Then_Respons_200OK()
        {
            var entity = _context.AirplaneTypes.First();
            var airplaneTypeUrlById = _airplaneTypeUrl + "/" + entity.Id.ToString();

            _restMethods.Get(airplaneTypeUrlById, out HttpWebResponse response);
            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);
            var result = JsonConvert
                .DeserializeObject<AirplaneTypeDto>(reader.ReadToEnd());

            Assert.NotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(entity.Id, result.Id);
        }

        [Test]
        public void Post_When_Request_ValidAirplaneType_Then_Respons_201OK()
        {
            var validAirplaneTypeDto = new AirplaneTypeDto()
            {
                Model = "Airbus A310",
                NumberOfSeats = 183,
                LoadCapacity = 164000
            };

            _restMethods.Post(_airplaneTypeUrl, out HttpWebResponse response, validAirplaneTypeDto);
            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);
            var result = JsonConvert
                .DeserializeObject<AirplaneTypeDto>(reader.ReadToEnd());

            Assert.NotNull(result);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual(validAirplaneTypeDto.NumberOfSeats, result.NumberOfSeats);
        }

        [Test]
        public void Post_When_Request_InvalidAirplaneType_Then_Respons_400BadRequest()
        {
            var invalidAirplaneTypeDto = new AirplaneTypeDto()
            {
                Model = "Airbus A310"
            };

            var result = new HttpWebResponse();
            try
            {
                _restMethods.Post(_airplaneTypeUrl, out HttpWebResponse response, invalidAirplaneTypeDto);
            }
            catch (WebException e)
            {
                result = e.Response as HttpWebResponse;
            }

            Assert.NotNull(result);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Test]
        public void Put_When_Request_ByValidId_Then_Respons_204NoContent()
        {
            var entity = _context.AirplaneTypes.First();
            entity.Model = "New Model";
            var airplaneTypeUrlById = _airplaneTypeUrl + "/" + entity.Id.ToString();

            _restMethods.Put(airplaneTypeUrlById, out HttpWebResponse response, entity);

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Test]
        public void Put_When_Request_ByInvalidId_Then_Respons_404NotFound()
        {
            var entity = _context.AirplaneTypes.First();
            entity.Model = "New Model";
            var airplaneTypeUrlByInvalidId = _airplaneTypeUrl + "/" + Guid.NewGuid().ToString();

            var result = new HttpWebResponse();
            try
            {
                _restMethods.Put(airplaneTypeUrlByInvalidId, out HttpWebResponse response, entity);
            }
            catch (WebException e)
            {
                result = e.Response as HttpWebResponse;
            }

            Assert.NotNull(result);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Test]
        public void Delete_When_Request_ByValidId_Then_Respons_204NoContent()
        {
            var entity = _context.AirplaneTypes.First();
            var airplaneTypeUrlById = _airplaneTypeUrl + "/" + entity.Id.ToString();

            _restMethods.Delete(airplaneTypeUrlById, out HttpWebResponse response);

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Test]
        public void Delete_When_Request_ByInvalidId_Then_Respons_404NotFound()
        {
            var airplaneTypeUrlByInvalidId = _airplaneTypeUrl + "/" + Guid.NewGuid().ToString();

            var result = new HttpWebResponse();
            try
            {
                _restMethods.Delete(airplaneTypeUrlByInvalidId, out HttpWebResponse response);
            }
            catch (WebException e)
            {
                result = e.Response as HttpWebResponse;
            }

            Assert.NotNull(result);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}
