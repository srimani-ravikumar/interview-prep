# BackendMastery.Persistence.Transactions.BoundaryPlacement

## 🧱 Section 3 — Transactions & Consistency

### Project #3 — **Transaction Boundary Placement**

---

## 🎯 What This Project Is About

This project answers one of the **most critical architectural questions** in backend systems:

> **Where should a transaction actually live?**

Most real-world production bugs are caused not by *missing* transactions, but by **transactions placed in the wrong layer**.

The dangerous part?

👉 The system often *appears to work* — until partial failures silently corrupt data.

---

## 🧠 Core Intuition (Non-Negotiable)

> **Transactions belong to business use cases, not infrastructure layers.**

Which translates to:

* ❌ Controller-level transactions → too broad, leaky
* ❌ Repository-level transactions → too narrow, unsafe
* ✅ Service / Use-case-level transactions → correct

> **Wrong transaction placement doesn’t fail loudly — it fails silently.**

That’s why this topic matters more than syntax.

---

## ⚠️ Why This Is a Real Problem

In many codebases you’ll see:

* Repositories calling `BeginTransaction()`
* Controllers wrapping everything in a transaction
* Multiple commits inside one business flow

All of these lead to:

* partial commits
* inconsistent business state
* bugs that appear months later

This project makes those failures **visible**.

---

## 📦 Project Scope

* ✅ Console application (Web-API-like layering)
* ❌ No real database
* ❌ No ORM
* ✅ Explicit transaction simulation
* ✅ Focus on **architectural correctness**, not tooling

---

## 📂 Project Structure

```
BackendMastery.Persistence.Transactions.BoundaryPlacement
│
├── Domain
│   ├── Account.cs
│   └── LedgerEntry.cs
│
├── Infrastructure
│   ├── FakeDatabase.cs
│   └── TransactionManager.cs
│
├── Repositories
│   └── AccountRepository.cs
│
├── Services
│   └── TransferService.cs
│
├── Controllers
│   └── TransferController.cs
│
├── Program.cs
└── README.md
```

The structure intentionally mirrors a **real ASP.NET Core application**, even though this is a console app — to isolate the **concept**, not the framework.

---

## 🧩 Folder Responsibilities

### 📁 Domain

**Pure business concepts**

* `Account`, `LedgerEntry`
* No persistence logic
* No transaction awareness
* Models business meaning only

---

### 📁 Infrastructure

**Technical mechanics**

* `TransactionManager` simulates:

  * BEGIN
  * COMMIT
  * ROLLBACK
* `FakeDatabase` simulates persistence
* No knowledge of business flows

---

### 📁 Repositories (Anti-Pattern Demonstration)

* Shows the **wrong approach**
* Repositories start and commit transactions
* Each write becomes its own transaction

❗ This guarantees **partial success** in multi-step flows.

---

### 📁 Services (Correct Placement)

* Represents **business use cases**
* Owns transaction boundaries
* Groups multiple writes into one unit of correctness

✅ This is where transactions **must live**.

---

### 📁 Controllers (Anti-Pattern Demonstration)

* Simulates API entry points
* Shows why controllers should not manage transactions
* Demonstrates boundary leakage and poor composability

---

## 🧠 Key Takeaways (Critical)

✔ Transaction boundaries define correctness
✔ Repositories must remain transaction-agnostic
✔ Controllers orchestrate I/O, not business rules
✔ Services own business integrity
✔ Wrong placement causes silent data corruption

---

## 🚫 Anti-Patterns This Project Eliminates

❌ Transactions inside repositories
❌ One transaction per save
❌ Controller-managed transactions
❌ Hidden commits across layers

These patterns **scale bugs, not systems**.

---

## 🌍 Real-World Mapping

| Common Practice               | Hidden Problem        |
| ----------------------------- | --------------------- |
| Repository starts transaction | Partial commits       |
| Controller wraps everything   | Poor reuse & coupling |
| Multiple `SaveChanges()`      | Broken invariants     |
| Nested transactions           | Illusion of safety    |

This is why transaction bugs are **hard to debug**.

---

## 🎤 Interview-Ready One-Liner

> **“Transaction boundaries must align with business use cases, which is why they belong in the service layer rather than controllers or repositories.”**

This answer signals **real backend maturity**.

---

## ✅ Completion Criteria

You’ve mastered this project if you can explain:

* Why repositories should not manage transactions
* Why controller-level transactions are harmful
* Why services are the correct boundary
* How wrong placement causes partial commits without errors

---