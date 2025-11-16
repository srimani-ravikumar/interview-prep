import java.util.*;

// ---------------------------- INTERFACE ----------------------------
// A common interface for all rentable items
interface Rentable {
    boolean isAvailable();
    void rent(String customerName);
    void returnVehicle();
    double calculateRentalCost(int days);
}

// ---------------------------- ABSTRACT CLASS ----------------------------
abstract class Vehicle implements Rentable {
    private String id;
    private String model;
    private boolean available = true;

    // Rental history per customer
    private List<String> rentalHistory = new ArrayList<>();

    public Vehicle(String id, String model) {
        this.id = id;
        this.model = model;
    }

    public String getId() { return id; }
    public String getModel() { return model; }

    @Override
    public boolean isAvailable() {
        return available;
    }

    @Override
    public void rent(String customerName) {
        if (!available) {
            System.out.println(model + " (" + id + ") is not available!");
            return;
        }
        available = false;
        rentalHistory.add(customerName);
        System.out.println(customerName + " rented " + model + " (" + id + ")");
    }

    @Override
    public void returnVehicle() {
        available = true;
        System.out.println(model + " (" + id + ") returned successfully!");
    }

    public List<String> getRentalHistory() {
        return rentalHistory;
    }

    @Override
    public String toString() {
        return id + " | " + model + " | Available: " + available;
    }
}

// ---------------------------- CAR ----------------------------
class Car extends Vehicle {
    private double dailyRate;

    public Car(String id, String model, double dailyRate) {
        super(id, model);
        this.dailyRate = dailyRate;
    }

    @Override
    public double calculateRentalCost(int days) {
        return days * dailyRate;
    }
}

// ---------------------------- BIKE ----------------------------
class Bike extends Vehicle {
    private double dailyRate;

    public Bike(String id, String model, double dailyRate) {
        super(id, model);
        this.dailyRate = dailyRate;
    }

    @Override
    public double calculateRentalCost(int days) {
        return days * dailyRate;
    }
}

// ---------------------------- TRUCK ----------------------------
class Truck extends Vehicle {
    private double dailyRate;

    public Truck(String id, String model, double dailyRate) {
        super(id, model);
        this.dailyRate = dailyRate;
    }

    @Override
    public double calculateRentalCost(int days) {
        return days * dailyRate;
    }
}

// ---------------------------- RENTAL SYSTEM ----------------------------
class RentalSystem {
    private Map<String, Vehicle> vehicles = new HashMap<>();

    public void addVehicle(Vehicle v) {
        vehicles.put(v.getId(), v);
        System.out.println("🚘 Added Vehicle: " + v.getModel());
    }

    public void rentVehicle(String vehicleId, String customer, int days) {
        Vehicle v = vehicles.get(vehicleId);
        if (v == null) {
            System.out.println("Vehicle not found!");
            return;
        }

        if (v.isAvailable()) {
            v.rent(customer);
            System.out.println("Cost for " + days + " days: ₹" + v.calculateRentalCost(days));
        } else {
            System.out.println("Vehicle currently unavailable!");
        }
    }

    public void returnVehicle(String vehicleId) {
        Vehicle v = vehicles.get(vehicleId);
        if (v != null) {
            v.returnVehicle();
        } else {
            System.out.println("Vehicle not found!");
        }
    }

    public void showRentalHistory(String vehicleId) {
        Vehicle v = vehicles.get(vehicleId);
        if (v != null) {
            System.out.println("\n📜 Rental History for " + v.getModel() + ":");
            v.getRentalHistory().forEach(System.out::println);
        }
    }
}

// ---------------------------- SIMULATION WITH SRIMANI ----------------------------
public class Main {
    public static void main(String[] args) {

        System.out.println("🚀 Vehicle Rental System Booting...\n");

        RentalSystem system = new RentalSystem();

        // Vehicles
        Vehicle c1 = new Car("C101", "Honda City", 1200);
        Vehicle b1 = new Bike("B201", "Yamaha FZ", 500);
        Vehicle t1 = new Truck("T301", "Tata Ace", 2000);

        // Add to system
        system.addVehicle(c1);
        system.addVehicle(b1);
        system.addVehicle(t1);

        System.out.println("\n👉 Srimani is looking to rent a vehicle for a trip!");

        // Srimani rents a Car
        system.rentVehicle("C101", "Srimani", 3);

        // Trying to rent the same car again
        system.rentVehicle("C101", "Rahul", 2);

        // Returning the car
        System.out.println("\n🔄 After the trip...");
        system.returnVehicle("C101");

        // Rahul rents now
        system.rentVehicle("C101", "Rahul", 2);

        // Show rental histories
        system.showRentalHistory("C101");
    }
}