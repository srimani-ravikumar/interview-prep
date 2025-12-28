# Value Objects vs Entities

**(Data Modeling & Mapping — Project 4)**

---

## 🎯 Purpose of This Project

This project exists to clarify a **fundamental modeling decision** in backend systems:

> **When should something have identity — and when should it not?**

Most real-world systems become complex because:

* Identity is overused
* Everything becomes an entity
* Equality becomes ambiguous
* Persistence becomes harder than necessary

This project demonstrates **how value objects simplify models** when identity is not required.

---

## 🧠 Core Intuition

> **If identity does not matter, don’t give it one.**

* **Entities** are defined by identity and continuity
* **Value Objects** are defined by their values
* Entities change over time
* Value Objects are **immutable and replaceable**

Value Objects describe **characteristics**, not **things**.

---

## 📂 Project Structure

```
BackendMastery.Persistence.DataModeling.ValueObjects
│
├── Domain
│   ├── Order.cs              # Entity
│   ├── OrderId.cs            # Strong identity
│   ├── Money.cs              # Value Object
│   └── Address.cs            # Value Object
│
├── Storage
│   └── OrderRecord.cs        # Flattened persistence shape
│
├── Mapping
│   └── OrderMapper.cs        # Domain ↔ Storage mapping
│
├── Program.cs                # Console demo (composition root)
└── README.md
```

This structure is intentional:

* Domain models intent
* Storage models shape
* Mapping absorbs mismatch
* Composition happens at the edge

---

## 🟦 Value Objects

Value Objects:

* Have **no identity**
* Are **immutable**
* Are equal **by value**
* Are replaced as a whole

### Examples in this project

* `Money`
* `Address`

> **Two value objects with the same values are the same thing.**

---

## 🟦 Entities

Entities:

* Have **identity**
* Maintain continuity over time
* Can change attributes
* Own value objects

### Example in this project

* `Order`

> **Two entities with the same values are NOT the same thing unless their identities match.**

---

## 🟥 Persistence Perspective

From the storage point of view:

* Value Objects are flattened
* Identity is just a column
* No equality or immutability exists

This is correct.

> **Persistence stores data; it does not model meaning.**

---

## 🔁 Mapping Strategy

Mapping:

* Translates between domain and storage
* Preserves identity
* Reconstructs value objects

Mapping ensures:

* Domain remains persistence-agnostic
* Storage remains business-agnostic

---

## 🧩 Why This Is a Console Application

This project uses a console application to:

* Remove framework noise
* Make equality and immutability visible
* Demonstrate replacement vs mutation
* Show mapping explicitly

`Program.cs` is the **composition root**, wiring everything together.

---

## 🚫 Common Mistakes This Project Prevents

* ❌ Giving IDs to Money or Address
* ❌ Mutating value object fields
* ❌ Comparing value objects by reference
* ❌ Treating value objects like entities

These mistakes lead to:

* Bloated schemas
* Confusing logic
* Bug-prone systems

---

## 🎯 Real-World Motivation

Value Objects:

* Simplify persistence
* Improve correctness
* Reduce schema complexity
* Make equality obvious

They are especially useful for:

* Money
* Addresses
* Coordinates
* Date ranges
* Measurements

---

## 🧠 Interview-Ready Explanation

You should be able to say:

> “Value objects are immutable, identity-less objects defined entirely by their values. If identity doesn’t matter, it shouldn’t exist.”

This reflects **strong modeling discipline**.

---

## ✅ Completion Checklist

You’ve understood this project if you can explain:

* Why value objects have no identity
* Why immutability matters
* Why replacement is safer than mutation
* How value objects simplify persistence

If all are clear — **this project is complete**.

---