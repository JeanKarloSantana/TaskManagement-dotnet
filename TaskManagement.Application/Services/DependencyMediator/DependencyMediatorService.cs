using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

public class DependencyMediator : IDependencyMediator
{
  private readonly IServiceProvider _serviceProvider;

  public DependencyMediator(IServiceProvider serviceProvider)
  {
    _serviceProvider = serviceProvider;
  }

  public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
  {
    if (request == null)
      throw new ArgumentNullException(nameof(request));

    var requestType = request.GetType();
    var handlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, typeof(TResponse));

    var handler = _serviceProvider.GetService(handlerType);

    if (handler == null)
      throw new InvalidOperationException($"No handler registered for request type {requestType.Name}");

    var method = handlerType.GetMethod("Handle");
    var result = method.Invoke(handler, new object[] { request, cancellationToken });

    return await (Task<TResponse>)result;
  }

  public async Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
  {
    if (notification == null)
      throw new ArgumentNullException(nameof(notification));

    var handlerType = typeof(INotificationHandler<>).MakeGenericType(typeof(TNotification));
    var handlers = _serviceProvider.GetServices(handlerType);

    var tasks = new List<Task>();

    foreach (var handler in handlers)
    {
      var method = handlerType.GetMethod("Handle");
      var task = (Task)method.Invoke(handler, new object[] { notification, cancellationToken });
      tasks.Add(task);
    }

    await Task.WhenAll(tasks);
  }
}


public class GetUserQuery : IRequest<User>
{
    public int UserId { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
{
    public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        // Your logic here
        return await Task.FromResult(new User { Id = request.UserId, Name = "John Doe" });
    }
}

// Notification example
public class UserCreatedEvent : INotification
{
    public int UserId { get; set; }
}

public class EmailNotificationHandler : INotificationHandler<UserCreatedEvent>
{
    public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Send email logic
        await Task.CompletedTask;
    }
}

public class AuditNotificationHandler : INotificationHandler<UserCreatedEvent>
{
    public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Audit logic
        await Task.CompletedTask;
    }
}