using TaskManagement.Domain.ApplicationUsers;
using TaskManagement.Domain.WorkItems;

namespace TaskManagement.Domain.UserWorkItems
{
  public class UserWorkItem
  {
    protected UserWorkItem(string userId)
    {
      UserId = userId;
      WorkItemId = new Guid();
    }

    public string UserId { get; set; }
    public Guid WorkItemId { get; set; }

    public required ApplicationUser User { get; set; }
    public required WorkItem WorkItem { get; set; }
  }
}