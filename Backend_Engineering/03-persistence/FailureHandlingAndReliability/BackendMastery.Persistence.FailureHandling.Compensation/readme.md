# 🔄 Partial Failures & Compensation

📦 **Project**

```
BackendMastery.Persistence.FailureHandling.Compensation
```

---

## 🎯 What This Project Is About

This project addresses a **hard truth in real systems**:

> **Not all operations can be rolled back.**

In distributed systems:

* Money may already be charged
* Inventory may already be reserved
* External APIs may already be called
* Emails may already be sent

At that point, **transactions are over**.

This project teaches how to **recover correctness when atomic rollback is impossible**.

---

## 🧠 Core Intuition (Lock This In)

> **When rollback is impossible, you must compensate — not retry.**

Retrying after partial success often causes:

* Double charges
* Duplicate reservations
* Broken business invariants

> ❗ **Compensation is an explicit undo, not a retry.**

---

## 🧠 Mental Boundary

This project enforces three critical ideas:

* Distributed transactions do not exist
* Partial failures are normal, not edge cases
* Correctness must be restored explicitly

If your system assumes *“all or nothing”* across services,
**it is already broken**.

---

## 📂 Project Structure

```
BackendMastery.Persistence.FailureHandling.Compensation
│
├── Domain
│   └── Order.cs
│
├── Infrastructure
│   ├── PaymentGateway.cs
│   ├── InventorySystem.cs
│   └── CompensationLog.cs
│
├── Services
│   └── OrderPlacementService.cs
│
├── Program.cs
├── output.md
└── README.md
```

---

## 🧩 Concept Breakdown

### 1️⃣ Orders Span Multiple Systems

Order placement touches:

* Payment gateway
* Inventory system
* Internal order records

No single database transaction can cover all of them.

➡️ **Partial failure is inevitable.**

---

### 2️⃣ External Side Effects Are Irreversible

Once money is charged or an external API is called:

* You cannot “rollback”
* You can only **counteract** the effect

This is the fundamental reason **compensation exists**.

---

### 3️⃣ Compensation Is Explicit Undo

Compensation means:

* Issuing a refund
* Releasing inventory
* Recording what was undone

It is **not automatic** and **not implicit**.

> ❗ Compensation must be deliberate, traceable, and auditable.

---

### 4️⃣ Retry Is the Wrong Tool Here

Retrying the whole operation after partial success causes:

* Double payment
* Duplicate reservations
* Escalating failures

➡️ **Retry solves transient failure, not partial success.**

---

## 🧪 What `Program.cs` Demonstrates

The console app simulates **real-world partial failure scenarios**:

1. **Clean success**
2. **Failure after payment**
3. **Repeated partial failures**

Each scenario shows:

* Where failure occurs
* Why rollback is impossible
* How compensation restores correctness

---

## 📄 Output File (`output.md`)

The `output.md` file contains **representative console output** for all scenarios.

It helps you:

* Visualize compensation paths
* Explain failure handling clearly in interviews
* See why retries are dangerous here

---

## 🧠 Key Rules Enforced by This Project

✔ Assume partial failure will happen
✔ Never rely on distributed rollback
✔ Compensate explicitly
✔ Log compensation actions
✔ Correctness > simplicity

---

## 🚫 Common Anti-Patterns This Prevents

* ❌ Retrying the whole workflow
* ❌ Assuming external systems roll back
* ❌ Ignoring partial success
* ❌ Silent compensation
* ❌ Treating compensation as optional

---

## 🌍 Real-World Mapping

| Scenario                          | Correct Strategy    |
| --------------------------------- | ------------------- |
| Payment succeeds, inventory fails | Compensate (refund) |
| External API succeeds, DB fails   | Compensate          |
| Multi-service workflow            | Saga / compensation |
| Distributed transaction           | ❌ Avoid             |

---

## 🎯 Interview-Ready Takeaway

> **“When multi-step operations partially succeed and rollback isn’t possible, systems must use compensating actions to restore correctness instead of retrying blindly.”**

If a system retries instead of compensating,
**it doesn’t understand partial failure**.

---

## ✅ Completion Criteria

You truly understand this project if you can explain:

* Why rollback isn’t always possible
* Why retry is dangerous after partial success
* What compensation means in practice
* Why compensation must be auditable

---