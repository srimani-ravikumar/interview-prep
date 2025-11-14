# Problem — Without Dependency Injection

## Issue Summary
The `OrderService` directly creates a specific payment gateway (e.g., `StripeGateway`).  
This leads to:
- Hard-coded dependencies  
- No testability (network calls cannot be mocked)  
- Zero flexibility to switch payment providers  
- Violates SRP and OCP  

## Bad Code Example (Tightly Coupled)

### ❌ C# Implementation (Problematic)
```csharp
// Concrete implementation of a payment gateway
public class StripeGateway : IPaymentGateway
{
    public AuthorizationResult Authorize(decimal amount)
    {
        // Imagine this method makes an actual call to Stripe's API.
        // This cannot be mocked or replaced easily.
        return new AuthorizationResult 
        { 
            Success = true, 
            Message = "Payment captured via Stripe" 
        };
    }
}

// Order service that tightly depends on StripeGateway
public class OrderService
{
    public AuthorizationResult Process(Order order)
    {
        // ❌ BAD PRACTICE: Creating a concrete dependency inside the class.
        // This means OrderService is now permanently tied to StripeGateway.
        // - Cannot switch to PayPalGateway without editing this class.
        // - Cannot unit test without hitting real APIs.
        // - Violates Open/Closed Principle.
        StripeGateway gateway = new StripeGateway();

        // Calls the method on the strongly coupled dependency
        AuthorizationResult result = gateway.Authorize(order.Amount);

        return result;
    }
}

// Supporting models (simple representations)
public class Order
{
    public decimal Amount { get; set; }
}

public class AuthorizationResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
}

// Payment gateway abstraction (not being used correctly here)
public interface IPaymentGateway
{
    AuthorizationResult Authorize(decimal amount);
}

```