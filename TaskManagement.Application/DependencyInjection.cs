using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Services;

namespace TaskManagement.Application
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
      services.AddScoped<ITasksService, TasksService>();
      
      return services;
    }
  }
}