# 📄 03-Building-Resilient-APIs

# 🧱 Building Resilient APIs

> **Core question:**
> *What happens when dependencies fail, slow down, or behave unpredictably?*

Production systems do not fail because of bad logic.
They fail because **dependencies misbehave**.

This section is about **designing APIs that survive failure**, not avoid it.

---

## 🧩 Projects in This Section

```
BackendMastery.ProdReadiness.Timeouts
BackendMastery.ProdReadiness.Retries
BackendMastery.ProdReadiness.Idempotency
BackendMastery.ProdReadiness.CircuitBreakers
BackendMastery.ProdReadiness.Bulkheads
BackendMastery.ProdReadiness.Fallbacks
BackendMastery.ProdReadiness.GracefulDegradation
```

Each project isolates **one failure-management responsibility**.

---

## 07. Timeouts

### 📦 Project

```
BackendMastery.ProdReadiness.Timeouts
```

---

### 🧠 Intuition

> A request that waits forever is already broken.

Timeouts are not about speed —
they are about **protecting system resources**.

---

### ❓ What problem does this solve?

Without timeouts:

* Threads remain blocked
* Connection pools exhaust
* Requests pile up behind slow calls

Eventually:

> **The system fails even though nothing is “down”.**

---

### 🌍 Real-world use cases

Timeouts are required for:

* HTTP calls
* Database queries
* Message brokers
* Cache lookups
* Any remote dependency

Especially critical when:

* Latency spikes occur
* Downstream services degrade gradually

---

### 🧩 What this project will demonstrate

This project focuses on **fail-fast boundaries**.

It will demonstrate:

* Explicit timeout configuration
* Per-dependency timeout tuning
* Why default timeouts are dangerous

---

### 🔍 What this project intentionally does NOT do

* ❌ Retries
* ❌ Fallbacks
* ❌ Circuit breaking

> This project answers only one question:
> *How long is “too long”?*

---

### ⚠️ Common timeout mistakes highlighted

| Mistake                 | Consequence         |
| ----------------------- | ------------------- |
| No timeout              | Resource exhaustion |
| Same timeout everywhere | Hidden bottlenecks  |
| Very large timeouts     | Latent failures     |
| Client-only timeouts    | Server collapse     |

---

### 🎯 Outcome of this project

You should be able to:

* Explain why timeouts are mandatory
* Identify unsafe blocking calls
* Tune timeout budgets per dependency

---

## 08. Retries & Backoff Strategies

### 📦 Project

```
BackendMastery.ProdReadiness.Retries
```

---

### 🧠 Intuition

> Retrying is useful — **until it makes things worse**.

Retries treat **transient failures**, not permanent ones.

---

### ❓ What problem does this solve?

Many failures are temporary:

* Network glitches
* Short-lived outages
* Cold starts

Retries allow systems to:

* Recover automatically
* Avoid user-visible errors

---

### 🌍 Real-world use cases

Retries are useful when:

* Failures are transient
* Operations are safe to repeat
* Calls are non-user-blocking

Examples:

* HTTP calls
* Queue publishing
* Cache population

---

### 🧩 What this project will demonstrate

This project focuses on **controlled retry behavior**.

It will demonstrate:

* Fixed backoff
* Exponential backoff
* Jitter to prevent thundering herds

---

### 🔍 What this project intentionally does NOT do

* ❌ Idempotency enforcement
* ❌ Circuit breaking

> Retrying unsafe operations is a **bug**, not resilience.

---

### ⚠️ Common retry mistakes highlighted

| Mistake                | Impact               |
| ---------------------- | -------------------- |
| Blind retries          | Outage amplification |
| No backoff             | Retry storms         |
| Retrying writes        | Data corruption      |
| Retrying user requests | Bad UX               |

---

### 🎯 Outcome of this project

You should be able to:

* Identify retry-safe operations
* Choose the right backoff strategy
* Explain why retries can be dangerous

---

## 09. Idempotency

### 📦 Project

```
BackendMastery.ProdReadiness.Idempotency
```

---

### 🧠 Intuition

> Retrying must not **repeat side effects**.

Idempotency makes retries **safe**.

---

### ❓ What problem does this solve?

Networks are unreliable:

* Clients retry
* Gateways retry
* Load balancers retry

Without idempotency:

* Each retry may cause duplication

---

### 🌍 Real-world use cases

Idempotency is mandatory for:

* Payments
* Orders
* Bookings
* Any write endpoint with retries

---

### 🧩 What this project will demonstrate

This project focuses on **write safety**.

It will demonstrate:

* Idempotency keys
* Request deduplication
* Safe write guarantees

---

### 🔍 What this project intentionally does NOT do

* ❌ Retry logic
* ❌ Business workflows

> Idempotency does not retry — it **protects retries**.

---

### ⚠️ Common idempotency mistakes highlighted

| Mistake             | Consequence            |
| ------------------- | ---------------------- |
| No idempotency      | Duplicate side effects |
| Partial idempotency | Inconsistent state     |
| Short-lived keys    | Replays                |
| Key reuse           | Data leaks             |

---

### 🎯 Outcome of this project

You should be able to:

* Design retry-safe write APIs
* Identify unsafe endpoints
* Explain idempotency across stacks

---

## 10. Circuit Breakers

### 📦 Project

