# 🧱 SECTION 2 — Persistence Mechanism (ORM)

> **Core theme:**
> *“How does the application interact with stored data safely and predictably?”*

This section is about **using an ORM correctly**, not memorizing APIs.

---

## 🧠 Mental Boundary

* Modeling answers **what data is**
* Persistence mechanism answers **how data is accessed**
* Still assuming **happy path** (no failures yet)

---

## ✅ Project Catalog — Persistence Mechanism

### 🟢 1. Persistence Context Lifecycle

📦 **Project**

```
BackendMastery.Persistence.ORM.ContextLifecycle
```

**Focus**

* Persistence context / session
* One request → one context
* Identity map behavior

**Key takeaway**

> **The ORM context is a unit of work, not a query tool.**

---

### 🟢 2. Change Tracking & State Transitions

📦 **Project**

```
BackendMastery.Persistence.ORM.ChangeTracking
```

**Focus**

* New vs modified vs deleted
* Explicit vs implicit updates
* Dirty checking

**Key takeaway**

> **ORMs persist intent, not method calls.**

---

### 🟢 3. Read vs Write Queries

📦 **Project**

```
BackendMastery.Persistence.ORM.ReadWriteBehavior
```

**Focus**

* Read-only queries
* Write tracking cost
* Query intent clarity

**Key takeaway**

> **Not all queries should be tracked.**

---

### 🟡 4. Repository Implementations (Correct Usage)

📦 **Project**

```
BackendMastery.Persistence.ORM.RepositoryImplementation
```

**Focus**

* Repository as persistence adapter
* Avoiding IQueryable leakage
* Returning domain objects safely

**Key takeaway**

> **Repositories abstract storage behavior, not collections.**

---

### 🟡 5. Lazy vs Eager Loading (Trade-offs)

📦 **Project**

```
BackendMastery.Persistence.ORM.LoadingStrategies
```

**Focus**

* Lazy loading risks
* N+1 problem
* Explicit loading

**Key takeaway**

> **Implicit data access is a production bug waiting to happen.**

---

### 🟡 6. Query Shaping & Performance

📦 **Project**

```
BackendMastery.Persistence.ORM.QueryShaping
```

**Focus**

* Selecting only required data
* Projection vs entity loading
* Read-model shaping

**Key takeaway**

> **ORM performance problems are usually modeling problems.**

---

### 🔵 7. ORM Anti-Patterns

📦 **Project**

```
BackendMastery.Persistence.ORM.AntiPatterns
```

**Focus**

* ORM in controllers
* Fat repositories
* Domain polluted with persistence concerns

**Key takeaway**

> **ORM misuse leaks infrastructure into business logic.**

---

## 📂 Section 2 Layout

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