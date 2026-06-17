using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.UserWorkItems;

namespace TaskManagement.Infrastructure.UserWorkItems.Persistance
{
  public class UserWorkItemConfiguration : IEntityTypeConfiguration<UserWorkItem>
  {
    public void Configure(EntityTypeBuilder<UserWorkItem> builder)
    {
      builder.ToTable("UserWorkItems");

      builder.HasKey(uwi => new { uwi.UserId, uwi.WorkItemId });

      builder.HasOne(x => x.User)
                .WithMany(x => x.UserWorkItems)
                .HasForeignKey(x => x.UserId);

      builder.HasOne(x => x.WorkItem)
                .WithMany(x => x.UserWorkItems)
                .HasForeignKey(x => x.WorkItemId);
    }
  }
}