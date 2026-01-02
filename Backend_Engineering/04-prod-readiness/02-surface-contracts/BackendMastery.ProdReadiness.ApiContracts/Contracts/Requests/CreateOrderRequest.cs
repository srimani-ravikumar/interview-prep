namespace BackendMastery.ProdReadiness.ApiContracts.Contracts.Requests;

/// <summary>
/// INTUITION:
/// This is a boundary object.
/// It defines what the API ACCEPTS — not what the system stores.
/// 
/// USE CASE:
/// Allows internal order models to evolve without breaking clients.
/// 
/// FAILURE MODE:
/// Using domain models here leaks internal changes to consumers.
/// </summary>
public sealed class CreateOrderRequest
{
    /// <summary>
    /// Client-provided identifier for correlation.
    /// Not required to be globally unique.
    /// </summary>
    public string Reference { get; init; } = string.Empty;

    /// <summary>
    /// Total order amount as understood by the client.
    /// </summary>
    public decimal Amount { get; init; }
}