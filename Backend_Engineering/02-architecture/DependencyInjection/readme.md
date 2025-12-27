# BackendMastery.Architecture.DependencyInjection

This project focuses **solely on Dependency Injection (DI)** as an **architectural discipline**, not as a framework feature.

The goal is to understand **why DI exists**, **what problems it solves**, and **how to design code that is testable, maintainable, and change-friendly by default**.

---

## 🎯 Why this project exists

Many developers “use DI” but cannot explain:

* why constructor injection is preferred
* why abstractions matter
* why `new` in business code is dangerous
* why some code is hard to test even with DI

This project answers the fundamental question:

> **“How do I design code so dependencies are explicit, swappable, and controlled?”**

---

## 🧠 Core Mental Model

> **Dependency Injection is about who controls object creation.**

### Without Dependency Injection

```text
Class creates its own dependencies
→ tight coupling
→ hidden assumptions
→ hard to test
→ hard to change
```

### With Dependency Injection

```text
Class declares what it needs
→ dependencies supplied from outside
→ loose coupling
→ easy testing
→ safer refactoring
```

**Key principle:**

> *Never `new` what you don’t own.*

---

## 🧱 What Dependency Injection Is (and Is Not)

### DI **IS**

* A design principle
* About explicit dependencies
* About inversion of control
* About testability by design

### DI **IS NOT**

* A framework feature
* About containers
* About reducing code
* About magic configuration

> The container is an implementation detail.
> DI exists even without a container.

---

## 🧩 Architectural Layers in This Project

This project intentionally models **real production layering**:

| Layer          | Responsibility               |
| -------------- | ---------------------------- |
| Controllers    | Orchestration, HTTP concerns |
| Services       | Business coordination        |
| Repositories   | Data access abstraction      |
| Infrastructure | External/system dependencies |
| Program.cs     | Object graph composition     |

Each layer **depends inward on abstractions**, never outward on implementations.

---

## 🧠 Constructor Injection (Preferred Pattern)

All mandatory dependencies are injected via constructors.

**Why this matters:**

* Dependencies are visible
* Objects cannot exist in an invalid state
* The compiler enforces correctness
* Tests become trivial to write

> If a dependency is required, it belongs in the constructor.

---

## 🧱 Abstractions as Boundaries

Interfaces are used **intentionally**, not everywhere.

They exist to:

* Separate *what* from *how*
* Enable substitution (tests, future implementations)
* Protect higher layers from change

**Rule of thumb:**

> Abstract at architectural boundaries, not everywhere.

---

## ⏱ Infrastructure Is a Dependency Too

The project treats **time** as a dependency.

Why?

* `DateTime.UtcNow` is non-deterministic
* Non-deterministic code is hard to test
* Abstracting time makes logic predictable

This demonstrates a key insight:

> Anything that can’t be controlled in a test is a dependency.

---

## 🧪 Testability by Design

Because of proper DI:

* Services can be tested with mocks/fakes
* Controllers can be tested without infrastructure
* No static state blocks testing
* No hidden dependencies exist

> If DI is done right, testing becomes boring — and that’s good.

---

## 🧠 Dependency Lifetimes (Industry Thinking)

The project uses lifetimes intentionally:

| Lifetime  | When to Use                           |
| --------- | ------------------------------------- |
| Singleton | Stateless, thread-safe infrastructure |
| Scoped    | Request-bound services                |
| Transient | Lightweight, stateless objects        |

**Key insight:**

> Lifetime choice is a correctness decision, not a performance trick.

---

## 🚫 What This Project Explicitly Avoids

This is just as important as what it includes.

* ❌ Service locator pattern
* ❌ Property injection
* ❌ Static dependencies
* ❌ `IServiceProvider` in business code
* ❌ Over-injection of dependencies
* ❌ DI leaking into domain logic

These patterns hide dependencies and undermine testability.

---

## 🧠 Common Misconceptions (Interview Traps)

### ❌ “DI means using a DI container”

Wrong.

> DI is a design principle. Containers are optional helpers.

---

### ❌ “Interfaces everywhere is good DI”

Wrong.

> Abstractions should exist at boundaries, not everywhere.

---

### ❌ “DI makes code complex”

Wrong.

> DI makes complexity visible — which is a feature.

---

## 🎤 Interview-Ready Takeaways

You should be able to confidently say:

> “Dependency Injection is about controlling object creation.”

> “Constructor injection makes dependencies explicit and enforces correctness.”

> “I treat Program.cs as the composition root — the only place wiring happens.”

> “If a class is hard to test, the DI design is wrong.”

These answers clearly signal **senior-level architectural thinking**.

---

## 🔗 How This Project Fits in the Backend Journey

```
Clean Code & SOLID
↓
Dependency Injection   ← YOU ARE HERE
↓
Testing Strategy
↓
Transactions & Consistency
↓
Resilience Patterns
↓
Distributed Architecture
```

Dependency Injection is the **foundation that enables everything above it**.

---

## ✅ Completion Criteria

You are done with this topic when:

* You instinctively avoid `new` in business code
* Dependencies are visible from constructors
* Tests require no hacks or workarounds
* Program.cs is the single wiring location

At this point, **your DI understanding is industry-grade**.

---