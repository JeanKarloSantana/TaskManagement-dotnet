using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.ApplicationUser;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
  public void Configure(EntityTypeBuilder<ApplicationUser> builder)
  {
    builder.Ignore(au => au.NormalizedUserName);
    builder.Ignore(au => au.NormalizedEmail);
    builder.Ignore(au => au.TwoFactorEnabled);
    builder.Ignore(au => au.PhoneNumber);
    builder.Ignore(au => au.PhoneNumberConfirmed);
  }
}