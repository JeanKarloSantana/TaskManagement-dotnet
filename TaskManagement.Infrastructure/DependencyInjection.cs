using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Domain.ApplicationUsers;
using TaskManagement.Infrastructure.Common.Persistence;
using TaskManagement.Infrastructure.WorkItems.Persistence;

namespace TaskManagement.Infrastructure
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<TaskManagementDbContext>(options =>
        options.UseSqlServer(
          configuration.GetConnectionString("DeimosDbContext")));

      services
        .AddIdentityCore<ApplicationUser>()
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<TaskManagementDbContext>();

      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped<IWorkItemRepository, WorkItemRepository>();

      return services;
    }
  }
}
