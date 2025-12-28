namespace BackendMastery.Persistence.ORM.ChangeTracking.Infrastructure;

/// <summary>
/// Represents how the ORM views an entity.
/// </summary>
/// <remarks>
/// INTUITION:
/// - ORM maintains its own view of entity state
///
/// USE CASE:
/// - Decide what SQL to generate
///
/// KEY RULE:
/// ❗ Entity state is an ORM concern, not a domain concern
/// </remarks>
public enum EntityState
{
    Unchanged,
    Modified
}