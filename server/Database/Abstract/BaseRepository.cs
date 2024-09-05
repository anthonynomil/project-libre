using Application.Interface;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Models.Interface;
using PrimaryKey = Entities.Abstract.PrimaryKey;

namespace Database.Abstract;

// TODO: https://entityframework-extensions.net/ || https://www.nuget.org/packages/EFCore.BulkExtensions/
public abstract class BaseRepository<TEntity>(ProjetLibreContext context) : IBaseRepository<TEntity>
    where TEntity : class
{
    public Task<bool> AnyByIdAsync<TPrimaryEntity>(int id)
        where TPrimaryEntity : PrimaryKey
    {
        return context.Set<TPrimaryEntity>().AsNoTracking().AnyAsync(e => e.Id == id);
    }

    public Task<TPrimaryEntity?> GetByIdAsync<TPrimaryEntity>(int id)
        where TPrimaryEntity : PrimaryKey
    {
        return context.Set<TPrimaryEntity>().SingleOrDefaultAsync(e => e.Id == id);
    }

    public Task<List<TEntity>> GetPagedListAsync(IPagedListParameters pagedListParameters)
    {
        return context
            .Set<TEntity>()
            .AsNoTracking()
            .Skip(pagedListParameters.Page * pagedListParameters.Limit)
            .Take(pagedListParameters.Limit)
            .ToListAsync();
    }

    public Task CreateAndSaveAsync(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
        return context.SaveChangesAsync();
    }

    public Task CreateBatchAndSaveAsync(IEnumerable<TEntity> entities)
    {
        context.Set<TEntity>().AddRangeAsync(entities);
        return context.SaveChangesAsync();
    }

    public Task UpdateAndSaveAsync(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
        return context.SaveChangesAsync();
    }

    public Task UpdateBatchAndSaveAsync(IEnumerable<TEntity> entities)
    {
        context.Set<TEntity>().UpdateRange(entities);
        return context.SaveChangesAsync();
    }

    public Task DeleteAndSaveAsync(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
        return context.SaveChangesAsync();
    }

    public Task DeleteBatchAndSaveAsync(IEnumerable<TEntity> entities)
    {
        context.Set<TEntity>().RemoveRange(entities);
        return context.SaveChangesAsync();
    }
}
