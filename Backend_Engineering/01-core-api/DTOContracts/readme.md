# BackendMastery.CoreAPI.DTOContracts

This project focuses on **DTOs (Data Transfer Objects)** and **contract boundaries** — one of the most misunderstood yet critical backend concepts.

This is where APIs stop being “internal code” and start becoming **public promises**.

---

## 🎯 What problem does this project solve?

Many APIs fail over time because:

* Domain models are exposed directly
* Internal changes break external clients
* Sensitive fields leak unintentionally
* APIs become impossible to evolve safely

This project answers the question:

> **“How do I protect my API consumers from internal change?”**

The answer is: **clear contract boundaries using DTOs**.

---

## 🧠 Core Intuition: What DTOs REALLY Are

DTOs are **not**:

* Just data containers
* Mapping overhead
* Boilerplate classes

DTOs **are contracts**.

> A DTO defines **what the outside world is allowed to know and send** — nothing more.

---

## 🧱 The Boundary Principle (Very Important)

Every backend system has two worlds:

### 🔒 Inside the system (Domain)

* Business rules
* Sensitive data
* Implementation details
* Changes frequently

### 🌍 Outside the system (API Clients)

* Mobile apps
* Web apps
* Other services
* Expect stability

DTOs sit **exactly at this boundary**.

> They absorb change so clients don’t have to.

---

## 🧩 Types of DTOs (Critical Distinction)

### 1️⃣ Write DTOs (Request Contracts)

**Purpose**

* Define what clients are allowed to send

**Intuition**

> Clients send intent, not internal structure.

**Use cases**

* Prevent over-posting
* Avoid security issues
* Enforce input shape

Example intent:

```
Create user with email + password
```

Not:

```
Create user with isAdmin=true
```

---

### 2️⃣ Read DTOs (Response Contracts)

**Purpose**

* Define what clients are allowed to see

**Intuition**

> Just because data exists doesn’t mean it should be exposed.

**Use cases**

* Hide sensitive fields
* Keep responses stable
* Support versioning

---

## 🚫 Why Domain Models Must NOT Be Exposed

Exposing domain models directly causes:

* ❌ Password hashes leaking
* ❌ Internal flags exposed
* ❌ Breaking changes when domain evolves
* ❌ Tight coupling between client and server

> Domain models evolve for **business reasons**.
> APIs must evolve for **client reasons**.

These two timelines are different.

---

## 🔁 Mapping Is Not the Enemy

Many developers complain:

> “DTOs add mapping code.”

That’s the point.

Mapping is a **deliberate friction** that forces you to think:

* What should go out?
* What should stay in?
* What is stable vs volatile?

> If mapping feels painful, your boundary is doing its job.

---

## 🌐 Real-World Use Cases

DTOs are essential when:

* APIs are public or long-lived
* Multiple clients consume the same API
* Teams evolve independently
* Backward compatibility matters

They are **not optional** in serious systems.

---

## 🧠 Common Misconceptions (Interview Traps)

### ❌ “DTOs are only for big systems”

Wrong.

> Even small APIs become big over time.

---

### ❌ “DTOs duplicate entities”

Wrong.

> DTOs and entities serve different audiences.

---

### ❌ “AutoMapper solves DTO design”

Wrong.

> Mapping tools don’t design contracts — engineers do.

---

## 🎤 Interview-Ready Takeaways

You should confidently say:

> “DTOs protect API contracts from domain churn.”

> “I use separate read and write DTOs to avoid over-posting and data leaks.”

> “Entities represent business truth; DTOs represent API promises.”

These answers signal **senior-level boundary thinking**.

---