namespace BackendMastery.ApiProduction.EnvironmentConfiguration.Infrastructure;

/// <summary>
/// WHY:
/// Isolates how the runtime environment is determined.
///
/// WHAT PROBLEM IT SOLVES:
/// Prevents scattering environment checks across the codebase.
///
/// WHEN TO USE:
/// Whenever environment awareness affects behavior.
///
/// WHAT BREAKS IF MISUSED:
/// Direct environment checks lead to untestable, brittle code.
/// </summary>
public sealed class EnvironmentResolver
{
    public string Resolve()
    {
        return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
               ?? "Production"; // Safe default
    }
}