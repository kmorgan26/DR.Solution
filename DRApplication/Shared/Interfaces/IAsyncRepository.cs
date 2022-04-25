using DRApplication.Shared.Filters;

namespace DRApplication.Shared.Interfaces
{
    public interface IAsyncRepository<TEntity> where TEntity : class
    {
        Task<bool> DeleteAsync(TEntity entityToDelete);
        Task<bool> DeleteAsync(object id);
        Task<IEnumerable<TEntity>> GetAllAsync(PaginationFilter? pagination = null);
        Task<TEntity> GetByIdAsync(object id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entityToUpdate);
        Task<IReadOnlyList<TEntity>> ListAllAsync();
        Task<IReadOnlyList<TEntity>> GetPagedReponseAsync(int page, int size);
    }
}