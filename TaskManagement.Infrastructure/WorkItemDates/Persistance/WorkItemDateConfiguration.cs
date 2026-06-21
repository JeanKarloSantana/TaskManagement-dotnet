using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.WorkItemDates;

namespace TaskManagement.Infrastructure.WorkItemDates.Persistance;

public class WorkItemDateConfiguration : IEntityTypeConfiguration<WorkItemDate>
{
    public void Configure(EntityTypeBuilder<WorkItemDate> builder)
    {
        builder.ToTable("WorkItemDates");

        builder.HasKey(wi => wi.Id);

        builder.Property(wi => wi.StartDate)
            .IsRequired();

        builder.Property(wi => wi.CloseDate)
            .IsRequired();

        builder.HasOne(wi => wi.WorkItem)
            .WithOne(wi => wi.WorkItemDate)
            .HasForeignKey<WorkItemDate>(wi => wi.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}