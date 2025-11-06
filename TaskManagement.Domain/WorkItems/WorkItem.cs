namespace TaskManagement.Domain.WorkItems

{
  public class WorkItem
  {
    public WorkItem() { }

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

    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime DueDate { get; set; }
    public required WorkItemPriorityType WorkItemPriorityType { get; set; }
    public required WorkItemStatusType WorkItemStatusType { get; set; }
  }
}
