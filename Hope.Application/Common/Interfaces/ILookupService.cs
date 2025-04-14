using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hope.Application.Common.Interfaces
{
    public interface ILookupService
    {
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class;
        Task<TEntity?> GetByIdAsync<TEntity>(int id) where TEntity : class;
        Task<IEnumerable<TEntity>> GetByIdsAsync<TEntity>(IEnumerable<int> ids) where TEntity : class;
        Task<bool> ExistsAsync<TEntity>(int id) where TEntity : class;
    }
}