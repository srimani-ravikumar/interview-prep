# 📄 02-API-Surface-and-Contracts

# 📜 API Surface & Consumer Contracts

> **Core question:**
> *How do clients interact with the API safely, predictably, and independently?*

The API surface is **the public face of your backend**.
Once exposed, it becomes a **shared contract** between teams, services, and sometimes companies.

Most production breakages are **not caused by business logic**,
but by **unstable or ambiguous API contracts**.

---

## 🧩 Projects in This Section

```
BackendMastery.ProdReadiness.ApiContracts
BackendMastery.ProdReadiness.Validation
BackendMastery.ProdReadiness.QueryCapabilities
BackendMastery.ProdReadiness.ApiVersioning
```

Each project isolates **one outward-facing responsibility** of an API.

---

## 03. API Contracts & Documentation

### 📦 Project

```
BackendMastery.ProdReadiness.ApiContracts
```

---

### 🧠 Intuition

> An API contract is a **promise to consumers**, not a reflection of internal implementation.

Clients do not care:

* How your data is stored
* How many services you have
* What framework you use

They care about:

* Request shape
* Response shape
* Status codes
* Behavioral guarantees

---

### ❓ What problem does this solve?

Without a clear contract:

* Frontend and backend block each other
* Changes break consumers silently
* APIs become tribal knowledge

---

### 🌍 Real-world use cases

API contracts are critical when:

* Frontend and backend are developed in parallel
* Multiple clients consume the same API
* APIs are exposed externally or publicly

Examples:

* Web + mobile clients
* Internal platform APIs
* Partner integrations

---

### 🧩 What this project will demonstrate

This project focuses on **contract clarity**, not controllers.

It will demonstrate:

#### 1️⃣ Explicit request / response models

* DTOs as boundary objects
* Separation from domain models

**Why this matters**

* Internal changes should not leak outside

---

#### 2️⃣ OpenAPI / Swagger as a contract

* Swagger as a **source of truth**
* Not just auto-generated documentation

**Key mindset**

> If it’s not in OpenAPI, it’s not supported.

---

#### 3️⃣ Backward-compatible evolution

* Additive vs breaking changes
* Optional fields
* Default behaviors

---

### 🔍 What this project intentionally does NOT do

* ❌ Business logic
* ❌ Validation rules
* ❌ Authorization

> This project defines *what the API looks like*, not how it behaves internally.

---

### ⚠️ Common contract mistakes this project highlights

| Mistake                   | Consequence        |
| ------------------------- | ------------------ |
| Returning domain models   | Leaky abstractions |
| Undocumented fields       | Client guesswork   |
| Inconsistent status codes | Fragile clients    |
| “Just read the code” APIs | Team coupling      |

---

### 🎯 Outcome of this project

After completing this project, you should be able to:

* Design APIs frontend teams trust
* Evolve APIs without fear
* Spot breaking changes before release
* Apply the same contract discipline in any tech stack

---

## 04. Validation & Standard Error Responses

### 📦 Project

```
BackendMastery.ProdReadiness.Validation
```

---

### 🧠 Intuition

> Validation exists to **fail fast and fail clearly**.

Invalid data should:

* Be rejected early
* Produce predictable errors
* Never reach business logic

---

### ❓ What problem does this solve?

Without consistent validation:

* Controllers become defensive
* Errors surface deep in the stack
* Clients cannot recover gracefully

---

### 🌍 Real-world use cases

Validation is essential when:

* APIs are public or external
* Clients are automated
* Errors must be handled programmatically

Examples:

* Form submissions
* Bulk uploads
* Partner APIs

---

### 🧩 What this project will demonstrate

This project focuses on **input correctness**, not processing.

It will demonstrate:

#### 1️⃣ Centralized validation

* Validation as a cross-cutting concern
* Consistent enforcement

---

#### 2️⃣ Standard error response format

* Machine-readable errors
* Stable error contracts

**Why this matters**

* Clients depend on error shapes as much as success responses

---

#### 3️⃣ Clear error classification

* Client errors vs server errors
* Validation vs business rule violations

---

### 🔍 What this project intentionally does NOT do

