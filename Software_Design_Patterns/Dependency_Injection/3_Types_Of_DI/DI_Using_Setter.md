# Setter Injection
Setter Injection allows dependencies to be **assigned or replaced after the object is created**.  
This provides flexibility when the dependency is optional or changeable at runtime.

---

## Example — C# (Setter Injection)

```csharp
// Payment gateway interface
public interface IPaymentGateway
{
    AuthorizationResult Authorize(decimal amount);
}

// Order service using Setter Injection
public class OrderService
{
    private IPaymentGateway _gateway;

    // ✅ Setter Injection
    // The dependency can be assigned or swapped anytime after object creation.
    public void SetGateway(IPaymentGateway gateway)
    {
        _gateway = gateway;
    }

    public AuthorizationResult Process(Order order)
    {
        if (_gateway == null)
        {
            throw new InvalidOperationException("Payment gateway is not set.");
        }

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

- Optional dependencies
- Dependencies may change at runtime