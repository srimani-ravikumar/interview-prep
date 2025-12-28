# BackendMastery.Persistence.Transactions.SingleOperation

## 🧱 Section 3 — Transactions & Consistency

### Project #1 — **Single-Operation Transactions**

---

## 🎯 What This Project Is About

This project exposes a **dangerous illusion** many engineers carry:

> **“I didn’t start a transaction — so no transaction happened.”**

In reality:

* ORMs
* Databases
* Persistence frameworks

**automatically wrap even single writes in transactions**.

You are already relying on transactional behavior — **whether you know it or not**.

---

## 🧠 Core Intuition (Read This First)

> **Most systems already use transactions implicitly.**

What actually happens under the hood:

* A write operation begins an **implicit transaction**
* If the operation succeeds → **commit**
* If an exception occurs → **rollback**

This behavior:

* Protects correctness
* Hides complexity
* Creates **false confidence**

This project exists to **make the invisible visible**.

---

## ⚠️ Why This Matters

If you don’t understand implicit transactions:

* You assume correctness without defining it
* You get surprised when logic grows beyond one operation
* You place transaction boundaries incorrectly later

This is where **real production bugs begin**.

---

## 📦 Project Scope

* ✅ Console application
* ❌ No real database
* ❌ No ORM
* ✅ Transaction behavior simulated explicitly
* ✅ Focus on **mental model**, not tooling

---

## 📂 Project Structure

```
BackendMastery.Persistence.Transactions.SingleOperation
│
├── Domain
│   └── Account.cs
│
├── Infrastructure
│   └── FakeDatabase.cs
│
├── Services
│   └── AccountService.cs
│
├── Program.cs
└── README.md
```

---

## 🧩 Folder Responsibilities

### 📁 Domain

**Pure business entities**

* No persistence logic
* No transaction awareness
* Models the real-world concept (`Account`)

---

### 📁 Infrastructure

**Persistence simulation**

* Mimics ORM behavior
* Demonstrates:

  * implicit `BEGIN`
  * `COMMIT` on success
  * `ROLLBACK` on failure

This is where the **hidden transaction** is revealed.

---

### 📁 Services

**Use-case execution**

* Coordinates domain + persistence
* Does **not** explicitly manage transactions
* Mirrors how most real services are written

---

### 📄 Program.cs

**Execution entry point**

* Triggers the use case
* Lets you observe:

  * successful commit
  * rollback on exception (if enabled)

---

## 🧠 Key Takeaways (Non-Negotiable)

✔ Single operations are transactional
✔ Transactions exist even when not declared
✔ ORMs provide implicit atomicity
✔ You already depend on rollback semantics
✔ Ignoring this leads to incorrect assumptions

---

## 🚫 Common Misconceptions This Project Kills

❌ “Transactions are only for multiple operations”
❌ “Rollback is manual”
❌ “I need `BeginTransaction()` for safety”
❌ “Single writes can’t corrupt state”

---

## 🌍 Real-World Mapping

| Real System             | What This Project Represents |
| ----------------------- | ---------------------------- |
| EF Core `SaveChanges()` | Implicit transaction         |
| Hibernate `flush()`     | Implicit transaction         |
| JDBC auto-commit        | Implicit unit of work        |

This is **not academic** — it’s how production systems behave.

---

## 🎤 Interview-Ready One-Liner

> **“Even a single database write runs inside an implicit transaction, which means most systems already rely on transactional guarantees without realizing it.”**

---

## ✅ Completion Criteria

You’ve fully understood this project if you can explain:

* Why single writes are atomic
* What an implicit unit of work is
* Why this behavior becomes dangerous in multi-step use cases
* Why explicit transaction boundaries matter later

---