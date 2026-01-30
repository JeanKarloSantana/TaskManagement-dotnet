using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Domain.ApplicationUser;
using TaskManagement.Domain.WorkItems;

namespace TaskManagement.Infrastructure.Common.Persistence
{
  public class TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options) : IdentityDbContext<ApplicationUser>(options)
  {
    public required DbSet<ApplicationUser> ApplicationUser { get; set; }
    public required DbSet<WorkItem> WorkItems { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfigurationsFromAssembly(
          Assembly.GetExecutingAssembly());
    }
  }
}