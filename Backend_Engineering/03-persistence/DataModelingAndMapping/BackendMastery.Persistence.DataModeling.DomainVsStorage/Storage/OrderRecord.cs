using BackendMastery.Persistence.DataModeling.DomainVsStorage.Domain;

namespace BackendMastery.Persistence.DataModeling.DomainVsStorage.Storage;

/// <summary>
/// Storage model representing how Order data is persisted.
/// </summary>
/// <remarks>
/// INTUITION:
/// - This model answers: "How do we store an Order?"
/// - Optimized for databases, not business logic
///
/// KEY RULE:
/// - Storage models are allowed to be ugly
/// - Domain models are not
/// </remarks>
public class OrderRecord
{
    public Guid Id { get; set; }

    // Stored value
    public decimal Amount { get; set; }

    // Storage-only concerns
    public DateTime CreatedAtUtc { get; set; }
    public Status Status { get; set; }
}