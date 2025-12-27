namespace BackendMastery.Architecture.DependencyInjection.Models;

/// <summary>
/// Domain model.
/// Intentionally simple – DI is about relationships, not data.
/// </summary>
public class Order
{
    public Guid Id { get; set; }
    public string Product { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}