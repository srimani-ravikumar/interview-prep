using BackendMastery.ECommerce.Domain.ValueObjects;

namespace BackendMastery.ECommerce.Domain.Entities;

public class OrderItem
{
    // Backing fields (EF Core friendly)
    private Product _product = null!;
    private int _quantity;

    // EF Core uses this
    private OrderItem() { }

    // Domain constructor (used by business logic)
    public OrderItem(Product product, int quantity)
    {
        Product = product ?? throw new ArgumentNullException(nameof(product));

        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero");

        Quantity = quantity;
    }

    public Product Product
    {
        get => _product;
        private set => _product = value;
    }

    public int Quantity
    {
        get => _quantity;
        private set => _quantity = value;
    }

    public Money TotalPrice()
        => Product.Price.Multiply(Quantity);
}