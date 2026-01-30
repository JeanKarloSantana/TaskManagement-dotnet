using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Common.Interfaces;

namespace TaskManagement.Infrastructure.Common.Persistence
{

  public class BaseRepository<TEntity>(TaskManagementDbContext context) : IBaseRepository<TEntity> where TEntity : class
  {
    protected TaskManagementDbContext Context { get; private set; } = context;

    public virtual TEntity? Get(Expression<Func<TEntity, bool>> predicate)
    {
      return Context.Set<TEntity>().Where(predicate).FirstOrDefault();
    }

    public virtual TEntity? Get(int id)
    {
      return Context.Set<TEntity>().Find(id);
    }

    public virtual TEntity? GetCompositeKey(int firstId, int secondId)
    {
      return Context.Set<TEntity>().Find(firstId, secondId);
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
      return [.. Context.Set<TEntity>()];
    }

    public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
    {
      return await Context.Set<TEntity>().ToListAsync();
    }

    public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
    {
      return [.. Context.Set<TEntity>().Where(predicate)];
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
      return await Context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
    }

    public virtual async Task<TEntity?> GetAsync(int id)
    {
      return await Context.Set<TEntity>().FindAsync(id);
    }


    public void Add(TEntity entity)
    {
      var entry = Context.Entry(entity);
      if (entry.State == EntityState.Detached)
      {
        Context.Set<TEntity>().Add(entity);
      }
      else
      {
        entry.State = EntityState.Modified;
      }
    }

    public void AddAll(IEnumerable<TEntity> entities)
    {
      foreach (var entity in entities)
      {
        Add(entity);
      }
    }

    public void RefreshEntity(TEntity entity)
    {
      Context.Entry(entity).Reload();
    }
  }
}