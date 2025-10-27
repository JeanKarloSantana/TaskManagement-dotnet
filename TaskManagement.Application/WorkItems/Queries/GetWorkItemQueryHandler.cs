using ErrorOr;
using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Domain.WorkItems;

namespace TaskManagement.Application.WorkItems.Queries

{
  public class GetWorkItemQueryHandler : IRequestHandler<GetWorkItemQuery, ErrorOr<WorkItem>>
  {
     private readonly IWorkItemRepository _workItemRepository;
  }

}