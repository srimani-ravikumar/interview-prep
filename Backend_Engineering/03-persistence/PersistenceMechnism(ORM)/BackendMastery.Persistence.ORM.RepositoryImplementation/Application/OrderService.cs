using BackendMastery.Persistence.ORM.RepositoryImplementation.Domain;

namespace BackendMastery.Persistence.ORM.RepositoryImplementation.Application;

/// <summary>
/// Coordinates order-related use cases.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Application layer orchestrates use cases
/// - It should not know ORM details
///
/// USE CASE:
/// - Mark order as paid
///
/// KEY RULE:
/// ❗ Application code talks to repositories, not DbContexts
/// </remarks>
public class OrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public void PayOrder(int orderId)
    {
        var order = _repository.GetByIdForUpdate(orderId);

        order.MarkAsPaid();

        _repository.Save(order);
    }
}