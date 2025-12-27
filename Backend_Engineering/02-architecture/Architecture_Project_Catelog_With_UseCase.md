# Architecture Project Catalog

**(Separation of Concerns · Repository · Service)**

This document catalogs **core architectural concepts** and their **cartesian combinations**, independent of frameworks, HTTP, or MVC.

It exists to answer one fundamental question:

> **“Which architectural concepts should exist for a given problem — and why?”**

---

## 🎯 Why this document exists

Most developers encounter architecture through MVC tutorials and frameworks.

This leads to misconceptions such as:

* Service layers exist because of MVC
* Repositories exist because of ORMs
* Architecture is tied to web applications

This document **decouples architecture from delivery mechanisms** and provides a **clear, principled catalog** of when each concept should exist.

---

## 🧠 Core Architectural Axes

This catalog is built on **three independent axes**:

| Axis                         | Purpose                    |
| ---------------------------- | -------------------------- |
| Separation of Concerns (SoC) | Responsibility isolation   |
| Repository Pattern           | Data access boundary       |
| Service Pattern              | Business behavior boundary |

These axes are **orthogonal**, not hierarchical.

---

## 1️⃣ Standalone Concept Projects

*(Single-Axis Focus)*

These projects exist **independently** and **without requiring MVC, HTTP, or frameworks**.

---

### 🟦 BackendMastery.Architecture.SoC

**Separation of Concerns Only**

#### What this project focuses on

* Responsibility isolation
* Change impact minimization
* Boundary thinking without patterns

#### What it deliberately avoids

* Repositories
* Services
* MVC / HTTP

#### Core use cases

* Compiler pipelines (parse / validate / emit)
* File processing systems
* ETL pipelines
* Batch data transformations
* Game engines (logic vs rendering vs physics)

#### Typical structure

```
Input
 ↓
Processing
 ↓
Output
```

#### Why this project exists

> To demonstrate that **architecture begins before patterns**.

---

### 🟩 BackendMastery.Architecture.Repository

**Repository Pattern Only**

#### What this project focuses on

* Data access abstraction
* Storage agnosticism
* Swappable persistence

#### What it deliberately avoids

* Business orchestration
* Service layer
* MVC / HTTP

#### Core use cases

* CLI tools
* Data migration utilities
* Import/export systems
* Batch jobs
* Legacy system adapters

#### Typical structure

```
Application
 ↓
Repository
 ↓
Storage (DB / File / API)
```

#### Why this project exists

> To show that **data access is a concern of its own**.

---

### 🟨 BackendMastery.Architecture.Service

**Service Pattern Only**

#### What this project focuses on

* Business behavior encapsulation
* Workflow orchestration
* Use-case driven design

#### What it deliberately avoids

* Persistence
* Repositories
* Framework delivery

#### Core use cases

* Pricing engines
* Rule engines
* Validation engines
* Calculation services
* Event processors

#### Typical structure

```
Input
 ↓
Service (Behavior)
 ↓
Output
```

#### Why this project exists

> To show that **behavior exists independently of storage**.

---

## 2️⃣ Pairwise Cartesian Products

*(Two-Axis Combinations)*

These projects intentionally combine **exactly two concepts**.

---

### 🟦🟩 BackendMastery.Architecture.SoC.Repository

**Separation of Concerns + Repository**

#### Core use cases

* Admin dashboards
* Reporting systems
* Read-heavy applications
* Analytics viewers

#### Typical structure

```
Input
 ↓
Flow Logic
 ↓
Repository
```

#### Why this combination exists

> Behavior is trivial; **data complexity dominates**.

---

### 🟦🟨 BackendMastery.Architecture.SoC.Service

**Separation of Concerns + Service**

#### Core use cases

* Pricing calculators
* Policy evaluation engines
* Stateless workflows
* Business rule evaluators

#### Typical structure

```
Input
 ↓
Service
 ↓
Output
```

#### Why this combination exists

> Logic is complex; **storage is irrelevant**.

---

### 🟩🟨 BackendMastery.Architecture.Repository.Service

**Repository + Service**

#### Core use cases

* APIs
* Background workers
* Event-driven services
* Domain-centric systems

#### Typical structure

```
Delivery
 ↓
Service
 ↓
Repository
```

#### Why this combination exists

> This represents the **core of most backend systems**.

---

## 3️⃣ Full Cartesian Product

*(Three-Axis Combination)*

---

### 🟦🟩🟨 BackendMastery.Architecture.SoC.Repository.Service

**Industry Default Architecture**

#### Core use cases

* SaaS platforms
* Enterprise systems
* Microservices
* Long-lived products
* Multi-team backends

#### Typical structure

```
Delivery (HTTP / CLI / MQ)
        ↓
     Service
        ↓
   Repository
```

#### Why this combination exists

> This architecture survives **time, scale, and change**.

---

## 4️⃣ Where MVC Fits (Important Clarification)

MVC is **not an architectural axis**.

It is a **delivery mechanism** that can be plugged into **any** of the above combinations.

Example:

```
Controller (MVC)
 ↓
Service
 ↓
Repository
```

MVC **uses** Service and Repository.
Service and Repository **do not depend on MVC**.

---

## 🧠 Final Mental Model

```
Separation of Concerns  → principle
Repository Pattern     → data boundary
Service Pattern        → behavior boundary
MVC                    → delivery mechanism
```

These concepts are **orthogonal**, not layered.

---

## ✅ Why This Catalog Matters

This catalog helps you:

* Choose patterns intentionally
* Avoid over-engineering
* Explain architecture clearly in interviews
* Design systems that evolve safely
* Separate core logic from delivery mechanisms

It serves as a **reference anchor** for all future architectural decisions.

---