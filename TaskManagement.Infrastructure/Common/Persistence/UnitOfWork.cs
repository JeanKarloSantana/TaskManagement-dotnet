using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Infrastructure.WorkItemDates.Persistance;
using TaskManagement.Infrastructure.WorkItems.Persistence;

namespace TaskManagement.Infrastructure.Common.Persistence
{

  public class UnitOfWork : IUnitOfWork, IDisposable
  {
    private readonly TaskManagementDbContext _dbContext;

    public UnitOfWork(TaskManagementDbContext dbContext)
    {
      _dbContext = dbContext;

      WorkItemRepository = new WorkItemRepository(_dbContext);
      WorkItemDateRepository = new WorkItemDateRepository(_dbContext);
    }

    public Task<int> Complete()
    {
      return _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
      _dbContext.Dispose();
    }

    public IWorkItemRepository WorkItemRepository { get; set; }
    public IWorkItemDateRepository WorkItemDateRepository { get; set; }
  }
}
