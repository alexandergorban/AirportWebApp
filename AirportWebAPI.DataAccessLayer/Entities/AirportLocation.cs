using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;

namespace AirportWebAPI.DataAccessLayer.Entities
{
    public class AirportLocation : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string AirportName { get; set; }

        [Required]
        [MaxLength(30)]
        public string Country { get; set; }

        [Required]
        [MaxLength(30)]
        public string City { get; set; }
    }
}
