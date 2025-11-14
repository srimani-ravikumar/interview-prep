# Constructor Injection
Constructor Injection provides required dependencies when creating the object.

## Example — C# (Constructor Injection)
```csharp
// Payment gateway interface
public interface IPaymentGateway
{
    AuthorizationResult Authorize(decimal amount);
}

// Order service receiving its dependency through the constructor
public class OrderService
{
    private readonly IPaymentGateway _gateway;

    // ✅ Constructor Injection
    // The required dependency (IPaymentGateway) is injected at object creation.
    public OrderService(IPaymentGateway gateway)
    {
        _gateway = gateway;
    }

    public AuthorizationResult Process(Order order)
    {
        // Uses the injected gateway instead of creating one internally.
        return _gateway.Authorize(order.Amount);
    }
}

// Supporting models
public class Order
{
    public decimal Amount { get; set; }
}

public class AuthorizationResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
}

```

## When To Use?
Dependency is mandatory.

Dependency should not change after object creation.

Ideal for stable, required collaborators like repositories, services, gateways.