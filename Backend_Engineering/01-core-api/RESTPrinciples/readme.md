# BackendMastery.CoreAPI.RESTPrinciples

This project focuses on **REST as a set of principles**, not as a framework feature.

It intentionally separates **HTTP behavior** from:

* Business logic
* Persistence
* DTOs
* Validation

Because REST is about **communication semantics**, not data storage.

---

## 🎯 What problem does this project solve?

Most APIs claim to be “RESTful” but:

* Use HTTP verbs incorrectly
* Return wrong status codes
* Encode behavior in URLs
* Treat HTTP as a transport, not a contract

This project answers:

> **“What does it actually mean to build a RESTful API?”**

---

## 🧠 Core Intuition: REST Is About CONSTRAINTS

REST is **not**:

* JSON over HTTP
* Controllers + routes
* CRUD naming conventions

REST **is**:

> A set of constraints that make APIs **predictable, scalable, and evolvable**.

HTTP is the **language** through which REST is expressed.

---

## 🧱 REST Principle #1: Resource-Oriented Design

In REST:

* URLs identify **resources**
* HTTP verbs describe **actions**
* URLs never describe behavior

### ❌ Bad

```
POST /createUser
GET  /getUserById
```

### ✅ Good

```
POST /users
GET  /users/{id}
```

**Intuition**

> Resources are nouns. Actions are verbs — and verbs already exist in HTTP.

---

## 🧱 REST Principle #2: Correct Use of HTTP Methods

Each HTTP method has **defined semantics**.

| Method  | Meaning              | Safe | Idempotent |
| ------- | -------------------- | ---- | ---------- |
| GET     | Read state           | ✅    | ✅          |
| HEAD    | Metadata only        | ✅    | ✅          |
| POST    | Create new resource  | ❌    | ❌          |
| PUT     | Full replacement     | ❌    | ✅          |
| PATCH   | Partial update       | ❌    | ❌          |
| DELETE  | Remove resource      | ❌    | ✅          |
| OPTIONS | Capability discovery | ✅    | ✅          |

**Intuition**

> The method tells the server *how to interpret the request*, not just what to do.

---

## 🧱 REST Principle #3: Safety vs Idempotency

### Safety

* Request does **not** modify server state
* Enables caching, retries, pre-fetching

### Idempotency

* Repeating the same request leads to the **same final state**

**Key insight**

> All safe methods are idempotent, but not all idempotent methods are safe.

This distinction enables:

* Retries
* Network resilience
* Client-side optimizations

---

## 🧱 REST Principle #4: Meaningful HTTP Status Codes

Status codes are **not decorations** — they are **communication primitives**.

### 2xx — Success

* Request succeeded
* Server fulfilled intent

### 3xx — Redirection / Caching

* Client can reuse cached data
* Resource moved or unchanged

### 4xx — Client Errors

* Client sent invalid request
* Client must fix input

### 5xx — Server Errors

* Server failed despite valid request
* Client may retry later

**Intuition**

> Status codes tell clients *who is responsible* for the outcome.

---

## 🧱 REST Principle #5: Status Codes Must Match Intent

Examples:

| Scenario           | Correct Code              |
| ------------------ | ------------------------- |
| Invalid input      | 400 Bad Request           |
| Unauthenticated    | 401 Unauthorized          |
| Unauthorized       | 403 Forbidden             |
| Resource not found | 404 Not Found             |
| Duplicate resource | 409 Conflict              |
| Too many requests  | 429 Too Many Requests     |
| Server crash       | 500 Internal Server Error |

❌ Returning `200 OK` with error messages breaks REST semantics.

---

## 🧱 REST Principle #6: Statelessness

Each request must:

* Contain all required context
* Not depend on server memory

**Intuition**

> Statelessness enables horizontal scaling.

Sessions, if used, must be:

* Token-based
* Explicit
* Externally stored

---

## 🧱 REST Principle #7: Conditional Requests & Caching

REST encourages **efficient data transfer**.

Mechanisms:

* ETag
* If-None-Match
* 304 Not Modified

**Intuition**

> Don’t resend data the client already has.

This improves:

* Performance
* Bandwidth usage
* Client responsiveness

---

## 🧱 REST Principle #8: Content Negotiation

Clients can request:

* Different formats (JSON, XML)
* Different versions
* Different representations

Server decides **how to represent the resource**, not the client.

**Intuition**

> Same resource, multiple representations.

---

## 🚫 What RESTPrinciples Project Deliberately Avoids

* ❌ Business logic
* ❌ Databases
* ❌ Authentication
* ❌ Validation rules

Why?

> REST principles must be understood **before** layering complexity.

---

## 🧠 Common REST Misconceptions (Interview Traps)

### ❌ “REST means CRUD over HTTP”

Wrong.

> REST is about **uniform interfaces**, not CRUD.

---

### ❌ “REST is outdated”

Wrong.

> REST underpins HTTP itself — modern APIs still rely on it.

---

### ❌ “Status codes are optional”

Wrong.

> Without correct status codes, clients cannot behave correctly.

---

## 🎤 Interview-Ready Takeaways

You should confidently say:

> “REST is about predictable communication, not frameworks.”

> “HTTP methods and status codes are part of the API contract.”

> “I design APIs around resources and state transitions, not actions.”

These answers signal **deep backend understanding**.

---