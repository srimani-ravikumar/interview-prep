# 📘 Persistence & Data

## Section 1 — Data Modeling & Mapping

*(Tech-stack agnostic project catalog)*

> **Goal of this section:**
> Learn how to model data that **survives schema changes, ORM changes, and scale**.

This section is about **thinking**, not tools.

---

## 🧠 How to think about this section

Data modeling & mapping answers **one question only**:

> **“How do I represent business reality in a way that can be stored safely and evolve over time?”**

Everything below is derived from that.

---

# ✅ Project Catalog — Data Modeling & Mapping

I’ll list them in **learning order**, from simplest → most architecturally powerful.

---

## 🟢 1. Domain vs Storage Model (Fundamental)

### 📦 Project

```
BackendMastery.Persistence.DataModeling.DomainVsStorage
```

### Focus

* Domain model ≠ database schema
* Why they SHOULD diverge
* Why exposing tables as domain models is dangerous

### Use Case

* Order domain vs Order table
* Calculated fields vs stored fields
* Derived vs persisted data

### Key takeaway

> **The domain models business truth.
> The database models storage efficiency.**

---

## 🟢 2. Entity Identity & Lifecycle

### 📦 Project

```
BackendMastery.Persistence.DataModeling.EntityIdentity
```

### Focus

* What makes an entity an entity
* Identity vs attributes
* Lifecycle (created, modified, deleted)

### Use Case

* Order ID generation
* Natural vs surrogate keys
* When identity is created

### Key takeaway

> **Identity defines continuity, not storage.**

---

## 🟢 3. Aggregate Boundaries (Lightweight)

### 📦 Project

```
BackendMastery.Persistence.DataModeling.Aggregates
```

### Focus

* What belongs together
* What should NOT be updated independently
* Consistency boundaries

### Use Case

* Order → OrderItems
* Why updating OrderItem alone is dangerous

### Key takeaway

> **Aggregates define consistency boundaries, not tables.**

---

## 🟢 4. Value Objects vs Entities

### 📦 Project

```
BackendMastery.Persistence.DataModeling.ValueObjects
```

### Focus

* When something should NOT have identity
* Immutability
* Equality by value

### Use Case

* Money
* Address
* Price

### Key takeaway

> **If identity doesn’t matter, don’t give it one.**

---

## 🟢 5. Mapping Rules (Object ↔ Storage)

### 📦 Project

```
BackendMastery.Persistence.DataModeling.MappingRules
```

### Focus

* How object models map to storage structures
* One-to-many, many-to-one
* Embedded vs separate structures

### Use Case

* Order + Address
* Embedded address vs separate table

### Key takeaway

> **Mapping is a translation problem, not a design problem.**

---

## 🟡 6. Schema Evolution & Backward Compatibility

### 📦 Project

```
BackendMastery.Persistence.DataModeling.SchemaEvolution
```

### Focus

* Designing for change
* Adding fields safely
* Renaming vs deprecating
* Backward compatibility

### Use Case

* Adding discount to Order
* Migrating old records

### Key takeaway

> **Schemas evolve; systems that don’t plan for it break.**

---

## 🟡 7. Normalization vs Pragmatism

### 📦 Project

```
BackendMastery.Persistence.DataModeling.NormalizationTradeoffs
```

### Focus

* Normalized vs denormalized models
* Read vs write optimization
* Practical trade-offs

### Use Case

* Order summary table
* Reporting vs transactional needs

### Key takeaway

> **Perfect normalization is rarely perfect in production.**

---

## 🟡 8. Read Model vs Write Model (Intro)

### 📦 Project

```
BackendMastery.Persistence.DataModeling.ReadWriteModels
```

### Focus

* Why one model is not enough
* Write-optimized vs read-optimized shapes
* Preparing for scale

### Use Case

* Order creation vs Order listing

### Key takeaway

> **Write for correctness, read for performance.**

---

## 🔵 9. Anti-Patterns in Data Modeling

### 📦 Project

```
BackendMastery.Persistence.DataModeling.AntiPatterns
```

### Focus

* Anemic domain models
* Table-driven design
* God entities
* Over-normalization

### Use Case

* “OrderTableService” smell
* Everything as DTO

### Key takeaway

> **Most persistence bugs are modeling bugs.**

---

# 🗂️ Final Section Layout (Clean)

```
Persistence & Data
└── 1. Data Modeling & Mapping
    ├── DomainVsStorage
    ├── EntityIdentity
    ├── Aggregates
    ├── ValueObjects
    ├── MappingRules
    ├── SchemaEvolution
    ├── NormalizationTradeoffs
    ├── ReadWriteModels
    └── AntiPatterns
```

---

## 🎯 Interview Alignment (Why this matters)

If you can explain **just this section well**, you can:

* Handle ORM questions easily
* Explain schema changes confidently
* Avoid most real-world data bugs
* Sound like someone who’s *designed* systems

---

## 🧠 Meta Insight (Very Important)

> **Persistence failures usually come from bad modeling, not bad queries.**

This section fixes that root cause.

---
