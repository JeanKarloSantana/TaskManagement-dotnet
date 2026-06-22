using ErrorOr;
using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Domain.WorkItemDates;

namespace TaskManagement.Application.WorkItemDates.Commands;

public class WorkItemDateHandler(IWorkItemDateRepository workItemDateRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateWorkItemDateCommand, ErrorOr<WorkItemDate>>
{
    private readonly IWorkItemDateRepository _workItemDateRepository = workItemDateRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ErrorOr<WorkItemDate>> Handle(UpdateWorkItemDateCommand request, CancellationToken cancellationToken = default)
    {
        var workItemDate = new WorkItemDate(request.WorkItemId, request.StartDate, request.CloseDate);

        var workItemDateQueryResult = await _workItemDateRepository.GetAsync(wid => wid.Id == workItemDate.Id);

        if (workItemDateQueryResult is null)
        {
            _workItemDateRepository.Add(workItemDate);
            await _unitOfWork.Complete();
            return workItemDate;
        }

        workItemDateQueryResult.StartDate = request.StartDate;
        workItemDateQueryResult.CloseDate = request.CloseDate;
        await _unitOfWork.Complete();
        return workItemDateQueryResult;
    }
}
