namespace BackendMastery.Persistence.ORM.AntiPatterns.GoodExamples;

/// <summary>
/// Infrastructure-only persistence logic.
/// </summary>
/// <remarks>
/// KEY RULE:
/// ❗ ORM stays here, nowhere else
/// </remarks>
public class OrderRepository : IOrderRepository
{
    private readonly Dictionary<int, Order> _store = new()
    {
        { 1, new Order(1) }
    };

    public Order GetByIdForUpdate(int id)
    {
        return _store[id];
    }

    public void Save(Order order)
    {
        Console.WriteLine($"Persisting Order {order.Id} with Status={order.Status}");
    }
}