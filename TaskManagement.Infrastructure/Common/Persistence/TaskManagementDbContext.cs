using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Domain.WorkItems;


namespace TaskManagement.Infrastructure.Common.Persistence
{

  public class TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options) : IdentityDbContext<ApplicationUser>(options), IUnitOfWork
  {
    public DbSet<WorkItem> WorkItems { get; set; }

    public Task CommitChangesAsync()
    {
      throw new NotImplementedException();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfigurationsFromAssembly(
          Assembly.GetExecutingAssembly());
    }
  }
}