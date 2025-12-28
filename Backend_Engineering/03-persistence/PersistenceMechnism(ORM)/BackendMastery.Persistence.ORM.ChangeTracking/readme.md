# 🟢 Change Tracking & State Transitions

`BackendMastery.Persistence.ORM.ChangeTracking`

---

## 🎯 What This Project Is About

This project answers the **second hidden persistence question**:

> **How does the ORM know what actually changed?**

Most developers assume:

> “Because I called `Update()` or `SaveChanges()`.”

That assumption is **wrong** — and dangerous.

---

## 🧠 Core Intuition (Read This First)

> **ORMs do not persist method calls.
> ORMs persist state transitions over time.**

When an entity is loaded:

* The ORM takes a **snapshot**
* The entity lives and mutates in memory
* At commit time, the ORM compares:

  * **Before state**
  * **After state**

Only the **difference** is persisted.

---

## 🧠 The Hidden Question This Project Solves

Every ORM must answer:

> **“What changed since I last saw this entity?”**

Not:

* “What method was called?”
* “What property setter ran?”

But:

* **“What is different now?”**

---

## ❗ Key Rule (Non-Negotiable)

> ❗ **Persistence happens at commit, not at mutation.**

* Mutating an object:

  * ❌ does not persist data
  * ✅ only records *intent*
* Calling `SaveChanges()`:

  * ✅ reconciles state
  * ✅ generates persistence commands

---

## 📦 Project Goal

This project demonstrates:

* How ORMs snapshot entity state
* How change tracking works conceptually
* Why updates feel “automatic”
* Why detached entities break persistence

We intentionally **simulate** ORM behavior
to make the mechanism **explicit and visible**.

---

## 📂 Project Structure

```
BackendMastery.Persistence.ORM.ChangeTracking
│
├── Domain
│   └── Product.cs
│
├── Infrastructure
│   ├── EntityState.cs
│   └── FakeDbContext.cs
│
├── Program.cs
└── README.md
```

---

## 🧪 What the Demo Shows

### Scenario — Modify Then Commit

1. Load an entity into the context
2. Modify it freely in memory
3. Call `SaveChanges()`
4. ORM detects:

   * What changed
   * What didn’t
5. Only modified data is persisted

No explicit `Update()` calls are required.

---

## 🧠 Why This Matters in Real Systems

This concept explains:

* Why `SaveChanges()` feels “magical”
* Why accidental updates happen
* Why detached entities don’t persist changes
* Why ORMs need a persistence context
* Why calling `Update()` blindly is harmful

If you misunderstand this, you will:

* Fight the ORM
* Introduce subtle bugs
* Corrupt data unintentionally

---

## 🚫 Common Mistakes This Project Prevents

* ❌ Calling `Update()` for every change
* ❌ Assuming mutation = persistence
* ❌ Modifying entities outside a context
* ❌ Forcing entity states manually
* ❌ Blaming the ORM for “unexpected updates”

---

## 🔁 Real-World Mapping (EF Core)

| Concept in This Project | EF Core Equivalent    |
| ----------------------- | --------------------- |
| Snapshot copy           | `OriginalValues`      |
| Tracked entity          | `ChangeTracker` entry |
| State detection         | Dirty checking        |
| Commit                  | `SaveChanges()`       |

> **EF Core does exactly this — you just don’t see it.**

---

## 🧠 Interview-Ready Explanation

> **“ORMs track entity state over time and persist differences at commit; they don’t rely on explicit update calls.”**

This is a **correct, senior-level explanation**.

---

## ✅ Completion Checklist

You fully understand this project if you can explain:

* How ORMs detect what changed
* Why mutation alone doesn’t persist data
* Why `SaveChanges()` is the real persistence point
* Why detached entities cause bugs

If any of these are unclear, revisit the demo.

---