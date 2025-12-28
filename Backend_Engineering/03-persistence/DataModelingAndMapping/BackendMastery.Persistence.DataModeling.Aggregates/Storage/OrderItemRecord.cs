namespace BackendMastery.Persistence.DataModeling.Aggregates.Storage;

public class OrderItemRecord
{
    public Guid OrderId { get; set; }
    public string Sku { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}