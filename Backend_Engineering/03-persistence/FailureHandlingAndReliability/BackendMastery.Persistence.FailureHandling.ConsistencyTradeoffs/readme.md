# ⚖️ Consistency vs Availability (Light CAP)

📦 **Project**

```
BackendMastery.Persistence.FailureHandling.ConsistencyTradeoffs
```

---

## 🎯 What This Project Is About

This project explores a **non-negotiable reality** of distributed systems:

> **When failures occur, you must choose between consistency and availability.**

There is **no perfect choice** — only **intentional trade-offs**.

This project is **not about memorizing CAP theorem**.
It is about understanding **how real systems behave when something breaks**.

---

## 🧠 Core Intuition (Lock This In)

> **Consistency and availability are not enemies — until failure happens.**

* No failure → you can have both
* Failure → you must choose

> ❗ **Choosing implicitly is a bug. Choosing explicitly is design.**

---

## 🧠 Mental Boundary

This project enforces three key ideas:

* CAP trade-offs only matter **during failures**
* Blocking is a valid design choice
* Returning stale data is also a valid design choice

The mistake is **not choosing**.

---

## 📂 Project Structure

```
BackendMastery.Persistence.FailureHandling.ConsistencyTradeoffs
│
├── Domain
│   └── Account.cs
│
├── Infrastructure
│   └── AccountStore.cs
│
├── Services
│   └── AccountService.cs
│
├── Program.cs
├── output.md
└── README.md
```

---

## 🧩 Concept Breakdown

### 1️⃣ Strong Invariants Demand Consistency

Some data **cannot be wrong**:

* Account balances
* Wallet amounts
* Financial ledgers

Returning incorrect data here causes:

* Financial loss
* Legal issues
* Broken trust

➡️ **Blocking is safer than lying.**

---

### 2️⃣ Availability Has a Cost

High availability means:

* System responds even during failures
* Data might be stale or incomplete

This is acceptable for:

* Dashboards
* Analytics
* Read-only views
* Non-critical data

> ❗ Availability always comes at a consistency cost during failures.

---

### 3️⃣ Partition Is the Real Enemy

This project simulates **network partitions**, not crashes.

During partitions:

* Some nodes cannot communicate
* Data correctness cannot be guaranteed
* The system must choose behavior

CAP is really about **partition tolerance decisions**.

---

### 4️⃣ Explicit Modes Are a Design Win

The service exposes **two explicit behaviors**:

* **Strong consistency** → may block
* **High availability** → may return stale data

This makes trade-offs:

* Visible
* Intentional
* Explainable

---

## 🧪 What `Program.cs` Demonstrates

The console app shows **three real-world scenarios**:

1. **Strong consistency read succeeds**
2. **High availability read always responds**
3. **Strong consistency blocks under partition**

You can clearly see:

* When the system refuses to answer
* When it answers with weaker guarantees
* Why both behaviors are valid

---

## 📄 Output File (`output.md`)

The `output.md` file contains **representative console output** showing:

* Blocking behavior
* Stale data warnings
* Partition impact on reads

This makes the CAP trade-off **concrete and interview-ready**.

---

## 🧠 Key Rules Enforced by This Project

✔ CAP trade-offs appear only during failures
✔ Blocking is sometimes the correct choice
✔ Stale data must be explicitly acknowledged
✔ Trade-offs must be visible in APIs
✔ No system gets consistency + availability during partitions

---

## 🚫 Common Anti-Patterns This Prevents

* ❌ Pretending CAP doesn’t exist
* ❌ Hiding stale reads
* ❌ Blocking without explanation
* ❌ Mixing consistency guarantees implicitly
* ❌ Claiming “we are fully consistent and always available”

---

## 🌍 Real-World Mapping

| System              | Typical Choice |
| ------------------- | -------------- |
| Banking balance     | Consistency    |
| Payment processing  | Consistency    |
| Product catalog     | Availability   |
| Analytics dashboard | Availability   |
| Notifications       | Availability   |

---

## 🎯 Interview-Ready Takeaway

> **“During failures, systems must explicitly choose between consistency and availability — pretending you can have both is a design flaw.”**

If a system doesn’t expose this choice,
**it is making it silently — and dangerously.**

---

## ✅ Completion Criteria

You fully understand this project if you can explain:

* Why CAP trade-offs exist
* Why they matter only during failures
* When blocking is correct
* When stale data is acceptable
* Why explicit choices matter

---