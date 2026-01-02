namespace BackendMastery.ProdReadiness.ApiVersioning.Configuration;

/// <summary>
/// INTUITION:
/// Versioning is a policy decision, not a framework feature.
///
/// USE CASE:
/// Allows multiple contract versions to coexist.
///
/// FAILURE MODE:
/// No versioning forces breaking changes on all consumers.
/// </summary>
public static class ApiVersioningConfiguration
{
    public static IServiceCollection ConfigureApiVersioning(this IServiceCollection services)
    {
        // Intentionally simple: URI-based versioning
        return services;
    }
}