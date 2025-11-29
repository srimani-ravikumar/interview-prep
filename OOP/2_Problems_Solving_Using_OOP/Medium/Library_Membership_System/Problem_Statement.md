## 📚 Library Management with Membership

* **Problem Statement:**
  Design a library management system where a library maintains a collection of books and registered members. Members belong to different membership tiers (Gold, Silver, Bronze), each providing different borrowing limits and maximum borrowing days. The library should allow adding books, registering members, issuing books based on membership rules, and managing book returns. Each member can borrow multiple books, and the system must track which books are borrowed and enforce membership restrictions.

* **OOP Concepts Tested:**

  * **Encapsulation** – Books, Members, and Membership rules manage their own data and behavior.
  * **Inheritance & Polymorphism** – Membership types (Gold, Silver, Bronze) extend an abstract Membership class with different borrowing rules.
  * **Composition** – The Library *owns* Books and Members.
  * **Association** – Members borrow Books and hold a reference to a Membership type.
  * **Abstraction** – Membership defines abstract borrowing limits.
