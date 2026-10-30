using AviaBooking.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using AviaBooking.Core.Entities;
using AviaBooking.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace AviaBooking.Data.Seed
{
    /// <summary>
    /// Класс для наполнения базы данных тестовыми данными
    /// </summary>
    public static class DbSeeder
    {
        /// <summary>
        /// Основной метод наполнения БД
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task SeedAsync(AppDbContext context)
        {
            //Применяем миграции если они не применены, если допустим я открою на другой машине проект 
            await context.Database.MigrateAsync();
            
            //если страны уже есть то ен добавляем их заново
            if (await context.Countries.AnyAsync())
            {
                return;
            }


            await SeedCountriesAndCitiesAsync(context);
            await SeedAirportsAsync(context);
            await SeedAirlinesAndAircraftsAsync(context);
            await SeedFareClassesAsync(context);
            await SeedFlightsAsync(context);
            await SeedUsersAsync(context);

            await context.SaveChangesAsync();
        }
        private static async Task SeedCountriesAndCitiesAsync(AppDbContext context)
        {
            // 1. Страны
            var russia = new Country { Name = "Россия", IsoCode = "RU" };
            var usa = new Country { Name = "США", IsoCode = "US" };
            var germany = new Country { Name = "Германия", IsoCode = "DE" };

            context.Countries.AddRange(russia, usa, germany);
            await context.SaveChangesAsync(); // Сохраняем, чтобы получить ID

            // 2. Города
            var moscow = new City { Name = "Москва", CountryId = russia.Id };
            var spb = new City { Name = "Санкт-Петербург", CountryId = russia.Id };
            var sochi = new City { Name = "Сочи", CountryId = russia.Id };

            var newYork = new City { Name = "Нью-Йорк", CountryId = usa.Id };
            var berlin = new City { Name = "Берлин", CountryId = germany.Id };

            context.Cities.AddRange(moscow, spb, sochi, newYork, berlin);
            await context.SaveChangesAsync();
        }

        private static async Task SeedAirportsAsync(AppDbContext context)
        {
            var moscow = await context.Cities.FirstAsync(c => c.Name == "Москва");
            var spb = await context.Cities.FirstAsync(c => c.Name == "Санкт-Петербург");
            var sochi = await context.Cities.FirstAsync(c => c.Name == "Сочи");
            var newYork = await context.Cities.FirstAsync(c => c.Name == "Нью-Йорк");
            var berlin = await context.Cities.FirstAsync(c => c.Name == "Берлин");

            var airports = new List<Airport>
        {
            new() { lataCode = "SVO", Name = "Шереметьево", CityId = moscow.Id },
            new() { lataCode = "DME", Name = "Домодедово", CityId = moscow.Id },
            new() { lataCode = "LED", Name = "Пулково", CityId = spb.Id },
            new() { lataCode = "AER", Name = "Адлер", CityId = sochi.Id },
            new() { lataCode = "JFK", Name = "Джона Кеннеди", CityId = newYork.Id },
            new() { lataCode = "BER", Name = "Бранденбург", CityId = berlin.Id }
        };

            context.Airports.AddRange(airports);
            await context.SaveChangesAsync();
        }

        private static async Task SeedAirlinesAndAircraftsAsync(AppDbContext context)
        {
            var russia = await context.Countries.FirstAsync(c => c.IsoCode == "RU");

            // 1. Авиакомпании
            var aeroflot = new Airline { IataCode = "SU", Name = "Аэрофлот", CountryId = russia.Id };
            var s7 = new Airline { IataCode = "S7", Name = "S7 Airlines", CountryId = russia.Id };

            context.Airlines.AddRange(aeroflot, s7);
            await context.SaveChangesAsync();

            // 2. Самолёты
            var aircrafts = new List<Aircraft>
        {
            new() { Model = "Boeing 737-800", RegistrationNumber = "RA-73000", SeatsCount = 189, AirlineId = aeroflot.Id },
            new() { Model = "Airbus A320", RegistrationNumber = "RA-89000", SeatsCount = 180, AirlineId = aeroflot.Id },
            new() { Model = "Airbus A320neo", RegistrationNumber = "VQ-B000", SeatsCount = 180, AirlineId = s7.Id }
        };

            context.Aircrafts.AddRange(aircrafts);
            await context.SaveChangesAsync();
        }

        private static async Task SeedFareClassesAsync(AppDbContext context)
        {
            var classes = new List<FareClass>
        {
            new() { Name = "Economy", Multiplier = 1.0m },
            new() { Name = "Business", Multiplier = 2.5m }
        };

            context.FareClasses.AddRange(classes);
            await context.SaveChangesAsync();
        }

        private static async Task SeedFlightsAsync(AppDbContext context)
        {
            var aeroflot = await context.Airlines.FirstAsync(a => a.IataCode == "SU");
            var s7 = await context.Airlines.FirstAsync(a => a.IataCode == "S7");

            var boeing = await context.Aircrafts.FirstAsync(a => a.Model == "Boeing 737-800");
            var airbus = await context.Aircrafts.FirstAsync(a => a.Model == "Airbus A320neo");

            var svo = await context.Airports.FirstAsync(a => a.lataCode == "SVO");
            var led = await context.Airports.FirstAsync(a => a.lataCode == "LED");
            var aer = await context.Airports.FirstAsync(a => a.lataCode == "AER");
            var jfk = await context.Airports.FirstAsync(a => a.lataCode == "JFK");

            var flights = new List<Flight>
        {
            new()
            {
                FlightNumber = "SU1234",
                AirlineId = aeroflot.Id,
                AircraftId = boeing.Id,
                DepartureAirportId = svo.Id,
                ArrivalAirportId = led.Id,
                DepartureTime = DateTime.UtcNow.AddDays(1).Date.AddHours(10),
                ArrivalTime = DateTime.UtcNow.AddDays(1).Date.AddHours(11).AddMinutes(30),
                BasePrice = 5000m,
                Status = FlightStatus.Scheduled
            },
            new()
            {
                FlightNumber = "S7890",
                AirlineId = s7.Id,
                AircraftId = airbus.Id,
                DepartureAirportId = led.Id,
                ArrivalAirportId = aer.Id,
                DepartureTime = DateTime.UtcNow.AddDays(2).Date.AddHours(14),
                ArrivalTime = DateTime.UtcNow.AddDays(2).Date.AddHours(17),
                BasePrice = 7500m,
                Status = FlightStatus.Scheduled
            },
            new()
            {
                FlightNumber = "SU999",
                AirlineId = aeroflot.Id,
                AircraftId = boeing.Id,
                DepartureAirportId = svo.Id,
                ArrivalAirportId = jfk.Id,
                DepartureTime = DateTime.UtcNow.AddDays(3).Date.AddHours(9),
                ArrivalTime = DateTime.UtcNow.AddDays(3).Date.AddHours(19),
                BasePrice = 35000m,
                Status = FlightStatus.Scheduled
            }
        };

            context.Flights.AddRange(flights);
            await context.SaveChangesAsync();
        }

        private static async Task SeedUsersAsync(AppDbContext context)
        {
            // Пароль: "admin123" и "user123" (в реальности нужно хешировать BCrypt!)
            var users = new List<User>
        {
            new()
            {
                Email = "admin@aviabooking.ru",
                PasswordHash = "TEMP_HASH_BCRYPT", // Позже заменим на реальный хеш
                FirstName = "Данила",
                LastName = "Нагаев",
                UserRole = UserRole.Admin,
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Email = "user@test.ru",
                PasswordHash = "TEMP_HASH_BCRYPT",
                FirstName = "Иван",
                LastName = "Иванов",
                UserRole = UserRole.User,
                CreatedAt = DateTime.UtcNow
            }
        };

            context.Users.AddRange(users);
            await context.SaveChangesAsync();
        }
    }

}
