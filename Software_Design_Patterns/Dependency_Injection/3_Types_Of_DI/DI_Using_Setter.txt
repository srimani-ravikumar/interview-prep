
---

## 📁 3_Types_Of_DI / **DI_Using_Setter.txt**
```md
# Setter Injection
Dependencies can be assigned or swapped after object creation.

## Example
```pseudo
class OrderService:
    setGateway(gateway: PaymentGateway):
        this.gateway = gateway

    process(order):
        return this.gateway.authorize(order.amount)

## When To Use?

- Optional dependencies
- Dependencies may change at runtime