using Ardalis.SmartEnum;

namespace TaskManagement.Domain.WorkItems
{
  public class WorkItemStatusType(int value, string name) : SmartEnum<WorkItemStatusType>(name, value)
  {
    public static readonly WorkItemStatusType ToDo = new(1, nameof(ToDo));
    public static readonly WorkItemStatusType InProgress = new(2, nameof(InProgress));
    public static readonly WorkItemStatusType Done = new(3, nameof(Done));
    public static readonly WorkItemStatusType Blocked = new(4, nameof(Blocked));
  }
}