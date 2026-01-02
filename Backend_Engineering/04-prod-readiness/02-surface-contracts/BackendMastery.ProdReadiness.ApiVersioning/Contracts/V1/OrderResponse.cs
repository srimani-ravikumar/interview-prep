namespace BackendMastery.ProdReadiness.ApiVersioning.Contracts.V1;

/// <summary>
/// INTUITION:
/// V1 contract reflects the original promise.
///
/// FAILURE MODE:
/// Changing this breaks existing consumers.
/// </summary>
public sealed class OrderResponse
{
    public Guid OrderId { get; set; }
    public string Status { get; set; } = string.Empty;

    // Legacy field — must not be removed in V1
    public decimal TotalAmount { get; set; }
}