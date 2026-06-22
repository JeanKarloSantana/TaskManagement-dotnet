using ErrorOr;
using TaskManagement.Domain.WorkItemDates;

namespace TaskManagement.Application.WorkItemDates.Commands;

public record UpdateWorkItemDateCommand(Guid WorkItemId, DateTime StartDate, DateTime? CloseDate) : IRequest<ErrorOr<WorkItemDate>>;