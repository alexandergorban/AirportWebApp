using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;

namespace AirportWebAPI.DataAccessLayer.Entities
{
    public class Ticket : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public uint  Number { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public Guid FlightId { get; set; }
    }
}
