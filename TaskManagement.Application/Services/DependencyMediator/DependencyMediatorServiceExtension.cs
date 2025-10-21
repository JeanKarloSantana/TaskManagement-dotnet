using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyMediatorServiceExtensions
{
  public static IServiceCollection AddCustomMediator(this IServiceCollection services, Assembly assembly)
  {
    // Register mediator infrastructure
    services.AddScoped<IDependencyMediator, DependencyMediator>(); // Your mediator implementation

    // Automatic handler discovery
    var handlerTypes = assembly.GetTypes()
        .Where(t => t.IsClass && !t.IsAbstract)
        .Select(t => new { Type = t, Interfaces = t.GetInterfaces() })
        .Where(t => t.Interfaces.Any(i =>
            i.IsGenericType &&
            i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
        .ToList();

    foreach (var handler in handlerTypes)
    {
      var handlerInterface = handler.Interfaces.First(i =>
          i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));

      services.AddScoped(handlerInterface, handler.Type);
    }

    return services;
  }

  // Keep this helper method for flexibility, but you might not need it
  public static IServiceCollection AddCustomMediatorFromAssemblyContaining<T>(this IServiceCollection services)
  {
    return services.AddCustomMediator(typeof(T).Assembly);
  }

}