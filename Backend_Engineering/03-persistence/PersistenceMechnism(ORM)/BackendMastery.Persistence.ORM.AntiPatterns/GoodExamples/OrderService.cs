namespace BackendMastery.Persistence.ORM.AntiPatterns.GoodExamples;

/// <summary>
/// Application service using repository.
/// </summary>
/// <remarks>
/// KEY RULE:
/// ❗ Application talks in intent, not persistence
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