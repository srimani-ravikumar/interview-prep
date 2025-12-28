# Anti-Patterns in Data Modeling

**(Data Modeling & Mapping — Project 9)**

---

## 🎯 Purpose of This Project

This project exists to make **common data-modeling mistakes explicit**.

Most real-world backend failures are **not caused by databases or ORMs**, but by:

* Poor modeling decisions
* Leaking persistence concerns
* Missing invariants
* Overloaded objects

This project shows **what NOT to do**, and **why those designs fail over time**.

---

## 🧠 Core Intuition

> **Most bad designs “work” at first — and that’s why they survive.**

Anti-patterns:

* Ship fast
* Look simple
* Feel flexible

But over time they:

* Destroy correctness
* Block refactoring
* Increase cognitive load
* Create fragile systems

This project trains your eye to **recognize danger early**.

---

## 📂 Project Structure

```
BackendMastery.Persistence.DataModeling.AntiPatterns
│
├── AntiPatterns
│   ├── AnemicDomainModel.cs    # No behavior, no protection
│   ├── TableDrivenDesign.cs    # DB schema dictates domain
│   └── GodEntity.cs            # One class does everything
│
├── Program.cs                  # Console demo
└── README.md
```

Each file demonstrates **one specific anti-pattern**, in isolation.

---

## ❌ Anti-Pattern 1 — Anemic Domain Model

### What it is

A domain model that:

* Contains only data
* Has no behavior
* Enforces no rules

### Typical Use Case (Wrong)

* CRUD-only applications
* “Just move logic to services”
* Table-to-class mapping

### Why it fails

* No invariants are protected
* Logic spreads across services
* Easy to misuse incorrectly
* Domain becomes meaningless

### Key Rule

> **If a domain object has no behavior, it is not a domain model.**

---

## ❌ Anti-Pattern 2 — Table-Driven Design

### What it is

A design where:

* Database tables define the domain
* Column names leak into business logic
* Schema structure dictates code structure

### Typical Use Case (Wrong)

* ORM-first development
* Auto-generated models
* “The DB already exists, just use it”

### Why it fails

* Domain changes require schema changes
* Business meaning is distorted
* Refactoring becomes expensive
* Tight coupling everywhere

### Key Rule

> **The database adapts to the domain — never the other way around.**

---

## ❌ Anti-Pattern 3 — God Entity

### What it is

A single class that:

* Holds data
* Applies business rules
* Persists itself
* Sends emails
* Generates reports

### Typical Use Case (Wrong)

* Rapid prototyping that never refactors
* “Just add it to Order”
* Fear of creating new classes

### Why it fails

* Violates Single Responsibility
* Hard to test
* Changes cascade everywhere
* Impossible to reason about

### Key Rule

> **If one class handles everything, it will eventually break everything.**

---

## 🧩 Why This Is a Console Application

This project uses a **console app** to:

* Remove ORM / framework noise
* Make design mistakes obvious
* Focus purely on modeling problems
* Show how easily invariants break

`Program.cs` demonstrates how these anti-patterns **fail silently**.

---

## 🚫 Why These Anti-Patterns Survive in Production

They survive because:

* They are easy to write
* They ship quickly
* Early systems are small
* Problems appear months later

> **By the time pain appears, the system is already expensive to fix.**

---

## 🎯 Real-World Impact

These anti-patterns lead to:

* Data corruption
* Hidden bugs
* Fear of change
* Rewrite discussions

Most legacy systems are **combinations of these mistakes**.

---

## 🧠 Interview-Ready Takeaways

You should be able to say:

* **Anemic Model**

  > “A domain model without behavior cannot protect invariants.”

* **Table-Driven Design**

  > “When schemas dictate domain design, business logic becomes brittle.”

* **God Entity**

  > “Classes with too many responsibilities are impossible to evolve safely.”

These answers signal **experience**, not theory.

---

## ✅ Completion Checklist

You’ve mastered this project if you can:

* Identify these anti-patterns in real code
* Explain why they fail at scale
* Propose correct alternatives (aggregates, value objects, mapping)

If yes — **this project is complete**.

---

## 🏁 Section 1 — Complete

You’ve now completed **Data Modeling & Mapping** end-to-end:

✅ Domain vs Storage
✅ Entity Identity & Lifecycle
✅ Aggregate Boundaries
✅ Value Objects
✅ Mapping Rules
✅ Schema Evolution
✅ Normalization Trade-offs
✅ Read vs Write Models
✅ Anti-Patterns

---