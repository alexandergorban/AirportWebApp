using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;
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

        public IEnumerable<TicketDto> GetEntities()
        {
            var data = _repository.GetEntities();
            return _mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDto>>(data);
        }

        public IEnumerable<TicketDto> GetEntities(Guid flightId)
        {
            if (!_flightRepository.EntityExists(flightId))
            {
                throw new NotFoundException();
            }

            var ticketsFromRepoByFlight = _repository.GetEntities(flightId);
            return _mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDto>>(ticketsFromRepoByFlight);
        }

        public TicketDto GetEntity(Guid entityId)
        {
            var ticketsFromRepo = _repository.GetEntity(entityId);
            return _mapper.Map<Ticket, TicketDto>(ticketsFromRepo);
        }

        public TicketDto GetEntity(Guid flightId, Guid entityId)
        {
            if (!_flightRepository.EntityExists(flightId))
            {
                throw new NotFoundException();
            }

            var ticketFromRepo = _repository.GetEntity(entityId);
            if (ticketFromRepo == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<Ticket, TicketDto>(ticketFromRepo);
        }

        public TicketDto AddEntity(TicketDto entity)
        {
            if (!_flightRepository.EntityExists(entity.FlightId))
            {
                throw new NotFoundException();
            }

            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<TicketDto, Ticket>(entity);
            _repository.AddEntity(mapedEntity);

            if (!_repository.Save())
            {
                throw new Exception("Adding Ticket failed on save.");
            }

            return _mapper.Map<Ticket, TicketDto>(mapedEntity);
        }

        public TicketDto AddEntity(Guid flightId, TicketDto entity)
        {
            if (!_flightRepository.EntityExists(flightId))
            {
                throw new NotFoundException();
            }

            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<TicketDto, Ticket>(entity);
            _repository.AddEntity(mapedEntity);

            if (!_repository.Save())
            {
                throw new Exception("Adding Ticket failed on save.");
            }

            return _mapper.Map<Ticket, TicketDto>(mapedEntity);
        }

        public TicketDto UpdateEntity(TicketDto entity)
        {
            if (!_repository.EntityExists(entity.Id))
            {
                throw new NotFoundException();
            }

            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<TicketDto, Ticket>(entity);
            _repository.UpdateEntity(mapedEntity);

            if (!_repository.Save())
            {
                throw new Exception("Updating Ticket failed on save.");
            }

            return _mapper.Map<Ticket, TicketDto>(mapedEntity);
        }

        public void DeleteEntity(Guid entityId)
        {
            var ticketFromRepo = _repository.GetEntity(entityId);
            if (ticketFromRepo == null)
            {
                throw new NotFoundException();
            }

            _repository.DeleteEntity(ticketFromRepo);
            if (!_repository.Save())
            {
                throw new Exception("Deleting Ticket failed on save.");
            }
        }

        public void DeleteEntity(Guid flightId, Guid entityId)
        {
            if (!_flightRepository.EntityExists(flightId))
            {
                throw new NotFoundException();
            }

            var ticketFromRepo = _repository.GetEntity(entityId);
            if (ticketFromRepo == null)
            {
                throw new NotFoundException();
            }

            _repository.DeleteEntity(ticketFromRepo);
            if (!_repository.Save())
            {
                throw new Exception("Deleting Ticket failed on save.");
            }
        }
    }
}
