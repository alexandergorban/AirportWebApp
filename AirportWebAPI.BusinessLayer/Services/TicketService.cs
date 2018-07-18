using System;
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

        public async Task<IEnumerable<TicketDto>> GetEntities()
        {
            var data = await _repository.GetEntities();
            return _mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDto>>(data);
        }

        public async Task<IEnumerable<TicketDto>> GetEntities(Guid flightId)
        {
            if (!_flightRepository.EntityExists(flightId).Result)
            {
                throw new NotFoundException();
            }

            var ticketsFromRepoByFlight = await _repository.GetEntities(flightId);
            return _mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDto>>(ticketsFromRepoByFlight);
        }

        public async Task<TicketDto> GetEntity(Guid entityId)
        {
            var ticketsFromRepo = await _repository.GetEntity(entityId);
            return _mapper.Map<Ticket, TicketDto>(ticketsFromRepo);
        }

        public async Task<TicketDto> GetEntity(Guid flightId, Guid entityId)
        {
            if (!_flightRepository.EntityExists(flightId).Result)
            {
                throw new NotFoundException();
            }

            var ticketFromRepo = await _repository.GetEntity(entityId);
            if (ticketFromRepo == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<Ticket, TicketDto>(ticketFromRepo);
        }

        public async Task<TicketDto> AddEntity(TicketDto entity)
        {
            if (!_flightRepository.EntityExists(entity.FlightId).Result)
            {
                throw new NotFoundException();
            }

            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<TicketDto, Ticket>(entity);
            await _repository.AddEntity(mapedEntity);

            if (!_repository.Save().Result)
            {
                throw new Exception("Adding Ticket failed on save.");
            }

            return _mapper.Map<Ticket, TicketDto>(mapedEntity);
        }

        public async Task<TicketDto> AddEntity(Guid flightId, TicketDto entity)
        {
            if (!_flightRepository.EntityExists(flightId).Result)
            {
                throw new NotFoundException();
            }

            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<TicketDto, Ticket>(entity);
            await _repository.AddEntity(mapedEntity);

            if (!_repository.Save().Result)
            {
                throw new Exception("Adding Ticket failed on save.");
            }

            return _mapper.Map<Ticket, TicketDto>(mapedEntity);
        }

        public async Task<TicketDto> UpdateEntity(TicketDto entity)
        {
            if (!_repository.EntityExists(entity.Id).Result)
            {
                throw new NotFoundException();
            }

            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<TicketDto, Ticket>(entity);
            await _repository.UpdateEntity(mapedEntity);

            if (!_repository.Save().Result)
            {
                throw new Exception("Updating Ticket failed on save.");
            }

            return _mapper.Map<Ticket, TicketDto>(mapedEntity);
        }

        public async Task DeleteEntity(Guid entityId)
        {
            var ticketFromRepo = await _repository.GetEntity(entityId);
            if (ticketFromRepo == null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteEntity(ticketFromRepo);
            if (!_repository.Save().Result)
            {
                throw new Exception("Deleting Ticket failed on save.");
            }
        }

        public async Task DeleteEntity(Guid flightId, Guid entityId)
        {
            if (!_flightRepository.EntityExists(flightId).Result)
            {
                throw new NotFoundException();
            }

            var ticketFromRepo = await _repository.GetEntity(entityId);
            if (ticketFromRepo == null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteEntity(ticketFromRepo);
            if (!_repository.Save().Result)
            {
                throw new Exception("Deleting Ticket failed on save.");
            }
        }
    }
}
