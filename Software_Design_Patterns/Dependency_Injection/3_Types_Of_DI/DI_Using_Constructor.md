# Constructor Injection
Constructor Injection provides required dependencies when creating the object.

## Example
```pseudo
class OrderService:
    constructor(gateway: PaymentGateway):
        this.gateway = gateway

    process(order):
        return this.gateway.authorize(order.amount)



## When To Use?

- Dependency is mandatory.
- Should not change after object creation.