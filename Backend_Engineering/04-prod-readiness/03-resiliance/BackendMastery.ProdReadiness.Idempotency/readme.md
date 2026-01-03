# 🧱 Building Resilient APIs — Idempotency

> **Core question:**
> *What happens if the same write request reaches my system more than once?*

---

## 📌 Concept Overview (Tech-Agnostic)

Idempotency guarantees that **repeating the same request does not repeat side effects**.

In distributed systems:

* Requests are retried
* Responses are lost
* Clients disconnect and retry
* Gateways and load balancers retry automatically

> **Duplicate requests are normal.
> Duplicate side effects are not.**

Idempotency is what separates **safe retries** from **data corruption**.

---

## ❓ Production Problem This Solves

Without idempotency, retries cause:

* Duplicate orders
* Double payments
* Oversold inventory
* Conflicting bookings
* Broken user trust

These are **business failures**, not just technical bugs.

Once money is charged or inventory is consumed,
**you cannot “retry your way out” of the damage**.

---

## 🧠 Intuition (Plain English)

Imagine paying an electricity bill online:

1. You click **Pay**
2. The screen freezes
3. You refresh
4. You click **Pay** again

If the backend is **not idempotent**:

* You are charged twice

If it **is idempotent**:

* The backend recognizes the request
* No second charge happens
* You receive the same result again

Retries are inevitable.
Idempotency makes them **harmless**.

---

## ⚠️ Why Naive Systems Fail

### 1. “Clients won’t retry”

They already do.

* Browsers retry
* SDKs retry
* Gateways retry
* Humans retry

---

### 2. “POST is unsafe anyway”

Unsafe ≠ unprotected.

Writes can still be **idempotent**.

---

### 3. “We’ll dedupe later”

You already:

* Charged the customer
* Shipped the item
* Sent the email

State corruption has already happened.

---

### 4. “Short-lived keys are enough”

Retries can happen:

* Minutes later
* Hours later
* After network partitions heal

Idempotency windows must match **business reality**.

---

## 🧩 What This Project Demonstrates

This project isolates **write safety**.

It demonstrates:

* Idempotency keys (`Idempotency-Key` header)
* Request deduplication
* First-write-wins behavior
* Safe replay with identical response

### What this project intentionally does NOT include

* ❌ Retry logic
* ❌ Business workflows
* ❌ External payment systems

> Idempotency does not retry.
> It **protects retries**.

---

## 🧱 Project Structure & Responsibility Boundaries

```
BackendMastery.ProdReadiness.Idempotency/
│
├── Controllers/          # HTTP orchestration only
├── Contracts/            # Request/response models
├── Services/             # Side-effect-producing business logic
├── Infrastructure/       # Idempotency state storage
├── Middleware/           # Cross-cutting idempotency enforcement
├── Program.cs
└── appsettings.json
```

### Key Design Principle

> **Idempotency must be enforced BEFORE business logic executes.**

If you apply it after:

* You already created damage
* You already lost correctness

That’s too late.

---

## 🧠 How This Models Real Production Behavior

This project simulates:

* A write endpoint (`POST /orders`)
* An idempotency key provided by the client
* A store that remembers processed requests
* Replay of the **same response** on duplicates

The **first request wins**.
All subsequent identical requests are **safe replays**.

---

## 🔁 How This Concept Transfers Across Stacks

Idempotency exists in every serious backend system:

| Stack     | Typical Approach                  |
| --------- | --------------------------------- |
| HTTP APIs | `Idempotency-Key` header          |
| Java      | DB uniqueness + request hash      |
| Node.js   | Redis / cache-based deduplication |
| Go        | Transaction + idempotency store   |
| .NET      | Same patterns                     |

Frameworks differ.
**The mental model does not.**

---

## ⚠️ Common Idempotency Mistakes (Highlighted Here)

| Mistake                      | Consequence            |
| ---------------------------- | ---------------------- |
| No idempotency               | Duplicate side effects |
| Partial idempotency          | Inconsistent state     |
| Key reuse                    | Data leaks             |
| Short-lived storage          | Replay attacks         |
| Different response on replay | Client confusion       |

---

## 🎯 What You Should Be Able to Explain After This Project

* Why retries without idempotency are dangerous
* Why idempotency is a **write concern**, not a retry concern
* How idempotency keys define request identity
* Why first execution must win
* Where idempotency must live architecturally

---

## 🧠 Mental Model to Carry Forward

> **Retries repeat requests.
> Idempotency prevents repeated damage.**

Retries answer *“should I try again?”*
Idempotency answers *“what happens if I do?”*

Both are required for correctness.

---