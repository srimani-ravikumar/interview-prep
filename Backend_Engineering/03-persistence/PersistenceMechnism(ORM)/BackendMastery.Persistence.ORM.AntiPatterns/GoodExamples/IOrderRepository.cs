namespace BackendMastery.Persistence.ORM.AntiPatterns.GoodExamples;

/// <summary>
/// Intent-based repository contract.
/// </summary>
/// <remarks>
/// KEY RULE:
/// ❗ Repository expresses use-case intent, not queries
/// </remarks>
public interface IOrderRepository
{
    Order GetByIdForUpdate(int id);
    void Save(Order order);
}