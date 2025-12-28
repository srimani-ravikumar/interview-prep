# Normalization vs Pragmatism

**(Data Modeling & Mapping — Project 7)**

---

## 🎯 Purpose of This Project

This project exists to clarify a **real-world truth** about data modeling:

> **Perfect normalization is not the same as a healthy production system.**

While normalization improves correctness, real systems also need:

* Fast reads
* Simple queries
* Scalable reporting

This project demonstrates **when and why denormalization is an intentional design choice**.

---

## 🧠 Core Intuition

> **Normalization optimizes correctness.
> Pragmatism optimizes system behavior.**

Key ideas:

* Normalized models are ideal for writes
* Denormalized models are ideal for reads
* Both can safely coexist

> **The danger is accidental denormalization — not intentional duplication.**

---

## 📂 Project Structure

```
BackendMastery.Persistence.DataModeling.NormalizationTradeoffs
│
├── Domain
│   ├── Order.cs              # Core domain entity
│   ├── OrderId.cs            # Entity identity
│   └── OrderItem.cs          # Internal entity
│
├── Storage
│   ├── Normalized
│   │   ├── OrderRecord.cs    # Write-optimized schema
│   │   └── OrderItemRecord.cs
│   │
│   └── Denormalized
│       └── OrderSummaryRecord.cs  # Read-optimized schema
│
├── Mapping
│   └── OrderMapper.cs        # Controlled duplication logic
│
├── Program.cs                # Console demo (composition root)
└── README.md
```

This layout makes **trade-offs explicit**, not accidental.

---

## 🟦 Domain Perspective

The domain model:

* Remains normalized
* Owns business rules
* Computes derived values (e.g., total amount)

> **The domain should never be denormalized for performance reasons.**

---

## 🟥 Storage Perspective

Two different storage shapes exist:

### Normalized storage

* Optimized for correctness
* Supports transactional integrity
* Suitable for writes

### Denormalized storage

* Optimized for fast reads
* Avoids joins
* Contains derived data intentionally

> **Duplication here is deliberate and controlled.**

---

## 🔁 Mapping Strategy

Mapping:

* Creates normalized records for transactional persistence
* Creates denormalized records for query performance
* Ensures both representations stay consistent

> **Mapping is where duplication is justified and managed.**

---

## 🧩 Why This Is a Console Application

This project uses a console application to:

* Remove database complexity
* Focus on modeling trade-offs
* Make denormalization explicit
* Demonstrate both storage shapes clearly

`Program.cs` acts as the **composition root**, mirroring real systems.

---

## 🚫 Common Mistakes This Project Prevents

* ❌ Denormalizing the domain model
* ❌ Writing through denormalized tables
* ❌ Letting reports hit transactional schemas
* ❌ Treating denormalization as a shortcut

These mistakes lead to:

* Data inconsistency
* Hard-to-fix bugs
* Scaling issues

---

## 🎯 Real-World Motivation

In production systems:

* Reporting needs grow
* Query performance matters
* Read paths dominate traffic

Intentional denormalization allows:

* Faster reads
* Simpler queries
* Predictable performance

Without sacrificing correctness.

---

## 🧠 Interview-Ready Explanation

You should be able to say:

> “Normalization ensures correctness, while denormalization improves read performance. Mature systems use both intentionally, with clear boundaries.”

This reflects **production-level experience**.

---

## ✅ Completion Checklist

You’ve understood this project if you can explain:

* Why normalization alone is insufficient
* Why denormalization must be controlled
* Why the domain stays normalized
* How read and write models differ

If all are clear — **this project is complete**.

---