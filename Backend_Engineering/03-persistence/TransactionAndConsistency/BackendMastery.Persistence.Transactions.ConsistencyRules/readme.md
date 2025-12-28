# BackendMastery.Persistence.Transactions.ConsistencyRules

## 🧱 Section 3 — Transactions & Consistency

### Project #5 — **Consistency Rules Enforcement**

---

## 🎯 What This Project Is About

This project answers one of the **most dangerous misconceptions** in backend systems:

> **“If the transaction commits successfully, the system must be correct.”**

❌ False.

A system can be:

* transactionally consistent
* technically correct
* **business-wise wrong**

This project shows **why business invariants must be enforced explicitly** — and where they belong.

---

## 🧠 Core Intuition (Lock This In)

> **Consistency is a business concern, not a database feature.**

Key separation of responsibilities:

* **Database constraints** → structural correctness
* **Transactions** → atomic execution
* **Business invariants** → logical correctness

If business invariants are not enforced:

> The database will happily store **invalid reality**.

---

## ⚠️ The Real Failure This Prevents

A transaction that commits successfully can still represent an **illegal business state**.

Example:

* Withdrawal exceeds balance
* Balance becomes negative
* Ledger entry exists
* Transaction commits

The database is happy.
The business is broken.

This project exists to prevent **that exact scenario**.

---

## 📦 Project Scope

* ✅ Console application
* ❌ No real database
* ❌ No ORM
* ✅ Explicit transaction simulation
* ✅ Business invariants enforced in domain logic

This project is about **correctness**, not persistence mechanics.

---

## 📂 Project Structure

```
BackendMastery.Persistence.Transactions.ConsistencyRules
│
├── Domain
│   ├── Account.cs
│   └── LedgerEntry.cs
│
├── Infrastructure
│   └── FakeDatabase.cs
│
├── Services
│   └── WithdrawalService.cs
│
├── Program.cs
└── README.md
```

---

## 🧩 Folder Responsibilities

### 📁 Domain

**Business truth lives here**

* `Account` enforces business invariants
* Prevents illegal state transitions
* Knows nothing about databases or transactions

📌 **Important**
If an invariant is violated, the operation must fail **before persistence**.

---

### 📁 Infrastructure

**Technical persistence layer**

* Simulates database behavior
* Accepts any data that fits structure
* Has zero understanding of business rules

This mirrors real databases exactly.

---

### 📁 Services

**Use-case orchestration**

* Defines transaction boundaries
* Coordinates domain + persistence
* Ensures invariants are checked before saving

This is where **business correctness is protected**.

---

### 📄 Program.cs

**Demonstration driver**

* Attempts an invalid business operation
* Shows that:

  * transaction rolls back
  * invalid state never persists
  * balance remains correct

---

## 🧠 Key Takeaways (Critical)

✔ Transactions do not guarantee business correctness
✔ Databases enforce structure, not meaning
✔ Business invariants must live in domain logic
✔ Invalid state must be rejected before persistence
✔ A committed transaction can still be wrong

---

## 🚫 Common Mistakes This Project Prevents

❌ Relying on DB constraints for business rules
❌ Allowing invalid domain state to persist
❌ Checking rules after database writes
❌ Assuming “commit = correct”

These bugs **pass tests and fail production**.

---

## 🌍 Real-World Mapping

| Business Rule | Failure Without Enforcement |
| ------------- | --------------------------- |
| No overdraft  | Negative balances           |
| Seat limits   | Overbooking                 |
| Inventory ≥ 0 | Overselling                 |
| Credit limits | Financial exposure          |

Databases won’t protect you from these.

---

## 🎤 Interview-Ready One-Liner

> **“Transactions ensure atomicity, but business invariants define correctness and must be enforced in application logic.”**

This answer signals **senior backend thinking**.

---

## ✅ Completion Criteria

You’ve fully understood this project if you can explain:

* Why database constraints are insufficient
* Why transactions don’t imply correctness
* Where business invariants must be enforced
* How invalid state can still be committed

---