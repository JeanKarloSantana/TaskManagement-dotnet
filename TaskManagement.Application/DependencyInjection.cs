using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Services;

namespace TaskManagement.Application
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
      services.AddScoped<ITasksService, TasksService>();
      services.AddCustomMediator(Assembly.GetExecutingAssembly());
      
      return services;
    }
  }
}