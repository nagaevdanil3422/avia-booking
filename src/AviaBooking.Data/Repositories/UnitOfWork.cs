using AviaBooking.Core.Entities;
using AviaBooking.Core.Interfaces;
using AviaBooking.Data.Context;

namespace AviaBooking.Data.Repositories;

/// <summary>
/// Реализация паттерна Unit of Work
/// Объединяет все репозитории и управляет сохранением изменений
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    // Приватные поля для ленивой инициализации 
    private IRepository<Country>? _countries;
    private IRepository<City>? _cities;
    private IRepository<Airport>? _airports;
    private IRepository<Airline>? _airlines;
    private IRepository<Aircraft>? _aircrafts;
    private IRepository<FareClass>? _fareClasses;
    private IRepository<Flight>? _flights;
    private IRepository<User>? _users;
    private IRepository<Booking>? _bookings;
    private IRepository<Ticket>? _tickets;

    /// <summary>
    /// Конструктор UnitOfWork.
    /// </summary>
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    // Свойства репозиториев
    //репозиторий создаётся только при первом обращении
    public IRepository<Country> Countries => _countries ??= new Repository<Country>(_context);
    public IRepository<City> Cities => _cities ??= new Repository<City>(_context);
    public IRepository<Airport> Airports => _airports ??= new Repository<Airport>(_context);
    public IRepository<Airline> Airlines => _airlines ??= new Repository<Airline>(_context);
    public IRepository<Aircraft> Aircrafts => _aircrafts ??= new Repository<Aircraft>(_context);
    public IRepository<FareClass> FareClasses => _fareClasses ??= new Repository<FareClass>(_context);
    public IRepository<Flight> Flights => _flights ??= new Repository<Flight>(_context);
    public IRepository<User> Users => _users ??= new Repository<User>(_context);
    public IRepository<Booking> Bookings => _bookings ??= new Repository<Booking>(_context);
    public IRepository<Ticket> Tickets => _tickets ??= new Repository<Ticket>(_context);

    /// <summary>
    /// Сохранить все изменения в БД
    /// </summary>
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}