using ErrorOr;
using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Domain.WorkItems;

namespace TaskManagement.Application.WorkItems.Commands.CreateWorkItem

{
  public class CreateWorkItemCommandHandler(IWorkItemRepository workItemRepository /*IUnitOfWork unitOfWork*/) : IRequestHandler<CreateWorkItemCommand, ErrorOr<WorkItem>>
  {
    private readonly IWorkItemRepository _workItemRepository = workItemRepository;
    //private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<WorkItem>> Handle(CreateWorkItemCommand request, CancellationToken cancellationToken)
    {
      var workItem = new WorkItem
      {
        Id = Guid.NewGuid(),
        UserId = request.UserId,
        Title = request.Title,
        Description = request.Description,
        DueDate = request.DueDate,
        Priority = request.Priority,
        Status = request.Status
      };

      await _workItemRepository.AddWorkItemAsync(workItem);

      //await _unitOfWork.CommitChangesAsync();

      return workItem;
    }
  }
}