---

## 📁 2_Problem_Without_DI / **UML_Diagram.txt**
```plantuml
@startuml
interface PaymentGateway {
  +authorize(amount): AuthorizationResult
}

class StripeGateway {
  +authorize(amount): AuthorizationResult
}

class OrderService {
  +process(order): void
}

StripeGateway ..|> PaymentGateway
OrderService --> StripeGateway : creates
@enduml