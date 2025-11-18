import java.util.*;

// ---------------------------- BOOK ----------------------------
class Book {
    private final UUID id;
    private final String title;
    private final String author;
    private boolean available;
    private UUID borrowedByUserId; // null if not borrowed

    public Book(String title, String author) {
        this.id = UUID.randomUUID();
        this.title = title;
        this.author = author;
        this.available = true;
        this.borrowedByUserId = null;
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

    public UUID getBorrowedByUserId() {
        return borrowedByUserId;
    }

    public void borrow(UUID userId) {
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
    private final UUID id;
    private final String name;
    private final Set<UUID> borrowedBookIds;

    public User(String name) {
        this.id = UUID.randomUUID();
        this.name = name;
        this.borrowedBookIds = new HashSet<UUID>();
    }

    public UUID getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public Set<UUID> getBorrowedBooks() {
        return borrowedBookIds;
    }

    public void addBorrowedBook(UUID bookId) {
        borrowedBookIds.add(bookId);
    }

    public void removeBorrowedBook(UUID bookId) {
        borrowedBookIds.remove(bookId);
    }
}

// ---------------------------- LIBRARY ----------------------------
class Library {
    private final String name;
    private final Map<UUID, Book> books;
    private final Map<UUID, User> users;

    public Library(String name) {
        this.name = name;
        this.books = new HashMap<>();
        this.users = new HashMap<>();
        System.out.println("Library \"" + name + "\" created.");
    }

    public String getName() {
        return name;
    }

    public void addBook(Book book) {
        books.put(book.getId(), book);
        System.out.println("Added Book:- Title: " + book.getTitle() + " Author:" + book.getAuthor());
    }

    public void registerUser(User user) {
        users.put(user.getId(), user);
        System.out.println("User Registered: " + user.getName());
    }

    public void borrowBook(UUID userId, UUID bookId) {
        Book book = books.get(bookId);
        User user = users.get(userId);

        if (user == null) {
            System.out.println("❌ User not found. Hey! do you mind register :)");
            return;
        }

        if (book == null) {
            System.out.println("❌ Book not found.");
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

    public void returnBook(UUID userId, UUID bookId) {
        Book book = books.get(bookId);
        User user = users.get(userId);

        if (book == null) {
            System.out.println("❌ Invalid book. It's not ours :) lol");
            return;
        }

        if (user == null) {
            System.out.println("❌ Invalid user. Wait, are you valid user :) lol");
            return;
        }

        if (book.isAvailable()) {
            System.out.println("❌ Book is not currently borrowed by anyone. Hey! Are u kidding :)");
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

// ---------------------------- CLIENT CODE ----------------------------
public class LibraryBookManagementApp {
    public static void main(String[] args) throws InterruptedException {

        Library library = new Library("Village Library");

        Book cn = new Book("Computer Networks", "Kurose");
        Book os = new Book("Operating Systems", "Galvin");
        library.addBook(cn);
        library.addBook(os);

        User srimani = new User("Srimani");
        library.registerUser(srimani);

        // assuming that srimani wants to unlearn, relearn fundamentals in the right way
        // so he borrowed the "Computer Networks" book
        library.borrowBook(srimani.getId(), cn.getId());

        // assuming he was taking 15 days to wrap up the learning (15 secs treated as 15
        // days)
        Thread.sleep(15000);

        // he went to library to return it
        library.returnBook(srimani.getId(), cn.getId());

        // now he switching to "Operating Systems"... Journery continues untill he
        // rooting his entire fundamentals :)
        library.borrowBook(srimani.getId(), os.getId());
    }
}