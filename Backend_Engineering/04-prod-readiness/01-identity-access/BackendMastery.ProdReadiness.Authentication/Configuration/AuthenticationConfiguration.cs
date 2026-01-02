using BackendMastery.ProdReadiness.Authentication.Infrastructure.ApiKeys;
using BackendMastery.ProdReadiness.Authentication.Infrastructure.Jwt;
using BackendMastery.ProdReadiness.Authentication.Services;

namespace BackendMastery.ProdReadiness.Authentication.Configuration;

/// WHY: Centralizes authentication wiring.
/// USE CASE: Keeps Program.cs clean.
/// WARNING: Misconfiguration here weakens security.
public static class AuthenticationConfiguration
{
    public static IServiceCollection AddAuthenticationInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var jwtOptions = configuration
            .GetSection("Jwt")
            .Get<JwtOptions>()!;

        services.AddSingleton(jwtOptions);
        services.AddSingleton<JwtTokenValidator>();
        services.AddSingleton<TokenIssuer>();
        services.AddSingleton<CredentialAuthenticationService>();

        services.AddSingleton(
            new ApiKeyValidator(
                configuration
                    .GetSection("ApiKeys")
                    .Get<string[]>()!));

        return services;
    }
}