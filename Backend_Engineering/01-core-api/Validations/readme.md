# BackendMastery.CoreAPI.Validation

This project focuses **solely on validation** as a first-class backend engineering concept.

It intentionally avoids:

* Databases
* Business logic
* Authentication
* Framework magic

The goal is to understand **what validation is, where it belongs, and how it should be applied** in a backend API.

---

## 🎯 Why this project exists

Many APIs fail not because of bad logic, but because:

* Invalid data enters the system
* Validation is mixed with business rules
* Error responses are inconsistent
* Validation logic is scattered and implicit

This project fixes that by **isolating validation as a boundary concern**.

---

## 🧠 Core Mental Model

### What is Validation?

> **Validation answers one question:**
> “Is this input acceptable to enter the system?”

Validation ensures:

* Required data is present
* Data is structurally correct
* Data is safe to process

---

### What Validation is NOT

Validation is **not**:

* Authorization
* Authentication
* Business decision making
* Persistence checks

Example:

| Check                   | Type            |
| ----------------------- | --------------- |
| Email is empty          | ✅ Validation    |
| Email domain is blocked | ❌ Business rule |
| User already exists     | ❌ Business rule |
| Password length < 8     | ✅ Validation    |

---

## 🧱 Where Validation Belongs

Validation must happen at **system boundaries**:

* HTTP Controllers
* API Gateways
* Message Consumers (Kafka / RabbitMQ)
* Public SDK inputs

Why?

> Because once bad data enters the system, every downstream layer becomes fragile.

---

## 🧩 Types of Validation Covered

This project demonstrates **three validation approaches**, from fundamental to framework-assisted.

---

### 1️⃣ Manual Validation (Explicit)

**What it is**

* Validation written directly in code
* Clear `if` checks
* Immediate feedback

**Intuition**

> Manual validation is the most explicit and debuggable form of validation.

**Use cases**

* Simple APIs
* Custom rules
* Non-DTO inputs (e.g., raw JSON, headers)

**Trade-off**

* Can become verbose if overused

---

### 2️⃣ Attribute-Based Validation (ASP.NET Core)

**What it is**

* Declarative validation using attributes like:

  * `[Required]`
  * `[EmailAddress]`
  * `[Range]`

**Intuition**

> Attributes describe *what is allowed*, not *how to handle it*.

**Use cases**

* Standard request validation
* Consistent rules across endpoints
* Clean controller code

**Key behavior**

* With `[ApiController]`, invalid input automatically returns **400 Bad Request**

---

### 3️⃣ ModelState Inspection (Explicit Control)

**What it is**

* Inspecting `ModelState` manually
* Customizing error responses
* Logging validation failures

**Intuition**

> Automatic validation is good — explicit control is better when needed.

**Use cases**

* Custom error formats
* Centralized logging
* Advanced client contracts

---

## 🔀 Validation vs Business Rules (Critical Separation)

One of the most important lessons in this project.

### Validation

* Checks **shape, presence, and safety**
* Happens **before** business logic
* Returns **400 Bad Request**

### Business Rules

* Enforce **domain meaning**
* Depend on system state
* Often return **409 Conflict** or **403 Forbidden**

> Mixing these two leads to unmaintainable APIs.

---

## 🌐 Validation and HTTP Semantics

Validation failures should:

* Fail fast
* Be predictable
* Clearly blame the client

Correct response:

* **400 Bad Request** → invalid input

Incorrect response:

* **500 Internal Server Error** → hides client mistake
* **200 OK with error message** → breaks HTTP semantics

---

## 🧪 Why This Matters in Real Systems

Proper validation:

* Prevents security issues (over-posting, injection)
* Improves API usability
* Makes client behavior predictable
* Simplifies downstream logic
* Reduces production bugs

---

## 🎤 Interview-Ready Takeaways

You should be able to confidently say:

> “Validation protects system boundaries; business rules protect domain invariants.”

> “I validate inputs early and fail fast with clear client feedback.”

> “Framework validation helps, but I always understand what it’s doing under the hood.”

These statements signal **senior backend thinking**.

---