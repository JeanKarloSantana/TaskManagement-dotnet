using TaskManagement.Domain.WorkItems;

namespace TaskManagement.Domain.WorkItemDates
{
    public class WorkItemDate
    {
        public WorkItemDate(Guid workItemId, DateTime startDate, DateTime? closeDate = null)
        {
            Id = workItemId;
            StartDate = startDate;
            CloseDate = closeDate;
        }
        private WorkItemDate() { }
        public Guid Id { get; set; }
        public DateTime StartDate { get; private set; }
        public DateTime? CloseDate { get; private set; }
        public WorkItem WorkItem { get; private set; } = default!;
    }
}