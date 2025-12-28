# 🧱 SECTION 2 — Persistence Mechanism (ORM)

> **Core theme:**
> *“How does the application interact with stored data safely and predictably?”*

This section is **not about learning ORM APIs**.
It is about understanding **how applications manage data that outlives memory**.

ORMs are just **tools**.
The **behavior they implement is universal**.

---

## 🧠 What This Section Is REALLY About

At a surface level, this section asks:

> **How does the application interact with stored data safely and efficiently?**

But internally, this question decomposes into **three hidden questions**
that *every ORM must answer*.

> **Most real-world persistence bugs come from misunderstanding one of these three.**

---

### 1️⃣ How long does data live in memory?

→ **Persistence Context / Session Lifecycle**

**Core intuition**

> Data does not live forever in memory.
> An ORM must define *when* an object is valid and *when it is not*.

**This explains**

* One request → one `DbContext`
* Why long-lived contexts are dangerous
* Why the same database row maps to the same object **only within a context**
* Identity map behavior

**Failure mode**

> Treating the ORM like a stateless query tool

---

### 2️⃣ How does the system know what changed?

→ **Change Tracking / Unit of Work**

**Core intuition**

> ORMs do not persist method calls —
> they persist **state transitions over time**.

**This explains**

* Dirty checking
* Why `SaveChanges()` works without explicit updates
* Why detached entities cause bugs
* Why accidental updates happen

**Failure mode**

> Assuming calling a method means persistence already happened

---

### 3️⃣ How do reads and writes behave differently?

→ **Query Behavior vs State Mutation**

**Core intuition**

> Reads optimize for speed and shape.
> Writes optimize for correctness and identity.

**This explains**

* Tracking vs no-tracking queries
* Why read-only queries shouldn’t be tracked
* Why CQRS naturally emerges
* Why performance issues often come from write-style reads

**Failure mode**

> Treating all queries as equal

---

## 🧠 The Unifying Insight

> **An ORM is a state synchronization engine between memory and storage.**

It is **not**:

* A query helper
* A CRUD generator
* A database wrapper that removes thinking

If you treat an ORM as a **state machine**, everything makes sense.
If you treat it as a **database shortcut**, you will fight it.

---

## 🧠 Mental Boundary (Important)

This section deliberately assumes:

* ✅ Happy path only
* ✅ No failures
* ✅ No retries
* ✅ No distributed concerns

Because:

* Modeling answers **what data is**
* Persistence mechanism answers **how data is accessed**
* Failures and consistency belong to **later sections**

> ❗ Mixing failure handling into ORM understanding creates bad abstractions.

---

## ✅ Project Catalog — Persistence Mechanism (ORM)

Each project isolates **one persistence rule**
and forces you to reason about it explicitly.

---

### 🟢 1. Persistence Context Lifecycle

📦 **Project**

```
BackendMastery.Persistence.ORM.ContextLifecycle
```

**Core Intuition**

> A persistence context defines an **identity boundary**.

**Focus**

* Persistence context / session
* One request → one context
* Identity map behavior

**Key Takeaway**

> **The ORM context is a unit of work, not a query tool.**

---

### 🟢 2. Change Tracking & State Transitions

📦 **Project**

```
BackendMastery.Persistence.ORM.ChangeTracking
```

**Core Intuition**

> ORMs track **state transitions**, not method calls.

**Focus**

* New vs modified vs deleted
* Explicit vs implicit updates
* Dirty checking

**Key Takeaway**

> **ORMs persist intent, not method calls.**

---

### 🟢 3. Read vs Write Queries

📦 **Project**

```
BackendMastery.Persistence.ORM.ReadWriteBehavior
```

**Core Intuition**

> Reads and writes have fundamentally different costs.

**Focus**

* Read-only queries
* Write tracking overhead
* Query intent clarity

**Key Takeaway**

> **Not all queries should be tracked.**

---

### 🟡 4. Repository Implementations (Correct Usage)

📦 **Project**

```
BackendMastery.Persistence.ORM.RepositoryImplementation
```

**Core Intuition**

> Repositories protect the domain from persistence mechanics.

**Focus**

* Repository as persistence adapter
* Avoiding `IQueryable` leakage
* Returning domain objects safely

**Key Takeaway**

> **Repositories abstract storage behavior, not collections.**

---

### 🟡 5. Lazy vs Eager Loading (Trade-offs)

📦 **Project**

```
BackendMastery.Persistence.ORM.LoadingStrategies
```

**Core Intuition**

> Implicit data access breaks predictability.

**Focus**

* Lazy loading risks
* N+1 problem
* Explicit loading

**Key Takeaway**

> **Implicit data access is a production bug waiting to happen.**

---

### 🟡 6. Query Shaping & Performance

📦 **Project**

```
BackendMastery.Persistence.ORM.QueryShaping
```

**Core Intuition**

> Data shape matters more than query count.

**Focus**

* Selecting only required data
* Projection vs entity loading
* Read-model shaping

**Key Takeaway**

> **ORM performance problems are usually modeling problems.**

---

### 🔵 7. ORM Anti-Patterns

📦 **Project**

```
BackendMastery.Persistence.ORM.AntiPatterns
```

**Core Intuition**

> ORM misuse leaks infrastructure into business logic.

**Focus**

* ORM usage inside controllers
* Fat repositories
* Domain polluted with persistence concerns

**Key Takeaway**

> **Persistence concerns must never define domain behavior.**

---

## 📂 Section Layout

```
2. Persistence Mechanism (ORM)
├── ContextLifecycle
├── ChangeTracking
├── ReadWriteBehavior
├── RepositoryImplementation
├── LoadingStrategies
├── QueryShaping
└── AntiPatterns
```

---

## 🧠 Final Lock-In Thought

> **Most ORM bugs come from misunderstanding context lifetime,
> change tracking, or read/write intent — not from the ORM itself.**

This section exists to **burn those three ideas into muscle memory**.

---