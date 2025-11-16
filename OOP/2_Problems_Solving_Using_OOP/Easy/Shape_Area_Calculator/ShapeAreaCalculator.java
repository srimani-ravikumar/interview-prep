import java.util.*;

// ---------------------------- ABSTRACT SHAPE ----------------------------
abstract class Shape {
    private final String name; // Encapsulation

    public Shape(String name) {
        this.name = name;
    }

    public String getName() { return name; }

    // Polymorphic behavior: each shape computes area differently
    public abstract double computeArea();
}

// ---------------------------- CIRCLE ----------------------------
class Circle extends Shape {
    private final double radius;

    public Circle(double radius) {
        super("Circle");
        this.radius = radius;
    }

    @Override
    public double computeArea() {
        return Math.PI * radius * radius;
    }
}

// ---------------------------- RECTANGLE ----------------------------
class Rectangle extends Shape {
    private final double width;
    private final double height;

    public Rectangle(double width, double height) {
        super("Rectangle");
        this.width = width;
        this.height = height;
    }

    @Override
    public double computeArea() {
        return width * height;
    }
}

// ---------------------------- TRIANGLE ----------------------------
class Triangle extends Shape {
    private final double base;
    private final double height;

    public Triangle(double base, double height) {
        super("Triangle");
        this.base = base;
        this.height = height;
    }

    @Override
    public double computeArea() {
        return 0.5 * base * height;
    }
}


// ---------------------------- CLIENT (REAL-TIME STORY) ----------------------------
public class ShapeAreaCalculator {
    public static void main(String[] args) throws InterruptedException {

        System.out.println("🧮 Shape Area Calculator Initialized...\n");

        List<Shape> shapes = new ArrayList<>();

        // Real-time simulation using your name (like before)
        System.out.println("📐 Srimani is practicing geometry fundamentals again...");
        Thread.sleep(1200);

        shapes.add(new Circle(7));
        System.out.println("➕ Added a Circle of radius 7");

        Thread.sleep(1200);

        shapes.add(new Rectangle(5, 8));
        System.out.println("➕ Added a Rectangle (5 x 8)");

        Thread.sleep(1200);

        shapes.add(new Triangle(10, 6));
        System.out.println("➕ Added a Triangle (base 10, height 6)");

        Thread.sleep(1500);

        System.out.println("\n🧠 Srimani is now calculating the areas of all shapes...\n");
        Thread.sleep(1000);

        // Polymorphism in action: each shape's computeArea() executes its own logic
        for (Shape shape : shapes) {
            System.out.println("📏 Area of " + shape.getName() + " = " + shape.computeArea());
            Thread.sleep(800);
        }

        System.out.println("\n✨ All areas computed successfully! Srimani's fundamentals are becoming stronger!");
    }
}