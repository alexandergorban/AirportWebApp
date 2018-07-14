using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;

namespace AirportWebAPI.DataAccessLayer.Entities
{
    public class AirplaneType : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Model { get; set; }

        [Required]
        public int NumberOfSeats { get; set; }

        [Required]
        public int LoadCapacity { get; set; }
    }
}
