using BackendMastery.ECommerce.Domain.Entities;
using BackendMastery.ECommerce.Domain.ValueObjects;
using BackendMastery.ECommerce.Infrastructure.Persistence.EfCore;
using BackendMastery.ProdReadiness.IntegrationTesting.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Net;
using System.Net.Http.Json;

namespace BackendMastery.ProdReadiness.IntegrationTesting.Api;

[TestFixture]
public class OrdersApiTests
{
    private CustomWebApplicationFactory _factory = null!;
    private HttpClient _client = null!;

    [SetUp]
    public void Setup()
    {
        _factory = new CustomWebApplicationFactory();
        _client = _factory.CreateClient();
    }

    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    [Test]
    public async Task CreateOrder_Returns201Created()
    {
        // Arrange — seed product
        using (var scope = _factory.Services.CreateScope())
        {
            var db = scope.ServiceProvider
                .GetRequiredService<ECommerceDbContext>();

            db.Products.Add(new Product(
                Guid.NewGuid(),
                "Keyboard",
                Money.Of(100)));

            db.SaveChanges();
        }

        var productId = GetProductIdFromDb();

        // Act
        var response = await _client.PostAsJsonAsync(
            "/api/orders",
            new
            {
                ProductId = productId,
                Quantity = 2
            });

        // Assert
        Assert.That(response.StatusCode,
            Is.EqualTo(HttpStatusCode.Created));
    }

    private Guid GetProductIdFromDb()
    {
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider
            .GetRequiredService<ECommerceDbContext>();

        return db.Products.Select(p => p.Id).First();
    }
}