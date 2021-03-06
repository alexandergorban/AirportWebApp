﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Entities;
using AutoMapper;
using FluentValidation;
using Shared.Exceptions;

namespace AirportWebAPI.BusinessLayer.Services
{
    public class TicketService : ITicketService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Flight> _flightRepository;
        private readonly ITicketRepository _repository;
        private readonly AbstractValidator<TicketDto> _validator;

        public TicketService(IMapper mapper,
            IRepository<Flight> flightRepository,
            ITicketRepository repository,
            AbstractValidator<TicketDto> validator)
        {
            _mapper = mapper;
            _flightRepository = flightRepository;
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<TicketDto>> GetEntitiesAsync()
        {
            var data = await _repository.GetEntitiesAsync();
            return _mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDto>>(data);
        }

        public async Task<IEnumerable<TicketDto>> GetEntitiesAsync(Guid flightId)
        {
            if (!_flightRepository.EntityExistsAsync(flightId).Result)
            {
                throw new NotFoundException();
            }

            var ticketsFromRepoByFlight = await _repository.GetEntitiesAsync(flightId);
            return _mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDto>>(ticketsFromRepoByFlight);
        }

        public async Task<TicketDto> GetEntityAsync(Guid entityId)
        {
            var ticketsFromRepo = await _repository.GetEntityAsync(entityId);
            return _mapper.Map<Ticket, TicketDto>(ticketsFromRepo);
        }

        public async Task<TicketDto> GetEntityAsync(Guid flightId, Guid entityId)
        {
            if (!_flightRepository.EntityExistsAsync(flightId).Result)
            {
                throw new NotFoundException();
            }

            var ticketFromRepo = await _repository.GetEntityAsync(entityId);
            if (ticketFromRepo == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<Ticket, TicketDto>(ticketFromRepo);
        }

        public async Task<TicketDto> AddEntityAsync(TicketDto entity)
        {
            if (!_flightRepository.EntityExistsAsync(entity.FlightId).Result)
            {
                throw new NotFoundException();
            }

            var validationResult = await _validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<TicketDto, Ticket>(entity);
            await _repository.AddEntityAsync(mapedEntity);

            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Adding Ticket failed on save.");
            }

            return _mapper.Map<Ticket, TicketDto>(mapedEntity);
        }

        public async Task<TicketDto> AddEntityAsync(Guid flightId, TicketDto entity)
        {
            if (!_flightRepository.EntityExistsAsync(flightId).Result)
            {
                throw new NotFoundException();
            }

            var validationResult = await _validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<TicketDto, Ticket>(entity);
            await _repository.AddEntityAsync(mapedEntity);

            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Adding Ticket failed on save.");
            }

            return _mapper.Map<Ticket, TicketDto>(mapedEntity);
        }

        public async Task<TicketDto> UpdateEntityAsync(TicketDto entity)
        {
            if (!_repository.EntityExistsAsync(entity.Id).Result)
            {
                throw new NotFoundException();
            }

            var validationResult = await _validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<TicketDto, Ticket>(entity);
            await _repository.UpdateEntityAsync(mapedEntity);

            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Updating Ticket failed on save.");
            }

            return _mapper.Map<Ticket, TicketDto>(mapedEntity);
        }

        public async Task DeleteEntityAsync(Guid entityId)
        {
            var ticketFromRepo = await _repository.GetEntityAsync(entityId);
            if (ticketFromRepo == null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteEntityAsync(ticketFromRepo);
            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Deleting Ticket failed on save.");
            }
        }

        public async Task DeleteEntityAsync(Guid flightId, Guid entityId)
        {
            if (!_flightRepository.EntityExistsAsync(flightId).Result)
            {
                throw new NotFoundException();
            }

            var ticketFromRepo = await _repository.GetEntityAsync(entityId);
            if (ticketFromRepo == null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteEntityAsync(ticketFromRepo);
            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Deleting Ticket failed on save.");
            }
        }
    }
}
