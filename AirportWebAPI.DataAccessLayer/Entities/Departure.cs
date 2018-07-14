using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;

namespace AirportWebAPI.DataAccessLayer.Entities
{
    public class Departure : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public bool IsFlightDelay { get; set; }

        [Required]
        public DateTime DepartureTimeChanged { get; set; }

        [Required]
        public Flight Flight { get; set; }

        [Required]
        public Crew Crew { get; set; }

        [Required]
        public Airplane Airplane { get; set; }
    }
}
