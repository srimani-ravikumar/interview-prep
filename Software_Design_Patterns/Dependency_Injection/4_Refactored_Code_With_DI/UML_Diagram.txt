
---

## 📁 4_Refactored_Code_With_DI / **UML_Diagram.txt**
```plantuml
@startuml
interface PaymentGateway {
  +authorize(amount, currency, metadata): AuthorizationResult
}

class StripeGateway
class PayPalGateway
class OrderRepository

class OrderService {
  -gateway: PaymentGateway
  -repo: OrderRepository
  +process(order)
}

OrderService o-- PaymentGateway
OrderService o-- OrderRepository
StripeGateway ..|> PaymentGateway
PayPalGateway ..|> PaymentGateway
@enduml
