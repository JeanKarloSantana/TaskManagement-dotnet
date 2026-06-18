using System.Reflection;
using FluentValidation;
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

    var validatorTypes = assembly.GetTypes()
        .Where(type => type.IsClass && !type.IsAbstract)
        .SelectMany(type => type.GetInterfaces()
            .Where(serviceType =>
                serviceType.IsGenericType &&
                serviceType.GetGenericTypeDefinition() == typeof(IValidator<>))
            .Select(serviceType => new { ServiceType = serviceType, ImplementationType = type }));

    foreach (var validator in validatorTypes)
    {
      services.AddScoped(validator.ServiceType, validator.ImplementationType);
    }

    return services;
  }
 
  public static IServiceCollection AddCustomMediatorFromAssemblyContaining<T>(this IServiceCollection services)
  {
    return services.AddCustomMediator(typeof(T).Assembly);
  }

}
