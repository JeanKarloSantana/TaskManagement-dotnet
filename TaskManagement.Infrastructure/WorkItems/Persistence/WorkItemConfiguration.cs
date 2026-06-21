using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.WorkItems;

namespace TaskManagement.Infrastructure.WorkItems.Persistence;
public class WorkItemConfiguration : IEntityTypeConfiguration<WorkItem>
{
    public void Configure(EntityTypeBuilder<WorkItem> builder)
    {
        builder.ToTable("WorkItems");

        builder.HasKey(wi => wi.Id);

        builder.Property(wi => wi.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(wi => wi.Description)
            .HasMaxLength(2000);

        builder.Property(wi => wi.DueDate)
            .IsRequired();

        builder.Property(wi => wi.WorkItemPriorityType)
           .HasConversion(
               priority => priority.Value, // Convert to int for storage
               value => WorkItemPriorityType.FromValue(value) // Convert back from int
           )
           .IsRequired();

        builder.Property(wi => wi.WorkItemStatusType)
            .HasConversion(
                status => status.Value, // Convert to int for storage
                value => WorkItemStatusType.FromValue(value) // Convert back from int
            )
            .IsRequired();
    }
}