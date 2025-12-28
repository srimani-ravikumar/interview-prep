namespace BackendMastery.Persistence.ORM.RepositoryImplementation.Domain;

/// <summary>
/// Defines persistence operations for Order.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Repository expresses intent, not queries
///
/// USE CASE:
/// - Fetch order for processing
///
/// KEY RULE:
/// ❗ Repository interfaces belong to the domain layer
/// </remarks>
public interface IOrderRepository
{
    Order GetByIdForUpdate(int id);
    void Save(Order order);
}