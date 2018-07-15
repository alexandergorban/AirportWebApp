using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;

namespace AirportWebAPI.DataAccessLayer.Entities
{
    public class Flight : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FlightNumber { get; set; }

        [Required]
        public AirportLocation DeparturePoint { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public AirportLocation DestinationPoint { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        public List<Ticket> Tickets { get; set; }

        public Departure Departure { get; set; }
        public Guid DepartureId { get; set; }
        public Guid AirportLocationId { get; set; }


    }
}
