using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Domain.ApplicationUser;
using TaskManagement.Infrastructure.Common.Persistence;

namespace TaskManagement.Infrastructure.ApplicationUsers.Persistence
{

  public class ApplicationUserRepository(TaskManagementDbContext context) : BaseRepository<ApplicationUser>(context), IApplicationUserRepository
  {

  }
}