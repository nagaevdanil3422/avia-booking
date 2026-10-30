using AviaBooking.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Core.Interfaces
{
    public interface IFlightService
    {
        Task<IEnumerable<FlightDto>> GetAllFlightsAsync();
    }
}
