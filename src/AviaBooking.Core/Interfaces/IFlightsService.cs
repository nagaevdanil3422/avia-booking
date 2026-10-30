using AviaBooking.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Core.Interfaces
{
    public interface IFlightsService
    {
        Task<IEnumerable<FlightDto>> GetAllFlightsAsync();
    }
}
