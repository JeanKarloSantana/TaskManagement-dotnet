using ErrorOr;

namespace TaskManagement.Application.Tasks.Commands.CreateTask

{
  public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, ErrorOr<Guid>>
  {
    public async Task<ErrorOr<Guid>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
      Console.WriteLine("Creating task...");
      return Guid.NewGuid();
    }
  }
}