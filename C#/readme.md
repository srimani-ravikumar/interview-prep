# 📘 C# Fundamentals – File-Based Learning Repository

This repository contains **base-level, file-based C# programs** designed for:

* Strong fundamentals
* Interview readiness (SDE-1 / Junior roles)
* Clear intuition-first learning

Each `.cs` file:

* Demonstrates **one core concept**
* Is **self-contained** and runnable
* Uses **clean, defensive coding practices**
* Avoids over-engineering

---

## 📂 Folder Structure

```text
CSharp-Fundamentals/
│
├── 01-Basics/
│   │
│   ├── Console/
│   │   ├── ConsoleInputValidationAndSum.cs
│   │   └── StringInterpolationDemo.cs
│   │
│   ├── ControlFlow/
│   │   ├── Branches/
│   │   │   ├── IfElseExamples.cs
│   │   │   └── SwitchCaseExamples.cs
│   │   │
│   │   └── Loops/
│   │       └── WhileDoWhileExamples.cs
│   │
│   └── TypeConversion/
│       └── TryParseVsParse.cs
│
└── README.md
```

---

## 🧭 Naming Conventions

### 📄 File Names

* Verbose and descriptive
* Explain **what is being demonstrated**

✅ Good examples:

* `ConsoleInputValidationAndSum.cs`
* `TryParseVsParse.cs`
* `LoopsWhileDoWhile.cs`

❌ Avoid:

* `Program.cs`
* `Sample.cs`
* `Test1.cs`

---

### 📦 Namespace Convention

```csharp
namespace Basics.<Category>
```

Examples:

* `Basics.Console`
* `Basics.ControlFlow`
* `Basics.Loops`
* `Basics.TypeConversion`

This mirrors the folder structure and improves readability.

---

### 🏷️ Class Naming

* Class name = file name
* No generic `Program` classes

```csharp
public class ConsoleInputValidationAndSum
```

This makes GitHub navigation and interview discussion easier.

---

## 🎯 Design Principles Used

* **Defensive coding** (`TryParse`, loops for validation)
* **Single Responsibility** (one concept per file)
* **Beginner-readable flow**
* **Interview explainable line-by-line**

---

## 👨‍💻 How to Run

Each file is independent.

```bash
dotnet new console
# Replace Program.cs with any file from this repo
# Run

dotnet run
```

---

## 📌 Target Audience

* Beginners learning C#
* Engineers revising fundamentals
* SDE-1 interview preparation
* Developers building strong foundations

---

## 🚀 Roadmap (Next Additions)

* Arrays vs List demo
* Dictionary basics
* Methods with parameters
* ref / out / in examples
* Exception handling basics
* LINQ intro (minimal)

---

## SOLID — CRISP SUMMARY (memoize this)

| Principle | One-line explanation             |
| --------- | -------------------------------- |
| SRP       | One class → one reason to change |
| OCP       | Extend behavior, don’t modify    |
| LSP       | Child must replace parent safely |
| ISP       | Many small interfaces > one big  |
| DIP       | Depend on abstractions           |

---

## ⭐ Final Note

This repository is intentionally **simple, explicit, and readable**.
The goal is mastery of fundamentals — not showing off language tricks.

Happy coding 💪