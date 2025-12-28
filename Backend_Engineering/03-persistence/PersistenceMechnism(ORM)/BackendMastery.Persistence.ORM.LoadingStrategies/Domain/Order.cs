namespace BackendMastery.Persistence.ORM.LoadingStrategies.Domain;

/// <summary>
/// Represents an order aggregate.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Navigation properties look harmless
/// - But may hide database calls
///
/// KEY RULE:
/// ❗ Accessing properties should not cause IO
/// </remarks>
public class Order
{
    public int Id { get; }

    // Simulated lazy-loaded navigation
    private readonly Func<List<OrderItem>> _loadItems;
    private List<OrderItem>? _items;

    public Order(int id, Func<List<OrderItem>> loadItems)
    {
        Id = id;
        _loadItems = loadItems;
    }

    public IReadOnlyList<OrderItem> Items
    {
        get
        {
            if (_items == null)
            {
                Console.WriteLine("⚠️ Lazy loading OrderItems (DB HIT)");
                _items = _loadItems();
            }
            return _items;
        }
    }
}