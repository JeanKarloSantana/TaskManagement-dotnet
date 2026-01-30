using TaskManagement.Application.Common.Interfaces;
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
    }

    public int Complete()
    {
      throw new NotImplementedException();
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public IWorkItemRepository WorkItemRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IApplicationUserRepository ApplicationUserRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


  }
}