using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TaskManagement.Infrastructure.Common.Persistence
{
    public class TaskManagementDbContextFactory
        : IDesignTimeDbContextFactory<TaskManagementDbContext>
    {
        public TaskManagementDbContext CreateDbContext(string[] args)
        {
            // Move up to solution root, then into API project
            var basePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "..",
                "TaskManagement.Api");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TaskManagementDbContext>();

            optionsBuilder.UseSqlServer(
                configuration.GetConnectionString("DeimosDbContext"));

            return new TaskManagementDbContext(optionsBuilder.Options)
            {
                ApplicationUser = null!,
                WorkItems = null!,
                UserWorkItems = null!,
                WorkItemDates = null!
            };
        }
    }
}
