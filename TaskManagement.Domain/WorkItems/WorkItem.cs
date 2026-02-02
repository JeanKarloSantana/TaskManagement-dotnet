using TaskManagement.Domain.UserWorkItems;

namespace TaskManagement.Domain.WorkItems

{
  public class WorkItem
  {
    public WorkItem(
      Guid userId,
      string title,
      string description,
      DateTime dueDate,
      WorkItemPriorityType priority,
      WorkItemStatusType status)
    {
      Id = Guid.NewGuid();
      UserId = userId;
      Title = title;
      Description = description;
      DueDate = dueDate;
      WorkItemPriorityType = priority;
      WorkItemStatusType = status;
    }
    private WorkItem() { }

    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Title { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public DateTime DueDate { get; private set; }
    public WorkItemPriorityType WorkItemPriorityType { get; private set; } = default!;
    public WorkItemStatusType WorkItemStatusType { get; private set; } = default!;
    public ICollection<UserWorkItem> UserWorkItems { get; set; } = new HashSet<UserWorkItem>();
  }
}
