namespace TaskManagement.Domain.WorkItems

{
  public class WorkItem(Guid userId, string title, string description, DateTime dueDate, WorkItemPriorityType workItemPriorityType, string status, Guid? id = null)
  {
    public Guid Id { get; set; } = id ?? Guid.NewGuid();
    public Guid UserId { get; set; } = userId;
    public string Title { get; set; } = title;
    public string Description { get; set; } = description;
    public DateTime DueDate { get; set; } = dueDate;
    public WorkItemPriorityType WorkItemPriorityType { get; set; } = workItemPriorityType;
    public string Status { get; set; } = status;
  }
}
