using BackendMastery.ECommerce.Domain.Entities;
using BackendMastery.ECommerce.Domain.ValueObjects;
using NUnit.Framework;

namespace BackendMastery.ProdReadiness.UnitTesting.Domain;

[TestFixture]
public class ProductTests
{
    [Test]
    public void Product_RequiresName()
    {
        Assert.Throws<ArgumentException>(() =>
            new Product(Guid.NewGuid(), "", Money.Of(100)));
    }

    [Test]
    public void Product_CreatedSuccessfully()
    {
        var product = new Product(
            Guid.NewGuid(),
            "Laptop",
            Money.Of(1500));

        Assert.That(product.Name, Is.EqualTo("Laptop"));
        Assert.That(product.Price.Amount, Is.EqualTo(1500));
    }
}