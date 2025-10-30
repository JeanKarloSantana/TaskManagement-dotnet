using Ardalis.SmartEnum;

namespace TaskManagement.Domain.WorkItems
{
  public class WorkItemPriorityType(int value, string name) : SmartEnum<WorkItemPriorityType>(name, value)
  {
    public static readonly WorkItemPriorityType Low = new(1, nameof(Low));
    public static readonly WorkItemPriorityType Medium = new(2, nameof(Medium));
    public static readonly WorkItemPriorityType High = new(3, nameof(High));
    public static readonly WorkItemPriorityType Critical = new(4, nameof(Critical));
  }
}