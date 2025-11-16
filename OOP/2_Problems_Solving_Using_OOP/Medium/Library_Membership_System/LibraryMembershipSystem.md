```mermaid

classDiagram
    direction TB

    class Membership {
        <<abstract>>
        - String type
        + Membership(String)
        + getType() String
        + getBorrowLimit() int*
        + getMaxBorrowDays() int*
    }

    class RegularMembership {
        + RegularMembership()
        + getBorrowLimit() int
        + getMaxBorrowDays() int
    }

    class PremiumMembership {
        + PremiumMembership()
        + getBorrowLimit() int
        + getMaxBorrowDays() int
    }

    class Book {
        - int id
        - String title
        - boolean available
        + Book(String)
        + getId() int
        + getTitle() String
        + isAvailable() boolean
        + borrow() void
        + returnBook() void
    }

    class Member {
        - int id
        - String name
        - Membership membership
        - Map~Integer, Integer~ borrowedBooks
        + Member(String, Membership)
        + getId() int
        + getName() String
        + getMembership() Membership
        + getBorrowedBooks() Map
        + canBorrow() boolean
        + borrowBook(int, int) void
        + returnBook(int) void
    }

    class LibrarySystem {
        - Map~Integer, Book~ books
        - Map~Integer, Member~ members
        + addBook(Book) void
        + addMember(Member) void
        + borrowBook(int, int, int) void
        + returnBook(int, int) void
    }

    %% Relationships
    Membership <|-- RegularMembership
    Membership <|-- PremiumMembership

    Member "1" --> "1" Membership : "has-a"
    LibrarySystem "1" --> "*" Book : "manages"
    LibrarySystem "1" --> "*" Member : "manages"

    Member "1" --> "*" Book : "borrows (via IDs)"

```
