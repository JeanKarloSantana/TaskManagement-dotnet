namespace TaskManagement.Domain.WorkItems

{
  public class WorkItem(Guid userId, string title, string description,
                  DateTime dueDate, WorkItemPriorityType workItemPriorityType,
                  WorkItemStatusType workItemStatusType, Guid? id = null)
  {
    public Guid Id { get; private set; } = id ?? Guid.NewGuid();
    public Guid UserId { get; private set; } = userId;
    public string Title { get; private set; } = title;
    public string Description { get; private set; } = description;
    public DateTime DueDate { get; private set; } = dueDate;
    public WorkItemPriorityType WorkItemPriorityType { get; private set; } = workItemPriorityType;
    public WorkItemStatusType WorkItemStatusType { get; private set; } = workItemStatusType;
  }
}
