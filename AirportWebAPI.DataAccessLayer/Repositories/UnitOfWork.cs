using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.DataAccessLayer.Repositories
{
    class UnitOfWork : IUnitOfWork
    {
        private IAirportContext _context;

        private AirplaneTypeRepository _airplaneTypeRepository;
        private AirplaneRepository _airplaneRepository;
        private PilotRepository _pilotRepository;
        private StewardessRepository _stewardessRepository;
        private CrewRepository _crewRepository;
        private FlightRepository _flightRepository;
        private TicketRepository _ticketRepository;
        private DepartureRepository _departureRepository;

        public UnitOfWork(IAirportContext context)
        {
            _context = context;
        }

        public IRepository<AirplaneType> AirplaneTypes => 
            _airplaneTypeRepository ?? (_airplaneTypeRepository = new AirplaneTypeRepository(_context));

        public IRepository<Airplane> Airplanes => 
            _airplaneRepository ?? (_airplaneRepository = new AirplaneRepository(_context));

        public IRepository<Pilot> Pilots => 
            _pilotRepository ?? (_pilotRepository = new PilotRepository(_context));

        public IRepository<Stewardess> Stewardesses => 
            _stewardessRepository ?? (_stewardessRepository = new StewardessRepository(_context));

        public IRepository<Crew> Crews => 
            _crewRepository ?? (_crewRepository = new CrewRepository(_context));

        public IRepository<Flight> Flights => 
            _flightRepository ?? (_flightRepository = new FlightRepository(_context));

        public IRepository<Ticket> Tickets => 
            _ticketRepository ?? (_ticketRepository = new TicketRepository(_context));

        public IRepository<Departure> Departures => 
            _departureRepository ?? (_departureRepository = new DepartureRepository(_context));
    }
}
