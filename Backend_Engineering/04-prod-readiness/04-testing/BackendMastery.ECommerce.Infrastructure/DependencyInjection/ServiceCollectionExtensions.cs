using BackendMastery.ECommerce.Application.Interfaces;
using BackendMastery.ECommerce.Application.Services;
using BackendMastery.ECommerce.Infrastructure.Persistence.EfCore;
using BackendMastery.ECommerce.Infrastructure.Persistence.InMemory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BackendMastery.ECommerce.Infrastructure.DependencyInjection;

/// <summary>
/// Centralized infrastructure wiring.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInMemoryInfrastructure(
        this IServiceCollection services)
    {
        services.AddSingleton<IProductRepository, InMemoryProductRepository>();
        services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();

        services.AddScoped<ProductService>();
        services.AddScoped<OrderService>();

        return services;
    }

    public static IServiceCollection AddEfCoreInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<ECommerceDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddScoped<IProductRepository, EfProductRepository>();
        services.AddScoped<IOrderRepository, EfOrderRepository>();

        services.AddScoped<ProductService>();
        services.AddScoped<OrderService>();

        return services;
    }
}