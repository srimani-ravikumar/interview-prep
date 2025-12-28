namespace BackendMastery.Persistence.DataModeling.NormalizationTradeoffs.Domain;

public class OrderItem
{
    public string Sku { get; }
    public decimal Price { get; }
    public int Quantity { get; }

    internal OrderItem(string sku, decimal price, int quantity)
    {
        Sku = sku;
        Price = price;
        Quantity = quantity;
    }
}