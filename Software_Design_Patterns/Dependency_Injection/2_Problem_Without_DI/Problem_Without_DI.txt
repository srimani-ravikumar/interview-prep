# Problem — Without Dependency Injection

## Issue Summary
The `OrderService` directly creates a specific payment gateway (e.g., `StripeGateway`).
This leads to:
- Hard‑coded dependencies
- No testability (network calls cannot be mocked)
- Zero flexibility to switch payment providers
- Violates SRP and OCP

## Bad Code Example (Tightly Coupled)
```pseudo
class StripeGateway implements PaymentGateway:
    authorize(amount):
        // Calls Stripe API

class OrderService:
    process(order):
        gateway = new StripeGateway()  // hard-coded dependency
        result = gateway.authorize(order.amount)
        return result
