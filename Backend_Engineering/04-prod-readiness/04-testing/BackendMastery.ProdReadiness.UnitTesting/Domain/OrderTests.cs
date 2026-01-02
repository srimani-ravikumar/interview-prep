using BackendMastery.ECommerce.Domain.Entities;
using BackendMastery.ECommerce.Domain.ValueObjects;
using NUnit.Framework;

namespace BackendMastery.ProdReadiness.UnitTesting.Domain;

[TestFixture]
public class OrderTests
{
    [Test]
    public void Order_CalculatesTotalCorrectly()
    {
        var product = new Product(
            Guid.NewGuid(),
            "Phone",
            Money.Of(500));

        var order = new Order(Guid.NewGuid());
        order.AddItem(product, 2);

        var total = order.TotalAmount();

        Assert.That(total.Amount, Is.EqualTo(1000));
    }

    [Test]
    public void Order_DoesNotAllowZeroQuantity()
    {
        var product = new Product(
            Guid.NewGuid(),
            "Tablet",
            Money.Of(300));

        var order = new Order(Guid.NewGuid());

        Assert.Throws<ArgumentException>(() =>
            order.AddItem(product, 0));
    }
}