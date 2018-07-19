﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AirportWebAPI.DataAccessLayer.Entities;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Repositories;
using AutoMapper;
using FluentValidation;
using Newtonsoft.Json;
using Shared.Exceptions;
using Shared.Models.Json;

namespace AirportWebAPI.BusinessLayer.DataServices
{
    public class CrewDataService
    {
        private readonly IMapper _mapper;
        private readonly CrewRepository _repository;
        private readonly AbstractValidator<CrewDto> _validator;

        public CrewDataService(IMapper mapper,
            CrewRepository repository,
            AbstractValidator<CrewDto> validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public async Task EntitiesLoadSaveToDbLog(string url)
        {
            var entitiesFromResource = await GetDataAsync(url);

            var addEntitiesToDbTask = AddEntitiesToDbAsync(entitiesFromResource);
            var writeEntitiesToLogTask = WriteLogAsync(entitiesFromResource);

            await Task.WhenAll(addEntitiesToDbTask, writeEntitiesToLogTask);
        }

        public async Task<List<JsonCrewDto>> GetDataAsync(string url)
        {
            HttpWebRequest httpWebRequest = WebRequest.CreateHttp(url);
            httpWebRequest.Method = "GET";
            httpWebRequest.ContentType = "application/json";

            var response = await httpWebRequest.GetResponseAsync() as HttpWebResponse;
            var stream = response.GetResponseStream();

            using (var reader = new StreamReader(stream))
            {
                var result = JsonConvert
                    .DeserializeObject<List<JsonCrewDto>>(
                        await reader.ReadToEndAsync());

                return result;
            }
        }

        public async Task AddEntitiesToDbAsync(List<JsonCrewDto> entities)
        {
            if (entities == null)
            {
                throw new BadRequestException();
            }

            var entitiesToAdd = entities.Select(e => e).Take(10).ToList();
            var models = _mapper.Map<List<JsonCrewDto>, List<Crew>>(entitiesToAdd);

            await _repository.AddEntities(models);

            if (!_repository.Save().Result)
            {
                throw new Exception("Adding Crew failed on save.");
            }
        }

        public async Task WriteLogAsync(List<JsonCrewDto> entities)
        {
            if (entities == null)
            {
                throw new BadRequestException();
            }

            string path = $"../Logs/log_{DateTime.Now.ToString().Replace(':', '_')}.csv'";

            using (StreamWriter sw = new StreamWriter(path, false))
            {
                foreach (var jsonCrewDto in entities)
                {
                    await sw.WriteLineAsync(
                        $"{jsonCrewDto.Id}, {jsonCrewDto.Pilot.First().FirstName} {jsonCrewDto.Pilot.First().LastName}, Stewardesses: {jsonCrewDto.Stewardesses.Count}");
                }
            }
        }
    }
}
