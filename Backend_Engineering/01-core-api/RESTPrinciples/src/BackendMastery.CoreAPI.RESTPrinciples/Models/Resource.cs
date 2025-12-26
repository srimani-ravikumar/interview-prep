namespace BackendMastery.CoreAPI.RESTPrinciples.Models;

/// <summary>
/// Represents a generic resource used to demonstrate HTTP semantics.
/// </summary>
public class Resource
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Version { get; set; }
}