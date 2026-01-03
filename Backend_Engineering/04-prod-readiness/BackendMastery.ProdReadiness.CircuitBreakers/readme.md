# 🧱 Building Resilient APIs — Circuit Breakers

> **Core question:**
> *When a dependency keeps failing, why do we keep calling it?*

---

## 📌 Concept Overview (Tech-Agnostic)

Circuit breakers prevent **cascading failures** in distributed systems.

When a dependency is repeatedly failing or timing out, continuing to call it:

* Wastes resources
* Increases latency
* Amplifies outages
* Spreads failure to healthy parts of the system

Circuit breakers **intentionally stop calls** to unhealthy dependencies for a period of time.

> **Failures are inevitable.
> Cascades are optional.**

---

## ❓ Production Problem This Solves

Without circuit breakers, systems fail like this:

1. A dependency degrades (slow or error-prone)
2. Requests start timing out
3. Retries increase traffic
4. Thread pools exhaust
5. Latency spikes everywhere
6. Healthy services become unhealthy
7. Full outage occurs

Nothing was *down* at the beginning.

The system **collapsed under its own retry pressure**.

Circuit breakers stop this chain early.

---

## 🧠 Intuition (Plain English)

Think of a home electrical circuit breaker:

* A device malfunctions
* Current spikes repeatedly
* The breaker trips
* Power is cut temporarily

Why?

> To protect the rest of the house.

Software circuit breakers do the same:

* They protect **your service**
* Not the dependency

---

## ⚠️ Critical Distinction (Senior-Level)

| Concept              | Responsibility                   |
| -------------------- | -------------------------------- |
| Timeouts             | *How long to wait*               |
| Retries              | *Whether to try again*           |
| Idempotency          | *What happens if retried*        |
| **Circuit Breakers** | **When to stop trying entirely** |

Retries without breakers = **outage amplification**
Breakers without retries = **brittle systems**

They must exist **together**, but be understood **separately**.

---

## 🧩 What This Project Demonstrates

This project isolates **failure containment**.

It demonstrates:

* Circuit breaker states

  * Closed
  * Open
  * Half-Open
* Failure thresholds
* Cool-down periods
* Fast-fail behavior when dependency is unhealthy

### What this project intentionally does NOT include

* ❌ Retries
* ❌ Fallbacks
* ❌ Graceful degradation

> Circuit breakers decide **when to stop calling**, not **what to return**.

---

## 🧱 Project Structure & Responsibility Boundaries

```
BackendMastery.ProdReadiness.CircuitBreakers/
│
├── Controllers/          # HTTP translation only
├── Contracts/            # Stable API response models
├── Services/             # Breaker coordination logic
├── Infrastructure/       # Breaker state + flaky dependency
├── Configuration/        # Thresholds and timers
├── Program.cs
└── appsettings.json
```

### Key Design Principle

> **Circuit breakers belong in the service layer — never in controllers.**

Controllers:

* Orchestrate HTTP
* Surface errors

Services:

* Decide whether a dependency is callable
* Enforce resilience boundaries

---

## 🧠 How This Models Real Production Behavior

This project simulates:

* A flaky external payment gateway
* Repeated failures over time
* A breaker that opens after a threshold
* Fast failures while the breaker is open
* Automatic recovery attempts (half-open)

The system **fails fast** instead of **failing slowly**.

---

## 🔁 How This Concept Transfers Across Stacks

Circuit breakers are universal:

| Stack   | Common Implementation     |
| ------- | ------------------------- |
| Java    | Resilience4j / Hystrix    |
| Node.js | Custom state machines     |
| Go      | State + counters + timers |
| .NET    | Polly / custom breakers   |

Libraries differ.
**The state machine does not.**

---

## ⚠️ Common Circuit Breaker Mistakes (Highlighted Here)

| Mistake                      | Consequence        |
| ---------------------------- | ------------------ |
| No circuit breaker           | Cascading outages  |
| Global breaker               | Over-blocking      |
| No half-open state           | Slow recovery      |
| Silent breaker trips         | Hidden outages     |
| Treating breaker as fallback | Incorrect behavior |

---

## 🎯 What You Should Be Able to Explain After This Project

* Why retries alone are dangerous
* How circuit breakers prevent cascading failures
* The difference between open, closed, and half-open states
* Why breakers protect *your system*, not dependencies
* Where breakers belong architecturally

---

## 🧠 Mental Model to Carry Forward

> **If something keeps failing, stop calling it.
> Protect your capacity first.**

Circuit breakers don’t fix failures.
They **contain** them.

---