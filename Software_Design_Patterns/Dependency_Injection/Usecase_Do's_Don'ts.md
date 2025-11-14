## Table for Symptoms and DI Solutions

| **Symptom**                                   | **Fix with DI**                       |
|-----------------------------------------------|----------------------------------------|
| Classes use `new` for internal collaborators  | Use **Constructor Injection**          |
| Cannot mock services in tests                 | Inject dependency via **Interface**    |
| Adding a feature breaks old code              | Use **Abstraction** and **Inject**     |
| Too many `if` / `switch` for service types    | Inject appropriate **Strategy Implementation** |

---

## When not to use Dependency Injection
While Dependency Injection (DI) is a powerful design pattern, it is not always necessary. Here are some situations where DI may not be needed:

1. Tiny Classes with zero dependencies
If a class is small and doesn't rely on any other services or components, there is no need to introduce DI. The simplicity of such classes doesn't justify the added complexity of dependency injection.
2. Static utility classes:
Static classes that provide utility functions (like string manipulation or date handling) don't require DI because they don't have any instance dependencies. Their behavior remains the same across all calls and does not change based on external factors.
3. One-off scripts or tools
For small, isolated scripts or tools used just once, the overhead of introducing DI might not be necessary. In such cases, simplicity and direct implementation may be more efficient than using a design pattern like DI.