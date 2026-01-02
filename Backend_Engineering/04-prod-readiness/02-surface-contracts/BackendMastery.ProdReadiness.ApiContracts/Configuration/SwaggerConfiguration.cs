using Microsoft.OpenApi.Models;

namespace BackendMastery.ProdReadiness.ApiContracts.Configuration;

/// <summary>
/// INTUITION:
/// Swagger is not documentation — it is a consumer-facing contract.
/// 
/// USE CASE:
/// Enables frontend, mobile, and partner teams to rely on a stable API surface.
/// 
/// FAILURE MODE:
/// If Swagger reflects internal models accidentally, consumers bind to internals.
/// </summary>
public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "BackendMastery API Contracts",
                Version = "v1",
                Description = "Demonstrates explicit, stable API contracts"
            });
        });

        return services;
    }
}