using Microsoft.AspNetCore.Identity;
using TaskManagement.Domain.UserWorkItems;

namespace TaskManagement.Domain.ApplicationUsers
{
  public class ApplicationUser : IdentityUser
  {
    protected ApplicationUser()
    {
      CreationDate = DateTime.UtcNow;
    }

     public DateTime CreationDate { get; set; }
     public ICollection<UserWorkItem> UserWorkItems { get; set; } = new HashSet<UserWorkItem>();
  }
}
