using ErrorOr;
using TaskManagement.Domain.WorkItems;

namespace TaskManagement.Application.WorkItems.Commands.CreateWorkItem

{
  public record CreateWorkItemCommand(Guid UserId, string Title, string Description, DateTime DueDate, string Priority, string Status) : IRequest<ErrorOr<WorkItem>>;

}