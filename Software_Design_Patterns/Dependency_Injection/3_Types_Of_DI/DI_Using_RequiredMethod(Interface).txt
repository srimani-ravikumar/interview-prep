
---

## 📁 3_Types_Of_DI / **DI_Using_RequiredMethod(Interface).txt**
```md
# Interface / Method Injection
A dependency is passed directly into the method that needs it.

## Example
```pseudo
class OrderService:
    process(order, gateway: PaymentGateway):
        return gateway.authorize(order.amount)


## When To Use?

- When only a single method needs a temporary dependency.