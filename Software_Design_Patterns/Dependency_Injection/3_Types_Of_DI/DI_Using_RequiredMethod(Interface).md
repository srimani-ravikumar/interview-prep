# Interface / Method Injection
In Method Injection, a dependency is passed **directly into the method** that needs it instead of being injected through the constructor or stored as a class-level field.

---

## Example — C# (Method Injection)

```csharp
// Payment gateway interface
public interface IPaymentGateway
{
    AuthorizationResult Authorize(decimal amount);
}

// Order service that receives its dependency directly in the method
public class OrderService
{
    // ✅ Method Injection
    // The dependency (IPaymentGateway) is passed only when this method is called.
    public AuthorizationResult Process(Order order, IPaymentGateway gateway)
    {
        return gateway.Authorize(order.Amount);
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

- When only a single method needs a temporary dependency.