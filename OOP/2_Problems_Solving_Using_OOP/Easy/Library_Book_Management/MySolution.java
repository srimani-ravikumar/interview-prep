import java.util.*;

// ------------------- BOOK CLASS -------------------
class Book
{
    private static int idCounter = 1;

    private int id;
    private String title;
    private String author;
    private boolean isAvailable;
    private int borrowedBy;

    public Book(String title, String author)
    {
        this.id = idCounter++;
        this.title = title;
        this.author = author;
        this.isAvailable = true;
        this.borrowedBy = -1;
    }

    public int getBookId()
    {
        return this.id;
    }

    public String getTitle()
    {
        return this.title;
    }

    public boolean isAvailable()
    {
        return this.isAvailable;
    }

    public int getBorrowerId()
    {
        return this.borrowedBy;
    }

    public void borrow(int userId)
    {
        this.isAvailable = false;
        this.borrowedBy = userId;
    }

    public void returnBook()
    {
        this.isAvailable = true;
        this.borrowedBy = -1;
    }
}

// ------------------- LIBRARY CLASS -------------------
class Library
{
    private static int idCounter = 1;

    private int id;
    private String name;
    private List<Book> bookList;

    public Library(String name)
    {
        this.id = idCounter++;
        this.name = name;
        this.bookList = new ArrayList<Book>();
        System.out.println("A new library named \"" + name + "\" constructed successfully.");
    }

    public void addBook(Book book)
    {
        this.bookList.add(book);
        System.out.println("Book titled \"" + book.getTitle() + "\" was successfully added to " + this.name);
    }

    public void borrowBook(int bookId, int userId)
    {
        for (Book book : this.bookList)
        {
            if (book.getBookId() == bookId)
            {
                if (!book.isAvailable())
                {
                    System.out.println("Book \"" + book.getTitle() + "\" is already borrowed!");
                    return;
                }

                book.borrow(userId);
                System.out.println("Book \"" + book.getTitle() + "\" borrowed by User ID " + userId);
                return;
            }
        }

        System.out.println("Book ID " + bookId + " not found in the library.");
    }

    public void returnBook(int bookId, int userId)
    {
        for (Book book : this.bookList)
        {
            if (book.getBookId() == bookId)
            {
                if (book.getBorrowerId() != userId)
                {
                    System.out.println("User ID " + userId + " did NOT borrow this book!");
                    return;
                }

                book.returnBook();
                System.out.println("Book \"" + book.getTitle() + "\" returned by User ID " + userId);
                return;
            }
        }

        System.out.println("Book ID " + bookId + " not found in the library.");
    }
}

// ------------------- USER CLASS -------------------
class User
{
    private static int idCounter = 1;

    private int id;
    private String name;
    private List<Book> borrowedBooks;

    public User(String name)
    {
        this.id = idCounter++;
        this.name = name;
        this.borrowedBooks = new ArrayList<Book>();
    }

    public int getUserId()
    {
        return this.id;
    }

    public String getName()
    {
        return this.name;
    }

    public void addBookToSelf(Book book)
    {
        this.borrowedBooks.add(book);
        System.out.println("Book \"" + book.getTitle() + "\" was added to " + this.name + "'s shelf.");
    }

    public void removeBookFromSelf(Book book)
    {
        this.borrowedBooks.remove(book);
        System.out.println("Book \"" + book.getTitle() + "\" was removed from " + this.name + "'s shelf.");
    }
}

// ------------------- MAIN PROGRAM -------------------
public class Solution
{
    public static void main(String[] args) throws InterruptedException
    {
        // create a library
        var library = new Library("MyLibrary_1");

        // add some books
        var operatingSystemBook = new Book("OS", "Raj");
        var computerNetworks = new Book("CN", "Vikramadithya");
        var dsa = new Book("DSA", "Striver");

        library.addBook(operatingSystemBook);
        library.addBook(computerNetworks);
        library.addBook(dsa);

        // register a user
        var srimani = new User("Srimani");

        // simulate borrowing
        library.borrowBook(computerNetworks.getBookId(), srimani.getUserId());
        srimani.addBookToSelf(computerNetworks);

        Thread.sleep(2000);

        // simulate returning
        library.returnBook(computerNetworks.getBookId(), srimani.getUserId());
        srimani.removeBookFromSelf(computerNetworks);
    }
}