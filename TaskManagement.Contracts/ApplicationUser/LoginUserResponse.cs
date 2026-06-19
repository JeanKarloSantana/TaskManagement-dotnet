namespace TaskManagement.Contracts.ApplicationUser
{
  public sealed record LoginUserResponse(
    string AccessToken,
    DateTime ExpiresAtUtc,
    string TokenType = "Bearer");
}
