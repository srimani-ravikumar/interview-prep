# Aggregate Boundaries

**(Data Modeling & Mapping — Project 3)**

---

## 🎯 Purpose of This Project

This project demonstrates **how to model consistency boundaries explicitly** using **aggregates**.

It answers one critical question:

> **What should change together, and what must never change independently?**

Aggregates exist to **protect business invariants** and ensure correctness under change.

---

## 🧠 Core Intuition

> **An aggregate defines a consistency boundary.**

* Inside the boundary → changes must be atomic
* Outside the boundary → changes are eventual
* The aggregate root is the **only gatekeeper**

Aggregates are **not about tables or ORM relationships**.
They are about **correctness**.

---

## 📂 Project Structure

```
BackendMastery.Persistence.DataModeling.Aggregates
│
├── Domain
│   ├── Order.cs              # Aggregate Root
│   ├── OrderItem.cs          # Internal entity (child)
│   └── OrderId.cs            # Strong identity
│
├── Storage
│   ├── OrderRecord.cs        # Order persistence shape
│   └── OrderItemRecord.cs    # Item persistence shape
│
├── Mapping
│   └── OrderMapper.cs        # Aggregate ↔ storage mapping
│
├── Program.cs                # Console demo (composition root)
└── README.md
```

This structure is **intentional**:

* Domain is pure
* Storage is flat
* Mapping absorbs mismatch
* Composition happens at the edge

---

## 🟦 Domain: Aggregate Root as Gatekeeper

The `Order` aggregate root:

* Owns internal entities
* Controls all mutation
* Enforces consistency rules
* Exposes read-only views externally

Child entities (`OrderItem`) **cannot be created or mutated directly**.

> **If you can modify a child without the root, your aggregate is broken.**

---

## 🟥 Storage: Flattened Reality

The storage layer:

* Has no concept of aggregates
* Stores flat records
* Knows nothing about invariants

This is correct.

> **Persistence should never enforce business rules.**

---

## 🔁 Mapping: Reconstructing the Aggregate

Mapping:

* Rehydrates the aggregate as a whole
* Prevents partial loading
* Preserves invariants

> **Aggregates must be saved and loaded as units.**

Partial persistence leads to **silent corruption**.

---

## 🧩 Why This Is a Console Application

This project uses a **console app** to:

* Remove framework distractions
* Make aggregate boundaries obvious
* Show mutation and mapping explicitly

`Program.cs` acts as the **composition root**, wiring domain, mapping, and storage — the same principle used in real APIs.

---

## 🚫 Common Anti-Patterns This Project Prevents

* ❌ Updating child entities independently
* ❌ Exposing mutable collections
* ❌ Treating aggregates as table groups
* ❌ Persisting partial aggregates

These issues cause:

* Broken invariants
* Hard-to-debug production bugs
* Data inconsistencies

---

## 🎯 Real-World Motivation

In real systems:

* Orders must match their items
* Totals must be accurate
* Partial updates are unacceptable

Aggregates ensure:

* Consistency
* Atomic updates
* Clear transaction boundaries

---

## 🧠 Interview-Ready Explanation

You should be able to say:

> “Aggregates define consistency boundaries. The aggregate root is the only entry point for mutation, ensuring business invariants are preserved atomically.”

This signals **architectural maturity**.

---

## ✅ Completion Checklist

You’ve understood this project if you can explain:

* Why aggregates exist
* Why child entities aren’t directly mutable
* Why aggregates align with transaction boundaries
* Why aggregates are not database tables

If all are clear — **this project is complete**.

---