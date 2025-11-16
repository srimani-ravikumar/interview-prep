import java.util.*;

// ---------------------------- MEMBERSHIP (ABSTRACT) ----------------------------
abstract class Membership {
    private String type;

    public Membership(String type) {
        this.type = type;
    }

    public String getType() { return type; }

    // Polymorphic rules
    public abstract int getBorrowLimit();
    public abstract int getMaxBorrowDays();
}

// ---------------------------- REGULAR MEMBERSHIP ----------------------------
class RegularMembership extends Membership {

    public RegularMembership() {
        super("Regular");
    }

    @Override
    public int getBorrowLimit() { return 2; }

    @Override
    public int getMaxBorrowDays() { return 7; }
}

// ---------------------------- PREMIUM MEMBERSHIP ----------------------------
class PremiumMembership extends Membership {

    public PremiumMembership() {
        super("Premium");
    }

    @Override
    public int getBorrowLimit() { return 5; }

    @Override
    public int getMaxBorrowDays() { return 21; }
}

// ---------------------------- BOOK ----------------------------
class Book {
    private static int bookCounter = 100; // auto ID starting value

    private int id;
    private String title;
    private boolean available = true;

    public Book(String title) {
        this.id = ++bookCounter;
        this.title = title;
    }

    public int getId() { return id; }
    public String getTitle() { return title; }
    public boolean isAvailable() { return available; }

    public void borrow() { available = false; }
    public void returnBook() { available = true; }
}

// ---------------------------- MEMBER ----------------------------
class Member {
    private static int memberCounter = 0;
    
    private int id;
    private String name;
    private Membership membership;
    private Map<Integer, Integer> borrowedBooks = new HashMap<>();

    public Member(String name, Membership membership) {
        this.id = ++memberCounter;
        this.name = name;
        this.membership = membership;
    }

    public int getId() { return id; }
    public String getName() { return name; }
    public Membership getMembership() { return membership; }
    public Map<Integer, Integer> getBorrowedBooks() { return borrowedBooks; }

    public boolean canBorrow() {
        return borrowedBooks.size() < membership.getBorrowLimit();
    }

    public void borrowBook(int bookId, int days) {
        borrowedBooks.put(bookId, days);
    }

    public void returnBook(int bookId) {
        borrowedBooks.remove(bookId);
    }
}

// ---------------------------- LIBRARY SYSTEM ----------------------------
class LibrarySystem {

    private Map<Integer, Book> books = new HashMap<>();
    private Map<Integer, Member> members = new HashMap<>();

    public void addBook(Book book) {
        books.put(book.getId(), book);
        System.out.println("📘 Added Book: " + book.getTitle() + " (ID: " + book.getId() + ")");
    }

    public void addMember(Member m) {
        members.put(m.getId(), m);
        System.out.println("👤 Added Member: " + m.getName() +
                " (" + m.getMembership().getType() + ", ID: " + m.getId() + ")");
    }

    public void borrowBook(int memberId, int bookId, int daysRequested) {
        Member m = members.get(memberId);
        Book b = books.get(bookId);

        if (m == null || b == null) {
            System.out.println("❌ Invalid member or book.");
            return;
        }

        if (!b.isAvailable()) {
            System.out.println("❌ Book already borrowed.");
            return;
        }

        if (!m.canBorrow()) {
            System.out.println("❌ Borrowing limit exceeded for " + m.getName());
            return;
        }

        if (daysRequested > m.getMembership().getMaxBorrowDays()) {
            System.out.println("❌ Cannot borrow for " + daysRequested +
                    " days. Max: " + m.getMembership().getMaxBorrowDays());
            return;
        }

        b.borrow();
        m.borrowBook(bookId, daysRequested);

        System.out.println("✅ " + m.getName() + " borrowed \"" +
                b.getTitle() + "\" for " + daysRequested + " days.");
    }

    public void returnBook(int memberId, int bookId) {
        Member m = members.get(memberId);
        Book b = books.get(bookId);

        if (m == null || b == null) {
            System.out.println("❌ Invalid member or book.");
            return;
        }

        b.returnBook();
        m.returnBook(bookId);

        System.out.println("🔄 " + m.getName() +
                " returned \"" + b.getTitle() + "\" successfully!");
    }
}

// ---------------------------- MAIN (SIMULATION) ----------------------------
public class Main {
    public static void main(String[] args) {

        System.out.println("📚 Library Membership System Initializing...\n");

        LibrarySystem library = new LibrarySystem();

        // Add books (NO NEED TO PROVIDE IDs)
        library.addBook(new Book("Clean Code"));
        library.addBook(new Book("Operating Systems"));
        library.addBook(new Book("DSA with Java"));

        // Add members (IDs auto-assigned)
        Member srimani = new Member("Srimani", new PremiumMembership());
        Member rahul = new Member("Rahul", new RegularMembership());

        library.addMember(srimani);
        library.addMember(rahul);

        System.out.println("\n👉 Story: Srimani wants to step up his fundamentals using a premium membership.\n");

        // Borrow attempts
        library.borrowBook(srimani.getId(), 101, 14);

        library.borrowBook(rahul.getId(), 102, 10);
        library.borrowBook(rahul.getId(), 102, 5);
        library.borrowBook(rahul.getId(), 103, 5);
        library.borrowBook(rahul.getId(), 101, 5);

        System.out.println("\n🔄 After study, they return the books.\n");

        library.returnBook(srimani.getId(), 101);
        library.returnBook(rahul.getId(), 102);
    }
}