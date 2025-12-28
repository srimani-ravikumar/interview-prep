namespace BackendMastery.Persistence.ORM.QueryShaping.ReadModels;

/// <summary>
/// Lightweight read model.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Designed for queries
/// - Contains only what the UI needs
///
/// KEY RULE:
/// ❗ Read models optimize shape, not behavior
/// </remarks>
public class CustomerSummary
{
    public int Id { get; }
    public string Name { get; }

    public CustomerSummary(int id, string name)
    {
        Id = id;
        Name = name;
    }
}