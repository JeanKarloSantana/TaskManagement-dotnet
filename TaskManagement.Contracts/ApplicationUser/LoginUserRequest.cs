namespace TaskManagement.Contracts.ApplicationUser
{
  public sealed record LoginUserRequest(
    string Email,
    string Password);
}
