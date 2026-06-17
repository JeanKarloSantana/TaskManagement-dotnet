using Microsoft.AspNetCore.Identity;
using TaskManagement.Domain.UserWorkItems;

namespace TaskManagement.Domain.ApplicationUsers
{
  public class ApplicationUser : IdentityUser
  {
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    public ICollection<UserWorkItem> UserWorkItems { get; set; } = new HashSet<UserWorkItem>();
  }
}
