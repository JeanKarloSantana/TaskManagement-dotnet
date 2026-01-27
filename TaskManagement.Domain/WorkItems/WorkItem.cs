namespace TaskManagement.Domain.WorkItems

{
  public class WorkItem
  {
    private WorkItem() { }

    public WorkItem(Guid userId, string title, string description,
                    DateTime dueDate, WorkItemPriorityType workItemPriorityType,
                    WorkItemStatusType workItemStatusType, Guid? id = null)
    {
      Id = id ?? Guid.NewGuid();
      UserId = userId;
      Title = title;
      Description = description;
      DueDate = dueDate;
      WorkItemPriorityType = workItemPriorityType;
      WorkItemStatusType = workItemStatusType;
    }

    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid UserId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime DueDate { get; private set; }
    public WorkItemPriorityType WorkItemPriorityType { get; private set; }
    public WorkItemStatusType WorkItemStatusType { get; private set; }
  }
}
