# 🗄️ EF Core Code-First — Production-Grade API (.NET 8)

📦 **Project**

```
BackendMastery.Persistence.EFCore.CodeFirst
```

---

## 🎯 What This Project Is About

This project demonstrates **how EF Core should be used in real production systems**, not in demos.

It focuses on:

* Correct **Code-First modeling**
* Explicit **schema control**
* Clean **layered architecture**
* Safe **database migrations**
* Enforced **domain invariants**

> **This is not an EF Core tutorial.
> This is a correctness-first persistence implementation.**

---

## 🧠 Core Intuition (Lock This In)

> **EF Core is not a database generator — it is a schema contract tool.**

Bad EF Core usage leads to:

* Implicit schemas
* Accidental migrations
* Weak constraints
* Data corruption

Good EF Core usage:

* Models reality first
* Lets the database enforce rules
* Makes schema changes intentional
* Treats migrations as history

---

## 🧱 Architecture Overview

```
BackendMastery.Persistence.EFCore.CodeFirst
│
├── Api                → HTTP boundary (thin)
│
├── Application        → Use cases & orchestration
│   ├── Abstractions   → Repository contracts
│   └── Services       → Transaction boundaries
│
├── Domain             → Business model (pure)
│   ├── Entities       → Aggregates
│   └── ValueObjects   → Strong types
│
├── Infrastructure     → EF Core + SQL Server
│   └── Persistence
│       ├── DbContext
│       ├── Configurations
│       └── Repositories
│
└── README.md
```

### Dependency Direction (Strict)

```
Api → Application → Domain
          ↓
   Infrastructure (EF Core)
```

> ❗ **Domain never depends on EF Core**

---

## 🧩 Key Design Decisions (Explained)

### 1️⃣ Domain-First Modeling

* Entities represent **business concepts**, not tables
* `Order` is an **aggregate root**
* `OrderItem` cannot exist outside `Order`
* `Money` is a **value object**, not a `decimal`

**Why this matters**

* Prevents primitive obsession
* Enforces invariants in code
* Keeps persistence from leaking into domain logic

---

### 2️⃣ Explicit EF Core Configuration (No Defaults)

Every entity has:

* `IEntityTypeConfiguration<T>`
* Explicit keys
* Explicit constraints
* Explicit relationships
* Explicit delete behavior

**Why this matters**

* EF Core defaults are unstable across versions
* Database schema must be predictable
* Migrations must reflect intent, not guesswork

> ❗ **Conventions are not contracts**

---

### 3️⃣ Aggregate Ownership & Shadow Foreign Keys

* `OrderItem` does **not** expose `OrderId`
* Foreign key is modeled as a **shadow property**
* Navigation is **one-way** (Order → Items)

**Why this matters**

* Aggregate boundaries are preserved
* Domain model stays persistence-agnostic
* Child entities cannot be misused independently

---

### 4️⃣ Repository Pattern (Used Correctly)

This project **intentionally uses a repository**, but:

* ❌ No generic repository
* ❌ No EF wrapper for everything
* ✅ One repository per aggregate root
* ✅ Repository exposes **aggregate-safe operations only**

**Key rule**

> **DbContext = Unit of Work
> Repository = Aggregate access**

`SaveChanges()` is **not** inside the repository.

---

### 5️⃣ Application Service = Transaction Boundary

The application service:

* Orchestrates domain + persistence
* Controls transaction boundaries
* Calls `SaveChangesAsync()`
* Does **not** contain HTTP logic
* Does **not** expose EF Core

**Why this matters**

* Clear ownership of side effects
* Predictable transaction scope
* Testable business workflows

---

### 6️⃣ Thin Controllers (Correct API Design)

Controllers:

* Accept HTTP requests
* Delegate to application services
* Return HTTP responses

Controllers **do not**:

* Talk to DbContext
* Contain business rules
* Perform persistence logic

---

## 🗄️ EF Core Code-First & Migrations

This project follows **industry-standard migration discipline**:

* Domain + configuration change first
* Migration generated second
* Migration reviewed before apply
* Migrations committed to source control
* No editing applied migrations
* Expand → Migrate → Contract for breaking changes

> See `docs/ef-core-migration-strategy.md` for full methodology.

---

## 🧠 What This Project Intentionally Avoids

* ❌ Generic repositories
* ❌ Fat controllers
* ❌ EF Core leaking into domain
* ❌ Auto-generated schema assumptions
* ❌ Annotation-driven mapping
* ❌ Magic conventions
* ❌ Over-engineering (CQRS, MediatR, etc.)

This is **clean by design**, not minimal by accident.

---

## 🌍 Real-World Readiness

This project structure scales to:

* Monoliths
* Modular monoliths
* Microservices (per-service DB)
* Regulated domains (finance, payments)
* Teams with DBAs

You can:

* Swap SQL Server
* Add background jobs
* Add outbox pattern
* Add read models

…without breaking the core design.

---

## 🎯 Interview-Ready Summary

If asked:

> “How do you implement EF Core Code-First in production?”

Your answer is this project.

One-liner you can confidently say:

> **“We model the domain first, configure EF Core explicitly, use repositories only for aggregate boundaries, treat DbContext as Unit of Work, and manage migrations as immutable history.”**

That answer **instantly signals seniority**.

---

## ✅ Completion Criteria

You fully understand this project if you can explain:

* Why EF Core defaults are dangerous
* Why repositories are not generic
* Why SaveChanges is not in repository
* Why aggregates matter for persistence
* How migrations are handled safely
* Why domain must stay EF-free

---

## 🏁 Final Note

You’ve now gone full circle:

**Concepts → Failure handling → Transactions → EF Core → Production discipline**

At this point, you’re not “learning EF Core”.

You’re **using it correctly**.

---