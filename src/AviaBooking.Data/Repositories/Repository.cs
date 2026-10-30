using AviaBooking.Core.Interfaces;
using AviaBooking.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AviaBooking.Data.Repositories;

/// <summary>
/// Универсальная реализация репозитория для любой сущности.
/// </summary>
/// <typeparam name="T">Тип сущности (например, Flight).</typeparam>
public class Repository<T> : IRepository<T> where T : class
{
    // Наш контекст БД (через него мы общаемся с базой)
    protected readonly AppDbContext _context;
    // Набор сущностей конкретного типа (например, DbSet<Flight>)
    protected readonly DbSet<T> _dbSet;

    /// <summary>
    /// Конструктор репозитория. EF Core сам передаст сюда контекст.
    /// </summary>
    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>(); // Получаем таблицу для типа T
    }

    /// <summary>
    /// Получить запись по ID.
    /// </summary>
    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    /// <summary>
    /// Получить все записи из таблицы.
    /// </summary>
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    /// <summary>
    /// Найти записи по условию (например, рейсы, где номер = "SU1234").
    /// </summary>
    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    /// <summary>
    /// Добавить новую запись.
    /// </summary>
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    /// <summary>
    /// Обновить запись.
    /// </summary>
    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    /// <summary>
    /// Удалить запись.
    /// </summary>
    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }
}