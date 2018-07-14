using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AirportWebAPI.DataAccessLayer.Data;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Entities;
using AutoMapper;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    class UnitOfWork : IUnitOfWork
    {
        private DataSource _context;
        private IMapper _mapper;

        private AirplaneTypeRepository _airplaneTypeRepository;
        private AirplaneRepository _airplaneRepository;
        private PilotRepository _pilotRepository;
        private StewardessRepository _stewardessRepository;
        private CrewRepository _crewRepository;
        private FlightRepository _flightRepository;
        private TicketRepository _ticketRepository;
        private DepartureRepository _departureRepository;

        public UnitOfWork(DataSource context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IRepository<AirplaneType> AirplaneTypes =>
            _airplaneTypeRepository ?? (_airplaneTypeRepository = new AirplaneTypeRepository(_context, _mapper));

        public IRepository<Airplane> Airplanes =>
            _airplaneRepository ?? (_airplaneRepository = new AirplaneRepository(_context, _mapper));

        public IRepository<Pilot> Pilots =>
            _pilotRepository ?? (_pilotRepository = new PilotRepository(_context, _mapper));

        public IRepository<Stewardess> Stewardesses =>
            _stewardessRepository ?? (_stewardessRepository = new StewardessRepository(_context, _mapper));

        public IRepository<Crew> Crews =>
            _crewRepository ?? (_crewRepository = new CrewRepository(_context, _mapper));

        public IRepository<Flight> Flights =>
            _flightRepository ?? (_flightRepository = new FlightRepository(_context, _mapper));

        public IRepository<Ticket> Tickets =>
            _ticketRepository ?? (_ticketRepository = new TicketRepository(_context, _mapper));

        public IRepository<Departure> Departures =>
            _departureRepository ?? (_departureRepository = new DepartureRepository(_context, _mapper));
    }
}
