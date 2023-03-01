using System.Linq.Expressions;
using Core.CrossCuttingConcerns.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Core.Persistence.Repositories;

public class EfRepositoryBase<TEntity,TContext>: IAsyncRepository<TEntity>
where TEntity:Entity
where TContext:DbContext
{
    protected TContext Context { get; }

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
    {
        return filter==null ? await  Context.Set<TEntity>().ToListAsync():await Context.Set<TEntity>().Where(filter).ToListAsync();
    }

    public async Task<TEntity?> GetByFilter(Expression<Func<TEntity, bool>> filter)
    {
        return await Context.Set<TEntity>().Where(filter).SingleOrDefaultAsync();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity?> DeleteAsync(int id)
    {
        var data = await Context.Set<TEntity>().Where(x => x.Id == id).SingleOrDefaultAsync();
        if (data is null)
        {
            throw new BusinessException("Bulunamadı");
        }
        Context.Entry(data).State = EntityState.Deleted;
        await Context.SaveChangesAsync();
        return data;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return entity;
    }
}