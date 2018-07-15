using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Range(1, 100)]
        public int NumberOfSeats { get; set; }

        [Required]
        [Range(1000, 1000000)]
        public int LoadCapacity { get; set; }

        public ICollection<Airplane> Airplanes { get; set; }
    }
}
