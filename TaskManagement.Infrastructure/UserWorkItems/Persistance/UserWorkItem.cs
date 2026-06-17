namespace TaskManagement.Infrastructure.UserWorkItems.Persistance
{
  using TaskManagement.Application.Common.Interfaces;
  using TaskManagement.Domain.UserWorkItems;
  using TaskManagement.Infrastructure.Common.Persistence;

  public class UserWorkItemRepository(TaskManagementDbContext context) : BaseRepository<UserWorkItem>(context), IUserWorkRepository
  {
  }
}