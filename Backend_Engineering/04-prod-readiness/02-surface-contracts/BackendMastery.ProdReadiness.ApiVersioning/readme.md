# BackendMastery.ProdReadiness.ApiVersioning

## API Versioning — Controlled Evolution of Contracts

---

## 📌 What this project is about (concept first)

This project demonstrates **how APIs evolve safely over time** without breaking consumers.

Versioning is not about URLs or headers.
It is about **honoring old promises while making new ones**.

Once an API is consumed in production, **change becomes a coordination problem**, not a coding problem.

---

## 🧠 Core intuition

> **Versioning exists because contracts outlive code.**

You version APIs **only when the meaning, shape, or guarantees change**.

If a client must change their code to keep working →
**you introduced a breaking change** → **you need a new version**.

---

## ❓ Production problem this solves

Without versioning discipline:

* Breaking changes go live silently
* Clients are forced to upgrade immediately
* Rollbacks become risky
* Teams become afraid to evolve APIs

This results in:

* frozen contracts
* duplicated endpoints
* undocumented behavior

Versioning restores **confidence to change**.

---

## 🌍 Real-world reasons that REQUIRE versioning

These are **non-negotiable breaking changes**.

---

### 1️⃣ Renaming a field ❌

```json
// v1
{
  "totalAmount": 500
}

// v2
{
  "amount": 500
}
```

➡️ Existing clients fail deserialization
➡️ **New version required**

---

### 2️⃣ Removing a field ❌

```json
// v1
{
  "status": "PAID",
  "legacyCode": "X1"
}
```

Removing `legacyCode` breaks clients relying on it.

➡️ **New version required**

---

### 3️⃣ Changing field semantics ❌

```json
// v1
status = "CREATED" | "PAID"

// v2
state = "PENDING" | "COMPLETED"
```

Same concept, **different meaning**.

➡️ **New version required**

---

### 4️⃣ Changing response structure ❌

```json
// v1
{ "items": [...] }

// v2
{ "data": { "items": [...] } }
```

➡️ **New version required**

---

## 🚫 Changes that do NOT require versioning

These are **safe, backward-compatible changes**.

### ✅ Adding a new optional field

```json
{
  "orderId": "...",
  "status": "PAID",
  "currency": "INR"
}
```

Clients ignoring unknown fields continue to work.

➡️ **No new version**

---

### ✅ Adding a new endpoint

Existing consumers are unaffected.

➡️ **No new version**

---

### ✅ Bug fixes with same behavior

If behavior matches the documented contract.

➡️ **No new version**

---

## 🧱 Versioning strategy used in this project

### ✔ URI-based versioning

```
/api/v1/orders
/api/v2/orders
```

**Why this strategy**

* Explicit and discoverable
* Easy to reason about
* Easy to document
* Clear ownership per version

Other strategies (headers, media-type) are discussed conceptually, but **URI-based versioning keeps intent obvious**.

---

## 🧩 What this project demonstrates

### 1️⃣ Multiple versions live side-by-side

* V1 remains stable
* V2 evolves freely
* Clients choose when to migrate

---

### 2️⃣ Explicit breaking change reasons

V2 introduces:

* Field rename (`TotalAmount` → `Amount`)
* Semantic change (`Status` → `State`)
* New optional field (`Currency`)

All changes are **intentional and explicit**.

---

### 3️⃣ Clear separation of contracts per version

* No shared DTOs
* No “if version == …” logic
* Each version owns its contract

This avoids accidental breakage.

---

## 🔁 Industry-standard way to transform V1 → V2

### 🧠 Key rule

> **Never transform versions in controllers.**

Controllers define contracts.
Transformation belongs to a **translation layer**.

---

### ✔ Recommended pattern: Version Translator / Mapper

In real systems, you introduce a **version adapter**.

Example (conceptual):

```csharp
public static class OrderVersionTranslator
{
    public static V2.OrderResponse FromV1(V1.OrderResponse v1)
    {
        return new V2.OrderResponse
        {
            OrderId = v1.OrderId,
            State = v1.Status switch
            {
                "PAID" => "COMPLETED",
                _ => "PENDING"
            },
            Amount = v1.TotalAmount,
            Currency = "INR"
        };
    }
}
```

---

### 🔍 Why this is industry-standard

* Keeps contracts isolated
* Makes breaking changes explicit
* Allows gradual migration
* Enables shadow traffic / dual responses
* Simplifies deprecation

---

### ❌ What NOT to do

| Anti-pattern                | Why it fails                  |
| --------------------------- | ----------------------------- |
| `if (version == 1)` logic   | Spreads versioning everywhere |
| Reusing same DTO            | Accidental breaking changes   |
| Transforming in controllers | Tight coupling                |
| “Temporary” hacks           | They become permanent         |

---

## 🧱 Project structure

```
BackendMastery.ProdReadiness.ApiVersioning/
│
├── Controllers/
│   ├── V1/
│   │   └── OrdersController.cs
│   └── V2/
│       └── OrdersController.cs
│
├── Contracts/
│   ├── V1/
│   │   └── OrderResponse.cs
│   └── V2/
│       └── OrderResponse.cs
│
├── Configuration/
│   └── ApiVersioningConfiguration.cs
│
├── Program.cs
├── appsettings.json
└── README.md
```

---

## ⚠️ Common versioning mistakes highlighted

| Mistake                           | Consequence            |
| --------------------------------- | ---------------------- |
| Versioning too early              | Maintenance overhead   |
| Never versioning                  | Silent client breakage |
| Multiple active versions forever  | Complexity explosion   |
| No deprecation plan               | Forced rewrites        |
| Sharing contracts across versions | Hidden coupling        |

---

## 🧠 How this transfers to other stacks

The concept is universal:

| Stack         | Equivalent               |
| ------------- | ------------------------ |
| REST          | URI / header versioning  |
| gRPC          | `.proto` evolution rules |
| GraphQL       | Field deprecation        |
| Event systems | Schema versioning        |

Frameworks differ.
**Versioning discipline does not.**

---

## 🎯 Outcome of completing this project

After this project, you should be able to:

* Decide **when versioning is necessary**
* Explain **why some changes don’t need versions**
* Design side-by-side API versions
* Implement safe contract evolution
* Migrate clients without breaking them

---

## 🧭 Mental model to carry forward

> **Change is inevitable.
> Breaking consumers is optional.**

Versioning is how mature systems evolve.

---
