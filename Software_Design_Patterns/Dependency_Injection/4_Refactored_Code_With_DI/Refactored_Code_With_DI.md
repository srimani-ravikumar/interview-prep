# Refactored Code Using Dependency Injection

## Clean Design Goals
- `OrderService` depends only on **abstractions**, not concrete classes.
- Payment gateways (Stripe, PayPal, etc.) are **easily swappable**.
- System becomes **test-friendly**, **extensible**, and **maintainable**.

---

## Interfaces & Implementations — C#

```csharp
// Common interface for all payment providers
public interface IPaymentGateway
{
    AuthorizationResult Authorize(decimal amount, string currency, Dictionary<string, string> metadata);
}

// Stripe payment gateway implementation
public class StripeGateway : IPaymentGateway
{
    private readonly string _apiKey;

    public StripeGateway(string apiKey)
    {
        _apiKey = apiKey;
    }

    public AuthorizationResult Authorize(decimal amount, string currency, Dictionary<string, string> metadata)
    {
        // Simulate Stripe API call
        return new AuthorizationResult
        {
            Success = true,
            Message = "Stripe authorization successful."
        };
    }
}

// PayPal payment gateway implementation
public class PayPalGateway : IPaymentGateway
{
    public AuthorizationResult Authorize(decimal amount, string currency, Dictionary<string, string> metadata)
    {
        // Simulate PayPal API call
        return new AuthorizationResult
        {
            Success = true,
            Message = "PayPal authorization successful."
        };
    }
}
````

---

## Order Repository Abstraction

```csharp
public interface IOrderRepository
{
    void MarkPaid(int orderId);
    void MarkFailed(int orderId);
}

public class SqlOrderRepository : IOrderRepository
{
    private readonly string _dbConnection;

    public SqlOrderRepository(string dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public void MarkPaid(int orderId)
    {
        // Simulated DB update
    }

    public void MarkFailed(int orderId)
    {
        // Simulated DB update
    }
}
```

---

## Business Logic (Clean) — C#

```csharp
public class OrderService
{
    private readonly IPaymentGateway _gateway;
    private readonly IOrderRepository _repository;

    // Constructor Injection
    public OrderService(IPaymentGateway gateway, IOrderRepository repository)
    {
        _gateway = gateway;
        _repository = repository;
    }

    public AuthorizationResult Process(Order order)
    {
        var metadata = new Dictionary<string, string>
        {
            { "orderId", order.Id.ToString() }
        };

        var result = _gateway.Authorize(order.Amount, order.Currency, metadata);

        if (result.Success)
            _repository.MarkPaid(order.Id);
        else
            _repository.MarkFailed(order.Id);

        return result;
    }
}
```

---

## Supporting Models

```csharp
public class Order
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
}

public class AuthorizationResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
}
```

---

## Composition Root (App Startup)

```csharp
// The ONLY place where dependencies are created manually.
var gateway = new StripeGateway(Environment.GetEnvironmentVariable("STRIPE_KEY"));
var repository = new SqlOrderRepository("Server=.;Database=AppDB;Trusted_Connection=True;");

var service = new OrderService(gateway, repository);

// Example
var result = service.Process(new Order { Id = 1, Amount = 100, Currency = "USD" });
```

---

## Unit Testing Example (Using Fake Dependencies)

```csharp
// Fake gateway for testing
public class FakeGateway : IPaymentGateway
{
    public AuthorizationResult Authorize(decimal amount, string currency, Dictionary<string, string> metadata)
    {
        return new AuthorizationResult
        {
            Success = true,
            Message = "Fake payment success."
        };
    }
}

// In-memory fake repository
public class InMemoryOrderRepository : IOrderRepository
{
    public List<int> PaidOrders = new();
    public List<int> FailedOrders = new();

    public void MarkPaid(int orderId) => PaidOrders.Add(orderId);
    public void MarkFailed(int orderId) => FailedOrders.Add(orderId);
}

// Unit test example
var service = new OrderService(new FakeGateway(), new InMemoryOrderRepository());
var result = service.Process(new Order { Id = 10, Amount = 50, Currency = "USD" });

// Assertion Example
// Assert.True(result.Success);
```