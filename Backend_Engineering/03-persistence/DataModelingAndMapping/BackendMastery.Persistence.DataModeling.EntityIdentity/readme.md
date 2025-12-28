# Entity Identity & Lifecycle

**(Data Modeling & Mapping — Project 2)**

---

## 🎯 Purpose of This Project

This project exists to clarify **one of the most misunderstood concepts in backend systems**:

> **What makes something an entity, and when does its identity begin?**

Many systems fail because identity is:

* Treated as a database concern
* Generated too late
* Confused with attributes
* Loosely represented using primitives

This project fixes that by making **identity explicit, intentional, and immutable**.

---

## 🧠 Core Intuition

> **An entity is defined by continuity, not by its data.**

* Attributes change
* Identity must not
* Identity gives meaning across time
* Persistence does not create identity

If something can change *what it is*, it is not an entity.

---

## 🟦 Domain Identity (First-Class Concept)

In this project, identity is modeled explicitly using a **strongly-typed identifier**.

### Why this matters

* Prevents accidental misuse of IDs
* Makes intent obvious in code
* Decouples identity from storage mechanisms
* Improves readability and safety

> **Identity should be impossible to ignore.**

---

## 🟦 Entity Lifecycle

Entities have a **lifecycle**:

```
Created → Modified → Rehydrated → Archived (eventually)
```

Key principles:

* Identity is created at construction
* Identity never changes
* Attributes may evolve over time
* Business operations mutate state, not identity

This project demonstrates:

* Safe mutation
* Identity continuity across changes
* Rehydration from storage

---

## 🟥 Storage Perspective on Identity

From a storage point of view:

* Identity is just a column
* No lifecycle semantics exist
* No business meaning is attached

This is intentional.

> **Storage does not understand identity — the domain does.**

---

## 🔁 Mapping Identity Correctly

Mapping must:

* Preserve identity exactly
* Never generate identity
* Never mutate identity

Mapping is responsible for:

* Translating representation
* Preserving continuity

> **Identity generation belongs in the domain, not in mapping or storage.**

---

## 🧩 Why This Project Uses a Console App

This project is implemented as a **console application** to:

* Avoid ORM magic
* Make identity flow visible
* Demonstrate lifecycle clearly
* Keep focus on modeling, not frameworks

`Program.cs` acts as the **composition root**, wiring:

* Domain
* Storage
* Mapping

Exactly as in production systems.

---

## 🚫 Common Mistakes This Project Prevents

* ❌ Treating database-generated IDs as identity
* ❌ Passing raw GUIDs everywhere
* ❌ Replacing entities instead of mutating them
* ❌ Letting persistence decide lifecycle

These mistakes lead to:

* Broken invariants
* Data corruption
* Difficult debugging

---

## 🎯 Real-World Motivation

Consider scenarios like:

* Retrying failed operations
* Rehydrating entities from caches
* Synchronizing across systems

Without stable identity:

* State becomes unreliable
* Duplicates appear
* Business logic breaks

This project establishes the foundation needed to handle these scenarios correctly.

---

## 🧠 Interview-Ready Explanation

You should be able to say:

> “Entities are defined by identity and continuity, not by attributes. Identity must exist independently of persistence and remain immutable throughout the entity’s lifecycle.”

This signals **deep modeling maturity**.

---

## ✅ Completion Checklist

You’ve understood this project if you can explain:

* Why identity is not a database concern
* Why strong identity types are safer than primitives
* Why identity must never change
* Why lifecycle matters beyond CRUD

If all four are clear — **this project is complete**.

---