# BackendMastery.Architecture.Repository

**(Repository Pattern — In Isolation)**

This project demonstrates the **Repository Pattern as a standalone architectural concept**, without:

* Service layer
* MVC / HTTP
* Databases or ORMs
* Framework assumptions

The goal is to understand **what the Repository pattern really is**, and just as importantly, **what it is not**.

---

## 🎯 Why this project exists

Many developers associate the Repository pattern with:

* EF Core
* Databases
* CRUD services
* MVC applications

This leads to confusion such as:

* “Repository = database wrapper”
* “Repository must sit under a service”
* “Repository exists only in web apps”

This project answers a simpler, more fundamental question:

> **“How do I isolate data access without introducing business orchestration?”**

---

## 🧠 Core Intuition

> **The Repository pattern answers exactly one question:
> *Where does data come from?***

It does **not** answer:

* What the system does
* How workflows are executed
* How HTTP requests are handled
* How business rules are applied

That separation is intentional.

---

## 📌 Use Case Chosen: Product Catalog Reader

This project models a **read-only product catalog**.

This use case appears in many real systems:

* CLI catalog viewers
* Admin reporting tools
* Batch export jobs
* Data migration utilities
* Legacy system adapters

There is:

* Minimal behavior
* No orchestration complexity

👉 The **dominant concern is data access**, making it a perfect fit for an isolated Repository example.

---

## 📂 Project Structure

```
BackendMastery.Architecture.Repository
│
├── Models
│   └── Product.cs
│
├── Repositories
│   ├── IProductRepository.cs
│   └── InMemoryProductRepository.cs
│
├── Consumers
│   └── ProductCatalogViewer.cs
│
└── Program.cs
```

Each folder exists because it changes for **a different reason**.

---

## 🧩 Responsibility Breakdown

### 🟦 Models

**Concern:** Data shape
**Changes when:** Stored data structure changes

---

### 🟩 Repository Interface

**Concern:** Data access contract
**Changes when:** Data access requirements change

---

### 🟨 Repository Implementation

**Concern:** Storage mechanism
**Changes when:** Data source changes (memory → DB → API)

---

### 🟧 Consumer

**Concern:** Data usage / presentation
**Changes when:** Consumption logic changes

---

### ⚙ Composition (`Program.cs`)

**Concern:** Object wiring
**Changes when:** Startup or composition logic changes

---

## 🧠 What This Project Proves

Even without:

* Services
* Business logic
* MVC
* Databases

You still gain:

* Storage abstraction
* Swap-friendly persistence
* Testable consumers
* Localized change impact

This means:

> **The Repository pattern is valuable on its own.**

---

## 🔁 Change Impact Examples

| Change Required      | Files Affected                |
| -------------------- | ----------------------------- |
| Switch to database   | New repository implementation |
| Add caching          | Repository layer only         |
| Replace data source  | Repository only               |
| Change display logic | Consumer only                 |

No consumer code needs to know **how** data is stored.

---

## 🚫 What This Project Deliberately Avoids

* ❌ Business logic
* ❌ Service layer
* ❌ Validation rules
* ❌ HTTP / controllers
* ❌ ORM-specific patterns

This keeps the focus **purely on data access abstraction**.

---

## 🧠 Common Misconceptions (Interview Traps)

### ❌ “Repository is just a database wrapper”

Wrong.

> Repository abstracts *where data comes from*, not how SQL is written.

---

### ❌ “Repository must sit under a service”

Wrong.

> Services coordinate behavior; repositories provide data.

---

### ❌ “Repository exists only in web apps”

Wrong.

> Repositories are common in CLI tools, batch jobs, and migrations.

---

## 🎤 Interview-Ready Takeaways

You should confidently say:

> “The Repository pattern isolates data access from its consumers.”

> “Repositories exist independently of services and MVC.”

> “Consumers should never know how data is stored.”

> “Repositories represent a data boundary, not business behavior.”

These statements signal **clear architectural thinking**.

---

## 🧠 Final Mental Model

```
Consumer
   ↓
Repository (WHAT data is needed)
   ↓
Storage (WHERE data lives)
```

The **direction of dependency is intentional**.

---

## ✅ Completion Criteria

You are done with the Repository pattern when:

* You can swap storage without touching consumers
* Data access logic lives in one place
* No business logic leaks into repositories

At this point, your understanding of Repository is **industry-grade**.

---