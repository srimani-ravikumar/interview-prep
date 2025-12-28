# Read Model vs Write Model

**(Data Modeling & Mapping — Project 8)**

---

## 🎯 Purpose of This Project

This project exists to demonstrate a **scaling truth** in backend systems:

> **One data model cannot serve both writes and reads well at scale.**

As systems grow:

* Writes must enforce business rules
* Reads dominate traffic
* Query shapes diverge from domain shapes

This project shows **why and how** we separate **write models** from **read models**.

---

## 🧠 Core Intuition

> **Write models protect invariants.
> Read models optimize queries.**

Key ideas:

* Write paths prioritize correctness
* Read paths prioritize performance
* Models are allowed to diverge
* Consistency between them is eventual

> **Trying to use one model for both leads to slow queries or fragile logic.**

---

## 📂 Project Structure

```
BackendMastery.Persistence.DataModeling.ReadWriteModels
│
├── Domain
│   ├── Order.cs                  # Write model (aggregate)
│   ├── OrderId.cs
│   └── OrderItem.cs
│
├── Storage
│   ├── Write
│   │   ├── OrderRecord.cs        # Normalized write schema
│   │   └── OrderItemRecord.cs
│   │
│   └── Read
│       └── OrderReadModel.cs     # Read-optimized shape
│
├── Mapping
│   └── OrderProjection.cs        # Write → Read projection
│
├── Program.cs                    # Console demo (composition root)
└── README.md
```

This structure makes **read/write separation explicit**.

---

## 🟦 Write Model Perspective

The write model:

* Is a domain aggregate
* Enforces business rules
* Protects invariants
* Is used for commands (create, update)

> **Correctness always comes before performance on the write path.**

---

## 🟥 Read Model Perspective

The read model:

* Is optimized for queries
* Contains precomputed values
* Avoids joins
* Has no business logic

> **Read models exist to answer questions quickly.**

---

## 🔁 Projection (Write → Read)

Read models are:

* Derived from write models
* Updated via projections
* Allowed to be eventually consistent

> **Read models are not the source of truth.**

The write model remains authoritative.

---

## 🧩 Why This Is a Console Application

This project uses a **console app** to:

* Remove database and ORM noise
* Focus purely on modeling decisions
* Make the separation obvious
* Demonstrate projection clearly

`Program.cs` acts as the **composition root**, as in real systems.

---

## 🚫 Common Mistakes This Project Prevents

* ❌ Using aggregates for queries
* ❌ Adding query-only fields to domain models
* ❌ Expecting strong consistency on read models
* ❌ Complex joins in hot paths

These mistakes limit scalability and clarity.

---

## 🎯 Real-World Motivation

In production systems:

* Read traffic is much higher than write traffic
* Query patterns evolve faster than domain logic
* Performance requirements differ

Separating models allows:

* Independent optimization
* Clear responsibilities
* Easier scaling

---

## 🧠 Interview-Ready Explanation

You should be able to say:

> “Write models enforce business invariants, while read models are optimized for querying. Separating them improves scalability and keeps domain logic clean.”

This reflects **real-world experience**.

---

## ✅ Completion Checklist

You’ve understood this project if you can explain:

* Why one model rarely scales well
* Why write and read concerns differ
* Why eventual consistency is acceptable
* Why projections exist

If all are clear — **this project is complete**.

---