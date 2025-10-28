using ErrorOr;
using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Domain.WorkItems;

namespace TaskManagement.Application.WorkItems.Queries

{
  public class GetWorkItemQueryHandler(IWorkItemRepository workItemRepository) : IRequestHandler<GetWorkItemQuery, ErrorOr<WorkItem>>
  {
    private readonly IWorkItemRepository _workItemRepository = workItemRepository;

    public async Task<ErrorOr<WorkItem>> Handle(GetWorkItemQuery request, CancellationToken cancellationToken)
    {
      var workItem = await _workItemRepository.GetWorkItemByIdAsync(request.WorkItemId);

      return workItem is null ? Error.NotFound(description: "Work item not found.") : workItem;
    }
  }
}