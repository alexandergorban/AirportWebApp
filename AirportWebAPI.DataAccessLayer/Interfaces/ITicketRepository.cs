﻿using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Entities;

namespace AirportWebAPI.DataAccessLayer.Interfaces
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        IEnumerable<Ticket> GetEntities(Guid flightId);
    }
}
