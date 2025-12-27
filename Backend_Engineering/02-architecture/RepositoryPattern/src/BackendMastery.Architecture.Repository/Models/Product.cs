namespace BackendMastery.Architecture.Repository.Models;

/// <summary>
/// Passive data model.
/// </summary>
/// <remarks>
/// Intuition:
/// - Represents data as stored/retrieved
/// - No behavior, no rules
///
/// Why?
/// - Repository focuses on data access, not business logic
/// </remarks>
public class Product
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}