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
        [MaxLength(10)]
        public string FlightNumber { get; set; }

        public AirportLocation DeparturePoint { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        public AirportLocation DestinationPoint { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
