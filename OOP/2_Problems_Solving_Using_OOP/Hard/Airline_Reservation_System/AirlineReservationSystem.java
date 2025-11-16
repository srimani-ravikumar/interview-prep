import java.util.*;

// ------------------------ PAYMENT STRATEGY ------------------------
interface PaymentStrategy {
    void pay(double amount);
}

class CardPayment implements PaymentStrategy {
    @Override
    public void pay(double amount) {
        System.out.println("Paid ₹" + amount + " using Credit/Debit Card");
    }
}

class UPIPayment implements PaymentStrategy {
    @Override
    public void pay(double amount) {
        System.out.println("Paid ₹" + amount + " using UPI");
    }
}

// ------------------------ PASSENGER ------------------------
class Passenger {
    private final int id;
    private final String name;

    public Passenger(int id, String name) {
        this.id = id;
        this.name = name;
    }
    public int getId() { return id; }
    public String getName() { return name; }
}

// ------------------------ TICKET ------------------------
class Ticket {
    private final int ticketId;
    private final Passenger passenger;
    private final Flight flight;
    private final String seatNumber;

    public Ticket(int ticketId, Passenger passenger, Flight flight, String seatNumber) {
        this.ticketId = ticketId;
        this.passenger = passenger;
        this.flight = flight;
        this.seatNumber = seatNumber;
    }

    @Override
    public String toString() {
        return "Ticket#" + ticketId + " | " + passenger.getName() + " | Seat: " + seatNumber +
               " | Flight: " + flight.getFlightNumber();
    }
}

// ------------------------ ABSTRACT FLIGHT ------------------------
abstract class Flight {
    protected String flightNumber;
    protected int maxSeats;
    protected Set<String> bookedSeats = new HashSet<>();
    protected List<Ticket> tickets = new ArrayList<>();

    public Flight(String flightNumber, int maxSeats) {
        this.flightNumber = flightNumber;
        this.maxSeats = maxSeats;
    }

    public String getFlightNumber() { return flightNumber; }

    public abstract double getBaseFare(); // polymorphic fare logic

    public boolean isSeatAvailable() {
        return bookedSeats.size() < maxSeats;
    }

    public Ticket bookSeat(Passenger p, String seatNumber, PaymentStrategy payment) {
        if (!isSeatAvailable()) {
            System.out.println("⚠️ Overbooked! No seats left in flight " + flightNumber);
            return null;
        }

        bookedSeats.add(seatNumber);
        Ticket ticket = new Ticket(tickets.size() + 1, p, this, seatNumber);
        tickets.add(ticket);

        payment.pay(getBaseFare());

        return ticket;
    }

    public void cancelTicket(Ticket ticket) {
        bookedSeats.remove(ticket.toString());
        tickets.remove(ticket);
    }
}

// ------------------------ SPECIFIC FLIGHTS ------------------------
class DomesticFlight extends Flight {
    public DomesticFlight(String number) {
        super(number, 100);
    }

    @Override
    public double getBaseFare() {
        return 3500.0;
    }
}

class InternationalFlight extends Flight {
    public InternationalFlight(String number) {
        super(number, 200);
    }

    @Override
    public double getBaseFare() {
        return 18000.0;
    }
}

// ------------------------ FLIGHT FACTORY ------------------------
// We can use Factory Design Pattern but for the sake of simplicity 
// I'm stick with just OOP
class FlightFactory {
    public static Flight createFlight(String type, String number) {
        return switch (type.toLowerCase()) {
            case "domestic" -> new DomesticFlight(number);
            case "international" -> new InternationalFlight(number);
            default -> throw new RuntimeException("Unknown flight type!");
        };
    }
}

// ------------------------ AIRLINE (COMPOSITION ROOT) ------------------------
class AirlineReservationSystem {
    private final List<Flight> flights = new ArrayList<>();

    public void addFlight(Flight f) {
        flights.add(f);
    }

    public Flight findFlight(String flightNumber) {
        return flights.stream()
                .filter(f -> f.getFlightNumber().equals(flightNumber))
                .findFirst()
                .orElse(null);
    }
}

// ------------------------ MAIN SIMULATION ------------------------
public class AirlineApp {
    public static void main(String[] args) {

        AirlineReservationSystem system = new AirlineReservationSystem();

        // Srimani chooses flights
        Flight domestic = FlightFactory.createFlight("domestic", "AI123");
        Flight international = FlightFactory.createFlight("international", "AI999");

        system.addFlight(domestic);
        system.addFlight(international);

        Passenger srimani = new Passenger(1, "Srimani Ravikumar");

        System.out.println("\n--- Domestic Flight Booking ---");
        Ticket t1 = domestic.bookSeat(srimani, "12B", new UPIPayment());
        System.out.println("Booked: " + t1);

        System.out.println("\n--- International Flight Booking ---");
        Ticket t2 = international.bookSeat(srimani, "45A", new CardPayment());
        System.out.println("Booked: " + t2);
    }
}