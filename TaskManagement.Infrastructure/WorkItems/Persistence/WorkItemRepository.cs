using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Domain.WorkItems;

namespace TaskManagement.Infrastructure.WorkItems.Persistence
{

  public class WorkItemRepository() : IWorkItemRepository
  {
    private readonly static List<WorkItem> _workItems = new();
    public Task AddWorkItemAsync(WorkItem workItem)
    {
      _workItems.Add(workItem);
      
      return Task.CompletedTask;
    }
  }
}