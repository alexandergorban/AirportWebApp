using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.DataAccessLayer.Data
{
    public class DataSource : IAirportContext
    {
        public List<AirplaneType> AirplaneTypes { get; set; }
        public List<Airplane> Airplanes { get; set; }
        public List<Pilot> Pilots { get; set; }
        public List<Stewardess> Stewardesses { get; set; }
        public List<Crew> Crews { get; set; }
        public List<AirportLocation> AirportLocations { get; set; }
        public List<Flight> Flights { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Departure> Departures { get; set; }

        public DataSource()
        {
            EnsureSeedDataForContext();
        }

        public int SaveChanges()
        {
            return 1;
        }

        public void EnsureSeedDataForContext()
        {
            AirplaneTypes = new List<AirplaneType>()
            {
                new AirplaneType()
                {
                    Id = new Guid("15320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    Model = "SSJ 100/95",
                    NumberOfSeats = 86,
                    LoadCapacity = 42500
                },
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
                },
                new AirplaneType()
                {
                    Id = new Guid("45320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    Model = "Boeing-737",
                    NumberOfSeats = 140,
                    LoadCapacity = 52800
                }
            };

            Airplanes = new List<Airplane>()
            {
                new Airplane()
                {
                    Id = new Guid("a1749477-f823-4124-aa4a-fc9ad5e79cd6"),
                    Name = "SSJ 100/95",
                    AirplaneType = AirplaneTypes
                        .FirstOrDefault(airplaneType => 
                            airplaneType.Id.Equals(new Guid("15320c5e-f58a-4b1f-b63a-8ee07a840bdf"))),
                    DateOfIssue = new DateTime(2011, 1, 17),
                    LifeTime = new TimeSpan(500, 0, 0, 0),
                    IsOwnAirplane = true
                },
                new Airplane()
                {
                    Id = new Guid("a2749477-f823-4124-aa4a-fc9ad5e79cd6"),
                    Name = "SSJ 100/95",
                    AirplaneType = AirplaneTypes
                        .FirstOrDefault(airplaneType => 
                            airplaneType.Id.Equals(new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"))),
                    DateOfIssue = new DateTime(2011, 1, 17),
                    LifeTime = new TimeSpan(500, 0, 0, 0),
                    IsOwnAirplane = true
                },
                new Airplane()
                {
                    Id = new Guid("a3749477-f823-4124-aa4a-fc9ad5e79cd6"),
                    Name = "SSJ 100/95",
                    AirplaneType = AirplaneTypes
                        .FirstOrDefault(airplaneType => 
                            airplaneType.Id.Equals(new Guid("35320c5e-f58a-4b1f-b63a-8ee07a840bdf"))),
                    DateOfIssue = new DateTime(2011, 1, 17),
                    LifeTime = new TimeSpan(500, 0, 0, 0),
                    IsOwnAirplane = true
                },
                new Airplane()
                {
                    Id = new Guid("a4749477-f823-4124-aa4a-fc9ad5e79cd6"),
                    Name = "SSJ 100/95",
                    AirplaneType = AirplaneTypes
                        .FirstOrDefault(airplaneType => 
                            airplaneType.Id.Equals(new Guid("45320c5e-f58a-4b1f-b63a-8ee07a840bdf"))),
                    DateOfIssue = new DateTime(2011, 1, 17),
                    LifeTime = new TimeSpan(500, 0, 0, 0),
                    IsOwnAirplane = true
                }
            };

            Pilots = new List<Pilot>()
            {
                new Pilot()
                {
                    Id = new Guid("p4749477-f823-4124-aa4a-fc9ad5e79cd1"),
                    Name = "Mike",
                    Surname = "Doe",
                    DateOfBirth = new DateTime(1980, 7, 20),
                    Experience = new TimeSpan(783, 0, 0, 0)
                },
                new Pilot()
                {
                    Id = new Guid("p4749477-f823-4124-aa4a-fc9ad5e79cd2"),
                    Name = "Jac",
                    Surname = "Low",
                    DateOfBirth = new DateTime(1980, 1, 10),
                    Experience = new TimeSpan(543, 0, 0, 0)
                },
                new Pilot()
                {
                    Id = new Guid("p4749477-f823-4124-aa4a-fc9ad5e79cd3"),
                    Name = "Brad",
                    Surname = "Marrow",
                    DateOfBirth = new DateTime(1990, 7, 21),
                    Experience = new TimeSpan(923, 0, 0, 0)
                },
                new Pilot()
                {
                    Id = new Guid("p4749477-f823-4124-aa4a-fc9ad5e79cd4"),
                    Name = "Nick",
                    Surname = "Hoy",
                    DateOfBirth = new DateTime(1980, 5, 15),
                    Experience = new TimeSpan(383, 0, 0, 0)
                }
            };

            Stewardesses = new List<Stewardess>()
            {
                new Stewardess()
                {
                    Id = new Guid("s4749477-f823-4124-aa4a-fc9ad5e79cd1"),
                    Name = "Jane",
                    Surname = "Spears",
                    DateOfBirth = new DateTime(1990, 7, 30)
                },
                new Stewardess()
                {
                    Id = new Guid("s4749477-f823-4124-aa4a-fc9ad5e79cd2"),
                    Name = "Helen",
                    Surname = "Moss",
                    DateOfBirth = new DateTime(1990, 7, 30)
                },
                new Stewardess()
                {
                    Id = new Guid("s4749477-f823-4124-aa4a-fc9ad5e79cd3"),
                    Name = "Stefany",
                    Surname = "Hilton",
                    DateOfBirth = new DateTime(1990, 7, 30)
                },
                new Stewardess()
                {
                    Id = new Guid("s4749477-f823-4124-aa4a-fc9ad5e79cd4"),
                    Name = "Merlin",
                    Surname = "Jess",
                    DateOfBirth = new DateTime(1990, 7, 30)
                }
            };

            Crews = new List<Crew>()
            {
                new Crew()
                {
                    Id = new Guid("c4749477-f823-4124-aa4a-fc9ad5e79cd1"),
                    Pilot = Pilots
                        .FirstOrDefault(pilot => 
                            pilot.Id.Equals(new Guid("p4749477-f823-4124-aa4a-fc9ad5e79cd1"))),
                    Stewardesseses = new List<Stewardess>()
                    {
                        Stewardesses
                            .FirstOrDefault(stewrdess => 
                                stewrdess.Id.Equals(new Guid("s4749477-f823-4124-aa4a-fc9ad5e79cd1"))),
                        Stewardesses
                            .FirstOrDefault(stewrdess => 
                                stewrdess.Id.Equals(new Guid("s4749477-f823-4124-aa4a-fc9ad5e79cd2"))),
                        Stewardesses
                            .FirstOrDefault(stewrdess => 
                                stewrdess.Id.Equals(new Guid("s4749477-f823-4124-aa4a-fc9ad5e79cd3"))),
                    }
                },
                new Crew()
                {
                    Id = new Guid("c4749477-f823-4124-aa4a-fc9ad5e79cd2"),
                    Pilot = Pilots
                        .FirstOrDefault(pilot =>
                            pilot.Id.Equals(new Guid("p4749477-f823-4124-aa4a-fc9ad5e79cd2"))),
                    Stewardesseses = new List<Stewardess>()
                    {
                        Stewardesses
                            .FirstOrDefault(stewrdess =>
                                stewrdess.Id.Equals(new Guid("s4749477-f823-4124-aa4a-fc9ad5e79cd4"))),
                        Stewardesses
                            .FirstOrDefault(stewrdess =>
                                stewrdess.Id.Equals(new Guid("s4749477-f823-4124-aa4a-fc9ad5e79cd2"))),
                        Stewardesses
                            .FirstOrDefault(stewrdess =>
                                stewrdess.Id.Equals(new Guid("s4749477-f823-4124-aa4a-fc9ad5e79cd3"))),
                    }
                },
                new Crew()
                {
                    Id = new Guid("c4749477-f823-4124-aa4a-fc9ad5e79cd3"),
                    Pilot = Pilots
                        .FirstOrDefault(pilot =>
                            pilot.Id.Equals(new Guid("p4749477-f823-4124-aa4a-fc9ad5e79cd3"))),
                    Stewardesseses = new List<Stewardess>()
                    {
                        Stewardesses
                            .FirstOrDefault(stewrdess =>
                                stewrdess.Id.Equals(new Guid("s4749477-f823-4124-aa4a-fc9ad5e79cd4"))),
                        Stewardesses
                            .FirstOrDefault(stewrdess =>
                                stewrdess.Id.Equals(new Guid("s4749477-f823-4124-aa4a-fc9ad5e79cd1"))),
                        Stewardesses
                            .FirstOrDefault(stewrdess =>
                                stewrdess.Id.Equals(new Guid("s4749477-f823-4124-aa4a-fc9ad5e79cd3"))),
                    }
                }
            };

            AirportLocations = new List<AirportLocation>()
            {
                new AirportLocation()
                {
                    Id = new Guid("l4749477-f823-4124-aa4a-fc9ad5e79cd1"),
                    AirportName = "Ben Gurion",
                    Country = "Israel",
                    City = "Tel-Aviv"
                },
                new AirportLocation()
                {
                    Id = new Guid("l4749477-f823-4124-aa4a-fc9ad5e79cd2"),
                    AirportName = "Borispol",
                    Country = "Ukraine",
                    City = "Kiev"
                },
                new AirportLocation()
                {
                    Id = new Guid("l4749477-f823-4124-aa4a-fc9ad5e79cd3"),
                    AirportName = "Ataturk",
                    Country = "Turkey",
                    City = "Istanbul"
                },
                new AirportLocation()
                {
                    Id = new Guid("l4749477-f823-4124-aa4a-fc9ad5e79cd4"),
                    AirportName = "Zulyany",
                    Country = "Ukraine",
                    City = "Kiev"
                }
            };

            Flights = new List<Flight>()
            {
                new Flight()
                {
                    Id = new Guid("f4749477-f823-4124-aa4a-fc9ad5e79cd1"),
                    FlightNumber = "OD1961",
                    DeparturePoint = AirportLocations
                        .FirstOrDefault(airportLocation => 
                            airportLocation.Id.Equals(new Guid("l4749477-f823-4124-aa4a-fc9ad5e79cd1"))),
                    DepartureTime = new DateTime(2019, 7, 19),
                    DestinationPoint = AirportLocations
                        .FirstOrDefault(airportLocation =>
                            airportLocation.Id.Equals(new Guid("l4749477-f823-4124-aa4a-fc9ad5e79cd2"))),
                    ArrivalTime = new DateTime(2019, 7, 19),
                    Tickets = new List<Ticket>()
                    {
                        new Ticket()
                        {
                            Id = new Guid("t4749477-f823-4124-aa4a-fc9ad5e79cd1"),
                            Number = 1,
                            Price = 200,
                            FlightId = "f4749477-f823-4124-aa4a-fc9ad5e79cd1"
                        },
                        new Ticket()
                        {
                            Id = new Guid("t4749477-f823-4124-aa4a-fc9ad5e79cd2"),
                            Number = 2,
                            Price = 200,
                            FlightId = "f4749477-f823-4124-aa4a-fc9ad5e79cd1"
                        }
                    }
                },
                new Flight()
                {
                    Id = new Guid("f4749477-f823-4124-aa4a-fc9ad5e79cd2"),
                    FlightNumber = "PN0034",
                    DeparturePoint = AirportLocations
                        .FirstOrDefault(airportLocation =>
                            airportLocation.Id.Equals(new Guid("l4749477-f823-4124-aa4a-fc9ad5e79cd2"))),
                    DepartureTime = new DateTime(2019, 5, 10),
                    DestinationPoint = AirportLocations
                        .FirstOrDefault(airportLocation =>
                            airportLocation.Id.Equals(new Guid("l4749477-f823-4124-aa4a-fc9ad5e79cd3"))),
                    ArrivalTime = new DateTime(2019, 5, 11),
                    Tickets = new List<Ticket>()
                    {
                        new Ticket()
                        {
                            Id = new Guid("t4749477-f823-4124-aa4a-fc9ad5e79cd3"),
                            Number = 3,
                            Price = 300
                        },
                        new Ticket()
                        {
                            Id = new Guid("t4749477-f823-4124-aa4a-fc9ad5e79cd4"),
                            Number = 4,
                            Price = 300
                        }
                    }
                },
                new Flight()
                {
                    Id = new Guid("f4749477-f823-4124-aa4a-fc9ad5e79cd3"),
                    FlightNumber = "TZ0529",
                    DeparturePoint = AirportLocations
                        .FirstOrDefault(airportLocation =>
                            airportLocation.Id.Equals(new Guid("l4749477-f823-4124-aa4a-fc9ad5e79cd3"))),
                    DepartureTime = new DateTime(2019, 1, 19),
                    DestinationPoint = AirportLocations
                        .FirstOrDefault(airportLocation =>
                            airportLocation.Id.Equals(new Guid("l4749477-f823-4124-aa4a-fc9ad5e79cd4"))),
                    ArrivalTime = new DateTime(2019, 1, 19),
                    Tickets = new List<Ticket>()
                    {
                        new Ticket()
                        {
                            Id = new Guid("t4749477-f823-4124-aa4a-fc9ad5e79cd5"),
                            Number = 5,
                            Price = 400
                        },
                        new Ticket()
                        {
                            Id = new Guid("t4749477-f823-4124-aa4a-fc9ad5e79cd6"),
                            Number = 6,
                            Price = 400
                        }
                    }
                },
                new Flight()
                {
                    Id = new Guid("f4749477-f823-4124-aa4a-fc9ad5e79cd4"),
                    FlightNumber = "OD2415",
                    DeparturePoint = AirportLocations
                        .FirstOrDefault(airportLocation =>
                            airportLocation.Id.Equals(new Guid("l4749477-f823-4124-aa4a-fc9ad5e79cd4"))),
                    DepartureTime = new DateTime(2019, 2, 18),
                    DestinationPoint = AirportLocations
                        .FirstOrDefault(airportLocation =>
                            airportLocation.Id.Equals(new Guid("l4749477-f823-4124-aa4a-fc9ad5e79cd1"))),
                    ArrivalTime = new DateTime(2019, 2, 19),
                    Tickets = new List<Ticket>()
                    {
                        new Ticket()
                        {
                            Id = new Guid("t4749477-f823-4124-aa4a-fc9ad5e79cd7"),
                            Number = 7,
                            Price = 340
                        },
                        new Ticket()
                        {
                            Id = new Guid("t4749477-f823-4124-aa4a-fc9ad5e79cd8"),
                            Number = 8,
                            Price = 340
                        }
                    }
                }
            };

            Departures = new List<Departure>()
            {
                new Departure()
                {
                    Id = new Guid("d4749477-f823-4124-aa4a-fc9ad5e79cd1"),
                    DepartureTime = new DateTime(2019, 7, 19, 21, 15, 0),
                    IsFlightDelay = false,
                    Flight = Flights
                        .FirstOrDefault(flight => 
                            flight.Id.Equals(new Guid("f4749477-f823-4124-aa4a-fc9ad5e79cd1"))),
                    Crew = Crews
                        .FirstOrDefault(crew => 
                            crew.Id.Equals(new Guid("c4749477-f823-4124-aa4a-fc9ad5e79cd1"))),
                    Airplane = Airplanes
                        .FirstOrDefault(airplane => 
                            airplane.Id.Equals(new Guid("a1749477-f823-4124-aa4a-fc9ad5e79cd6")))
                },
                new Departure()
                {
                    Id = new Guid("d4749477-f823-4124-aa4a-fc9ad5e79cd2"),
                    DepartureTime = new DateTime(2019, 5, 10, 22, 10, 0),
                    IsFlightDelay = false,
                    Flight = Flights
                        .FirstOrDefault(flight =>
                            flight.Id.Equals(new Guid("f4749477-f823-4124-aa4a-fc9ad5e79cd2"))),
                    Crew = Crews
                        .FirstOrDefault(crew =>
                            crew.Id.Equals(new Guid("c4749477-f823-4124-aa4a-fc9ad5e79cd2"))),
                    Airplane = Airplanes
                        .FirstOrDefault(airplane =>
                            airplane.Id.Equals(new Guid("a1749477-f823-4124-aa4a-fc9ad5e79cd2")))
                },
                new Departure()
                {
                    Id = new Guid("d4749477-f823-4124-aa4a-fc9ad5e79cd3"),
                    DepartureTime = new DateTime(2019, 1, 19, 22, 10, 0),
                    IsFlightDelay = true,
                    DepartureTimeChanged = new DateTime(2019, 1, 19, 23, 45, 0),
                    Flight = Flights
                        .FirstOrDefault(flight =>
                            flight.Id.Equals(new Guid("f4749477-f823-4124-aa4a-fc9ad5e79cd3"))),
                    Crew = Crews
                        .FirstOrDefault(crew =>
                            crew.Id.Equals(new Guid("c4749477-f823-4124-aa4a-fc9ad5e79cd3"))),
                    Airplane = Airplanes
                        .FirstOrDefault(airplane =>
                            airplane.Id.Equals(new Guid("a1749477-f823-4124-aa4a-fc9ad5e79cd3")))
                }
            };

        }

    }
}
