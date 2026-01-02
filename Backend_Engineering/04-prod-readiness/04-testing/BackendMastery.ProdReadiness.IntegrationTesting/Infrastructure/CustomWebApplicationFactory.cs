using BackendMastery.ECommerce.Infrastructure.Persistence.EfCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BackendMastery.ProdReadiness.IntegrationTesting.Infrastructure;

/// <summary>
/// Custom test host for integration tests.
/// </summary>
public class CustomWebApplicationFactory
    : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Remove existing DbContext registration
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<ECommerceDbContext>));

            if (descriptor != null)
                services.Remove(descriptor);

            // Register SQLite in-memory DB
            services.AddDbContext<ECommerceDbContext>(options =>
            {
                options.UseSqlite("Data Source=:memory:");
            });

            // Build provider & initialize DB
            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider
                .GetRequiredService<ECommerceDbContext>();

            db.Database.OpenConnection();
            db.Database.EnsureCreated();
        });
    }
}