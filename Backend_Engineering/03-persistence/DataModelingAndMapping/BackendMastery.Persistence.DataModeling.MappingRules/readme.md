# Mapping Rules (Object ↔ Storage)

**(Data Modeling & Mapping — Project 5)**

---

## 🎯 Purpose of This Project

This project exists to answer a **non-negotiable question** in real-world systems:

> **How do rich domain models map to flat storage structures without leaking persistence concerns?**

Once your system has:

* Separate domain models
* Entities and value objects
* Aggregates

👉 **Mapping becomes unavoidable.**

This project shows how to do mapping **explicitly, intentionally, and safely**.

---

## 🧠 Core Intuition

> **Mapping is a translation problem, not a design problem.**

* Domain models express **business meaning**
* Storage models express **persistence structure**
* Mapping absorbs the mismatch between the two

If mapping is done incorrectly:

* ORMs start shaping your domain
* Business logic leaks into persistence
* Models become rigid and hard to evolve

---

## 📂 Project Structure

```
BackendMastery.Persistence.DataModeling.MappingRules
│
├── Domain
│   ├── Order.cs              # Entity (business concept)
│   ├── OrderId.cs            # Strong identity
│   ├── Money.cs              # Value Object
│   └── Address.cs            # Value Object
│
├── Storage
│   ├── OrderRecord.cs        # Flat persistence shape
│   └── AddressRecord.cs      # Separate storage structure
│
├── Mapping
│   └── OrderMapper.cs        # Explicit translation logic
│
├── Program.cs                # Console demo (composition root)
└── README.md
```

This structure is intentional:

* **Domain** is rich and expressive
* **Storage** is flat and efficient
* **Mapping** isolates structural differences
* **Composition** happens at the edge

---

## 🟦 Domain Perspective

From the domain’s point of view:

* An `Order` has:

  * Identity
  * A `Money` value
  * An `Address` value object
* No knowledge of:

  * Tables
  * Foreign keys
  * Storage splitting

> **The domain describes what the business cares about — nothing more.**

---

## 🟥 Storage Perspective

From the storage point of view:

* Data is normalized or flattened
* Value objects may be:

  * Embedded
  * Split
  * Stored separately
* Identity is just a column

> **Storage optimizes for querying, indexing, and persistence — not meaning.**

---

## 🔁 Mapping Layer (The Translator)

The mapping layer:

* Translates domain → storage
* Translates storage → domain
* Preserves identity
* Reconstructs value objects
* Absorbs schema differences

### Key rule

> **Mapping must be explicit and visible.**

Hidden or “magic” mapping:

* Obscures intent
* Makes debugging harder
* Couples domain to ORM behavior

---

## 🧩 Why This Is a Console Application

This project uses a **console application** to:

* Remove framework noise
* Make mapping logic fully visible
* Demonstrate round-trip translation clearly
* Reinforce composition-at-the-edge principles

`Program.cs` acts as the **composition root**, just like in production APIs.

---

## 🚫 Common Mistakes This Project Prevents

* ❌ Putting ORM annotations in domain models
* ❌ Treating database schema as domain design
* ❌ Hiding mapping inside repositories
* ❌ Letting storage relationships define aggregates

These mistakes lead to:

* Rigid systems
* Painful migrations
* Business logic entangled with persistence

---

## 🎯 Real-World Motivation

In real systems:

* Domain models evolve faster than schemas
* Storage strategies change (DB, ORM, caching)
* Performance needs force denormalization

Explicit mapping allows:

* Safe evolution
* ORM replacement
* Clean separation of concerns

---

## 🧠 Interview-Ready Explanation

You should be able to say:

> “Mapping isolates domain models from storage structures. It’s a translation layer that keeps business logic independent of persistence decisions.”

This signals **strong architectural thinking**.

---

## ✅ Completion Checklist

You’ve understood this project if you can explain:

* Why mapping is unavoidable in non-trivial systems
* Why domain and storage shapes differ
* Why mapping should be explicit
* Why ORMs should never dictate domain design

If all four are clear — **this project is complete**.

---