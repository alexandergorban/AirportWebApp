using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AirportWebAPI.DataAccessLayer.Interfaces
{
    public interface IEntity 
    {
        Guid Id { get; set; }
    }
}
