# 🟢 Read vs Write Queries

`BackendMastery.Persistence.ORM.ReadWriteBehavior`

---

## 🎯 What This Project Is About

This project answers the **third hidden persistence question**:

> **Do all queries need to be tracked by the ORM?**

Most systems silently assume **yes** — and pay the price later.

This project makes **query intent explicit** and shows why
**reads and writes must be treated differently**.

---

## 🧠 Core Intuition (Read This First)

> **Reads and writes have fundamentally different goals.**

* **Reads**

  * Optimize for speed
  * Care about data shape
  * Do **not** require identity
  * Do **not** require change tracking

* **Writes**

  * Optimize for correctness
  * Require identity
  * Require change tracking
  * Must participate in a unit of work

When you treat reads like writes, you introduce **silent performance bugs**.

---

## 🧠 The Hidden Question This Project Solves

Every ORM must answer:

> **“Does this data need to be tracked?”**

Tracking:

* Allocates memory
* Takes snapshots
* Participates in change detection

If you don’t intend to modify the data, tracking is wasted work.

---

## ❗ Key Rule (Non-Negotiable)

> ❗ **Only data you intend to modify should be tracked.**

Tracking is **not free**:

* Memory overhead
* CPU cost during `SaveChanges`
* Increased context complexity

---

## 📦 Project Goal

This project demonstrates:

* The difference between **read intent** and **write intent**
* Why no-tracking queries exist
* How performance issues often start at the query layer
* Why CQRS emerges naturally in mature systems

We intentionally simulate ORM behavior to keep the **mental model clear**.

---

## 📂 Project Structure

```
BackendMastery.Persistence.ORM.ReadWriteBehavior
│
├── Domain
│   └── Order.cs
│
├── Infrastructure
│   └── FakeDbContext.cs
│
├── Program.cs
└── README.md
```

---

## 🧪 What the Demo Shows

### Scenario 1 — Read-Only Query

* Data is loaded **without tracking**
* No identity is maintained
* No memory is retained
* No persistence is possible

### Scenario 2 — Write Query

* Data is loaded **with tracking**
* Identity is preserved
* Changes are detected
* Updates are generated at commit

Both queries may return the **same data**,
but their **intent and cost are completely different**.

---

## 🧠 Why This Matters in Real Systems

This single distinction explains:

* Why `AsNoTracking()` exists
* Why reporting queries should not use entities
* Why ORMs feel slow under load
* Why read/write separation improves scalability
* Why CQRS is not overengineering

Most “ORM performance problems” start here.

---

## 🚫 Common Mistakes This Project Prevents

* ❌ Tracking read-only queries
* ❌ Using entities for reporting
* ❌ Treating all queries equally
* ❌ Large `DbContext` memory footprints
* ❌ Blaming the ORM for poor performance

---

## 🔁 Real-World Mapping (EF Core)

| Concept in This Project | EF Core Equivalent |
| ----------------------- | ------------------ |
| Tracked query           | Default LINQ query |
| No-tracking query       | `AsNoTracking()`   |
| Write intent            | Command handler    |
| Read intent             | Query handler      |

> **EF Core gives you the control — you must use it intentionally.**

---

## 🧠 Interview-Ready Explanation

> **“Read queries and write queries have different intent; only write paths should be tracked, otherwise you incur unnecessary memory and performance cost.”**

This is a **strong, production-grade answer**.

---

## ✅ Completion Checklist

You fully understand this project if you can explain:

* Why not all queries should be tracked
* The real cost of tracking
* How read/write intent affects performance
* Why CQRS emerges from this naturally

If this distinction feels obvious now — the project worked.

---