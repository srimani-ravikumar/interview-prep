
---

## 📁 4_Refactored_Code_With_DI / **Refactored_Code_With_DI.txt**
```md
# Refactored Code Using Dependency Injection

## Clean Design Goals
- OrderService depends only on abstractions.
- Payment gateways are swappable.
- Code becomes test-friendly.

## Interfaces & Implementations
```pseudo
interface PaymentGateway:
    authorize(amount, currency, metadata): AuthorizationResult

class StripeGateway implements PaymentGateway:
    authorize(amount, currency, metadata):
        // Stripe API call

class PayPalGateway implements PaymentGateway:
    authorize(amount, currency, metadata):
        // PayPal API call


## Business Logic (Clean)

```
class OrderService:
    constructor(gateway: PaymentGateway, repo: OrderRepository):
        this.gateway = gateway
        this.repo = repo

    process(order):
        result = this.gateway.authorize(order.amount, order.currency, {orderId: order.id})

        if result.success:
            repo.markPaid(order.id)
        else:
            repo.markFailed(order.id)

        return result

```

## Composition Root (App Startup)

```
gateway = new StripeGateway(env.STRIPE_KEY)
repo = new SqlOrderRepository(dbConn)
service = new OrderService(gateway, repo)

```

## Unit Testing Example

```
class FakeGateway implements PaymentGateway:
    authorize(...): return AuthorizationResult(success=true)

service = new OrderService(new FakeGateway(), new InMemoryOrderRepo())
result = service.process(testOrder)
assert result.success == true

```