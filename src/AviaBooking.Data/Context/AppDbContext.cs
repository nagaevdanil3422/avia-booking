using Microsoft.EntityFrameworkCore;
using AviaBooking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace AviaBooking.Data.Context
{
    /// <summary>
    /// Контекст базы данных приложения AviaBooking.
    /// Отвечает за подключение к БД и управление сущностями.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Конструктор контекста.
        /// </summary>
        /// <param name="options">Опции подключения к БД (строка подключения, провайдер).</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //------------- Справочники -------------
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<City> Cities => Set<City>();
        public DbSet<Airport> Airports => Set<Airport>();
        public DbSet<Airline> Airlines => Set<Airline>();
        public DbSet<Aircraft> Aircrafts => Set<Aircraft>();
        public DbSet<FareClass> FareClasses => Set<FareClass>();

        //---------- Операционные сущности ------------
        public DbSet<Flight> Flights => Set<Flight>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Booking> Bookings => Set<Booking>();
        public DbSet<Ticket> Tickets => Set<Ticket>();


        /// <summary>
        /// Настройка модели данных (связи, индексы, ограничения).
        /// </summary>
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Автоматически применяем все IEntityTypeConfiguration из этого assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
