import java.util.*;

// ====================== Core System Classes ======================

class Hotel {
    private String name;
    private List<Room> rooms = new ArrayList<>();
    private Map<String, Booking> activeBookings = new HashMap<>();

    public Hotel(String name) { this.name = name; }

    public void addRoom(Room room) {
        rooms.add(room);
    }

    public Booking bookRoom(String roomType, Guest guest, int days) {
        for (Room room : rooms) {
            if (!room.isBooked() && room.getRoomType().equalsIgnoreCase(roomType)) {
                String bookingId = UUID.randomUUID().toString();
                Booking booking = new Booking(bookingId, guest, room, days);
                room.setBooked(true);
                activeBookings.put(bookingId, booking);
                notifyStaff("New Booking → Room " + room.getRoomNumber());
                return booking;
            }
        }
        return null;
    }

    public double checkout(String bookingId) {
        Booking booking = activeBookings.get(bookingId);
        if (booking == null) return 0;

        booking.getRoom().setBooked(false);
        activeBookings.remove(bookingId);

        notifyStaff("Checkout → Room " + booking.getRoom().getRoomNumber());
        return booking.calculateTotalBill();
    }

    private void notifyStaff(String message) {
        System.out.println("[STAFF NOTIFICATION] " + message);
    }
}


// ====================== Room Classes (Inheritance + Polymorphism) ======================

abstract class Room {
    protected int roomNumber;
    protected double pricePerDay;
    protected boolean isBooked = false;

    public Room(int roomNumber, double pricePerDay) {
        this.roomNumber = roomNumber;
        this.pricePerDay = pricePerDay;
    }

    public abstract String getRoomType();

    public boolean isBooked() { return isBooked; }
    public void setBooked(boolean status) { isBooked = status; }
    public int getRoomNumber() { return roomNumber; }
    public double getPricePerDay() { return pricePerDay; }
}

class SingleRoom extends Room {
    public SingleRoom(int roomNumber, double pricePerDay) {
        super(roomNumber, pricePerDay);
    }

    @Override
    public String getRoomType() { return "Single"; }
}

class DoubleRoom extends Room {
    public DoubleRoom(int roomNumber, double pricePerDay) {
        super(roomNumber, pricePerDay);
    }

    @Override
    public String getRoomType() { return "Double"; }
}

class SuiteRoom extends Room {
    public SuiteRoom(int roomNumber, double pricePerDay) {
        super(roomNumber, pricePerDay);
    }

    @Override
    public String getRoomType() { return "Suite"; }
}


// ====================== Guest Class ======================

class Guest {
    private String name;
    private String email;

    public Guest(String name, String email) {
        this.name = name;
        this.email = email;
    }

    public String getName() { return name; }
    public String getEmail() { return email; }

    public void printGuestInfo() {
        System.out.println("Guest Name: " + name);
        System.out.println("Email: " + email);
    }
}


// ====================== Booking Class (Composition) ======================

class Booking {
    private String bookingId;
    private Guest guest;
    private Room room;
    private int numberOfDays;

    public Booking(String bookingId, Guest guest, Room room, int numberOfDays) {
        this.bookingId = bookingId;
        this.guest = guest;
        this.room = room;
        this.numberOfDays = numberOfDays;
    }

    public String getBookingId() { return bookingId; }
    public Room getRoom() { return room; }

    public double calculateTotalBill() {
        return room.getPricePerDay() * numberOfDays;
    }

    public void printBookingDetails() {
        System.out.println("Booking ID: " + bookingId);
        guest.printGuestInfo();
        System.out.println("Room Type: " + room.getRoomType());
        System.out.println("Room Number: " + room.getRoomNumber());
        System.out.println("Days: " + numberOfDays);
        System.out.println("Price Per Day: ₹" + room.getPricePerDay());
    }
}

public class HotelManagementSystem {

    public static void main(String[] args) {
        Hotel hotel = new Hotel("Grand Palace Hotel");

        // Adding Rooms
        hotel.addRoom(new SingleRoom(101, 2000));
        hotel.addRoom(new DoubleRoom(102, 3500));
        hotel.addRoom(new SuiteRoom(201, 8000));

        // Simulate a real booking by Srimani
        Guest srimani = new Guest("Srimani", "srimani@example.com");
        Booking booking = hotel.bookRoom("Single", srimani, 2);

        if (booking != null) {
            System.out.println("\nBooking Successful!");
            booking.printBookingDetails();
        } else {
            System.out.println("Room not available!");
        }

        // Checkout Simulation
        System.out.println("\n---- After 2 Days ----");
        double billAmount = hotel.checkout(booking.getBookingId());
        System.out.println("Total Bill for Srimani: ₹" + billAmount);
    }
}