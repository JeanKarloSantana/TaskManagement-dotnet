namespace TaskManagement.Contracts.Tasks;

    public record CreateTaskRequest(Guid userId, string title, string description, DateTime dueDate, string priority, string status);
