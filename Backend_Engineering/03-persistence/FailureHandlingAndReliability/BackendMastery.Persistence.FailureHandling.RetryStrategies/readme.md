# 🔁 Retry Strategies & Limits

📦 **Project**

```
BackendMastery.Persistence.FailureHandling.RetryStrategies
```

---

## 🎯 What This Project Is About

This project tackles one of the **most misunderstood ideas in backend systems**:

> **“If something fails, just retry.”**

In reality:

* Some failures are **transient**
* Some failures are **permanent**
* Some retries **fix the problem**
* Some retries **make the problem worse**

This project teaches you **when retries are safe, when they are dangerous, and when they must stop**.

---

## 🧠 Core Intuition (Lock This In)

> **Retry is a correctness decision, not a resilience hack.**

More retries do **not** mean more reliability.

> ❗ **Blind retries corrupt systems.**

---

## 🧠 Mental Boundary

This project enforces three critical truths:

* Not all failures should be retried
* Retry must be **bounded**
* Retry must be **failure-type aware**

If you retry everything forever,
**you are hiding bugs, not fixing them**.

---

## 📂 Project Structure

```
BackendMastery.Persistence.FailureHandling.RetryStrategies
│
├── Domain
│   └── Order.cs
│
├── Infrastructure
│   └── OrderStore.cs
│
├── Services
│   └── OrderService.cs
│
├── Program.cs
├── output.md
└── README.md
```

---

## 🧩 Concept Breakdown

### 1️⃣ Order Creation Is Irreversible

Orders represent **real-world commitments**:

* Money movement
* Inventory reservation
* Legal records

Duplicate orders are **catastrophic**, not just bugs.

➡️ **Retrying order creation blindly is dangerous.**

---

### 2️⃣ Failure Types Matter

This project simulates two kinds of failures:

#### 🟠 Transient Failures

* Network timeout
* Temporary DB unavailability
* Resource contention

➡️ Retry *may* succeed.

#### 🔴 Permanent Failures

* Constraint violations
* Invalid state
* Business rule errors

➡️ Retry will **never** succeed.

---

### 3️⃣ Retry Must Be Intentional

Retries are applied **only when all of the following are true**:

* Failure is transient
* Operation is safe to retry
* Retry count is limited

Anything else is **guessing**.

---

### 4️⃣ Retry Limits Are Mandatory

This project enforces a **maximum retry count**.

Why?

* Prevent infinite loops
* Avoid resource exhaustion
* Stop cascading failures
* Surface real issues early

> ❗ **Infinite retries are a system bug.**

---

## 🧪 What `Program.cs` Demonstrates

The console app simulates **four real-world retry scenarios**:

1. **Clean success (no retry needed)**
2. **Transient failures with recovery**
3. **Permanent failure (no retry)**
4. **Retry limit exceeded**

Each scenario shows:

* When retry helps
* When retry stops
* When the system fails fast intentionally

---

## 📄 Output File (`output.md`)

The `output.md` file contains **representative console output** for all scenarios.

It helps you:

* Visually understand retry behavior
* See retry limits in action
* Explain system behavior in interviews

---

## 🧠 Key Rules Enforced by This Project

✔ Retry only transient failures
✔ Never retry permanent failures
✔ Always cap retries
✔ Fail fast after retry exhaustion
✔ Correctness > availability

---

## 🚫 Common Anti-Patterns This Prevents

* ❌ Infinite retry loops
* ❌ Retrying permanent failures
* ❌ Retrying irreversible operations blindly
* ❌ Hiding failures behind retries
* ❌ Treating retry as a “fix”

---

## 🌍 Real-World Mapping

| Scenario             | Correct Strategy        |
| -------------------- | ----------------------- |
| DB timeout           | Retry (bounded)         |
| Network glitch       | Retry (bounded)         |
| Validation error     | Fail-fast               |
| Constraint violation | Fail-fast               |
| Duplicate request    | Idempotency (not retry) |

---

## 🎯 Interview-Ready Takeaway

> **“Retries should only be applied to transient failures and must always be bounded — blind retries lead to data corruption and cascading failures.”**

If a system retries everything,
**it does not understand its own failures**.

---

## ✅ Completion Criteria

You truly understand this project if you can explain:

* Why retries are dangerous
* Difference between transient and permanent failures
* Why retry limits exist
* Why fail-fast still matters even with retries

---