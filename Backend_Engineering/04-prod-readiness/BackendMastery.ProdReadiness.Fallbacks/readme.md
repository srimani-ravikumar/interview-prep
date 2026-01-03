# 🧱 Building Resilient APIs — Fallback Strategies (E-commerce)

> **Core question:**
> *When something fails, what is the least harmful response we can still serve?*

---

## 📌 Concept Overview (Tech-Agnostic)

Fallbacks define **what your system returns when a dependency fails**.

They are not about:

* Preventing failures
* Retrying failures
* Hiding failures

They are about **choosing a controlled, business-approved degradation** instead of total failure.

> **Partial correctness is often better than total unavailability.**

Especially in e-commerce.

---

## ❓ Production Problem This Solves (E-commerce Reality)

In an e-commerce system, not all dependencies are equally critical.

Typical product page dependencies:

* Pricing service
* Inventory service
* Recommendation engine
* Reviews service
* Personalization engine

Without fallbacks:

* Pricing down → product page down → revenue loss
* Recommendations down → browsing blocked → engagement loss
* Reviews down → checkout blocked → conversion loss

> **Non-critical failures cause critical business damage.**

Fallbacks prevent this.

---

## 🧠 Intuition (Plain English)

Imagine an online store:

* The recommendation engine is down
  → You can still buy the product

* The pricing service is temporarily unavailable
  → You can still show the *last known valid price*

* Reviews are unavailable
  → You can still check out

Users prefer:

> “Some information now”
> over
> “Nothing at all”

Fallbacks make that possible.

---

## ⚠️ Senior-Level Distinction (Very Important)

### Fallbacks are **NOT**:

* Silent error suppression
* Guessing data
* Lying to users
* “Catch-all try/catch”

### Fallbacks **ARE**:

* Explicit business decisions
* Clearly scoped degradations
* Observable and monitorable
* Approved by product & business teams

> **Bad fallbacks lie.
> Good fallbacks admit degradation.**

---

## 🧩 What This Project Demonstrates

This project focuses on **response strategy under failure**.

Using an **e-commerce product API**, it demonstrates:

* Cached fallback for **pricing** (critical but cacheable)
* Empty fallback for **recommendations** (non-critical)
* Clear separation of critical vs non-critical dependencies
* Visible degradation in response contracts measuring `IsFromCache`

### What this project intentionally does NOT include

* ❌ Retries
* ❌ Circuit breakers
* ❌ Graceful degradation orchestration

> This project answers only one question:
> **“What do we return when something fails?”**

---

## 🧱 Project Structure & Responsibility Boundaries

```
BackendMastery.ProdReadiness.Fallbacks/
│
├── Controllers/          # HTTP orchestration only
├── Contracts/            # Explicit response contracts
├── Services/             # Business-owned fallback decisions
├── Infrastructure/       # External dependencies + cache
├── Program.cs
└── appsettings.json
```

### Key Design Principle

> **Fallback decisions belong to the business layer — not controllers.**

Controllers:

* Translate HTTP semantics

Services:

* Decide what degrades
* Decide what must fail hard

---

## 🧠 How This Models Real Production Behavior

This project simulates:

* A **pricing service** that fails intermittently
* A **recommendation engine** that fails frequently
* A **cached price store** holding last known good values

Behavior under failure:

* Pricing failure → cached price (explicitly marked)
* Recommendation failure → empty list
* Product page still loads

This is **real e-commerce behavior**, not theory.

---

## 🔁 How This Concept Transfers Across Stacks

Fallbacks are universal:

| Stack   | Typical Pattern                 |
| ------- | ------------------------------- |
| Java    | Cached DTOs / default responses |
| Node.js | Conditional response branches   |
| Go      | Alternate execution paths       |
| .NET    | Explicit try/fallback blocks    |

Different syntax.
**Same business reasoning.**

---

## ⚠️ Common Fallback Mistakes (Highlighted Here)

| Mistake                    | Consequence         |
| -------------------------- | ------------------- |
| Silent fallbacks           | Hidden outages      |
| Guessing values            | Financial loss      |
| Fallback everywhere        | Inconsistent system |
| No response signal         | Client confusion    |
| Treating fallback as retry | Amplified failures  |

---

## 🎯 What You Should Be Able to Explain After This Project

* Why fallbacks are **business decisions**, not technical hacks
* How to classify dependencies as critical vs non-critical
* Why fallback data must be explicit and visible
* How fallback differs from retries and breakers
* Why hiding failures is dangerous

---

## 🧠 Mental Model to Carry Forward

> **Availability beats perfection —
> but honesty beats both.**

Fallbacks keep systems usable.
Visibility keeps systems trustworthy.

---