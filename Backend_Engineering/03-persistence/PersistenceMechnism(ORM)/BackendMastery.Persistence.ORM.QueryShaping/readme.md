# 🟡 Query Shaping & Performance

`BackendMastery.Persistence.ORM.QueryShaping`

---

## 🎯 What This Project Is About

This project answers a question that is often misunderstood and frequently misdiagnosed:

> **Why is my query slow even though the ORM is “optimized”?**

In most real systems, the problem is **not**:

* the ORM
* the database
* the network

The real problem is **loading the wrong shape of data**.

---

## 🧠 Core Intuition (Read This First)

> **ORM performance problems are usually modeling problems, not query problems.**

ORMs don’t return “rows”.
They materialize **object graphs**.

If you load:

* full entities when you only need two fields
* deep aggregates for simple screens
* domain models for reporting

You pay for it in:

* memory
* CPU
* serialization time
* garbage collection
* network bandwidth

---

## 🧠 The Hidden Question This Project Solves

Every ORM-based system must answer:

> **“What is the minimum data shape required for this use case?”**

If you don’t answer this explicitly, the default becomes:

> **Load everything.**

That default is the root cause of most performance issues.

---

## ❗ Key Rule (Non-Negotiable)

> ❗ **Always load the minimum data required for the use case.**

Anything more is **wasted cost**.

This rule applies regardless of:

* ORM
* database
* infrastructure
* scale

---

## 📦 Project Goal

This project demonstrates:

* Why `SELECT *` is a performance bug
* Why entities are **not** read models
* How projections reduce cost
* Why query shaping is a design decision, not an optimization trick

We intentionally simulate ORM behavior to make the **cost difference obvious**.

---

## 📂 Project Structure

```
BackendMastery.Persistence.ORM.QueryShaping
│
├── Domain
│   └── Customer.cs
│
├── ReadModels
│   └── CustomerSummary.cs
│
├── Infrastructure
│   └── FakeDbContext.cs
│
├── Program.cs
└── README.md
```

---

## 🧪 What the Demo Shows

### Scenario 1 — Full Entity Load

* Loads a rich domain entity
* Materializes all fields
* Allocates more memory
* Suitable for **business behavior**
* Expensive for simple reads

### Scenario 2 — Projection / Read Model

* Loads only required fields
* Minimal object creation
* Faster materialization
* Suitable for **UI and reporting**
* Predictable performance

Both queries may hit the same table —
but their **runtime cost is completely different**.

---

## 🧠 Why This Matters in Real Systems

This single concept explains:

* Why APIs feel slow under load
* Why response sizes are large
* Why GC pressure increases
* Why “EF Core is slow” is often false
* Why CQRS naturally emerges

Most teams try to “optimize SQL”
when they should be **fixing data shape**.

---

## 🚫 Common Mistakes This Project Prevents

* ❌ Using domain entities for UI responses
* ❌ SELECT * queries everywhere
* ❌ Over-fetching unused fields
* ❌ Serializing large aggregates
* ❌ Blaming the ORM for poor performance

---

## 🔁 Real-World Mapping (EF Core)

| Concept in This Project | EF Core Equivalent              |
| ----------------------- | ------------------------------- |
| Full entity load        | `context.Customers.First()`     |
| Projection              | `.Select(x => new Dto { ... })` |
| Read model              | DTO / ViewModel                 |
| Query shaping           | LINQ projections                |

> **EF Core is efficient — over-fetching is not.**

---

## 🧠 Interview-Ready Explanation

> **“Most ORM performance issues come from over-fetching data; shaping queries with projections is more important than optimizing SQL.”**

That’s a **strong, practical, senior-level answer**.

---

## ✅ Completion Checklist

You fully understand this project if you can explain:

* Why SELECT * is dangerous
* Why entities are not read models
* How projections reduce memory and CPU cost
* Why performance is a modeling concern

If you still think performance starts with indexes —
revisit this project.

---