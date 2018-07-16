using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("Flights")]
        public Guid FlightId { get; set; }

        [Required]
        public float Price { get; set; }
    }
}
