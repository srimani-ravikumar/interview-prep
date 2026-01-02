using BackendMastery.ECommerce.Domain.ValueObjects;
using NUnit.Framework;

namespace BackendMastery.ProdReadiness.UnitTesting.Domain;

[TestFixture]
public class MoneyTests
{
    [Test]
    public void Money_CannotBeNegative()
    {
        Assert.Throws<ArgumentException>(() =>
            Money.Of(-10));
    }

    [Test]
    public void Money_AddsCorrectly()
    {
        var m1 = Money.Of(100);
        var m2 = Money.Of(50);

        var result = m1.Add(m2);

        Assert.That(result.Amount, Is.EqualTo(150));
    }

    [Test]
    public void Money_MultipliesCorrectly()
    {
        var money = Money.Of(200);

        var result = money.Multiply(3);

        Assert.That(result.Amount, Is.EqualTo(600));
    }
}