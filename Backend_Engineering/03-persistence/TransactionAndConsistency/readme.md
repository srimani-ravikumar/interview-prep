# 🧱 SECTION 3 — Transactions & Consistency

> **Core theme:**
> *“When multiple operations happen, when is the system correct?”*

This is where **real systems fail**.

---

## 🧠 Mental Boundary

* ORM can start transactions
* Database can enforce atomicity
* **Application defines correctness**

---

## ✅ Project Catalog — Transactions & Consistency

### 🟢 1. Single-Operation Transactions

📦 **Project**

```
BackendMastery.Persistence.Transactions.SingleOperation
```

**Focus**

* Default transaction behavior
* Implicit unit of work
* Commit vs rollback

**Key takeaway**

> **Most systems rely on implicit transactions without realizing it.**

---

### 🟢 2. Multi-Step Use Case Consistency

📦 **Project**

```
BackendMastery.Persistence.Transactions.MultiStepUseCase
```

**Focus**

* Multiple writes
* All-or-nothing semantics
* Service-level boundaries

**Key takeaway**

> **Transaction boundaries belong to use cases, not repositories.**

---

### 🟡 3. Transaction Scope Placement

📦 **Project**

```
BackendMastery.Persistence.Transactions.BoundaryPlacement
```

**Focus**

* Controller vs service vs repository
* Why repositories should not manage transactions

**Key takeaway**

> **Wrong transaction boundaries cause invisible bugs.**

---

### 🟡 4. Idempotency (Data Perspective)

📦 **Project**

```
BackendMastery.Persistence.Transactions.Idempotency
```

**Focus**

* Duplicate requests
* Safe retries
* Idempotent writes

**Key takeaway**

> **Correctness includes handling repetition.**

---

### 🟡 5. Consistency Rules Enforcement

📦 **Project**

```
BackendMastery.Persistence.Transactions.ConsistencyRules
```

**Focus**

* Business invariants across writes
* Preventing partial updates

**Key takeaway**

> **Consistency is a business concern, not a database feature.**

---

### 🟡 6. Consistency Models — Strong vs Eventual

📦 **Project**

```
BackendMastery.Persistence.Transactions.ConsistencyModels
```

**Focus**

*  **how to choose consistency intentionally**, based on business needs.
* **Strong consistency** vs **Eventual consistency** (TradeOffs)

**Key takeaway**

> **“Strong consistency guarantees correctness, while eventual consistency trades freshness for scalability.”**


---

### 🔵 7. Transaction Anti-Patterns

📦 **Project**

```
BackendMastery.Persistence.Transactions.AntiPatterns
```

**Focus**

* Long-running transactions
* Transactions in repositories
* Nested transaction confusion

**Key takeaway**

> **Transactions are easy to misuse and hard to debug.**

---

## 📂 Section 3 Layout

```
3. Transactions & Consistency
├── SingleOperation
├── MultiStepUseCase
├── BoundaryPlacement
├── Idempotency
├── ConsistencyRules
└── AntiPatterns
```

---