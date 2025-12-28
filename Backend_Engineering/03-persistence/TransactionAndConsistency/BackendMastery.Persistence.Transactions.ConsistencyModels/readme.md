# Consistency Models — Strong vs Eventual

**(Persistence & Data — Transactions & Consistency | Project 2)**

---

## 🎯 Purpose of This Project

This project exists to answer a **non-obvious but critical question** in distributed systems:

> **Do users always need the latest data, or do they just need data that becomes correct over time?**

Choosing the wrong consistency model leads to:

* High latency
* Poor scalability
* Unnecessary complexity
* Bad user experience

This project teaches **how to choose consistency intentionally**, based on business needs.

---

## 🧠 Core Intuition

> **Consistency is a spectrum, not a binary choice.**

* **Strong consistency**

  * Every read sees the latest write
  * Higher latency
  * Harder to scale
* **Eventual consistency**

  * Reads may be stale temporarily
  * Faster and scalable
  * System converges over time

> **The real mistake is demanding strong consistency everywhere.**

---

## 📂 Project Structure

```
BackendMastery.Persistence.Transactions.ConsistencyModels
│
├── Domain
│   ├── Order.cs                 # Business entity
│   └── OrderStatus.cs           # Lifecycle states
│
├── Stores
│   ├── StronglyConsistentStore.cs   # Immediate consistency
│   └── EventuallyConsistentStore.cs # Delayed convergence
│
├── Services
│   └── OrderStatusService.cs     # Chooses consistency per use case
│
├── Program.cs                   # Console demo
└── README.md
```

The structure reflects **real system thinking**, not framework structure.

---

## 🟦 Domain Perspective

The domain defines:

* What correctness means
* Which operations are critical
* Which updates can tolerate delay

### Order creation

* Must be strongly consistent
* User expects immediate confirmation

### Order status updates

* Can be eventually consistent
* Minor delays are acceptable

> **Not all domain operations require the same consistency guarantees.**

---

## 🟥 Strong Consistency

### When to use

* Payments
* Inventory checks
* Order creation
* Financial operations

### Guarantees

* Reads always reflect the latest write
* No stale data exposure

### Trade-off

* Higher latency
* Reduced scalability

> **Use strong consistency only where correctness is mandatory.**

---

## 🟩 Eventual Consistency

### When to use

* Notifications
* Dashboards
* Search results
* Status tracking

### Guarantees

* System converges over time
* Temporary staleness is acceptable

### Trade-off

* Users may see outdated data briefly

> **Eventual consistency optimizes system throughput and user experience.**

---

## 🧩 Service Layer Responsibility

The service layer:

* Chooses consistency per operation
* Writes to both strong and eventual stores
* Encodes business intent

> **Consistency is a business decision, not a database setting.**

---

## 🧠 Why This Is a Console Application

This project uses a **console app** to:

* Remove database complexity
* Focus on consistency behavior
* Make timing effects visible
* Reinforce conceptual understanding

`Program.cs` acts as the **composition root**, just like in real applications.

---

## 🚫 Common Mistakes This Project Prevents

* ❌ Using strong consistency for every read
* ❌ Treating eventual consistency as a bug
* ❌ Mixing consistency models unintentionally
* ❌ Ignoring business tolerance for staleness

These mistakes limit scalability and flexibility.

---

## 🎯 Real-World Use Cases

| Scenario           | Consistency |
| ------------------ | ----------- |
| Payment processing | Strong      |
| Order placement    | Strong      |
| Order tracking     | Eventual    |
| Notifications      | Eventual    |
| Search             | Eventual    |

---

## 🧠 Interview-Ready Explanation

You should be able to say:

> **“Consistency is a business decision. Strong consistency guarantees correctness, while eventual consistency trades freshness for scalability.”**

This answer signals **production experience**.

---

## ✅ Completion Checklist

You’ve mastered this project if you can explain:

* Difference between strong and eventual consistency
* Why eventual consistency exists
* When staleness is acceptable
* How systems converge over time

If all are clear — **this project is complete**.

---