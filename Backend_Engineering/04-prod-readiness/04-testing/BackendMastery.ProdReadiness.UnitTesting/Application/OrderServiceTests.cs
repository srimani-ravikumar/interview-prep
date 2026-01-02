using BackendMastery.ECommerce.Application.Exceptions;
using BackendMastery.ECommerce.Application.Services;
using BackendMastery.ECommerce.Domain.Entities;
using BackendMastery.ECommerce.Domain.ValueObjects;
using BackendMastery.ECommerce.Infrastructure.Persistence.InMemory;
using NUnit.Framework;

namespace BackendMastery.ProdReadiness.UnitTesting.Application;

[TestFixture]
public class OrderServiceTests
{
    [Test]
    public async Task CreateOrder_CreatesOrderSuccessfully()
    {
        var productRepo = new InMemoryProductRepository();
        var orderRepo = new InMemoryOrderRepository();

        var product = new Product(
            Guid.NewGuid(),
            "Monitor",
            Money.Of(800));

        await productRepo.AddAsync(product);

        var service = new OrderService(productRepo, orderRepo);

        var orderId = await service.CreateOrderAsync(product.Id, 2);
        var order = await orderRepo.GetByIdAsync(orderId);

        Assert.That(order, Is.Not.Null);
        Assert.That(order!.TotalAmount().Amount, Is.EqualTo(1600));
    }

    [Test]
    public void CreateOrder_ThrowsIfProductNotFound()
    {
        var productRepo = new InMemoryProductRepository();
        var orderRepo = new InMemoryOrderRepository();

        var service = new OrderService(productRepo, orderRepo);

        Assert.ThrowsAsync<NotFoundException>(() =>
            service.CreateOrderAsync(Guid.NewGuid(), 1));
    }
}