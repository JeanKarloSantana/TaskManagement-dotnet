using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Domain.WorkItems;

namespace TaskManagement.Infrastructure.Common.Persistence
{

  public class TaskManagementDbContext : DbContext, IUnitOfWork
  {
    public DbSet<WorkItem> WorkItems { get; set; }
    public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options)
      : base(options)
    {
    }

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