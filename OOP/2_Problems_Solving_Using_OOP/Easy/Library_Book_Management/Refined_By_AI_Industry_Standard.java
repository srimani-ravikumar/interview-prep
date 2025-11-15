import java.util.*;

// ---------------------------- BOOK ----------------------------
class Book {
    private static int idCounter = 1;

    private final int id;
    private final String title;
    private final String author;
    private boolean available;
    private Integer borrowedByUserId; // null if not borrowed

    public Book(String title, String author) {
        this.id = idCounter++;
        this.title = title;
        this.author = author;
        this.available = true;
        this.borrowedByUserId = null;
    }

    public int getId() { return id; }
    public String getTitle() { return title; }
    public boolean isAvailable() { return available; }
    public Integer getBorrowedByUserId() { return borrowedByUserId; }

    public void borrow(int userId) {
        this.available = false;
        this.borrowedByUserId = userId;
    }

    public void returnBook() {
        this.available = true;
        this.borrowedByUserId = null;
    }
}

// ---------------------------- USER ----------------------------
class User {
    private static int idCounter = 1;

    private final int id;
    private final String name;
    private final Set<Integer> borrowedBookIds;

    public User(String name) {
        this.id = idCounter++;
        this.name = name;
        this.borrowedBookIds = new HashSet<>();
    }

    public int getId() { return id; }
    public String getName() { return name; }
    public Set<Integer> getBorrowedBooks() { return borrowedBookIds; }

    public void addBorrowedBook(int bookId) {
        borrowedBookIds.add(bookId);
    }

    public void removeBorrowedBook(int bookId) {
        borrowedBookIds.remove(bookId);
    }
}

// ---------------------------- LIBRARY ----------------------------
class Library {
    private final String name;
    private final Map<Integer, Book> books;
    private final Map<Integer, User> users;

    public Library(String name) {
        this.name = name;
        this.books = new HashMap<>();
        this.users = new HashMap<>();
        System.out.println("Library \"" + name + "\" created.");
    }

    public void addBook(Book book) {
        books.put(book.getId(), book);
        System.out.println("Added Book: " + book.getTitle());
    }

    public void registerUser(User user) {
        users.put(user.getId(), user);
        System.out.println("User Registered: " + user.getName());
    }

    public void borrowBook(int userId, int bookId) {
        Book book = books.get(bookId);
        User user = users.get(userId);

        if (book == null) {
            System.out.println("❌ Book not found.");
            return;
        }
        if (user == null) {
            System.out.println("❌ User not found.");
            return;
        }
        if (!book.isAvailable()) {
            System.out.println("❌ Book \"" + book.getTitle() + "\" is already borrowed.");
            return;
        }

        // process borrow
        book.borrow(userId);
        user.addBorrowedBook(bookId);

        System.out.println("✅ \"" + book.getTitle() + "\" borrowed successfully by " + user.getName());
    }

    public void returnBook(int userId, int bookId) {
        Book book = books.get(bookId);
        User user = users.get(userId);

        if (book == null || user == null) {
            System.out.println("❌ Invalid user or book.");
            return;
        }

        if (book.isAvailable()) {
            System.out.println("❌ Book is not currently borrowed by anyone.");
            return;
        }

        if (!Objects.equals(book.getBorrowedByUserId(), userId)) {
            System.out.println("❌ " + user.getName() + " did NOT borrow \"" + book.getTitle() + "\"");
            return;
        }

        // process return
        book.returnBook();
        user.removeBorrowedBook(bookId);

        System.out.println("✅ \"" + book.getTitle() + "\" returned successfully by " + user.getName());
    }
}

// ---------------------------- MAIN ----------------------------
public class Solution {
    public static void main(String[] args) throws InterruptedException {

        Library library = new Library("Village Library");

        Book cn = new Book("Computer Networks", "Kurose");
        Book os = new Book("Operating Systems", "Galvin");
        library.addBook(cn);
        library.addBook(os);

        User srimani = new User("Srimani");
        library.registerUser(srimani);

        library.borrowBook(srimani.getId(), cn.getId());
        Thread.sleep(1500);
        library.returnBook(srimani.getId(), cn.getId());
    }
}