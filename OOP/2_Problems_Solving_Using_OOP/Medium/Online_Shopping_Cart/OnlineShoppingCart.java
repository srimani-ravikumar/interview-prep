import java.util.*;

// Base Product Class (Encapsulation + Inheritance)
abstract class Product {
    private static int idCounter = 1;

    private int id;
    private String name;
    private double price;

    public Product(String name, double price) {
        this.id = idCounter++;
        this.name = name;
        this.price = price;
    }

    public int getId() { return id; }
    public String getName() { return name; }
    public double getPrice() { return price; }

    // Polymorphic discount
    public abstract double getDiscountedPrice();
}

// Category: Electronics – 10% Discount
class Electronics extends Product {
    public Electronics(String name, double price) {
        super(name, price);
    }

    @Override
    public double getDiscountedPrice() {
        return getPrice() * 0.90;
    }
}

// Category: Clothing – Flat ₹50 off
class Clothing extends Product {
    public Clothing(String name, double price) {
        super(name, price);
    }

    @Override
    public double getDiscountedPrice() {
        return Math.max(0, getPrice() - 50);
    }
}

// Category: Books – No discount
class BookProduct extends Product {
    public BookProduct(String name, double price) {
        super(name, price);
    }

    @Override
    public double getDiscountedPrice() {
        return getPrice();
    }
}

// CartItem – Composition
class CartItem {
    private Product product;
    private int quantity;

    public CartItem(Product product, int quantity) {
        this.product = product;
        this.quantity = quantity;
    }

    public Product getProduct() { return product; }
    public int getQuantity() { return quantity; }

    public double getTotalPrice() {
        return product.getDiscountedPrice() * quantity;
    }
}

// Shopping Cart – Core Operations
class ShoppingCart {
    private Map<Integer, CartItem> items = new HashMap<>();

    public void addProduct(Product product, int qty) {
        items.put(product.getId(), new CartItem(product, qty));
        System.out.println(product.getName() + " added to cart.");
    }

    public void removeProduct(int productId) {
        if (items.containsKey(productId)) {
            items.remove(productId);
            System.out.println("Item removed from cart.");
        }
    }

    public double calculateTotal() {
        return items.values()
                    .stream()
                    .mapToDouble(CartItem::getTotalPrice)
                    .sum();
    }

    public void showCart() {
        System.out.println("\n--- Cart Items ---");
        for (CartItem item : items.values()) {
            System.out.println(item.getProduct().getName() + 
                               " | Qty: " + item.getQuantity() +
                               " | Price After Discount: ₹" + item.getProduct().getDiscountedPrice());
        }
        System.out.println("-------------------");
    }

    public void checkout() {
        System.out.println("\nFinal Amount to Pay: ₹" + calculateTotal());
        System.out.println("Checkout complete. Thank you!");
    }
}

// Simulation with Srimani
public class Main {
    public static void main(String[] args) {

        ShoppingCart cart = new ShoppingCart();

        Product laptop = new Electronics("Laptop", 60000);
        Product tshirt = new Clothing("T-Shirt", 800);
        Product book = new BookProduct("Atomic Habits", 450);

        // Simulation
        System.out.println("🛍️ Srimani starts shopping...\n");

        cart.addProduct(laptop, 1);
        cart.addProduct(tshirt, 2);
        cart.addProduct(book, 1);

        cart.showCart();

        System.out.println("\n🛒 Total after discounts: ₹" + cart.calculateTotal());

        cart.removeProduct(book.getId());
        System.out.println("\nRemoved 'Atomic Habits' from cart.");

        cart.showCart();
        cart.checkout();
    }
}