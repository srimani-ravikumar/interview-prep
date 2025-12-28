# 🔵 ORM Anti-Patterns

`BackendMastery.Persistence.ORM.AntiPatterns`

---

## 🎯 What This Project Is About

This project answers a hard but essential question:

> **Why do ORMs feel painful, unpredictable, and “magical” in many real systems?**

The answer is almost never:

* EF Core
* Hibernate
* The database

The real cause is:

> **Broken architectural boundaries and incorrect mental models.**

This project intentionally shows **how ORMs are misused**,
using a deliberately naïve `FakeDbContext`,
and then contrasts those mistakes with the **correct design**.

---

## 🧠 Core Intuition (Read This First)

> **ORM problems are usually architecture problems, not tooling problems.**

ORMs work best when:

* Their responsibilities are **contained**
* Their behavior is **predictable**
* Their usage is **intentional**

ORMs become painful when:

* Infrastructure leaks upward
* Layers mix responsibilities
* Persistence is treated as “just CRUD”

This project exists to make those failures **obvious**.

---

## 🧠 The Hidden Question This Project Solves

Every ORM-based system must answer:

> **“Where are persistence concerns allowed to exist?”**

There are only two outcomes:

* ❌ *Everywhere* → hidden coupling, unpredictable behavior
* ✅ *Behind a boundary* → stable, testable systems

This project enforces the second.

---

## ❗ Key Rule (Non-Negotiable)

> ❗ **Persistence concerns must never define domain or application behavior.**

If your:

* Controllers know about `DbContext`
* Domain models know about persistence
* Application code reasons about tracking
* Queries leak outside repositories

Your architecture is already compromised.

---

## 📦 Project Goal

This project demonstrates:

* Common ORM anti-patterns **using a fake ORM context**
* Why those patterns feel convenient initially
* Why they rot codebases over time
* What the correct alternative looks like

Some code in this project is **intentionally bad**.
It exists only to sharpen your instincts.

---

## 📂 Project Structure

```
BackendMastery.Persistence.ORM.AntiPatterns
│
├── Infrastructure
│   └── FakeDbContext.cs
│
├── BadExamples
│   ├── ControllerUsingDbContext.cs
│   ├── GenericRepository.cs
│   └── IQueryableLeak.cs
│
├── GoodExamples
│   ├── Order.cs
│   ├── IOrderRepository.cs
│   ├── OrderRepository.cs
│   └── OrderService.cs
│
├── Program.cs
└── README.md
```

---

## 🧪 The Role of FakeDbContext (Important)

`FakeDbContext` simulates a **misused ORM context**:

* Exposes `IQueryable`
* Allows direct querying
* Has a visible `SaveChanges()`

This is **intentional**.

> ❗ `FakeDbContext` exists to show
> **how ORMs are incorrectly treated as global query tools.**

It is **not** an example of good design.

---

## 🚫 Anti-Patterns Demonstrated

### ❌ 1. ORM in Controllers

**What happens**

* Controller directly uses `FakeDbContext`
* Business logic and persistence logic mix
* Testing becomes painful
* Persistence choices leak everywhere

**Root cause**

> Treating ORM as a convenience API instead of infrastructure

---

### ❌ 2. Generic Repository

**What happens**

* Repository exposes `IQueryable`
* CRUD thinking replaces intent
* Persistence mechanics leak upward

**Root cause**

> Treating repositories as collections instead of boundaries

---

### ❌ 3. IQueryable Leakage

**What happens**

* Query execution happens unpredictably
* Performance characteristics leak across layers
* ORM behavior infects application logic

**Root cause**

> Letting infrastructure abstractions escape their layer

---

## ✅ Correct Pattern (Contrast)

The **good examples** enforce strict boundaries:

### Domain

* Pure business behavior
* No persistence knowledge

### Repository Interface

* Intent-based operations
* Owned by the domain layer

### Repository Implementation

* Uses persistence internally
* Hides ORM mechanics completely

### Application Service

* Coordinates use cases
* Never talks to ORM directly

> **ORM stays in infrastructure — nowhere else.**

---

## 🧠 Why This Matters in Real Systems

This project explains why:

* ORMs get blamed unfairly
* Performance issues feel “random”
* Legacy systems become rigid
* Refactoring becomes scary
* Junior devs struggle with “EF Core magic”

Almost every painful ORM story traces back to **these mistakes**.

---

## 🚫 Smells You Should Now Detect Instantly

After completing this project, these should trigger alarms:

* `DbContext` inside controllers
* Repositories returning `IQueryable`
* Generic repositories everywhere
* Domain models with persistence concerns
* ORM blamed for architectural bugs

These are **design smells**, not style issues.

---

## 🔁 Real-World Mapping (EF Core)

| Anti-Pattern           | Correct Approach                  |
| ---------------------- | --------------------------------- |
| Controller → DbContext | Controller → Service → Repository |
| Generic repository     | Intent-based repository           |
| IQueryable leakage     | Explicit repository methods       |
| ORM everywhere         | ORM only in infrastructure        |

> **EF Core is not the problem — boundaries are.**

---

## 🧠 Interview-Ready Explanation

> **“Most ORM problems are caused by leaking persistence concerns across layers, not by the ORM itself.”**

That answer signals **architectural maturity**.

---

## ✅ Completion Checklist

You fully understand this project if you can explain:

* Why `FakeDbContext` is intentionally naïve
* Why each bad example is harmful
* How the good example fixes the issue
* How to spot these smells in real codebases

If you can **identify these anti-patterns instantly**,
Section 2 has done its job.

---