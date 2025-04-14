using Hope.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hope.Infrastructure.Services;

public class LookupService : ILookupService
{
    private readonly ApplicationDbContext _context;

    public LookupService(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync<TEntity>(int id) where TEntity : class
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetByIdsAsync<TEntity>(IEnumerable<int> ids) where TEntity : class
    {
        // This assumes the entity has an Id property
        // You might need to adjust this based on your entity structure
        return await _context.Set<TEntity>()
            .Where(e => ids.Contains(EF.Property<int>(e, "Id")))
            .ToListAsync();
    }

    public async Task<bool> ExistsAsync<TEntity>(int id) where TEntity : class
    {
        return await _context.Set<TEntity>().FindAsync(id) != null;
    }
}