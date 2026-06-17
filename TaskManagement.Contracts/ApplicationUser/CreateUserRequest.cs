namespace TaskManagement.Contracts.ApplicationUser
{
  public record CreateUserRequest(string UserName, string Email, string Password);
}