```
BackendMastery.ProdReadiness.CircuitBreakers
```

---

### 🧠 Intuition

> When something is failing repeatedly, **stop calling it**.

Circuit breakers protect **your system**, not the dependency.

---

### ❓ What problem does this solve?

Without circuit breakers:

* Systems keep calling failing dependencies
* Latency increases
* Thread pools exhaust
* Cascading failures occur

---

### 🌍 Real-world use cases

Circuit breakers are essential for:

* Third-party APIs
* Unstable services
* Distributed systems

---

### 🧩 What this project will demonstrate

This project focuses on **failure containment**.

It will demonstrate:

* Closed, open, half-open states
* Failure thresholds
* Recovery probing

---

### 🔍 What this project intentionally does NOT do

* ❌ Fallback logic
* ❌ Graceful degradation

> Circuit breakers decide *when to stop*, not *what to return*.

---

### ⚠️ Common circuit breaker mistakes highlighted

| Mistake              | Impact            |
| -------------------- | ----------------- |
| No breaker           | Cascading outages |
| Global breaker       | Over-blocking     |
| No half-open state   | Slow recovery     |
| Silent breaker trips | Hidden failures   |

---

### 🎯 Outcome of this project

You should be able to:

* Recognize cascading failure patterns
* Configure meaningful thresholds
* Explain circuit breakers without libraries

---

## 11. Bulkheads & Failure Isolation

### 📦 Project

```
BackendMastery.ProdReadiness.Bulkheads
```

---

### 🧠 Intuition

> Compartments stop flooding from sinking the whole ship.

Bulkheads isolate failures.

---

### ❓ What problem does this solve?

Without isolation:

* One slow dependency blocks all traffic
* Shared pools become choke points

---

### 🌍 Real-world use cases

Bulkheads are needed when:

* Multiple features share infrastructure
* Some dependencies are riskier than others

---

### 🧩 What this project will demonstrate

This project focuses on **resource isolation**.

It will demonstrate:

* Thread pool isolation
* Connection pool partitioning
* Feature-level isolation

---

### 🔍 What this project intentionally does NOT do

* ❌ Retry logic
* ❌ Circuit breaking

> Bulkheads limit blast radius — nothing more.

---

### ⚠️ Common bulkhead mistakes highlighted

| Mistake        | Consequence       |
| -------------- | ----------------- |
| Shared pools   | Global slowdowns  |
| Over-isolation | Resource waste    |
| No monitoring  | Hidden starvation |

---

### 🎯 Outcome of this project

You should be able to:

* Identify shared bottlenecks
* Isolate risky dependencies
* Prevent failure propagation

---

## 12. Fallback Strategies

### 📦 Project

```
BackendMastery.ProdReadiness.Fallbacks
```

---

### 🧠 Intuition

> Partial correctness is often better than total failure.

Fallbacks trade **accuracy for availability**.

---

### ❓ What problem does this solve?

When dependencies fail:

* Returning nothing may be worse than returning something degraded

---

### 🌍 Real-world use cases

Fallbacks work best for:

* Read-heavy systems
* Cached data
* Non-critical features

---

### 🧩 What this project will demonstrate

This project focuses on **alternative responses**.

It will demonstrate:

* Cached fallbacks
* Default responses
* Read-only modes

---

### 🔍 What this project intentionally does NOT do

* ❌ Hiding failures
* ❌ Masking critical errors

> Fallbacks should be **visible**, not silent.

---

### ⚠️ Common fallback mistakes highlighted

| Mistake             | Impact              |
| ------------------- | ------------------- |
| Silent fallbacks    | Undetected outages  |
| Wrong fallback data | Incorrect behavior  |
| Fallback everywhere | Inconsistent system |

---

### 🎯 Outcome of this project

You should be able to:

* Choose safe fallback points
* Communicate degraded states
* Avoid misleading responses

---

## 13. Graceful Degradation

### 📦 Project

```
BackendMastery.ProdReadiness.GracefulDegradation
```

---

### 🧠 Intuition

> When resources are limited, **drop features — not the system**.

Graceful degradation is **prioritization under stress**.

---

### ❓ What problem does this solve?

During high load or partial outages:

* Systems must protect core functionality
* Optional features should fail first

---

### 🌍 Real-world use cases

Graceful degradation is critical for:

* High-traffic systems
* Tiered feature systems
* Peak load scenarios

---

### 🧩 What this project will demonstrate

This project focuses on **feature prioritization**.

It will demonstrate:

* Feature flags
* Load shedding
* Priority-based execution

---

### 🔍 What this project intentionally does NOT do

* ❌ Capacity planning
* ❌ Auto-scaling

> Degradation manages scarcity — it does not eliminate it.

---

### ⚠️ Common degradation mistakes highlighted

| Mistake                 | Consequence         |
| ----------------------- | ------------------- |
| All-or-nothing behavior | Full outages        |
| No prioritization       | Critical paths fail |
| Hidden degradation      | User confusion      |

---

### 🎯 Outcome of this project

You should be able to:

* Design systems that fail partially
* Protect core business flows
* Explain degradation strategies clearly

---

## 🧠 Key Mental Model (Carry Forward)

> **Failures are inevitable.
> Cascades are optional.**

Resilience is not about avoiding failure —
it is about **containing it**.

---