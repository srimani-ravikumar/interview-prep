# 🟡 Lazy vs Eager Loading (Trade-offs)

`BackendMastery.Persistence.ORM.LoadingStrategies`

---

## 🎯 What This Project Is About

This project answers a deceptively simple but **dangerous** question:

> **Why did accessing a property hit the database?**

Many production bugs originate here because **data access becomes implicit**
and developers lose control over *when* IO happens.

---

## 🧠 Core Intuition (Read This First)

> **Implicit data access breaks predictability.**

Lazy loading:

* Defers database access
* Hides IO behind property access
* Triggers queries at unexpected times

Eager loading:

* Makes database access explicit
* Loads data upfront
* Preserves predictability

> ❗ **Surprise IO is a production bug, not a convenience.**

---

## 🧠 The Hidden Question This Project Solves

Every ORM must answer:

> **“When should related data be loaded?”**

There are two strategies:

* **Lazy loading** → Load when accessed
* **Eager loading** → Load explicitly upfront

The wrong choice leads to:

* N+1 query explosions
* Serialization failures
* Random performance regressions

---

## ❗ Key Rule (Non-Negotiable)

> ❗ **Accessing a property must never cause unexpected IO.**

If reading an object graph can:

* Hit the database
* Trigger network calls
* Fail at runtime

…then your system is **no longer deterministic**.

---

## 📦 Project Goal

This project demonstrates:

* How lazy loading hides database access
* Why eager loading is safer for APIs
* How N+1 bugs are born
* Why predictability matters more than convenience

We simulate ORM behavior so the **danger is visible**, not theoretical.

---

## 📂 Project Structure

```
BackendMastery.Persistence.ORM.LoadingStrategies
│
├── Domain
│   ├── Order.cs
│   └── OrderItem.cs
│
├── Infrastructure
│   └── FakeDbContext.cs
│
├── Program.cs
└── README.md
```

---

## 🧪 What the Demo Shows

### Scenario 1 — Lazy Loading

* Order is loaded **without items**
* Items are fetched **only when accessed**
* Property access triggers a **database hit**
* IO happens at an unpredictable point

### Scenario 2 — Eager Loading

* Order and items are loaded together
* All database access is explicit
* Property access is safe and cheap
* Behavior is predictable

Both approaches return the same data —
but their **runtime behavior is radically different**.

---

## 🧠 Why This Matters in Real Systems

This single concept explains:

* Why APIs break during JSON serialization
* Why loops cause N+1 query explosions
* Why “it worked locally” fails in production
* Why performance bugs feel random
* Why many teams disable lazy loading entirely

Most ORM horror stories start here.

---

## 🚫 Common Mistakes This Project Prevents

* ❌ Enabling lazy loading in web APIs
* ❌ Assuming property access is cheap
* ❌ Serializing tracked entities
* ❌ Accidentally triggering DB calls in loops
* ❌ Debugging “random” performance issues

---

## 🔁 Real-World Mapping (EF Core)

| Concept in This Project | EF Core Equivalent           |
| ----------------------- | ---------------------------- |
| Lazy-loaded navigation  | Virtual navigation + proxies |
| Eager loading           | `.Include()`                 |
| Surprise DB hit         | Lazy load trigger            |
| N+1 problem             | Loop + lazy navigation       |

> **EF Core allows lazy loading — that doesn’t mean you should use it.**

---

## 🧠 Interview-Ready Explanation

> **“Lazy loading hides database access behind property access, which breaks predictability and often causes N+1 and serialization bugs.”**

This is a **strong, production-grade answer**.

---

## ✅ Completion Checklist

You fully understand this project if you can explain:

* Why lazy loading is dangerous
* Why eager loading is safer for APIs
* How N+1 queries occur
* Why implicit IO is a design smell

If property access ever surprises you — revisit this project.

---