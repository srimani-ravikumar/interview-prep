```mermaid

classDiagram
    %% ===================== Interfaces & Implemenations of Payment Mode =====================
    class PaymentStrategy {
        <<interface>>
        +pay(amount: double) void
    }

    class CardPayment {
        +pay(amount: double) void
    }

    class UPIPayment {
        +pay(amount: double) void
    }

    PaymentStrategy <|.. CardPayment
    PaymentStrategy <|.. UPIPayment

    %% ===================== Passenger =====================
    class Passenger {
        -final id: int
        -final name: String
        +Passenger(id: int, name: String)
        +getId() int
        +getName() String
    }

    %% ===================== Ticket =====================
    class Ticket {
        -final ticketId: int
        -final passenger: Passenger
        -final flight: Flight
        -final seatNumber: String
        +Ticket(ticketId: int, passenger: Passenger, flight: Flight, seatNumber: String)
        +getTicketId() int
        +getPassenger() Passenger
        +getFlight() Flight
        +getSeatNumber() String
        +toString() String
    }

    Ticket "1" --> "1" Passenger "assigned to"
    Ticket "1" --> "1" Flight "for"

    %% ===================== Abstract Flight & its types =====================
    class Flight {
        <<abstract>>
        #final flightNumber: String
        #final maxSeats: int
        #final bookedSeats: Set~String~
        #final tickets: List~Ticket~
        -nextTicketId: int
        +Flight(flightNumber: String, maxSeats: int)
        +getFlightNumber() String
        +isSeatAvailable() boolean
        +getBaseFare() double*
        +bookSeat(p: Passenger, seat: String, payment: PaymentStrategy) Ticket
        +cancelTicket(ticket: Ticket) void
    }

    class DomesticFlight {
        +DomesticFlight(number: String)
        +getBaseFare() double
    }

    class InternationalFlight {
        +InternationalFlight(number: String)
        +getBaseFare() double
    }

    Flight <|-- DomesticFlight
    Flight <|-- InternationalFlight

    %% ===================== Flight Factory =====================
    class FlightFactory {
        +static createFlight(type: String, number: String) Flight
    }

    %% ===================== Airline Reservation System =====================
    class AirlineReservationSystem {
        -final flights: List~Flight~
        +addFlight(f: Flight) void
        +findFlight(flightNumber: String) Flight
    }

    AirlineReservationSystem "`" --> Flight "manages"

    %% ===================== Main App =====================
    class AirlineApp {
        <<main>>
        +main(args: String[])
    }

```