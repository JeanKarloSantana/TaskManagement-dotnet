namespace TaskManagement.Application.Common.Interfaces
{
  public interface IUnitOfWork
  {
    Task<int> Complete();
    void Dispose();

    public IWorkItemRepository WorkItemRepository { get; set; }
    public IApplicationUserRepository ApplicationUserRepository { get; set; }
  }
}