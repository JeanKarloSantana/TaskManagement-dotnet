public static class DependencyMediatorServiceExtensions
{
  public static IServiceCollection AddCustomMediator(
      this IServiceCollection services,
      params Assembly[] assemblies)
  {
    if (assemblies.Length == 0)
    {
      throw new ArgumentException("At least one assembly must be provided");
    }

    // Register the mediator itself
    services.AddScoped<ICustomMediator, CustomMediator>();

    // Scan and register handlers from all provided assemblies
    foreach (var assembly in assemblies)
    {
      RegisterHandlersFromAssembly(services, assembly);
    }

    return services;
  }

  public static IServiceCollection AddCustomMediatorFromAssemblyContaining<T>(
      this IServiceCollection services)
  {
    return services.AddCustomMediator(typeof(T).Assembly);
  }

  private static void RegisterHandlersFromAssembly(IServiceCollection services, Assembly assembly)
  {
    var handlerTypes = assembly.GetTypes()
        .Where(t => !t.IsAbstract && !t.IsInterface)
        .Select(t => new
        {
          Type = t,
          HandlerInterfaces = t.GetInterfaces()
                .Where(i => i.IsGenericType &&
                           (i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) ||
                            i.GetGenericTypeDefinition() == typeof(INotificationHandler<>)))
                .ToList()
        })
        .Where(x => x.HandlerInterfaces.Any());

    foreach (var handler in handlerTypes)
    {
      foreach (var handlerInterface in handler.HandlerInterfaces)
      {
        services.AddTransient(handlerInterface, handler.Type);
      }
    }
  }
}