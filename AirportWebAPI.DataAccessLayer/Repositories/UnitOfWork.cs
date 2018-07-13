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

        public IRepository<AirplaneType> AirplaneTypes
        {
            get
            {
                if (_airplaneTypeRepository == null)
                {
                    _airplaneTypeRepository = new AirplaneTypeRepository(_context);
                }

                return _airplaneTypeRepository;
            }
        }

        public IRepository<Airplane> Airplanes
        {
            get
            {
                if (_airplaneRepository == null)
                {
                    _airplaneRepository = new AirplaneRepository(_context);
                }

                return _airplaneRepository;
            }
        }

        public IRepository<Pilot> Pilots
        {
            get
            {
                if (_pilotRepository == null)
                {
                    _pilotRepository = new PilotRepository(_context);
                }

                return _pilotRepository;
            }
        }

        public IRepository<Stewardess> Stewardesses
        {
            get
            {
                if (_stewardessRepository == null)
                {
                    _stewardessRepository = new StewardessRepository(_context);
                }

                return _stewardessRepository;
            }
        }

        public IRepository<Crew> Crews
        {
            get
            {
                if (_crewRepository == null)
                {
                    _crewRepository = new CrewRepository(_context);
                }

                return _crewRepository;
            }
        }

        public IRepository<Flight> Flights
        {
            get
            {
                if (_flightRepository == null)
                {
                    _flightRepository = new FlightRepository(_context);
                }

                return _flightRepository;
            }
        }

        public IRepository<Ticket> Tickets
        {
            get
            {
                if (_ticketRepository == null)
                {
                    _ticketRepository = new TicketRepository(_context);
                }

                return _ticketRepository;
            }
        }

        public IRepository<Departure> Departures
        {
            get
            {
                if (_departureRepository == null)
                {
                    _departureRepository = new DepartureRepository(_context);
                }

                return _departureRepository;
            }
        }
    }
}
