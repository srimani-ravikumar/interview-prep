+---------------------------+
|          Book             |
+---------------------------+
| - id: int                 |
| - title: String           |
| - author: String          |
| - isAvailable: boolean    |
| - borrowedBy: int         |
| - idCounter: static int   |
+---------------------------+
| + Book(title, author)     |
| + getBookId(): int        |
| + getTitle(): String      |
| + isAvailable(): boolean  |
| + getBorrowerId(): int    |
| + borrow(userId: int): void |
| + returnBook(): void      |
+---------------------------+


                1  * 
Book <---------------------- Library
                contains


+--------------------------------+
|            Library             |
+--------------------------------+
| - id: int                      |
| - name: String                 |
| - bookList: List<Book>         |
| - idCounter: static int        |
+--------------------------------+
| + Library(name: String)        |
| + addBook(book: Book): void    |
| + borrowBook(bookId, userId): void |
| + returnBook(bookId, userId): void |
+--------------------------------+


                1   *
User <------------------------ owns
                (borrowedBooks)


+------------------------------+
|            User              |
+------------------------------+
| - id: int                    |
| - name: String               |
| - borrowedBooks: List<Book>  |
| - idCounter: static int      |
+------------------------------+
| + User(name: String)         |
| + getUserId(): int           |
| + getName(): String          |
| + addBookToSelf(Book): void  |
| + removeBookFromSelf(Book): void |
+------------------------------+