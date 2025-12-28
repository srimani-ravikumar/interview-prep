# 🟢 Persistence Context Lifecycle

`BackendMastery.Persistence.ORM.ContextLifecycle`

---

## 🎯 What This Project Is About

This project answers the **first and most fundamental persistence question**:

> **How long does data live in memory?**

Before worrying about:

* change tracking
* repositories
* lazy loading
* performance
* transactions

You must understand **what a persistence context really is**.

---

## 🧠 Core Intuition (Read This First)

> **The database stores rows.
> The application works with objects.
> The ORM context is the boundary that connects them.**

An ORM does **not** fetch data directly into your application and forget about it.

Instead, it creates a **persistence context** that:

* Defines how long objects live in memory
* Guarantees object identity
* Tracks changes over time

---

## 🧠 The Hidden Question This Project Solves

Every ORM must answer:

> **“If I load the same row twice, should I get the same object?”**

The answer is:

* ✅ **Yes — inside the same context**
* ❌ **No — across different contexts**

This rule explains **most ORM behavior**.

---

## 🧠 Key Rule (Non-Negotiable)

> ❗ **One database row maps to exactly one object *per persistence context*.**

Not per application
Not per thread
Not per database

**Per context.**

---

## 📦 Project Goal

This project demonstrates:

* What a persistence context really is
* Why identity is context-scoped
* Why ORMs are **stateful**, not stateless
* Why context lifetime defines correctness

We intentionally **do NOT use EF Core yet**.

Why?

> Because frameworks hide the rule.
> This project makes it obvious.

---

## 📂 Project Structure

```
BackendMastery.Persistence.ORM.ContextLifecycle
│
├── Domain
│   └── User.cs
│
├── Infrastructure
│   └── FakeDbContext.cs
│
├── Program.cs
└── README.md
```

---

## 🧪 What the Demo Shows

### Scenario 1 — Same Context

* Load the same user twice
* Get the **same object instance**
* Identity is preserved

### Scenario 2 — Different Contexts

* Load the same user from a new context
* Get a **different object instance**
* Identity is intentionally broken

---

## 🧠 Why This Matters in Real Systems

This single concept explains:

* Why `DbContext` is **scoped per request**
* Why singleton contexts cause memory leaks
* Why detached entities behave strangely
* Why ORMs cache data
* Why lazy loading works at all

If you don’t understand this, everything else feels “magical”.

---

## 🚫 Common Mistakes This Project Prevents

* ❌ Using a singleton `DbContext`
* ❌ Expecting entity identity across requests
* ❌ Treating ORM like a stateless query helper
* ❌ Passing tracked entities across layers
* ❌ Blaming ORM for “random behavior”

---

## 🔁 Real-World Mapping (EF Core)

| Concept in This Project | EF Core Equivalent |
| ----------------------- | ------------------ |
| `FakeDbContext`         | `DbContext`        |
| Identity map            | Change Tracker     |
| Cached entity           | Tracked entity     |
| Context lifetime        | Request scope      |

> **EF Core is doing exactly this — even when you don’t see it.**

---

## 🧠 Interview-Ready Explanation

> **“A persistence context defines the lifetime and identity of entities in memory.
> The same database row maps to the same object only within that context.”**

That’s a **strong, senior-level answer**.

---

## ✅ Completion Checklist

You fully understand this project if you can explain:

* Why the same entity instance is reused
* Why identity breaks across contexts
* Why one request → one context is the default
* Why long-lived contexts are dangerous

If any of these feel fuzzy — reread the project and rerun the demo.

---