using TaskManagement.Domain.ApplicationUsers;
using TaskManagement.Domain.WorkItems;

namespace TaskManagement.Domain.UserWorkItems
{
  public class UserWorkItem
  {
    public UserWorkItem(
      ApplicationUser userId,
      WorkItem workItemId)
    {
      User = userId;
      WorkItem = workItemId;
    }
    private UserWorkItem() { }

    public string UserId { get; set; }
    public Guid WorkItemId { get; set; }

    public required ApplicationUser User { get; set; }
    public required WorkItem WorkItem { get; set; }
  }
}