using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Entities;

namespace AirportWebAPI.DataAccessLayer.Data
{
    public class DataSource
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
            InitData();
        }

        public int SaveChanges()
        {
            return 1;
        }

        public void InitData()
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
//                    LifeTime = new TimeSpan(500, 0, 0, 0),
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
//                    LifeTime = new TimeSpan(500, 0, 0, 0),
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
//                    LifeTime = new TimeSpan(500, 0, 0, 0),
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
//                    LifeTime = new TimeSpan(500, 0, 0, 0),
                    IsOwnAirplane = true
                }
            };

            Pilots = new List<Pilot>
            {
                new Pilot()
                {
                    Id = new Guid("412c3012-d891-4f5e-9613-ff7aa63e6bb1"),
                    Name = "Mike",
                    Surname = "Doe",
                    DateOfBirth = new DateTime(1980, 7, 20),
//                    Experience = new TimeSpan(783, 0, 0, 0)
                },
                new Pilot()
                {
                    Id = new Guid("412c3012-d891-4f5e-9613-ff7aa63e6bb2"),
                    Name = "Jac",
                    Surname = "Low",
                    DateOfBirth = new DateTime(1980, 1, 10),
//                    Experience = new TimeSpan(543, 0, 0, 0)
                },
                new Pilot()
                {
                    Id = new Guid("412c3012-d891-4f5e-9613-ff7aa63e6bb3"),
                    Name = "Brad",
                    Surname = "Marrow",
                    DateOfBirth = new DateTime(1990, 7, 21),
//                    Experience = new TimeSpan(923, 0, 0, 0)
                },
                new Pilot()
                {
                    Id = new Guid("412c3012-d891-4f5e-9613-ff7aa63e6bb4"),
                    Name = "Nick",
                    Surname = "Hoy",
                    DateOfBirth = new DateTime(1980, 5, 15),
//                    Experience = new TimeSpan(383, 0, 0, 0)
                }
            };

            Stewardesses = new List<Stewardess>()
            {
                new Stewardess()
                {
                    Id = new Guid("01457142-358f-495f-aafa-fb23de3d67e1"),
                    Name = "Jane",
                    Surname = "Spears",
                    DateOfBirth = new DateTime(1990, 7, 30)
                },
                new Stewardess()
                {
                    Id = new Guid("01457142-358f-495f-aafa-fb23de3d67e2"),
                    Name = "Helen",
                    Surname = "Moss",
                    DateOfBirth = new DateTime(1990, 7, 30)
                },
                new Stewardess()
                {
                    Id = new Guid("01457142-358f-495f-aafa-fb23de3d67e3"),
                    Name = "Stefany",
                    Surname = "Hilton",
                    DateOfBirth = new DateTime(1990, 7, 30)
                },
                new Stewardess()
                {
                    Id = new Guid("01457142-358f-495f-aafa-fb23de3d67e4"),
                    Name = "Merlin",
                    Surname = "Jess",
                    DateOfBirth = new DateTime(1990, 7, 30)
                }
            };

            Crews = new List<Crew>()
            {
                new Crew()
                {
                    Id = new Guid("a1da1d8e-1988-4634-b538-a01709477b71"),
                    Pilot = Pilots
                        .FirstOrDefault(pilot =>
                            pilot.Id.Equals(new Guid("412c3012-d891-4f5e-9613-ff7aa63e6bb1"))),
                    Stewardesses = new List<Stewardess>()
                    {
                        Stewardesses
                            .FirstOrDefault(stewrdess =>
                                stewrdess.Id.Equals(new Guid("01457142-358f-495f-aafa-fb23de3d67e1"))),
                        Stewardesses
                            .FirstOrDefault(stewrdess =>
                                stewrdess.Id.Equals(new Guid("01457142-358f-495f-aafa-fb23de3d67e2"))),
                        Stewardesses
                            .FirstOrDefault(stewrdess =>
                                stewrdess.Id.Equals(new Guid("01457142-358f-495f-aafa-fb23de3d67e3")))
                    }
                },
                new Crew()
                {
                    Id = new Guid("a1da1d8e-1988-4634-b538-a01709477b72"),
                    Pilot = Pilots
                        .FirstOrDefault(pilot =>
                            pilot.Id.Equals(new Guid("412c3012-d891-4f5e-9613-ff7aa63e6bb2"))),
                    Stewardesses = new List<Stewardess>()
                    {
                        Stewardesses
                            .FirstOrDefault(stewrdess =>
                                stewrdess.Id.Equals(new Guid("01457142-358f-495f-aafa-fb23de3d67e1"))),
                        Stewardesses
                            .FirstOrDefault(stewrdess =>
                                stewrdess.Id.Equals(new Guid("01457142-358f-495f-aafa-fb23de3d67e2"))),
                        Stewardesses
                            .FirstOrDefault(stewrdess =>
                                stewrdess.Id.Equals(new Guid("01457142-358f-495f-aafa-fb23de3d67e3")))
                    }
                },
                new Crew()
                {
                    Id = new Guid("a1da1d8e-1988-4634-b538-a01709477b73"),
                    Pilot = Pilots
                        .FirstOrDefault(pilot =>
                            pilot.Id.Equals(new Guid("412c3012-d891-4f5e-9613-ff7aa63e6bb3"))),
                    Stewardesses = new List<Stewardess>()
                    {
                        Stewardesses
                            .FirstOrDefault(stewrdess =>
                                stewrdess.Id.Equals(new Guid("01457142-358f-495f-aafa-fb23de3d67e1"))),
                        Stewardesses
                            .FirstOrDefault(stewrdess =>
                                stewrdess.Id.Equals(new Guid("01457142-358f-495f-aafa-fb23de3d67e2"))),
                        Stewardesses
                            .FirstOrDefault(stewrdess =>
                                stewrdess.Id.Equals(new Guid("01457142-358f-495f-aafa-fb23de3d67e4")))
                    }
                }
            };

            AirportLocations = new List<AirportLocation>()
            {
                new AirportLocation()
                {
                    Id = new Guid("e17b605f-8b3c-4089-b672-6ce9e6d6c23f"),
                    AirportName = "Ben Gurion",
                    Country = "Israel",
                    City = "Tel-Aviv"
                },
                new AirportLocation()
                {
                    Id = new Guid("e27b605f-8b3c-4089-b672-6ce9e6d6c23f"),
                    AirportName = "Borispol",
                    Country = "Ukraine",
                    City = "Kiev"
                },
                new AirportLocation()
                {
                    Id = new Guid("e37b605f-8b3c-4089-b672-6ce9e6d6c23f"),
                    AirportName = "Ataturk",
                    Country = "Turkey",
                    City = "Istanbul"
                },
                new AirportLocation()
                {
                    Id = new Guid("e47b605f-8b3c-4089-b672-6ce9e6d6c23f"),
                    AirportName = "Zulyany",
                    Country = "Ukraine",
                    City = "Kiev"
                }
            };

            Tickets = new List<Ticket>()
            {
                new Ticket()
                {
                    Id = new Guid("147eb762-95e9-4c31-95e1-b20053fbe215"),
                    Number = 1,
                    Price = 310,
                    FlightId = new Guid("1325360c-8253-473a-a20f-55c269c20401")
                },
                new Ticket()
                {
                    Id = new Guid("247eb762-95e9-4c31-95e1-b20053fbe215"),
                    Number = 2,
                    Price = 310,
                    FlightId = new Guid("1325360c-8253-473a-a20f-55c269c20401")
                },
                new Ticket()
                {
                    Id = new Guid("347eb762-95e9-4c31-95e1-b20053fbe215"),
                    Number = 3,
                    Price = 300,
                    FlightId = new Guid("1325360c-8253-473a-a20f-55c269c20402")
                },
                new Ticket()
                {
                    Id = new Guid("447eb762-95e9-4c31-95e1-b20053fbe215"),
                    Number = 4,
                    Price = 300,
                    FlightId = new Guid("1325360c-8253-473a-a20f-55c269c20402")
                },
                new Ticket()
                {
                    Id = new Guid("547eb762-95e9-4c31-95e1-b20053fbe215"),
                    Number = 5,
                    Price = 400,
                    FlightId = new Guid("1325360c-8253-473a-a20f-55c269c20403")
                },
                new Ticket()
                {
                    Id = new Guid("647eb762-95e9-4c31-95e1-b20053fbe215"),
                    Number = 6,
                    Price = 400,
                    FlightId = new Guid("1325360c-8253-473a-a20f-55c269c20403")
                }

            };

            Flights = new List<Flight>()
            {
                new Flight()
                {
                    Id = new Guid("1325360c-8253-473a-a20f-55c269c20401"),
                    FlightNumber = "OD1961",
                    DeparturePoint = AirportLocations
                        .FirstOrDefault(airportLocation =>
                            airportLocation.Id.Equals(new Guid("e17b605f-8b3c-4089-b672-6ce9e6d6c23f"))),
                    DepartureTime = new DateTime(2019, 7, 19),
                    DestinationPoint = AirportLocations
                        .FirstOrDefault(airportLocation =>
                            airportLocation.Id.Equals(new Guid("e27b605f-8b3c-4089-b672-6ce9e6d6c23f"))),
                    ArrivalTime = new DateTime(2019, 7, 19),
                    Tickets = new List<Ticket>()
                    {
                        Tickets
                            .FirstOrDefault(ticket =>
                                ticket.Id.Equals(new Guid("147eb762-95e9-4c31-95e1-b20053fbe215"))),
                        Tickets
                            .FirstOrDefault(ticket =>
                                ticket.Id.Equals(new Guid("247eb762-95e9-4c31-95e1-b20053fbe215")))
                    }
                },
                new Flight()
                {
                    Id = new Guid("1325360c-8253-473a-a20f-55c269c20402"),
                    FlightNumber = "PN0034",
                    DeparturePoint = AirportLocations
                        .FirstOrDefault(airportLocation =>
                            airportLocation.Id.Equals(new Guid("e27b605f-8b3c-4089-b672-6ce9e6d6c23f"))),
                    DepartureTime = new DateTime(2019, 5, 10),
                    DestinationPoint = AirportLocations
                        .FirstOrDefault(airportLocation =>
                            airportLocation.Id.Equals(new Guid("e17b605f-8b3c-4089-b672-6ce9e6d6c23f"))),
                    ArrivalTime = new DateTime(2019, 5, 11),
                    Tickets = new List<Ticket>()
                    {
                        Tickets
                            .FirstOrDefault(ticket =>
                                ticket.Id.Equals(new Guid("347eb762-95e9-4c31-95e1-b20053fbe215"))),
                        Tickets
                            .FirstOrDefault(ticket =>
                                ticket.Id.Equals(new Guid("447eb762-95e9-4c31-95e1-b20053fbe215")))
                    }
                },
                new Flight()
                {
                    Id = new Guid("1325360c-8253-473a-a20f-55c269c20403"),
                    FlightNumber = "TZ0529",
                    DeparturePoint = AirportLocations
                        .FirstOrDefault(airportLocation =>
                            airportLocation.Id.Equals(new Guid("e37b605f-8b3c-4089-b672-6ce9e6d6c23f"))),
                    DepartureTime = new DateTime(2019, 1, 19),
                    DestinationPoint = AirportLocations
                        .FirstOrDefault(airportLocation =>
                            airportLocation.Id.Equals(new Guid("e47b605f-8b3c-4089-b672-6ce9e6d6c23f"))),
                    ArrivalTime = new DateTime(2019, 1, 19),
                    Tickets = new List<Ticket>()
                    {
                        Tickets
                            .FirstOrDefault(ticket =>
                                ticket.Id.Equals(new Guid("547eb762-95e9-4c31-95e1-b20053fbe215"))),
                        Tickets
                            .FirstOrDefault(ticket =>
                                ticket.Id.Equals(new Guid("647eb762-95e9-4c31-95e1-b20053fbe215")))
                    }
                }
            };

            Departures = new List<Departure>()
            {
                new Departure()
                {
                    Id = new Guid("70a1f9b9-0a37-4c1a-99b1-c7709fc64161"),
                    DepartureTime = new DateTime(2019, 7, 19, 21, 15, 0),
                    IsFlightDelay = false,
                    Flight = Flights
                        .FirstOrDefault(flight =>
                            flight.Id.Equals(new Guid("1325360c-8253-473a-a20f-55c269c20401"))),
                    Crew = Crews
                        .FirstOrDefault(crew =>
                            crew.Id.Equals(new Guid("a1da1d8e-1988-4634-b538-a01709477b71"))),
                    Airplane = Airplanes
                        .FirstOrDefault(airplane =>
                            airplane.Id.Equals(new Guid("a2749477-f823-4124-aa4a-fc9ad5e79cd6")))
                },
                new Departure()
                {
                    Id = new Guid("70a1f9b9-0a37-4c1a-99b1-c7709fc64162"),
                    DepartureTime = new DateTime(2019, 5, 10, 22, 10, 0),
                    IsFlightDelay = false,
                    Flight = Flights
                        .FirstOrDefault(flight =>
                            flight.Id.Equals(new Guid("1325360c-8253-473a-a20f-55c269c20402"))),
                    Crew = Crews
                        .FirstOrDefault(crew =>
                            crew.Id.Equals(new Guid("a1da1d8e-1988-4634-b538-a01709477b72"))),
                    Airplane = Airplanes
                        .FirstOrDefault(airplane =>
                            airplane.Id.Equals(new Guid("a3749477-f823-4124-aa4a-fc9ad5e79cd6")))
                },
                new Departure()
                {
                    Id = new Guid("70a1f9b9-0a37-4c1a-99b1-c7709fc64163"),
                    DepartureTime = new DateTime(2019, 1, 19, 22, 10, 0),
                    IsFlightDelay = true,
                    DepartureTimeChanged = new DateTime(2019, 1, 19, 23, 45, 0),
                    Flight = Flights
                        .FirstOrDefault(flight =>
                            flight.Id.Equals(new Guid("1325360c-8253-473a-a20f-55c269c20403"))),
                    Crew = Crews
                        .FirstOrDefault(crew =>
                            crew.Id.Equals(new Guid("a1da1d8e-1988-4634-b538-a01709477b73"))),
                    Airplane = Airplanes
                        .FirstOrDefault(airplane =>
                            airplane.Id.Equals(new Guid("a4749477-f823-4124-aa4a-fc9ad5e79cd6")))
                }
            };

        }

    }
}
