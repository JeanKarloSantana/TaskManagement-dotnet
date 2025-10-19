// Marker interfaces for requests and notifications
public interface IRequest<TResponse> { }
public interface IRequest : IRequest<Unit> { }
public interface INotification { }
public record Unit;

// Handler interfaces
public interface IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
  Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken = default);
}

public interface INotificationHandler<TNotification> where TNotification : INotification
{
  Task Handle(TNotification notification, CancellationToken cancellationToken = default);
}
