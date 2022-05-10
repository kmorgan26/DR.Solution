using DRApplication.Shared.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRApplication.Shared.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<bool> DeleteAsync(TEntity EntityToDelete);
        Task<bool> DeleteByIdAsync(object Id);
        Task DeleteAllAsync(); // Do not implement for now!
        Task<IEnumerable<TEntity>> GetAsync(QueryFilter<TEntity> Filter);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(object Id);
        Task<TEntity> InsertAsync(TEntity Entity);
        Task<TEntity> UpdateAsync(TEntity EntityToUpdate);
    }
}
