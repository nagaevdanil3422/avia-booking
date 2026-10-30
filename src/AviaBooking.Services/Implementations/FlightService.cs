using AviaBooking.Core.DTOs;
using AviaBooking.Core.Interfaces;

namespace AviaBooking.Services.Implementations;

public class FlightService : IFlightsService
{
    private readonly IUnitOfWork _unitOfWork;

    public FlightService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork; // ИСПРАВЛЕНО: сначала поле, потом параметр
    }

    public async Task<IEnumerable<FlightDto>> GetAllFlightsAsync() // ИСПРАВЛЕНО: добавили 's' в Flights
    {
        // 1. Достаем данные
        var flights = await _unitOfWork.Flights.GetAllAsync();
        var airports = await _unitOfWork.Airports.GetAllAsync();

        // 2. Мапим (превращаем) Flight в FlightDto
        var result = flights.Select(f => new FlightDto
        {
            Id = f.Id,
            FlightNumber = f.FlightNumber,
            // Ищем город вылета
            DepartureCity = airports.FirstOrDefault(a => a.Id == f.DepartureAirportId)?.City.Name ?? "Неизвестно",
            // Ищем город прилета
            ArrivalCity = airports.FirstOrDefault(a => a.Id == f.ArrivalAirportId)?.City.Name ?? "Неизвестно",
            DepartureTime = f.DepartureTime,
            ArrivalTime = f.ArrivalTime,
            BasePrice = f.BasePrice,
            AvailableSeats = 100 // Пока заглушка
        });

        return result;
    }
}