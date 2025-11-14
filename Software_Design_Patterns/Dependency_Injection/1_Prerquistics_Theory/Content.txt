# Prerequisites — Dependency Injection

## What Is Dependency Injection?
Dependency Injection (DI) is a design pattern in which an object receives its dependencies from an external source rather than creating them itself.
In simple terms, instead of creating objects directly inside a class, you "inject" them from outside.

## Why Do We Need DI?
- Removes tight coupling between classes.
- Allows swapping implementations easily.
- Makes code testable using mocks/fakes.
- Supports SOLID principles (especially Dependency Inversion).

## Real Industry Use Case
**Payment Authorization System** — An order service must use Stripe, PayPal, or any other provider. DI allows switching providers without touching business logic.

## Core Idea
> "Depend on abstractions, not concrete implementations."

## Why Dependency Injection?
Flexibility: It allows you to easily swap out dependencies without changing the core logic of the class.
Loose Coupling: By injecting dependencies, your classes become decoupled from the specific implementations, making your system easier to maintain and extend.
Testability: Since dependencies are injected, it's easier to replace them with mock objects or stubs for unit testing.
