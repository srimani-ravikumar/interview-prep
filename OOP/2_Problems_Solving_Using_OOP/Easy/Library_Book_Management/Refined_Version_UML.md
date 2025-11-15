UML Class Diagram (ASCII Version)
+---------------------+
|       Library       |
+---------------------+
| - name: String      |
| - books: Map<int,Book> |
| - users: Map<int,User> |
+---------------------+
| + addBook(Book)     |
| + registerUser(User)|
| + borrowBook(userId:int, bookId:int) |
| + returnBook(userId:int, bookId:int) |
+---------------------+
            |
            | 1..*
            v
+---------------------+
|        Book         |
+---------------------+
| - id: int           |
| - title: String     |
| - author: String    |
| - available: boolean|
| - borrowedByUserId: Integer |
+---------------------+
| + getId(): int      |
| + getTitle(): String|
| + isAvailable(): boolean |
| + borrow(userId:int)|
| + returnBook()      |
+---------------------+

            ^
            | *
            |
+---------------------+
|        User         |
+---------------------+
| - id: int           |
| - name: String      |
| - borrowedBookIds: Set<int> |
+---------------------+
| + getId(): int      |
| + getName(): String |
| + addBorrowedBook(int) |
| + removeBorrowedBook(int) |
+---------------------+
