# Persistence & Data

**(ORM-Agnostic, Architecture-First)**

---

## 🎯 Why this section exists

Persistence is one of the **most misunderstood areas** in backend engineering.

Many developers think:

* “EF Core”
* “Hibernate”
* “Prisma”

But those are **tools**.

What actually matters is understanding the **problems of data** that every backend system must solve — *regardless of language or ORM*.

This section exists to answer:

> **“How should I think about data, correctness, and failure in backend systems?”**

---

## 🧠 Core Mental Model

> **Persistence is not one topic.
> It is a set of independent concerns that interact.**

To reason clearly, we must **separate these concerns**.

---

## 🧱 The Four Pillars of Persistence & Data

Every backend system — monolith or distributed — deals with **four orthogonal concerns**:

```
1. Data Modeling & Mapping
2. Persistence Mechanism (ORM)
3. Transactions & Consistency
4. Failure Handling & Reliability
```

Each pillar answers a **different question**.

---

## 🧱 1. Data Modeling & Mapping

**(What does the data represent?)**

### Core Question

> **How do business concepts map to stored data?**

This is about **modeling reality**, not about databases or APIs.

### What this includes

* Domain model vs storage model
* Entity vs table / document
* Aggregate boundaries (lightweight)
* Value objects (lightweight)
* Mapping rules
* Schema evolution mindset
* Code-first vs schema-first thinking

### Key insight

> **Schemas change slower than business ideas.
> Models must be designed with evolution in mind.**

ORMs *map* models — they don’t design them for you.

---

## 🧱 2. Persistence Mechanism (ORM)

**(How is data stored and retrieved?)**

### Core Question

> **How does the application interact with stored data safely and efficiently?**

This is where ORMs live — but **ORM ≠ persistence**.

### What this includes

* Persistence context / session lifecycle
* Change tracking
* Identity map
* Query behavior
* Lazy vs eager loading
* Read vs write paths
* Repository implementations

### ORM-agnostic truth

Different tools, same ideas:

| Concept             | Common Names                 |
| ------------------- | ---------------------------- |
| Persistence context | DbContext / Session / Client |
| Change tracking     | Unit of Work                 |
| Query translation   | LINQ / JPQL / Query Builder  |

> **Learning the concepts makes the tool swappable.**

---

## 🧱 3. Transactions & Consistency

**(When is data considered correct?)**

This is a **separate mental model** and the source of many real-world bugs.

### Core Question

> **When multiple operations occur, what does correctness mean?**

### What this includes

* Atomicity
* Transaction boundaries
* Implicit vs explicit unit of work
* Consistency rules
* Rollbacks
* Idempotency (data perspective)
* Read-your-writes guarantees

### Key insight

> **Transactions are not about databases.
> They are about correctness guarantees.**

ORMs *expose* transactions — they don’t define correctness.

---

## 🧱 4. Failure Handling & Reliability

**(What happens when things go wrong?)**

This is about **data safety**, not just exceptions.

### Core Question

> **How does the system behave when persistence partially fails?**

### What this includes

* Partial failures
* Retry vs rollback
* Fail-fast vs fail-safe (data perspective)
* Compensating actions
* Poison data
* Eventual consistency (light intuition)
* Consistency vs availability trade-offs

### Key insight

> **Not all failures should be retried.
> Not all failures can be rolled back.**

This is where *engineering judgment* matters.

---

## 🗂️ How This Section Is Structured

```
Persistence & Data
│
├── 1. Data Modeling & Mapping
│   ├── Domain vs Storage Models
│   ├── Mapping Rules
│   └── Schema Evolution
│
├── 2. Persistence Mechanism (ORM)
│   ├── ORM Lifecycle & Context
│   ├── Repositories
│   └── Query Behavior
│
├── 3. Transactions & Consistency
│   ├── Transaction Boundaries
│   ├── Consistency Rules
│   └── Rollbacks & Idempotency
│
└── 4. Failure Handling & Reliability
    ├── Partial Failures
    ├── Retry Strategies
    └── Compensating Actions
```

Each subsection can have:

* A focused README
* One or more small projects
* Interview-oriented notes

---

## 🎯 Interview Perspective

When an interviewer asks:

> “Tell me about ORM / EF Core / persistence”

They are **not** testing APIs.

They are probing:

* Can you reason about data correctness?
* Do you understand transaction boundaries?
* Can you handle failure scenarios?
* Do you design for evolution?

This structure lets you answer **cleanly and confidently**.

---

## ✅ Completion Check

You are **done with Persistence & Data** when:

* You can swap ORMs without mental rework
* You reason about correctness, not just CRUD
* You know where failures must be handled
* You design for evolution, not perfection

Tools will change.
**These mental models will not.**

---

## 🧠 Final One-Liner (For Yourself)

> **“Persistence is about modeling reality, ensuring correctness, and surviving failure — ORMs are just tools.”**

---