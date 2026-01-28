namespace TaskManagement.Contracts.ApplicationUser
{
  public record CreateApplicationUserRequest(string UserName, string Email, bool EmailConfirmed, string Password);
}

