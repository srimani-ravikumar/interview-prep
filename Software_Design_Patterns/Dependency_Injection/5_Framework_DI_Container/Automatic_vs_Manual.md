# Manual DI vs Automatic DI in .NET (C#)

## 1. Manual Dependency Injection

👉 **You create and wire dependencies yourself.**

### Example

```csharp
public interface IMessageService
{
    void Send(string message);
}

public class EmailService : IMessageService
{
    public void Send(string message) => Console.WriteLine("Email: " + message);
}

public class NotificationManager
{
    private readonly IMessageService _messageService;

    // Manually injecting dependency
    public NotificationManager()
    {
        _messageService = new EmailService(); // Manual creation & tight coupling
    }

    public void Notify() => _messageService.Send("Hello!");
}
```

### ❌ Problems

* Tight coupling (depends on concrete class)
* Hard to replace implementations
* Difficult to unit test
* Not scalable

---

## 2. Automatic Dependency Injection (Framework DI)

👉 **Framework creates & injects dependencies using the DI container.**

### Registration

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<IMessageService, EmailService>();
    services.AddTransient<NotificationManager>();
}
```

### Consumption

```csharp
public class NotificationManager
{
    private readonly IMessageService _messageService;

    // Framework automatically injects EmailService
    public NotificationManager(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Notify() => _messageService.Send("Hello!");
}
```

### ✔ Benefits

* No manual `new EmailService()`
* Loosely coupled code via interfaces
* Easy to swap implementations
* Built-in lifetime management (Singleton / Scoped / Transient)
* Cleaner, scalable, and testable

---

## 3. Comparison Table

| Feature             | Manual DI                      | Automatic DI (Framework)       |
| ------------------- | ------------------------------ | ------------------------------ |
| **Object creation** | Done manually using `new`      | Handled by DI container        |
| **Coupling**        | Tight (to concrete types)      | Loose (depends on interfaces)  |
| **Injection**       | You wire dependencies          | Framework auto-injects         |
| **Flexibility**     | Hard to switch implementations | Change registration only       |
| **Testing**         | Manual mocks                   | Mocks injected via container   |
| **Lifecycle mgmt**  | You manage manually            | Singleton / Scoped / Transient |
| **Boilerplate**     | High                           | Low                            |

---

## 📝 Closing Note

**Manual DI = You create + wire dependencies.
Automatic DI = Framework handles creation + injection using a DI container.**

---