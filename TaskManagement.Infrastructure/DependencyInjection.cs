using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Application.Services.JwtGenerator;
using TaskManagement.Domain.ApplicationUsers;
using TaskManagement.Infrastructure.Authentication;
using TaskManagement.Infrastructure.Common.Persistence;
using TaskManagement.Infrastructure.WorkItemDates.Persistance;
using TaskManagement.Infrastructure.WorkItems.Persistence;

namespace TaskManagement.Infrastructure
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
      var jwtSettings = CreateJwtSettings(configuration);
      var signingKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(jwtSettings.Secret));

      services.AddDbContext<TaskManagementDbContext>(options =>
        options.UseSqlServer(
          configuration.GetConnectionString("DeimosDbContext")));

      services
        .AddIdentityCore<ApplicationUser>()
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<TaskManagementDbContext>();

      services.Configure<IdentityOptions>(options =>
      {
        options.User.RequireUniqueEmail = true;
        options.Lockout.AllowedForNewUsers = true;
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
      });

      services
        .AddAuthentication(options =>
        {
          options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
          options.MapInboundClaims = false;
          options.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtSettings.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = signingKey,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromSeconds(30),
            NameClaimType = ClaimTypes.NameIdentifier,
            RoleClaimType = ClaimTypes.Role
          };
        });

      services.AddAuthorization();
      services.AddSingleton(jwtSettings);
      services.AddSingleton(TimeProvider.System);
      services.AddScoped<IJwtGenerator, JwtGenerator>();

      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped<IWorkItemRepository, WorkItemRepository>();
      services.AddScoped<IWorkItemDateRepository, WorkItemDateRepository>();

      return services;
    }

    private static JwtSettings CreateJwtSettings(IConfiguration configuration)
    {
      var issuer = configuration[$"{JwtSettings.SectionName}:Issuer"];
      var audience = configuration[$"{JwtSettings.SectionName}:Audience"];
      var secret = configuration[$"{JwtSettings.SectionName}:Secret"];
      var expirationMinutes = configuration.GetValue<int?>(
        $"{JwtSettings.SectionName}:ExpirationMinutes") ?? 15;

      if (string.IsNullOrWhiteSpace(issuer) ||
          string.IsNullOrWhiteSpace(audience) ||
          string.IsNullOrWhiteSpace(secret))
      {
        throw new InvalidOperationException(
          "JWT Issuer, Audience, and Secret configuration values are required.");
      }

      if (Encoding.UTF8.GetByteCount(secret) < 32)
      {
        throw new InvalidOperationException(
          "JWT Secret must contain at least 32 bytes.");
      }

      if (expirationMinutes <= 0)
      {
        throw new InvalidOperationException(
          "JWT ExpirationMinutes must be greater than zero.");
      }

      return new JwtSettings
      {
        Issuer = issuer,
        Audience = audience,
        Secret = secret,
        ExpirationMinutes = expirationMinutes
      };
    }
  }
}
