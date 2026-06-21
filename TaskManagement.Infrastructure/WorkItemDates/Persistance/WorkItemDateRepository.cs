using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Domain.WorkItemDates;
using TaskManagement.Infrastructure.Common.Persistence;

namespace TaskManagement.Infrastructure.WorkItemDates.Persistance;

public class WorkItemDateRepository(TaskManagementDbContext context) : BaseRepository<WorkItemDate>(context), IWorkItemDateRepository
{

}