import java.util.*;

// ---------------------------- ADD-ON ----------------------------
class AddOn {
    private String name;
    private double price;

    public AddOn(String name, double price) {
        this.name = name;
        this.price = price;
    }

    public double getPrice() { return price; }
    public String getName() { return name; }
}

// ---------------------------- ABSTRACT DISH ----------------------------
abstract class Dish {
    private String name;
    private double basePrice;

    // Composition → Dish HAS add-ons
    private List<AddOn> addOns = new ArrayList<>();

    public Dish(String name, double basePrice) {
        this.name = name;
        this.basePrice = basePrice;
    }

    public String getName() { return name; }

    public void addAddOn(AddOn addOn) {
        addOns.add(addOn);
    }

    public double getTotalPrice() {
        double total = basePrice;
        for (AddOn a : addOns) {
            total += a.getPrice();
        }
        return total;
    }

    public List<AddOn> getAddOns() {
        return addOns;
    }

    @Override
    public String toString() {
        return name + " (₹" + basePrice + ")";
    }
}

// ---------------------------- POLYMORPHIC DISH TYPES ----------------------------
class MainCourse extends Dish {
    public MainCourse(String name, double price) {
        super(name, price);
    }
}

class Beverage extends Dish {
    public Beverage(String name, double price) {
        super(name, price);
    }
}

class Dessert extends Dish {
    public Dessert(String name, double price) {
        super(name, price);
    }
}

// ---------------------------- ORDER ----------------------------
class Order {
    private static int idCounter = 1;

    private int orderId;
    private List<Dish> items = new ArrayList<>();
    private String status = "Pending"; // Pending → Preparing → Completed

    public Order() {
        this.orderId = idCounter++;
    }

    public int getOrderId() { return orderId; }
    public List<Dish> getItems() { return items; }
    public String getStatus() { return status; }

    public void addDish(Dish dish) {
        items.add(dish);
    }

    public double calculateTotal() {
        return items.stream().mapToDouble(Dish::getTotalPrice).sum();
    }

    public void updateStatus(String status) {
        this.status = status;
        System.out.println("Order #" + orderId + " → Status updated to: " + status);
    }
}

// ---------------------------- RESTAURANT SYSTEM ----------------------------
class RestaurantSystem {

    Map<String, List<Dish>> menu = new HashMap<>();
    Map<Integer, Order> orders = new HashMap<>();

    public RestaurantSystem() {
        menu.put("MainCourse", new ArrayList<>());
        menu.put("Beverage", new ArrayList<>());
        menu.put("Dessert", new ArrayList<>());
    }

    public void addDishToMenu(String category, Dish dish) {
        menu.get(category).add(dish);
        System.out.println("🍽️ Added to Menu: " + category + " → " + dish);
    }

    public Order createOrder() {
        Order order = new Order();
        orders.put(order.getOrderId(), order);
        System.out.println("\n🆕 Created Order #" + order.getOrderId());
        return order;
    }

    public void showMenu() {
        System.out.println("\n📜 MENU:");
        menu.forEach((category, list) -> {
            System.out.println("== " + category + " ==");
            for (Dish d : list) {
                System.out.println("   • " + d);
            }
        });
    }

    public void printBill(int orderId) {
        Order order = orders.get(orderId);
        System.out.println("\n💵 BILL for Order #" + orderId);

        for (Dish d : order.getItems()) {
            System.out.print("• " + d.getName() + " - ₹" + d.getTotalPrice());
            if (!d.getAddOns().isEmpty()) {
                System.out.print(" (Add-ons: ");
                d.getAddOns().forEach(a -> System.out.print(a.getName() + " "));
                System.out.print(")");
            }
            System.out.println();
        }

        System.out.println("TOTAL: ₹" + order.calculateTotal());
    }
}

// ---------------------------- SIMULATION WITH SRIMANI ----------------------------
public class Main {
    public static void main(String[] args) {

        RestaurantSystem rs = new RestaurantSystem();

        // Adding dishes to menu
        rs.addDishToMenu("MainCourse", new MainCourse("Paneer Butter Masala", 180));
        rs.addDishToMenu("MainCourse", new MainCourse("Chicken Biryani", 240));
        rs.addDishToMenu("Beverage", new Beverage("Cold Coffee", 90));
        rs.addDishToMenu("Dessert", new Dessert("Gulab Jamun", 60));

        rs.showMenu();

        System.out.println("\n👉 STORY: After long hours of DSA + LLD practice, Srimani visits a restaurant to reward himself.\n");

        // Create order for Srimani
        Order order1 = rs.createOrder();

        // Choose dishes
        Dish biryani = new MainCourse("Chicken Biryani", 240);
        biryani.addAddOn(new AddOn("Extra Chicken", 50));
        biryani.addAddOn(new AddOn("Raita", 20));

        Dish coffee = new Beverage("Cold Coffee", 90);
        coffee.addAddOn(new AddOn("Ice Cream Scoop", 30));

        // Add to order
        order1.addDish(biryani);
        order1.addDish(coffee);

        // Update order status
        order1.updateStatus("Preparing");
        order1.updateStatus("Completed");

        // Print final bill
        rs.printBill(order1.getOrderId());

        System.out.println("\n🍽️ Srimani enjoyed his meal and went back to coding stronger!");
    }
}