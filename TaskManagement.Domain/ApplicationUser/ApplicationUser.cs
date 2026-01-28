using Microsoft.AspNetCore.Identity;

namespace TaskManagement.Domain.ApplicationUser
{
  public class ApplicationUser : IdentityUser
  {
    public ApplicationUser(string username, string email, bool emailConfirmed, string password)
    {
      Id = Guid.NewGuid().ToString();
      UserName = username;
      Email = email;
      EmailConfirmed = emailConfirmed;
      SecurityStamp = Guid.NewGuid().ToString();
      ConcurrencyStamp = Guid.NewGuid().ToString();
      CreationDate = DateTime.UtcNow;

      var hasher = new PasswordHasher<string>();
      PasswordHash = hasher.HashPassword(username, password);
    }

    public DateTime CreationDate { get; private set; }
  }
}