import java.util.*;

// ---------------------------- LIBRARY ----------------------------
class Library {
    private Map<UUID, Book> books = new HashMap<>();
    private Map<UUID, Member> members = new HashMap<>();

    public void addBook(Book book) {
        books.put(book.getId(), book);
        System.out.println("📘 Added Book: " + book.getTitle() + " (ID: " + book.getId() + ")");
    }

    public void addMember(Member m) {
        members.put(m.getId(), m);
        System.out.println("👤 Added Member: " + m.getName() +
                " (" + m.getMembership().getType() + ", ID: " + m.getId() + ")");
    }

    public void borrowBook(UUID memberId, UUID bookId, int daysRequested) {
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

    public void returnBook(UUID memberId, UUID bookId) {
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

// ---------------------------- BOOK ----------------------------
class Book {
    private UUID id;
    private String title;
    private String author;
    private boolean available;

    public Book(String title, String author) {
        this.id = UUID.randomUUID();
        this.title = title;
        this.author = author;
        this.available = true;
    }

    public UUID getId() {
        return id;
    }

    public String getTitle() {
        return title;
    }

    public String getAuthor() {
        return author;
    }

    public boolean isAvailable() {
        return available;
    }

    public void borrow() {
        available = false;
    }

    public void returnBook() {
        available = true;
    }
}

// ---------------------------- MEMBER ----------------------------
class Member {
    private UUID id;
    private String name;
    private Membership membership;
    private Map<UUID, Integer> borrowedBooks = new HashMap<>();

    public Member(String name, Membership membership) {
        this.id = UUID.randomUUID();
        this.name = name;
        this.membership = membership;
    }

    public UUID getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public Membership getMembership() {
        return membership;
    }

    public boolean canBorrow() {
        return borrowedBooks.size() < membership.getBorrowLimit();
    }

    public void borrowBook(UUID bookId, int days) {
        borrowedBooks.put(bookId, days);
    }

    public void returnBook(UUID bookId) {
        borrowedBooks.remove(bookId);
    }
}

// ---------------------------- MEMBERSHIP (ABSTRACT)
// ----------------------------
abstract class Membership {
    private String type;

    public Membership(String type) {
        this.type = type;
    }

    public String getType() {
        return type;
    }

    public abstract int getBorrowLimit();

    public abstract int getMaxBorrowDays();
}

// ---------------------------- GOLD MEMBERSHIP ----------------------------
class GoldMembership extends Membership {
    public GoldMembership() {
        super("Gold");
    }

    @Override
    public int getBorrowLimit() {
        return 15;
    }

    @Override
    public int getMaxBorrowDays() {
        return 31;
    }
}

// ---------------------------- SILVER MEMBERSHIP ----------------------------
class SilverMembership extends Membership {
    public SilverMembership() {
        super("Silver");
    }

    @Override
    public int getBorrowLimit() {
        return 10;
    }

    @Override
    public int getMaxBorrowDays() {
        return 14;
    }
}

// ---------------------------- BRONZE MEMBERSHIP ----------------------------
class BronzeMembership extends Membership {
    public BronzeMembership() {
        super("Bronze");
    }

    @Override
    public int getBorrowLimit() {
        return 5;
    }

    @Override
    public int getMaxBorrowDays() {
        return 7;
    }
}

// ---------------------------- MAIN (SIMULATION) ----------------------------
public class LibraryManagementWithMembershipApp {
    public static void main(String[] args) {

        System.out.println("📚 Library Membership System Initializing...\n");

        Library library = new Library();

        // Load books
        Book cleanCode = new Book("Clean Code", "Narayana");
        Book osBook = new Book("Operating Systems", "Keshav Maharaj");
        Book dsaBook = new Book("DSA with Java", "Striver");

        library.addBook(cleanCode);
        library.addBook(osBook);
        library.addBook(dsaBook);

        // Register members
        Member srimani = new Member("Srimani", new GoldMembership());
        Member ruban = new Member("Ruban", new SilverMembership());
        Member srini = new Member("Srini", new BronzeMembership());

        library.addMember(srimani);
        library.addMember(ruban);
        library.addMember(srini);

        System.out.println("\n👉 Story: Srimani wants to level up his fundamentals using his Gold membership.\n");

        // ⭐ Story-driven Borrow Attempts
        System.out.println("📖 Srimani starts his learning journey...");
        library.borrowBook(srimani.getId(), cleanCode.getId(), 14);

        System.out.println("\n📘 Ruban tries to borrow multiple books...");
        library.borrowBook(ruban.getId(), osBook.getId(), 10);
        library.borrowBook(ruban.getId(), osBook.getId(), 5); // Already borrowed
        library.borrowBook(ruban.getId(), dsaBook.getId(), 5);
        library.borrowBook(ruban.getId(), cleanCode.getId(), 5); // Already taken by Srimani

        System.out.println("\n🔄 After studying, they return the books.\n");

        library.returnBook(srimani.getId(), cleanCode.getId());
        library.returnBook(ruban.getId(), osBook.getId());
    }
}