* ❌ Authentication
* ❌ Authorization
* ❌ Business workflows

> Validation guards the boundary — it does not decide outcomes.

---

### ⚠️ Common validation mistakes this project highlights

| Mistake                            | Why it hurts      |
| ---------------------------------- | ----------------- |
| Throwing exceptions for validation | Expensive & noisy |
| Inconsistent error shapes          | Client complexity |
| Validating too late                | Corrupted state   |
| Over-validating                    | Rigid APIs        |

---

### 🎯 Outcome of this project

After completing this project, you should be able to:

* Design predictable error contracts
* Separate validation from business rules
* Build APIs that clients can safely automate against

---

## 05. Filtering, Sorting & Pagination

### 📦 Project

```
BackendMastery.ProdReadiness.QueryCapabilities
```

---

### 🧠 Intuition

> APIs should give clients **controlled access** to data, not raw power.

Large datasets must be:

* Bounded
* Predictable
* Efficient

---

### ❓ What problem does this solve?

Without query controls:

* APIs return too much data
* Databases are stressed
* Performance degrades unpredictably

---

### 🌍 Real-world use cases

Query capabilities matter when:

* Returning lists
* Building dashboards
* Supporting reporting or search

Examples:

* Orders list
* Transaction history
* Admin views

---

### 🧩 What this project will demonstrate

This project focuses on **safe data exposure**.

It will demonstrate:

#### 1️⃣ Filtering contracts

* Explicit filter parameters
* No arbitrary query execution

---

#### 2️⃣ Sorting guarantees

* Stable sort fields
* Predictable ordering

---

#### 3️⃣ Pagination strategies

* Offset vs cursor-based pagination
* Consistent paging guarantees

---

### 🔍 What this project intentionally does NOT do

* ❌ Full-text search engines
* ❌ Complex reporting logic

> This project is about **API-level data access**, not analytics.

---

### ⚠️ Common mistakes this project highlights

| Mistake                       | Impact                   |
| ----------------------------- | ------------------------ |
| Returning all rows            | Performance collapse     |
| Unstable pagination           | Duplicate / missing data |
| Letting clients sort anything | Index misuse             |
| DB-coupled query params       | Fragile APIs             |

---

### 🎯 Outcome of this project

After completing this project, you should be able to:

* Design scalable list endpoints
* Prevent accidental DoS via queries
* Port the same ideas across stacks

---

## 06. API Versioning Strategies

### 📦 Project

```
BackendMastery.ProdReadiness.ApiVersioning
```

---

### 🧠 Intuition

> Versioning exists because **change is inevitable**, but breaking consumers is optional.

---

### ❓ What problem does this solve?

Without versioning:

* Breaking changes go live silently
* Clients are forced to upgrade immediately
* Rollbacks become complex

---

### 🌍 Real-world use cases

Versioning is required when:

* APIs are public
* Multiple clients evolve at different speeds
* Backward compatibility matters

---

### 🧩 What this project will demonstrate

This project focuses on **controlled evolution**.

It will demonstrate:

#### 1️⃣ When NOT to version

* Avoid premature versioning
* Prefer backward-compatible changes

---

#### 2️⃣ Versioning strategies

* URI-based
* Header-based
* Media-type-based

---

#### 3️⃣ Version lifecycle management

* Deprecation
* Sunset policies

---

### 🔍 What this project intentionally does NOT do

* ❌ Business logic
* ❌ Contract generation

> Versioning governs **how contracts evolve**, not what they contain.

---

### ⚠️ Common versioning mistakes this project highlights

| Mistake                          | Consequence           |
| -------------------------------- | --------------------- |
| Version everything               | Maintenance nightmare |
| Never version                    | Breaking clients      |
| No deprecation policy            | Forced rewrites       |
| Multiple active versions forever | Complexity explosion  |

---

### 🎯 Outcome of this project

After completing this project, you should be able to:

* Decide if versioning is needed
* Choose the right strategy per API
* Manage API evolution professionally

---

## 🧠 Key Mental Model (Carry Forward)

> **Contracts are harder to change than code.**
> Treat them with the same care as database schemas.

---