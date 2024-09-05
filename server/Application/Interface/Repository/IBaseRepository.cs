using Entities.Abstract;
using Models.Interface;

namespace Application.Interface;

public interface IBaseRepository<TEntity>
    where TEntity : class
{
    Task<bool> AnyByIdAsync<TPrimaryEntity>(int id)
        where TPrimaryEntity : PrimaryKey;

    Task<TPrimaryEntity?> GetByIdAsync<TPrimaryEntity>(int id)
        where TPrimaryEntity : PrimaryKey;
    Task<List<TEntity>> GetPagedListAsync(IPagedListParameters pagedListParameters);

    Task CreateAndSaveAsync(TEntity entity);
    Task CreateBatchAndSaveAsync(IEnumerable<TEntity> entities);

    Task UpdateAndSaveAsync(TEntity entity);
    Task UpdateBatchAndSaveAsync(IEnumerable<TEntity> entities);

    Task DeleteAndSaveAsync(TEntity entity);
    Task DeleteBatchAndSaveAsync(IEnumerable<TEntity> entities);
}
