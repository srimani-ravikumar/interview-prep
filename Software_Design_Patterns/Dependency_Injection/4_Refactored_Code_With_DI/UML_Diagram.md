@startuml

' Interfaces
interface IPaymentGateway {
    +Authorize(amount: decimal, currency: string, metadata: Dictionary<string,string>): AuthorizationResult
}

' Payment Gateway Implementations
class StripeGateway
class PayPalGateway

' Repository Interface
interface IOrderRepository {
    +MarkPaid(orderId: int)
    +MarkFailed(orderId: int)
}

' Service Class
class OrderService {
    -_gateway: IPaymentGateway
    -_repository: IOrderRepository
    +Process(order: Order): AuthorizationResult
}

' Relationships
OrderService o-- IPaymentGateway
OrderService o-- IOrderRepository

StripeGateway ..|> IPaymentGateway
PayPalGateway ..|> IPaymentGateway

@enduml
