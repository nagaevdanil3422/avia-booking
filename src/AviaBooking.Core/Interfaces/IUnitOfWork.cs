using AviaBooking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Core.Interfaces
{
    /// <summary>
    /// Интерфейс Единицы Работы
    /// Объединяет все репозитории и управляет транзакциями
    /// </summary>
    public interface IUnitOfWork
    {
        //Свойства для доступа к репозиториям конкретных сущностей
        IRepository<Country> Countries { get; }
        IRepository<City> Cities { get; }
        IRepository<Airport> Airports { get; }
        IRepository<Airline> Airlines { get; }
        IRepository<Aircraft> Aircrafts { get; }
        IRepository<FareClass> FareClasses { get; }
        IRepository<Flight> Flights { get; }
        IRepository<User> Users { get; }
        IRepository<Booking> Bookings { get; }
        IRepository<Ticket> Tickets { get; }

        /// <summary>
        /// Сохранить все изменения в базе данных
        /// Возвращает количество затронутых строк
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync(); 
    }
}
