# Quick Guide — C#

---

<aside>
💡

https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/

</aside>

---

# A. Language Fundamentals

## **1. Data Types**

## 📌 What problem does this solve?

Understanding **how data is stored, copied, and passed** in C# is critical to:

- Avoid unintended side effects
- Write performant code
- Correctly reason about method behavior

Most **real interview bugs** come from misunderstanding this topic.

---

## 🧠 Intuition (Plain English)

> “Do I get a copy of the data, or a pointer to the same data?”
> 

That single question defines **value vs reference**.

---

## 🧩 How It Works Internally (Mental Model)

### Value Type

- Holds the **actual data**
- Assignment → **copies data**
- Each variable is **independent**

### Reference Type

- Holds a **reference (address)**
- Assignment → **copies reference**
- Multiple variables point to **same object**

---

## 🔹 Value Types

### Characteristics

- Stored **directly** (usually on stack)
- Can move to heap via **boxing**
- Fast allocation & cleanup
- Copy semantics

### Examples

```
int,float,double,bool,char,struct,enum

```

### Behavior

```csharp
int a =10;
int b = a;// COPY of value

b =20;

Console.WriteLine(a);// 10
Console.WriteLine(b);// 20

```

✔ Changes do **not** affect each other.

---

## 🔹 Reference Types

### Characteristics

- Object lives on **heap**
- Stack stores **reference**
- Shared mutable state
- Reference semantics

### Examples

```csharp
class,interface,array,string,object,delegate,record

```

### Behavior

```csharp
Person p1 =new Person();
Person p2 = p1;// COPY of reference

p2.Age =30;

Console.WriteLine(p1.Age);// 30

```

✔ Both point to **same object**.

---

## ⭐ WHY VALUE VS REFERENCE MATTERS (Interview Gold)

### 1️⃣ Performance

- Value types → cheap allocation, no GC pressure
- Reference types → heap allocation + GC

### 2️⃣ Mutability

- Value types → isolated changes
- Reference types → shared changes

### 3️⃣ Method Passing Semantics

- Value type → **copy passed**
- Reference type → **reference copied**

⚠ Reference is copied, **not the object**

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;

class Program
{
    static void Main()
    {
        // -------- VALUE TYPE --------
        int x = 10;
        ModifyValue(x);
        Console.WriteLine(x); // 10 (unchanged)

        // -------- REFERENCE TYPE --------
        Person p = new Person { Age = 25 };
        ModifyReference(p);
        Console.WriteLine(p.Age); // 99 (changed)
    }

    static void ModifyValue(int value)
    {
        value = 99;
        // Modifies local COPY only
    }

    static void ModifyReference(Person person)
    {
        person.Age = 99;
        // Modifies the SAME object on heap
    }
}

class Person
{
    public int Age { get; set; }
}
```

---

## 🎯 Interview Question (Must-Memorize)

### ❓ *What happens when passing value types to a method?*

✅ **Answer:**

> “A copy of the value is passed. Modifying it inside the method does not affect the caller unless ref or out is used.”
> 

---

## 🆚 Value vs Reference (Quick Table)

| Aspect | Value Type | Reference Type |
| --- | --- | --- |
| Stores | Actual data | Reference |
| Assignment | Copies data | Copies reference |
| Mutability | Isolated | Shared |
| GC impact | Minimal | Higher |
| Boxing | Possible | Not applicable |

---

## 🚨 Common Interview Traps

1. ❌ *“Reference types are passed by reference”*
    
    → Reference is passed **by value**
    
2. ❌ *“Structs are always on stack”*
    
    → Can be boxed → heap
    
3. ❌ *“Strings behave like value types”*
    
    → Reference type + immutability
    

---

## 🎯 Interview One-Liners

- **Why does this matter?**
    
    → “It affects performance, correctness, and side effects.”
    
- **Why use value types?**
    
    → “For small, immutable data with no shared state.”
    
- **When to prefer reference types?**
    
    → “When identity and shared state matter.”
    

---

## **2. Type Conversions**

## 📌 What problem does this solve?

Different data types **cannot always interact directly**.

Type conversions allow you to:

- Move data between types safely
- Handle user input and external data
- Control precision and data loss explicitly

---

## 🧠 Intuition (Plain English)

> “Can this value fit into the target type without losing information?”
> 
- If **yes** → implicit
- If **no** → explicit or conversion API

---

## 🧩 How Type Conversion Works Internally

- Implicit conversions are checked **at compile time**
- Explicit conversions may cause **data loss**
- `Convert` and `Parse` perform **runtime checks**
- Boxing may occur when converting to `object`

---

## 🔍 Types of Conversions

### **1️⃣ Implicit Conversion**

- Safe
- No data loss
- No cast required

```csharp
int x =10;
long y = x;// int → long

```

✔ Widening numeric conversions only

❌ No implicit conversion from `long → int`

---

### **2️⃣ Explicit Conversion (Casting)**

- Risky
- Data loss possible
- Cast required

```csharp
double d =10.5;
int i = (int)d;// truncates → 10

```

⚠ **Edge cases (important):**

```csharp
double big =1e20;
int x = (int)big;// overflow → undefined value

```

```csharp
int a =int.MaxValue;
checked
{
    a++;// throws OverflowException
}

```

💡 **Interview tip:**

Casting does **not** round — it **truncates**

---

### **3️⃣ Convert Class**

- Handles multiple input types
- Safer for runtime data
- Converts `null → 0`

```csharp
Convert.ToInt32(null);// 0
Convert.ToInt32("123");// 123

```

⚠ **Edge cases:**

```csharp
Convert.ToInt32("10.5");// FormatException
Convert.ToInt32(true);// 1
Convert.ToInt32(false);// 0

```

💡 Uses `IConvertible` internally

---

### **4️⃣ Parse vs TryParse**

Used mainly for **string → value type** conversions.

```csharp
int.Parse("123");// OK
int.TryParse("123",outint n);// true

```

⚠ **Edge cases:**

```csharp
int.Parse(null);// ArgumentNullException
int.Parse("abc");// FormatException

```

```csharp
bool ok =int.TryParse(null,outint x);// false

```

✔ `TryParse` **never throws**

✔ Always prefer for user input / APIs

---

## ❗ Common Interview Traps

1. ❌ *“Casting rounds values”*
    
    → Casting **truncates**
    
2. ❌ *“Convert never throws”*
    
    → Throws on invalid formats
    
3. ❌ *“TryParse gives default value”*
    
    → It returns `false`, output is default
    
4. ❌ *“Overflow always throws”*
    
    → Only inside `checked`
    

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;

class Program
{
    static void Main()
    {
        // -------- IMPLICIT --------
        int a = 10;
        long b = a;

        // -------- EXPLICIT --------
        double d = 10.9;
        int i = (int)d; // truncates

        // -------- CONVERT --------
        int x = Convert.ToInt32(null);     // 0
        int y = Convert.ToInt32("123");    // 123

        // -------- PARSE --------
        int p = int.Parse("456");

        // -------- TRYPARSE --------
        bool ok = int.TryParse("789", out int t);

        // -------- OVERFLOW --------
        try
        {
            checked
            {
                int max = int.MaxValue;
                max++;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Overflow detected");
        }
    }
}
```

---

## 🎯 Interview: Cast vs Convert.ToInt32

| Cast | Convert.ToInt32 |
| --- | --- |
| Compatible numeric types | Strings, bool, null |
| Faster | Slower |
| May overflow silently | Throws on overflow |
| Compile-time | Runtime |

---

## 🚨 Real-World Best Practices

✅ Use **implicit** conversions whenever possible

✅ Use `TryParse` for all external input

✅ Use `checked` in financial / critical code

❌ Avoid `Parse` in production APIs

---

## 🎯 Interview One-Liners

- **Why TryParse?**
    
    → “Prevents exceptions for invalid input.”
    
- **What happens on numeric overflow?**
    
    → “Silent unless inside `checked`.”
    
- **Cast vs Convert?**
    
    → “Cast is faster but limited; Convert is safer but runtime-based.”
    

---

## **3. var vs dynamic**

## 📌 What problem does this solve?

Both `var` and `dynamic` let you **avoid explicitly writing a type name**, but they solve **very different problems**:

- `var` → reduces **verbosity**
- `dynamic` → enables **runtime flexibility**

Misunderstanding this causes **runtime crashes** and **bad design choices**.

---

## 🧠 Intuition (Plain English)

> var: “Compiler, you figure out the type — I still want safety.”
> 
> 
> **`dynamic`**: “I’ll figure it out at runtime — trust me.”
> 

---

## 🔍 `var`

### Characteristics

- Compile-time typing
- Type is **fixed at compile time**
- Full IntelliSense & refactoring support
- Zero runtime cost

```csharp
var x =10;// int
var s ="text";// string

```

❌ Cannot change type later:

```csharp
var x =10;
x ="hello";// compile-time error

```

⚠ **Edge cases (important):**

```csharp
var n =null;// ❌ compile-time error (type cannot be inferred)

```

```csharp
var list =new[] {1,2,3 };// int[]

```

💡 **Interview truth:**

`var` is **not dynamic** — it’s just syntactic sugar.

---

## 🔍 `dynamic`

### Characteristics

- Runtime typing (late binding)
- No compile-time checks
- No IntelliSense safety
- Errors surface **only at runtime**

```csharp
dynamic d =10;
d ="hello";// allowed

```

```csharp
dynamic d =10;
d.Fly();// RuntimeBinderException

```

⚠ **Edge cases (very important):**

```csharp
dynamic x =null;
x.ToString();// RuntimeBinderException (null reference)

```

```csharp
dynamic obj =new { Name ="John" };
Console.WriteLine(obj.Name);// works
Console.WriteLine(obj.Age);// runtime error

```

💡 Uses **Dynamic Language Runtime (DLR)** under the hood.

---

## ⭐ WHY THIS MATTERS (Interview Gold)

### Performance

- `var` → compile-time resolved → **fast**
- `dynamic` → runtime binder → **slower**

### Safety

- `var` → compile-time guarantees
- `dynamic` → runtime crashes possible

### Usage intent

- `var` → readability & refactoring
- `dynamic` → interoperability & flexibility

---

## ❗ Common Interview Traps

1. ❌ *“var is weakly typed”*
    
    → No, it’s **strongly typed**
    
2. ❌ *“dynamic skips type checking entirely”*
    
    → Checked at **runtime**, not skipped
    
3. ❌ *“dynamic is only for JavaScript-like coding”*
    
    → Also used for **COM, JSON, reflection-heavy APIs**
    

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;

class Program
{
    static void Main()
    {
        // -------- var --------
        var a = 10;        // int
        var b = "hello";  // string
        // a = "world";   // ❌ compile-time error

        // -------- dynamic --------
        dynamic d = 10;
        d = "now string"; // allowed

        try
        {
            d.Fly(); // runtime error
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.GetType().Name);
        }

        // -------- dynamic + null --------
        dynamic n = null;
        try
        {
            n.ToString(); // runtime error
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.GetType().Name);
        }
    }
}
```

---

## 🎯 Interview: When does `dynamic` throw runtime errors?

✅ **Answer:**

> “When the resolved member does not exist, or when the runtime value is null or incompatible.”
> 

Examples:

- Calling a missing method
- Accessing a missing property
- Invoking members on `null`

---

## 🆚 `var` vs `dynamic` (Quick Table)

| Feature | `var` | `dynamic` |
| --- | --- | --- |
| Type resolution | Compile-time | Runtime |
| IntelliSense | ✅ Yes | ❌ No |
| Refactoring safety | ✅ High | ❌ Low |
| Runtime overhead | ❌ None | ✅ Yes |
| Can change type | ❌ No | ✅ Yes |

---

## 🚨 Real-World Best Practices

✅ Use `var` when type is obvious

✅ Use `dynamic` only when **required** (COM, JSON, reflection)

❌ Avoid `dynamic` in core business logic

❌ Never use `dynamic` to “skip typing”

---

## 🎯 Interview One-Liners

- **Is `var` dynamic?**
    
    → “No, it’s compile-time typed.”
    
- **Why is `dynamic` dangerous?**
    
    → “Errors appear only at runtime.”
    
- **When should I use `dynamic`?**
    
    → “When type is truly unknown until runtime.”
    

---

## **4. Nullable Types**

## 📌 What problem does this solve?

Value types (`int`, `bool`, `DateTime`) **cannot represent “no value”**.

Nullable types allow value types to:

- Represent **absence of data**
- Model **optional fields**
- Avoid magic values like `1` or `DateTime.MinValue`

---

## 🧠 Intuition (Plain English)

> “This value type may or may not have a value.”
> 

Instead of inventing fake defaults, nullable types make **absence explicit**.

---

## 🧩 How Nullable Types Work Internally

```csharp
int? n;

```

Is syntax sugar for:

```csharp
Nullable<int> n;

```

Internally it contains:

- `bool HasValue`
- `int Value`

---

## 🔍 Core Nullable Features

| Feature | Purpose |
| --- | --- |
| `T?` | Nullable value type |
| `HasValue` | Checks presence |
| `Value` | Access underlying value |
| `??` | Provide fallback |
| `??=` | Assign fallback if null |
| `?.` | Safe navigation |
| `GetValueOrDefault()` | Safe value extraction |

---

## ❗ Common Interview Traps

1. ❌ *“Nullable prevents null reference exceptions”*
    
    → Only if **used correctly**
    
2. ❌ *“Nullable is same as reference null”*
    
    → Value types behave **very differently**
    
3. ❌ *“Accessing `.Value` is safe”*
    
    → Throws if `HasValue == false`
    

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;

class Program
{
    static void Main()
    {
        // -------- NULLABLE VALUE TYPE --------
        int? n = null;

        // Safe check
        if (n.HasValue)
        {
            Console.WriteLine(n.Value);
        }

        // -------- NULL-COALESCING (??) --------
        int x = n ?? 0; // fallback if null

        // -------- NULL-COALESCING ASSIGNMENT (??=) --------
        n ??= 10; // assign only if n is null

        // -------- SAFE VALUE EXTRACTION --------
        int y = n.GetValueOrDefault();     // 10
        int z = n.GetValueOrDefault(99);   // custom default

        // -------- NULL-PROPAGATION (?.) --------
        Person person = null;
        string city = person?.Address?.City;
        // null-safe navigation

        // -------- NULLABLE BOXING --------
        int? a = 10;
        int? b = null;

        object boxedA = a; // boxes int
        object boxedB = b; // becomes null

        Console.WriteLine(boxedA);          // 10
        Console.WriteLine(boxedB == null);  // True
    }
}

class Person
{
    public Address Address { get; set; }
}

class Address
{
    public string City { get; set; }
}
```

---

## ⭐ Nullable Boxing (Interview Favorite)

| Nullable Value | Boxed Result |
| --- | --- |
| `int? x = 5` | Boxes `int` |
| `int? x = null` | `null` |

💡 **Important:**

Nullable itself is **not boxed** — only the underlying value is.

---

## 🆚 Nullable vs Reference Null

| Aspect | Nullable (`int?`) | Reference (`string`) |
| --- | --- | --- |
| HasValue | Yes | No |
| Boxing behavior | Special | Normal |
| Internal structure | Struct | Reference |
| Common use | Optional numbers | Optional objects |

---

## 🎯 Interview One-Liners

- **Why nullable types?**
    
    → “To represent absence of value for value types.”
    
- **What does `??` do?**
    
    → “Provides a default when the left side is null.”
    
- **What does `??=` do?**
    
    → “Assigns a value only if the variable is null.”
    
- **What happens when nullable is boxed?**
    
    → “Underlying value is boxed, null stays null.”
    

---

## 🚨 Real-World Best Practices

✅ Use nullable for **DB columns**

✅ Prefer `??` / `??=` over manual null checks

❌ Avoid `.Value` without `HasValue`

❌ Don’t use sentinel values (`-1`)

---

## **5. Strings**

## 📌 What problem does this solve?

Strings represent **textual data**, but they are used **everywhere** — logging, APIs, UI, file handling.

C# makes strings **immutable by design** to ensure:

- Thread safety
- Predictable behavior
- Performance optimizations (interning)

---

## 🧠 Intuition (Plain English)

> “A string never changes — every ‘change’ creates a new string.”
> 

This design:

- Prevents accidental modification
- Enables memory sharing
- Avoids subtle multi-threading bugs

---

## 🧩 How Strings Work Internally

- `string` is a **reference type**
- Stored on the **heap**
- **Immutable**
- Backed by a **character array**
- Literal strings are **interned**

---

## 🔍 Core String Characteristics

| Feature | Behavior |
| --- | --- |
| Type | Reference type |
| Mutability | ❌ Immutable |
| Thread-safe | ✅ Yes |
| Equality | Value-based |
| Interning | Automatic for literals |

---

## ❗ Common Interview Traps

1. ❌ *“String is a value type”*
    
    → No, it’s a **reference type with value semantics**
    
2. ❌ *“+= modifies the same string”*
    
    → It creates a **new object**
    
3. ❌ *“StringBuilder is always faster”*
    
    → Only for **repeated modifications**
    

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;
using System.Text;

class Program
{
    static void Main()
    {
        // -------- IMMUTABILITY --------
        string a = "Hello";
        string b = a + " World"; // NEW string created

        Console.WriteLine(a); // Hello
        Console.WriteLine(b); // Hello World

        // -------- STRING INTERNING --------
        string s1 = "test";
        string s2 = "test";

        Console.WriteLine(object.ReferenceEquals(s1, s2)); // True (same memory)

        string s3 = new string("test".ToCharArray());
        Console.WriteLine(object.ReferenceEquals(s1, s3)); // False (not interned)

        // -------- BAD: STRING CONCATENATION IN LOOP --------
        string result = "";
        for (int i = 0; i < 3; i++)
        {
            result += i;
            // Each iteration:
            // 1. Creates a new string
            // 2. Copies old content
            // 3. Discards previous string (GC pressure)
        }

        // -------- GOOD: STRINGBUILDER --------
        var sb = new StringBuilder();
        for (int i = 0; i < 3; i++)
        {
            sb.Append(i); // Mutates internal buffer
        }

        string finalResult = sb.ToString();
        Console.WriteLine(finalResult);
    }
}
```

---

## 🏎 StringBuilder (When & Why)

### Use `StringBuilder` when:

- Concatenating inside **loops**
- Building large strings dynamically
- Performance is critical

### Avoid `StringBuilder` when:

- Few concatenations
- Readability matters more than micro-optimizations

---

## 🎯 Interview Question: Why is string concatenation inside loops bad?

**Answer:**

> “Because strings are immutable, every concatenation creates a new object, causing repeated allocations, copying, and GC overhead.”
> 

---

## 🆚 String vs StringBuilder

| Feature | string | StringBuilder |
| --- | --- | --- |
| Mutability | ❌ Immutable | ✅ Mutable |
| Thread-safe | ✅ Yes | ❌ No |
| Performance (loops) | ❌ Poor | ✅ Excellent |
| Memory | Higher allocations | Reuses buffer |

---

## 🎯 Interview One-Liners

- **Why are strings immutable?**
    
    → “Thread safety, memory sharing, and predictable behavior.”
    
- **What is string interning?**
    
    → “Reusing identical string literals to save memory.”
    
- **When to use StringBuilder?**
    
    → “When strings change frequently, especially in loops.”
    

---

## 🚨 Real-World Rule of Thumb

- ≤ 2 concatenations → `string`
- Inside loops → `StringBuilder`
- Logging templates → `string interpolation`

---

## **6. Collections**

# 🔹 **1. Array**

---

## 📌 What problem does Array solve?

Arrays provide:

- **Fastest indexed access**
- **Contiguous memory**
- **Minimal overhead**

They are ideal when:

- Size is known upfront
- Performance is critical
- Memory layout matters

---

## 🧠 Intuition

> “A fixed-size box where every slot is known.”
> 

---

## 🔍 Key Characteristics

- Fixed size
- Zero-based indexing
- Stored contiguously in memory
- Value types stored inline

---

## 🎯 Commonly Used Members

| Member | Description |
| --- | --- |
| `Length` | Total number of elements |
| Indexer (`[]`) | Access by position |
| `Array.Copy` | Copy arrays |
| `Array.Sort` | Sort array |
| `Array.IndexOf` | Find index |

---

## 🧩 **ArrayDemo.cs** (Single File — All Demonstrations)

```csharp
using System;

classArrayDemo
{
staticvoidMain()
    {
// Declaration & Initialization
int[] numbers =newint[] {5,2,9,1 };

// Length
        Console.WriteLine($"Length: {numbers.Length}");

// Index access
        Console.WriteLine(numbers[0]);

// Modify
        numbers[1] =10;

// Sort
        Array.Sort(numbers);

// IndexOf
int index = Array.IndexOf(numbers,9);
        Console.WriteLine($"Index of 9: {index}");

// Copy
int[] copy =newint[numbers.Length];
        Array.Copy(numbers, copy, numbers.Length);

// Iterate
foreach (var nin copy)
        {
            Console.WriteLine(n);
        }
    }
}

```

---

# 🔹 **2. List<T>**

---

## 📌 What problem does List<T> solve?

List<T> provides:

- **Dynamic resizing**
- **Rich API**
- **Ordered storage**

Perfect for:

- General-purpose collections
- Unknown size
- Frequent add/remove

---

## 🧠 Intuition

> “An expandable array that manages resizing for you.”
> 

---

## 🧩 Internal Working (Interview Favorite)

- Backed by an **array**
- When full → **capacity doubles**
- Copy happens during resize

---

## 🔍 Properties

| Property | Description |
| --- | --- |
| `Count` | Number of elements |
| `Capacity` | Internal array size |

---

## 🔍 Methods (Most Used)

| Method | Purpose |
| --- | --- |
| `Add` | Add one item |
| `AddRange` | Add multiple |
| `Remove` | Remove by value |
| `RemoveAt` | Remove by index |
| `Contains` | Check existence |
| `IndexOf` | Find index |
| `Sort` | Sort list |
| `Clear` | Remove all |

---

## 🧩 **ListDemo.cs**

```csharp
using System;
using System.Collections.Generic;

classListDemo
{
staticvoidMain()
    {
        List<int> list =new List<int>();

// Add
        list.Add(10);
        list.Add(5);

// AddRange
        list.AddRange(new[] {20,15 });

// Count & Capacity
        Console.WriteLine($"Count: {list.Count}");
        Console.WriteLine($"Capacity: {list.Capacity}");

// Contains
        Console.WriteLine(list.Contains(10));

// IndexOf
        Console.WriteLine(list.IndexOf(20));

// Remove
        list.Remove(5);

// RemoveAt
        list.RemoveAt(0);

// Sort
        list.Sort();

// Iterate
foreach (var itemin list)
        {
            Console.WriteLine(item);
        }

// Clear
        list.Clear();
    }
}

```

---

# 🔹 **3. Dictionary<TKey, TValue>**

---

## 📌 What problem does Dictionary solve?

- **Fast key-based lookup**
- Near **O(1)** access
- No duplicate keys

Used for:

- Lookups
- Caches
- Maps

---

## 🧠 Intuition

> “A locker system — key opens exactly one value.”
> 

---

## 🔍 Properties

| Property | Description |
| --- | --- |
| `Count` | Number of entries |
| `Keys` | All keys |
| `Values` | All values |

---

## 🔍 Methods

| Method | Purpose |
| --- | --- |
| `Add` | Insert key-value |
| `ContainsKey` | Check key |
| `TryGetValue` | Safe lookup |
| `Remove` | Remove key |
| `Clear` | Remove all |

---

## 🧩 **DictionaryDemo.cs**

```csharp
using System;
using System.Collections.Generic;

classDictionaryDemo
{
staticvoidMain()
    {
        Dictionary<int,string> users =new Dictionary<int,string>();

// Add
        users.Add(1,"Alice");
        users.Add(2,"Bob");

// Count
        Console.WriteLine(users.Count);

// ContainsKey
        Console.WriteLine(users.ContainsKey(1));

// TryGetValue
if (users.TryGetValue(2,outstring name))
        {
            Console.WriteLine(name);
        }

// Keys
foreach (var keyin users.Keys)
        {
            Console.WriteLine(key);
        }

// Values
foreach (varvaluein users.Values)
        {
            Console.WriteLine(value);
        }

// Remove
        users.Remove(1);

// Clear
        users.Clear();
    }
}

```

---

# 🔹 **4. Queue<T> (FIFO)**

---

## 📌 What problem does Queue solve?

- Ordered processing
- First-come-first-served logic

---

## 🧠 Intuition

> “A real-world queue — first in, first out.”
> 

---

## 🧩 **QueueDemo.cs**

```csharp
using System;
using System.Collections.Generic;

classQueueDemo
{
staticvoidMain()
    {
        Queue<string> queue =new Queue<string>();

// Enqueue
        queue.Enqueue("Job1");
        queue.Enqueue("Job2");

// Count
        Console.WriteLine(queue.Count);

// Peek
        Console.WriteLine(queue.Peek());

// Dequeue
        Console.WriteLine(queue.Dequeue());

// Clear
        queue.Clear();
    }
}

```

---

# 🔹 **5. Stack<T> (LIFO)**

---

## 📌 What problem does Stack solve?

- Undo / Redo
- Backtracking
- Call stacks

---

## 🧠 Intuition

> “A pile — last item added is first removed.”
> 

---

## 🧩 **StackDemo.cs**

```csharp
using System;
using System.Collections.Generic;

classStackDemo
{
staticvoidMain()
    {
        Stack<int> stack =new Stack<int>();

// Push
        stack.Push(1);
        stack.Push(2);

// Count
        Console.WriteLine(stack.Count);

// Peek
        Console.WriteLine(stack.Peek());

// Pop
        Console.WriteLine(stack.Pop());

// Clear
        stack.Clear();
    }
}

```

---

# 🔹 **6. HashSet<T>**

---

## 📌 What problem does HashSet solve?

- Enforces **uniqueness**
- Fast `Contains`
- Set operations

---

## 🧠 Intuition

> “A bag that rejects duplicates.”
> 

---

## 🧩 **HashSetDemo.cs**

```csharp
using System;
using System.Collections.Generic;

classHashSetDemo
{
staticvoidMain()
    {
        HashSet<int>set =new HashSet<int>();

// Add
set.Add(1);
set.Add(2);
set.Add(2);// ignored

// Count
        Console.WriteLine(set.Count);

// Contains
        Console.WriteLine(set.Contains(1));

// Remove
set.Remove(1);

// UnionWith
set.UnionWith(new[] {3,4 });

// IntersectWith
set.IntersectWith(new[] {3 });

foreach (var iteminset)
        {
            Console.WriteLine(item);
        }
    }
}

```

---

## 🎯 Interview Closing Cheat Sheet

| Scenario | Collection |
| --- | --- |
| Fixed size, max speed | Array |
| Dynamic list | List |
| Key lookup | Dictionary |
| FIFO | Queue |
| LIFO | Stack |
| Unique values | HashSet |

---

## **7. Enums**

### 📌 What problem does this solve?

Enums solve the problem of **magic numbers and unclear state representation** by giving **meaningful names** to a fixed set of related values.

Instead of:

```csharp
if (status ==2) { ... }// What is 2?

```

You write:

```csharp
if (status == OrderStatus.Shipped) { ... }

```

---

## 🧠 Intuition (Plain English)

> “This variable can only have one of these known values, nothing else.”
> 

Enums:

- Improve **readability**
- Prevent **invalid values**
- Encode **business states** clearly

---

## 🧩 How Enums Work Internally

- Enums are **named constants**
- Backed by an **integral type** (`int` by default)
- Stored as **numbers at runtime**
- Names exist **only at compile time**

```csharp
enum Status { Pending =0, Approved =1 }
// Stored as int → 0 or 1

```

---

## 🔍 Key Characteristics

| Feature | Behavior |
| --- | --- |
| Default underlying type | `int` |
| Allowed underlying types | byte, short, int, long |
| Storage | Value type |
| Comparison | Numeric |
| Type safety | Strong |

---

## ❗ Common Interview Traps

1. ❌ *“Enums prevent invalid values”*
    
    → You can cast any `int` into an enum
    
2. ❌ *“Enums are strings”*
    
    → Names are compile-time only; runtime value is numeric
    
3. ❌ *“Enums can change freely”*
    
    → Changing values breaks DB/API contracts
    

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;

// ---------------- BASIC ENUM ----------------
public enum OrderStatus
{
    Pending    = 1,
    Processing = 2,
    Shipped    = 3,
    Delivered  = 4
}

// ---------------- FLAGS ENUM ----------------
[Flags]
public enum FilePermission
{
    None    = 0,
    Read    = 1, // 001
    Write   = 2, // 010
    Execute = 4  // 100
}

class Program
{
    static void Main()
    {
        // -------- BASIC ENUM USAGE --------
        OrderStatus status = OrderStatus.Processing;

        if (status == OrderStatus.Processing)
        {
            Console.WriteLine("Order is being processed");
        }

        // Enum to int (explicit cast)
        int statusCode = (int)status; // 2

        // int to enum (unsafe – no validation!)
        OrderStatus invalidStatus = (OrderStatus)99;
        Console.WriteLine(invalidStatus); // Prints "99"

        // -------- ENUM PARSING --------
        if (Enum.TryParse("Shipped", out OrderStatus parsed))
        {
            Console.WriteLine(parsed); // Shipped
        }

        // -------- FLAGS ENUM --------
        FilePermission permissions = FilePermission.Read | FilePermission.Write;

        // Check flag
        if (permissions.HasFlag(FilePermission.Read))
        {
            Console.WriteLine("Read allowed");
        }

        Console.WriteLine(permissions); // Read, Write
    }
}
```

---

## 🏷 Flags Enum (Interview MUST-KNOW)

### When to Use `[Flags]`

- When **multiple values can coexist**
- Permissions, features, capabilities

### When NOT to Use

- Mutually exclusive states (OrderStatus, PaymentStatus)

---

## 🔐 Enum Safety Best Practices

✅ Always **explicitly assign values**

✅ Never reorder existing enum values

✅ Validate user input (`Enum.IsDefined`)

✅ Use enums for **states**, not data

---

## 🆚 Enum vs Other Types

| Use Case | Best Choice |
| --- | --- |
| Fixed known states | Enum |
| Multiple independent options | Flags enum |
| Extensible data | Class / Record |
| Temporary grouping | Tuple |

---

## 🎯 Interview One-Liners

- **Why enums?**
    
    → “To represent a fixed set of named values safely.”
    
- **Why assign enum values explicitly?**
    
    → “To avoid breaking DB and API contracts.”
    
- **Why Flags enum?**
    
    → “To model combinable options efficiently.”
    

---

## 🚨 Real-World Interview Tip

❌ Bad:

```csharp
int status =3;

```

✅ Good:

```csharp
OrderStatus status = OrderStatus.Shipped;

```

---

## **8. Records**

## 📌 What problem does this solve?

In real-world applications, we often need to model **data**, not behavior — such as **DTOs, API models, events, and messages**.

Before records, using classes for this caused problems:

- Equality compared **references**, not data
- Required **manual overrides** of `Equals()` and `GetHashCode()`
- Immutability had to be **enforced manually**
- Easy to introduce bugs and boilerplate

Records solve this by:

- Making **value-based equality the default**
- Encouraging **immutable data models**
- Eliminating repetitive boilerplate code
- Making data objects **safer and more expressive** by design

> In short: records make data correctness the default instead of an afterthought.
> 

### What is a `record`?

A **record** is a data-centric type (introduced in **C# 9**) designed to:

- Represent **immutable data**
- Use **value-based equality**
- Reduce **boilerplate code**

It can be either:

- `record class` → reference type
- `record struct` → value type

---

## 🔍 Core Differences at a Glance

| Feature | Class | Struct | Record |
| --- | --- | --- | --- |
| Type | Reference | Value | Reference (default) / Value |
| Equality | Reference (default) | Value | **Value (by default)** |
| Immutability | Manual | Manual | **Built-in (`init`)** |
| Boilerplate | High | Medium | **Very low** |
| `with` expression | ❌ | ❌ | ✅ |
| Best for | Behavior + state | Small data | **DTOs, Models, Events** |

---

## 🧠 Why Records Exist (Interview Intuition)

> “Most enterprise applications pass data, not behavior.”
> 

Before records:

- DTOs required **manual equality**, `ToString`, immutability
- Easy to introduce bugs in `Equals()` / `GetHashCode()`

Records:

- Make **data correctness the default**
- Encourage **immutability**
- Are **safe for multi-threaded & functional-style code**

---

## ❗ Common Interview Traps

1. ❌ *“Records are immutable”*
    
    → **Only if you use `init` (default for positional records)**
    
2. ❌ *“Records are value types”*
    
    → **No. `record` = reference type, `record struct` = value type**
    
3. ❌ *“Structs always live on stack”*
    
    → **No. Depends on usage (boxing, fields, heap allocations)**
    

---

## 🧩 One Consolidated Code Example

```csharp
using System;

// -------------------- RECORD --------------------
public record Person(string FirstName, string LastName, int Age);
// Compiler auto-generates:
// - init-only properties (immutability)
// - value-based Equals + GetHashCode
// - == and != operators
// - Deconstruct()
// - readable ToString()

// -------------------- CLASS --------------------
public class PersonClass
{
    public string FirstName { get; set; }
    public int Age { get; set; }

    public PersonClass(string firstName, int age)
    {
        FirstName = firstName;
        Age = age;
    }
}

// -------------------- STRUCT --------------------
public struct PersonStruct
{
    public string FirstName { get; init; }
    public int Age { get; init; }

    public PersonStruct(string firstName, int age)
    {
        FirstName = firstName;
        Age = age;
    }
}

class Program
{
    static void Main()
    {
        // -------- RECORD BEHAVIOR --------
        var r1 = new Person("John", "Doe", 30);
        var r2 = new Person("John", "Doe", 30);

        Console.WriteLine(r1 == r2); // ✅ True (value equality)

        var r3 = r1 with { Age = 40 }; // Non-destructive mutation
        Console.WriteLine(r3);
        // Person { FirstName = John, LastName = Doe, Age = 40 }

        // -------- CLASS BEHAVIOR --------
        var c1 = new PersonClass("John", 30);
        var c2 = c1; // Copies reference
        c2.Age = 99;

        Console.WriteLine(c1.Age); // ❗ 99 (same object)

        // -------- STRUCT BEHAVIOR --------
        var s1 = new PersonStruct("John", 30);
        var s2 = s1; // Copies value
        s2 = new PersonStruct("John", 99);

        Console.WriteLine(s1.Age); // ✅ 30 (independent copy)
    }
}
```

---

## 🎯 Interview One-Liner Answers

- **Why records?**
    
    → “To model immutable data with value equality and minimal boilerplate.”
    
- **Record vs class?**
    
    → “Same memory model, different equality semantics.”
    
- **When to use record struct?**
    
    → “Small immutable value objects where copying is cheap.”
    

---

## **9. Tuples**

## 📌 What problem does this solve?

Sometimes you need to **group a few values temporarily** or **return multiple values from a method** without creating:

- a full class
- a struct
- or a record

Tuples provide a **lightweight, disposable data container** for this purpose.

---

## 🧠 Intuition (Plain English)

> “I want to return more than one value, but I don’t want to create a new type just for that.”
> 

Tuples:

- Are **not domain models**
- Are **not meant for long-term storage**
- Are best used for **method boundaries, internal logic, and quick grouping**

---

## 🧩 Types of Tuples in C#

### 1️⃣ Value Tuples (Modern – Recommended)

- Introduced in **C# 7.0**
- Implemented as **`ValueTuple` structs**
- Lightweight and fast
- Support **named elements**
- Support **deconstruction**

### 2️⃣ Reference Tuples (Legacy – Avoid)

- Introduced in **C# 4.0**
- Implemented as **`System.Tuple` classes**
- Heap allocated
- Poor readability (`Item1`, `Item2`)
- No deconstruction

---

## 🔍 Key Differences

| Feature | ValueTuple | System.Tuple |
| --- | --- | --- |
| Type | Struct (value type) | Class (reference type) |
| Allocation | Stack (usually) | Heap |
| Element Names | ✅ Supported | ❌ Item1, Item2 |
| Deconstruction | ✅ Yes | ❌ No |
| Performance | ✅ Faster | ❌ Slower |
| Usage Today | ✅ Preferred | ❌ Legacy only |

---

## ❗ Common Interview Traps

1. ❌ *“Tuples replace records”*
    
    → Tuples are **temporary**, records are **models**
    
2. ❌ *“Tuples are always stack allocated”*
    
    → Structs **can be heap allocated** depending on usage
    
3. ❌ *“Use tuples everywhere to avoid classes”*
    
    → Overuse hurts **readability and intent**
    

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;

class Program
{
    static void Main()
    {
        // ---------------- VALUE TUPLES ----------------

        // 1. Basic tuple (implicit names: Item1, Item2)
        var person1 = ("John", 30);
        Console.WriteLine(person1.Item1); // John

        // 2. Named tuple (RECOMMENDED)
        var person2 = (Name: "Jane", Age: 25);
        Console.WriteLine(person2.Name); // Jane

        // 3. Explicit type declaration
        (string Name, int Age) person3 = ("Mike", 40);
        Console.WriteLine(person3.Age); // 40

        // 4. Deconstruction (unpacking tuple values)
        var (name, age) = person2;
        Console.WriteLine($"{name} is {age} years old");

        // 5. Tuple returned from method
        var student = GetStudentDetails();
        Console.WriteLine($"{student.FullName} scored {student.Average}");

        // ---------------- LEGACY SYSTEM.TUPLE ----------------

        Tuple<string, int> legacyPerson = new Tuple<string, int>("Bob", 50);
        Console.WriteLine(legacyPerson.Item1); // Bob
    }

    // Returning multiple values using ValueTuple
    static (string FullName, double Average) GetStudentDetails()
    {
        // complex logic here
        return ("Alice Smith", 89.5);
    }
}
```

---

## 🎯 When to Use Tuples (Interview Answer)

✅ Use tuples when:

- Returning **multiple values from a method**
- Writing **internal helper logic**
- Data has **short lifetime**

❌ Avoid tuples when:

- Data represents a **domain concept**
- Passed across **layers (API, DB, UI)**
- Needs **validation or behavior**

👉 Use **Record** instead in those cases.

---

## 🆚 Tuple vs Record vs Class (Quick Interview Table)

| Scenario | Best Choice |
| --- | --- |
| Return multiple values | Tuple |
| DTO / API model | Record |
| Business logic + behavior | Class |
| Small immutable value | Record struct |

---

## 🧠 Interview One-Liners

- **Why tuples?**
    
    → “To return multiple values without creating a new type.”
    
- **Why ValueTuple over Tuple?**
    
    → “Better performance, readability, and modern language support.”
    
- **Tuple vs Record?**
    
    → “Tuples are temporary; records represent data models.”
    

---

# B. Methods & Control Flow

---

## 1. Control Flows

## 📌 What problem does this solve?

Control flow determines **how execution moves through code**.

It allows programs to:

- Make **decisions**
- Repeat **operations**
- React to **conditions**

Without control flow, code would execute **top to bottom only**, with no logic.

---

## 🧠 Intuition (Plain English)

- **Branching** → “Which path should I take?”
- **Looping** → “How many times should I repeat this?”

---

# 🌿 Branching Statements

Branching controls **decision-making** in code.

---

## 🔹 `if / else`

### When to use

- Simple or complex conditional logic
- When conditions are **not mutually exclusive**

```csharp
if (x >0)
{
    Console.WriteLine("Positive");
}
else if (x <0)
{
    Console.WriteLine("Negative");
}
else
{
    Console.WriteLine("Zero");
}
```

### Interview Edge Case

- Conditions evaluated **top to bottom**
- First match wins

---

## 🔹 `switch` Statement

### When to use

- Multiple **mutually exclusive** branches
- Cleaner than many `else if`

```csharp
switch (day)
{
		case 1:
		        Console.WriteLine("Monday");
		break;
		case 2:
		        Console.WriteLine("Tuesday");
		break;
		default:
		        Console.WriteLine("Invalid");
		break;
}
```

### Modern C# (Switch Expression)

```csharp
string result = day switch
{
		1 =>"Monday",
		2 =>"Tuesday",
    _ =>"Invalid"
};

```

### Interview Notes

- `break` required in classic switch
- Switch expressions are **exhaustive**

---

## ❗ Branching Interview Traps

1. ❌ *“switch is slower than if”*
    
    → Compiler optimizes both
    
2. ❌ *“switch only works with int”*
    
    → Works with enums, strings, patterns
    
3. ❌ *“default is optional”*
    
    → Optional but **recommended**
    

---

# 🔁 Looping Statements

Looping controls **repetition**.

---

## 🔹 `for` Loop

### When to use

- Known iteration count
- Index-based access

```csharp
for (int i = 0; i < 3; i++)
{
    Console.WriteLine(i);
}
```

### Interview Notes

- Initialization → condition → iteration
- Best for arrays when index needed

---

## 🔹 `foreach` Loop

### When to use

- Iterate collections
- No index needed
- Safer & cleaner

```csharp
foreach (var item in items)
{
    Console.WriteLine(item);
}
```

### Interview Edge Case

- Cannot modify collection structure
- Iteration variable is **read-only**

---

## 🔹 `while` Loop

### When to use

- Unknown iteration count
- Condition checked **before** loop

```csharp
while (x > 0)
{
    x--;
}
```

### Risk

- Infinite loops if condition never changes

---

## 🔹 `do-while` Loop

### When to use

- Loop must run **at least once**

```csharp
do
{
    Console.WriteLine("Runs once");
}
while (false);
```

---

## 🔹 `break` & `continue`

```csharp
for (int i = 0; i < 5; i++)
{
		if (i ==2) continue;// skip
		if (i ==4) break;// exit
    Console.WriteLine(i);
}
```

---

## ❗ Looping Interview Traps

1. ❌ *“foreach is slower than for”*
    
    → Usually same after JIT optimization
    
2. ❌ *“foreach allows modification”*
    
    → ❌ Not allowed structurally
    
3. ❌ *“do-while is same as while”*
    
    → Runs **at least once**
    

---

## 🆚 Loop Comparison (Quick Table)

| Loop | Condition Check | Use Case |
| --- | --- | --- |
| `for` | Before | Known count |
| `foreach` | Internal | Collections |
| `while` | Before | Unknown count |
| `do-while` | After | Must run once |

---

## 🎯 Interview One-Liners

- **When to use switch?**
    
    → “Multiple mutually exclusive conditions.”
    
- **for vs foreach?**
    
    → “Use `for` for index, `foreach` for safety.”
    
- **do-while special case?**
    
    → “Executes at least once.”
    

---

## 🚨 Real-World Best Practices

✅ Prefer `foreach` for collections

✅ Prefer switch expressions for mappings

❌ Avoid deeply nested `if-else`

❌ Avoid infinite loops

---

## **2. ref, out, in**

## 📌 What problem does this solve?

By default, C# passes **value types by value** (a copy).

Sometimes you need to:

- Modify the **original variable**
- Return **multiple values**
- Avoid copying **large structs** for performance

`ref`, `out`, and `in` allow parameters to be passed **by reference**, meaning the method works on the **original memory location**.

---

## 🧠 Intuition (Plain English)

- **`ref`** → “I want to **read and modify** this variable.”
- **`out`** → “I’ll **produce** this value for you.”
- **`in`** → “I want **read-only access** without copying.”

---

## 🧩 How It Works Internally

- All three pass the **address** of the variable
- No copy of the value is made
- Compiler enforces **different rules** for safety

⚠ Even reference types behave differently with these keywords.

---

## 🔍 Core Differences

| Keyword | Passed By | Must be initialized before call? | Can method modify value? | Primary Use |
| --- | --- | --- | --- | --- |
| `ref` | Reference | ✅ Yes | ✅ Yes | Modify existing value |
| `out` | Reference | ❌ No | ✅ Yes (must assign) | Return extra values |
| `in` | Reference | ✅ Yes | ❌ No (read-only) | Performance optimization |

---

## ❗ Common Interview Traps

1. ❌ *“ref and out are the same”*
    
    → Initialization rules differ
    
2. ❌ *“in makes code immutable”*
    
    → Only the parameter is read-only
    
3. ❌ *“Reference types don’t need ref”*
    
    → `ref` allows **reassignment**, not just mutation
    

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;

public class ParameterExamples
{
    // -------- ref --------
    // Must be initialized before call
    // Method can read and modify the value
    public static void IncrementRef(ref int value)
    {
        value += 1;
    }

    // -------- out --------
    // No need to initialize before call
    // Method MUST assign before returning
    public static void GetNewValueOut(out int value)
    {
        value = 100;
    }

    // -------- in --------
    // Must be initialized
    // Read-only reference (no modification)
    public static void ReadValueIn(in int value)
    {
        Console.WriteLine(value);
        // value = 99; ❌ compile-time error
    }

    public static void Main()
    {
        // ref
        int a = 10;
        IncrementRef(ref a);
        Console.WriteLine(a); // 11

        // out
        int b;
        GetNewValueOut(out b);
        Console.WriteLine(b); // 100

        // in
        int c = 50;
        ReadValueIn(in c);
        Console.WriteLine(c); // 50 (unchanged)
    }
}
```

---

## ⭐ IMPORTANT Edge Cases (Interview Gold)

### 1️⃣ `ref` with reference types

```csharp
void ChangeRef(ref Person p)
{
    p = new Person();// reassignment allowed
}
```

Without `ref`, reassignment would not affect caller.

---

### 2️⃣ `out` is commonly used with Try-patterns

```csharp
bool success = int.TryParse("123",out int result);
```

✔ Safe

✔ No exceptions

✔ Widely used in .NET APIs

---

### 3️⃣ `in` shines with large structs

```csharp
void Process(in BigStruct data)
{
// avoids copying large struct
}
```

✔ Performance optimization

❌ Overkill for small structs

---

## 🎯 Interview Questions & Answers

### ❓ What happens when passing a value type by `ref`?

> “The method receives a reference to the original variable, so changes affect the caller.”
> 

---

### ❓ When should you use `out`?

> “When a method’s purpose is to produce a value, especially for Try-style APIs.”
> 

---

### ❓ Why use `in`?

> “To avoid copying large structs while guaranteeing read-only access.”
> 

---

## 🆚 `ref` vs Reference Type Mutation (Important)

```csharp
void Modify(Person p)
{
    p.Age = 30;// works without ref
}

void Reassign(ref Person p)
{
    p = new Person();// requires ref
}
```

💡 `ref` is about **variable reassignment**, not just mutation.

---

## 🚨 Real-World Best Practices

✅ Use `out` for Try-patterns

✅ Use `ref` sparingly and intentionally

✅ Use `in` for **large immutable structs**

❌ Avoid overusing `ref` (hurts readability)

---

## 🎯 Interview One-Liners

- **Why ref?**
    
    → “To modify the caller’s variable.”
    
- **Why out?**
    
    → “To guarantee a value is produced.”
    
- **Why in?**
    
    → “For performance without mutation.”
    

---

## **3. params**

## 📌 What problem does this solve?

Sometimes a method needs to accept a **variable number of arguments**.

Without `params`, callers would need to:

- Manually create arrays
- Or overload methods multiple times

`params` lets callers pass **zero, one, or many arguments** naturally.

---

## 🧠 Intuition (Plain English)

> “I don’t know how many values you’ll pass — give me all of them as an array.”
> 

The compiler:

- Collects all supplied arguments
- Packs them into an array automatically

---

## 🧩 How `params` Works Internally

- `params` is just **syntax sugar**
- At runtime, the method **receives an array**
- The array is **created by the compiler**

```csharp
void Print(params int[] numbers)
```

Is treated internally as:

```csharp
void Print(int[] numbers)
```

---

## 🔍 Rules of `params` (MUST KNOW)

- Must be the **last parameter**
- Only **one `params` parameter** per method
- Parameter type must be an **array**

📌 Reason:

> Compiler cannot disambiguate argument grouping otherwise
> 

---

## ❗ Common Interview Traps

1. ❌ *“params accepts any collection”*
    
    → Only **arrays**
    
2. ❌ *“params avoids array allocation”*
    
    → Array **is still created**
    
3. ❌ *“params improves performance”*
    
    → It improves **usability**, not performance
    

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;

class Program
{
    static void Main()
    {
        PrintNumbers(1, 2, 3);
        PrintNumbers(); // zero arguments
        PrintNumbers(new int[] { 4, 5, 6 }); // explicit array
    }

    static void PrintNumbers(params int[] numbers)
    {
        Console.WriteLine($"Count: {numbers.Length}");

        foreach (var n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}
```

---

## ⭐ Important Edge Cases (Interview Gold)

### 1️⃣ `params` must be last

```csharp
// ❌ Compile-time error
void Test(params int[] x, string y) { }
```

```csharp
// ✅ Correct
void Test(string y, params int[] x) { }
```

---

### 2️⃣ Only one `params` allowed

```csharp
// ❌ Invalid
void Test(params int[] a,params int[] b) { }
```

Reason:

> Compiler cannot determine argument boundaries
> 

---

### 3️⃣ Passing `null`

```csharp
PrintNumbers(null);// numbers = null → NullReferenceException if not checked
```

✔ Always null-check inside method if needed

---

## 🆚 `params` vs Method Overloading

| Scenario | Better Choice |
| --- | --- |
| Variable argument count | `params` |
| Different logic per signature | Overloads |
| Performance critical | Explicit array |

---

## 🎯 Interview One-Liners

- **Why must `params` be last?**
    
    → “So the compiler can group remaining arguments.”
    
- **Does `params` avoid array creation?**
    
    → “No, it still creates an array.”
    
- **Can I pass an array explicitly?**
    
    → “Yes — `params` is optional at call site.”
    

---

## 🚨 Real-World Best Practices

✅ Use `params` for logging, formatting, helpers

✅ Combine with strong typing

❌ Avoid in performance-critical hot paths

❌ Avoid multiple overloads when `params` suffices

---

## **4. Optional & Named arguments**

## 📌 What problem does this solve?

Methods with many parameters are:

- Hard to read
- Error-prone at call sites
- Difficult to evolve

**Optional and named arguments** improve **readability, usability, and flexibility** of method calls.

---

## 🧠 Intuition (Plain English)

- **Optional arguments** → “You can skip this if you’re fine with the default.”
- **Named arguments** → “I’ll specify which parameter this value belongs to.”

---

## 🔍 Optional Arguments

### Characteristics

- Default values are specified at **method definition**
- Caller can **omit** them
- Default values must be **compile-time constants**

```csharp
void Log(string message,int level = 1)
{
    Console.WriteLine($"{level}: {message}");
}
```

Usage:

```csharp
Log("Started");// level = 1
Log("Error", 5);// level = 5
```

---

## ❗ Why avoid optional parameters in public APIs?

Because default values are **compiled into the caller’s assembly**.

```csharp
// Library v1
void Log(string msg, int level = 1)
```

```csharp
// Library v2
void Log(string msg,int level = 2)
```

⚠ Existing callers still pass `1`

⚠ Causes **silent behavior bugs**

---

## 🔍 Named Arguments

### Characteristics

- Improve readability
- Allow arguments **out of order**
- No runtime overhead

```csharp
Log(level:3, message:"Something happened");
```

✔ Self-documenting

✔ Safe to reorder parameters internally

---

## ❗ Common Interview Traps

1. ❌ *“Optional params are evaluated at runtime”*
    
    → No, they’re **compiled into caller**
    
2. ❌ *“Named arguments slow execution”*
    
    → No runtime cost
    
3. ❌ *“Named args break method overloads”*
    
    → Only if signatures become ambiguous
    

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;

class Program
{
    static void Main()
    {
        Log("Application started");
        Log("Disk space low", level: 3);

        // Named arguments allow reordering
        Log(level: 5, message: "Critical error");
    }

    static void Log(string message, int level = 1)
    {
        Console.WriteLine($"{level}: {message}");
    }
}
```

---

## 🆚 Optional vs Overloads

| Scenario | Better Choice |
| --- | --- |
| Public APIs | Method overloads |
| Internal helpers | Optional parameters |
| Version-safe design | Overloads |

---

## 🎯 Interview One-Liners

- **Why avoid optional params in public APIs?**
    
    → “Defaults are baked into caller assemblies, causing versioning issues.”
    
- **Why use named arguments?**
    
    → “Improves readability and reduces positional errors.”
    
- **Do named arguments affect performance?**
    
    → “No, they’re compile-time only.”
    

---

## 🚨 Real-World Best Practices

✅ Use named arguments for clarity

✅ Prefer overloads for public APIs

❌ Avoid optional params across assemblies

❌ Don’t mix optional params with many overloads

---

## **5. Expression-bodied members**

## 📌 What problem does this solve?

Many methods, properties, and constructors contain **only a single expression**.

Writing full blocks for them adds:

- Unnecessary boilerplate
- Reduced readability

**Expression-bodied members** provide a **concise, readable syntax** for simple logic.

---

## 🧠 Intuition (Plain English)

> “This member does just one thing — say it in one line.”
> 

If the body is:

- One return statement
- One expression
- One throw

→ Expression-bodied syntax is ideal.

---

## 🧩 Where Expression-Bodied Members Can Be Used

They can be applied to:

- Methods
- Properties (get / set)
- Constructors
- Finalizers
- Indexers
- Operators

---

## 🔍 Syntax Overview

```csharp
ReturnType MethodName(args) => expression;
```

The `=>` replaces:

- Method body `{ }`
- `return` keyword (when applicable)

---

## ❗ Common Interview Traps

1. ❌ *“Expression-bodied members are lambdas”*
    
    → No, they’re **member syntax**, not delegates
    
2. ❌ *“They improve performance”*
    
    → No runtime difference — **compile-time sugar**
    
3. ❌ *“They can contain multiple statements”*
    
    → Only **one expression**
    

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;

class Calculator
{
    // -------- METHOD --------
    public int Sum(int x, int y) => x + y;

    // -------- PROPERTY --------
    public int Value => 42;

    // -------- CONSTRUCTOR --------
    private int _value;
    public Calculator(int v) => _value = v;

    // -------- THROW EXPRESSION --------
    public int Divide(int a, int b) =>
        b == 0 ? throw new DivideByZeroException() : a / b;

    // -------- ToString --------
    public override string ToString() => $"Value = {_value}";
}

class Program
{
    static void Main()
    {
        var calc = new Calculator(10);
        Console.WriteLine(calc.Sum(3, 4)); // 7
        Console.WriteLine(calc);           // Value = 10
    }
}
```

---

## ⭐ Important Edge Cases (Interview Gold)

### 1️⃣ Readability matters more than brevity

❌ Bad:

```csharp
int Complex(int x) => x > 0 ? x * 2 : x < 0 ? x / 2 :throw new Exception();
```

✅ Good:

```csharp
int Complex(int x)
{
	if (x ==0) throw new Exception();
	return x > 0 ? x * 2 : x / 2;
}

```

---

### 2️⃣ Debugging experience

- Harder to set breakpoints
- Stack traces are less expressive

---

## 🆚 Expression-Bodied vs Block Body

| Aspect | Expression-bodied | Block |
| --- | --- | --- |
| Lines of code | Minimal | More |
| Readability (simple logic) | ✅ High | ❌ Lower |
| Complex logic | ❌ Poor | ✅ Better |
| Performance | Same | Same |

---

## 🎯 Interview One-Liners

- **Why use expression-bodied members?**
    
    → “For concise, readable single-expression logic.”
    
- **Do they affect performance?**
    
    → “No, they’re just syntax sugar.”
    
- **Can they throw exceptions?**
    
    → “Yes, using throw expressions.”
    

---

## 🚨 Real-World Best Practices

✅ Use for trivial logic

✅ Use for DTOs, records, operators

❌ Avoid for complex business rules

❌ Don’t sacrifice readability

---

# C. Classes & Object Model

---

## 1. Types of Classes

## 📌 What problem does this solve?

Not all classes serve the same purpose.

C# provides **specialized class types** to:

- Enforce architectural rules
- Prevent misuse through inheritance
- Improve maintainability and clarity
- Reduce boilerplate for common patterns

Understanding *which class type to use* is a **design decision**, not syntax trivia.

---

## 🧠 Intuition (Plain English)

> “Different problems need different kinds of classes.”
> 
- Some classes **represent objects**
- Some classes **provide utilities**
- Some classes **define contracts**
- Some classes **lock behavior**
- Some classes **split responsibilities**
- Some classes **model immutable data**

---

## 🔍 Major Types of Classes

---

## 1️⃣ Standard (Concrete) Class

### What it is

- The default class type
- Can be instantiated
- Can inherit and be inherited

### Purpose

- Represent **real-world objects**
- Hold **state + behavior**

```csharp
public class Car
{
		public string Model { get; set; }
		public int Year { get; set; }

		public void StartEngine()
    {
        Console.WriteLine($"The {Model}'s engine is starting.");
    }
}
```

🧠 Think:

> “Normal object with data and behavior.”
> 

---

## 2️⃣ Static Class

### What it is

- Cannot be instantiated
- All members must be static

### Purpose

- Utility methods
- Shared logic
- Global helpers

```csharp
public static class MathHelpers
{
		public static double Pi = 3.14159;

		public static int Add(int a,int b) => a + b;
}
```

🧠 Think:

> “A namespace with behavior.”
> 

❗ Interview trap:

- Static ≠ thread-safe

---

## 3️⃣ Abstract Class

### What it is

- Cannot be instantiated
- Can contain abstract + concrete members

### Purpose

- Define **base behavior**
- Enforce **implementation contracts**

```csharp
public abstract class Animal
{
		public void Sleep() => Console.WriteLine("Zzz...");
		public abstract void MakeSound();
}

public class Dog : Animal
{
		public override void MakeSound() => Console.WriteLine("Woof!");
}
```

🧠 Think:

> “A partially complete blueprint.”
> 

---

## 4️⃣ Sealed Class

### What it is

- Cannot be inherited

### Purpose

- Prevent behavior modification
- Lock implementation
- Improve predictability

```csharp
public sealed class ConfigurationManager
{
		public string ConnectionString { get; }

		public ConfigurationManager()
    {
        ConnectionString ="Data Source=...";
    }
}
```

🧠 Think:

> “Final version — no extensions allowed.”
> 

❗ Interview trap:

- Sealed methods can also exist inside non-sealed classes

---

## 5️⃣ Partial Class

### What it is

- Class definition split across files
- Compiled as **one class**

### Purpose

- Separate auto-generated code from manual code
- Improve maintainability

```csharp
// File 1: EmployeeField.cs
public partial class Employee
{
		public int Id { get; set; }
		public string FirstName { get; set; }
}

// File 2: EmployeeOthers.cs
public partial class Employee
{
		public string LastName { get; set; }
		public string GetFullName() => $"{FirstName}{LastName}";
}
```

🧠 Think:

> “One class, many files.”
> 

---

## 6️⃣ Record Class (C# 9+)

### What it is

- Special class with **value-based equality**
- Immutable by default

### Purpose

- DTOs
- Immutable models
- Message/event objects

```csharp
public record Person(string FirstName, string LastName);
```

```csharp
var p1 = new Person("Jane","Doe");
var p2 = new Person("Jane","Doe");

Console.WriteLine(p1 == p2);// True
```

🧠 Think:

> “Data, not behavior.”
> 

---

## 🧩 ONE Consolidated Comparison Table

| Class Type | Instantiable | Inheritable | Key Purpose |
| --- | --- | --- | --- |
| Standard | ✅ Yes | ✅ Yes | Objects & behavior |
| Static | ❌ No | ❌ No | Utilities |
| Abstract | ❌ No | ✅ Yes | Base contracts |
| Sealed | ✅ Yes | ❌ No | Lock behavior |
| Partial | ✅ Yes | ✅ Yes | Split code |
| Record | ✅ Yes | ✅ Yes | Immutable data |

---

## ❗ Common Interview Traps

1. ❌ *“Abstract class = interface”*
    
    → Abstract classes can have state & implementation
    
2. ❌ *“Static class is just faster”*
    
    → It’s about **design**, not speed
    
3. ❌ *“Partial affects runtime behavior”*
    
    → Compile-time only
    
4. ❌ *“Records are value types”*
    
    → Record class = reference type
    

---

## 🎯 Interview One-Liners

- **Why abstract classes?**
    
    → “To share behavior and enforce contracts.”
    
- **Why sealed classes?**
    
    → “To prevent unintended inheritance.”
    
- **When to use record?**
    
    → “For immutable data with value equality.”
    
- **Why partial classes?**
    
    → “To separate generated and custom code.”
    

---

## 🚨 Real-World Best Practices

✅ Use **record** for DTOs

✅ Use **abstract** for base behavior

✅ Use **sealed** for security & stability

❌ Avoid overusing static classes

❌ Avoid inheritance where composition fits better

---

## **2. Constructors**

## 📌 What problem does this solve?

Constructors ensure an object starts its life in a **valid, predictable state**.

They allow you to:

- Initialize required data
- Enforce invariants
- Control how objects are created

> Without constructors, objects could exist in half-initialized or invalid states.
> 

---

## 🧠 Intuition (Plain English)

> “Before you use me, let me set myself up correctly.”
> 

Constructors define the **entry point** into an object’s lifecycle.

---

## 🔍 Types of Constructors

---

### 🔹 Default Constructor

- If **no constructor is defined**, compiler provides one
- Assigns **default values** (`0`, `null`, `false`)
- Has no parameters

```csharp
class A
{
	// Compiler inserts:
	// public A() { }
}
```

🧠 Think of it as:

> Auto-generated start state
> 

⚠ If you define **any constructor**, the compiler **does not generate** the default one.

---

### 🔹 Parameterized Constructor

- Accepts arguments
- Used to inject **required state or dependencies**

```csharp
class User
{
		public string Name;
		
		public User(string name)
    {
        Name = name;
    }
}
```

🧠 Think:

> “Give me what I need before you use me.”
> 

---

### 🔹 Static Constructor

- Runs **once per type**
- Executed before:
    - First object creation **or**
    - First static member access
- Cannot have parameters
- Cannot be called explicitly

```csharp
class Config
{
		staticConfig()
    {
				// One-time initialization
    }
}

```

🧠 Think:

> “One-time setup for the entire class.”
> 

---

## ⭐ Why does static constructor exist?

- Static fields need **safe, one-time initialization**
- Guarantees:
    - Thread safety
    - Exactly-once execution

---

## 🔗 Constructor Chaining (`this`)

### 📌 What problem does this solve?

Avoids **duplicate initialization logic** across constructors.

---

### `this()` Constructor Chaining

- Calls another constructor in the **same class**
- Must be the **first statement**

```csharp
class Person
{
		public string Name;
		public int Age;

		public Person() : this("Unknown", 0)
    {
    }

		public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
```

🧠 Think:

> “Reuse my own initialization logic.”
> 

---

## 🔗 Base Constructor Chaining (`base`)

### 📌 What problem does this solve?

Ensures the **base class is properly initialized** before the derived class.

---

### `base()` Constructor Chaining

- Calls constructor of **parent class**
- Must be the **first statement**
- Happens **before derived constructor body**

```csharp
class Animal
{
		public Animal(string type)
    {
        Console.WriteLine($"Animal: {type}");
    }
}

class Dog : Animal
{
		public Dog() : base("Dog")
    {
        Console.WriteLine("Dog created");
    }
}
```

🧠 Execution order:

1. Base constructor
2. Derived constructor

---

## ❗ Common Interview Traps

1. ❌ *“Base constructor is optional”*
    
    → Only if base has a parameterless constructor
    
2. ❌ *“this() and base() can both be used”*
    
    → ❌ Only **one**, and it must be first
    
3. ❌ *“Static constructors run per object”*
    
    → ❌ Run **once per type**
    

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;

class Base
{
    static Base()
    {
        Console.WriteLine("Static Base");
    }

    public Base(string msg)
    {
        Console.WriteLine("Base constructor: " + msg);
    }
}

class Derived : Base
{
    public Derived() : this("default")
    {
    }

    public Derived(string msg) : base(msg)
    {
        Console.WriteLine("Derived constructor");
    }
}

class Program
{
    static void Main()
    {
        var d = new Derived();
    }
}
```

### Execution Order:

1. Static Base
2. Base constructor
3. Derived constructor

---

## 🎯 Interview Questions & Answers

### ❓ Does static constructor block other threads?

✅ **Yes**

CLR locks the type initializer until it completes.

---

### ❓ Can static class have instance constructor?

❌ **No**

Static classes cannot be instantiated.

---

### ❓ Why use constructor chaining?

> “To avoid duplication and enforce consistent initialization.”
> 

---

## 🆚 `this()` vs `base()`

| Feature | `this()` | `base()` |
| --- | --- | --- |
| Calls | Same class constructor | Parent constructor |
| Purpose | Reuse logic | Initialize base |
| Can use together | ❌ No | ❌ No |
| Must be first | ✅ Yes | ✅ Yes |

---

## 🚨 Real-World Best Practices

✅ Use constructor chaining to avoid duplication

✅ Keep constructors lightweight

❌ Avoid heavy logic in constructors

❌ Avoid throwing exceptions unless unavoidable

---

## **3. Static vs Instance**

## 📌 What problem does this solve?

Classes often need:

- **Shared behavior/state** (same for everyone)
- **Per-object behavior/state** (unique per instance)

C# separates these concerns using **static** and **instance** members.

---

## 🧠 Intuition (Plain English)

- **Static** → “This belongs to the **class itself**.”
- **Instance** → “This belongs to **each object**.”

🧠 Mental model:

- Static = **class-level personality**
- Instance = **object-level personality**

---

## 🔍 Static Members

### Characteristics

- Belong to the **type**
- Created **once per application domain**
- Shared across all instances
- Accessed using **ClassName.Member**

```csharp
Math.Sqrt(16);
```

### Use cases

- Utility/helper methods
- Caching & shared state
- Constants & configuration
- Factory methods

---

## 🔍 Instance Members

### Characteristics

- Belong to a **specific object**
- Created per `new` instance
- Hold **unique state**
- Accessed using **object.Member**

```csharp
person.Name;
```

### Use cases

- Business state
- Object behavior
- Per-user / per-request data

---

## ❗ Common Interview Traps

1. ❌ *“Static methods can access instance data”*
    
    → ❌ They don’t have an object reference
    
2. ❌ *“Static means global and unsafe”*
    
    → Safe if **immutable or synchronized**
    
3. ❌ *“Instance members are always better”*
    
    → Shared logic belongs in static
    

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;

class Counter
{
    // -------- STATIC --------
    public static int GlobalCount = 0;

    // -------- INSTANCE --------
    public int InstanceCount = 0;

    public Counter()
    {
        GlobalCount++;    // shared across all objects
        InstanceCount++;  // unique per object
    }
}

class Program
{
    static void Main()
    {
        var c1 = new Counter();
        var c2 = new Counter();

        Console.WriteLine(Counter.GlobalCount); // 2
        Console.WriteLine(c1.InstanceCount);   // 1
        Console.WriteLine(c2.InstanceCount);   // 1
    }
}
```

---

## ⭐ Important Edge Cases (Interview Gold)

### 1️⃣ Static constructor & static members

- Static members are initialized:
    - Before first static access **or**
    - Before first object creation

```csharp
class Config
{
		static Config()
    {
			// Runs once, thread-safe
    }
}
```

---

### 2️⃣ Static classes

```csharp
static class Utils
{
		public static void Log(string msg) { }
}
```

- Cannot be instantiated
- Cannot contain instance members
- All members must be static

---

### 3️⃣ Static + Thread Safety

```csharp
staticint count;

static void Increment()
{
    count++;// ❌ not thread-safe
}
```

💡 Static does **not** imply thread-safe.

---

## 🆚 Static vs Instance (Quick Table)

| Aspect | Static | Instance |
| --- | --- | --- |
| Belongs to | Class | Object |
| Memory | One copy | One per object |
| Access | `Class.Member` | `obj.Member` |
| Holds state | Shared | Unique |
| Lifetime | App lifetime | Object lifetime |

---

## 🎯 Interview One-Liners

- **Why static methods?**
    
    → “For behavior not tied to object state.”
    
- **Can static access instance members?**
    
    → “No, there’s no `this` reference.”
    
- **Is static thread-safe?**
    
    → “No, synchronization is required.”
    

---

## 🚨 Real-World Best Practices

✅ Use static for **stateless helpers**

✅ Use instance for **business state**

❌ Avoid mutable static state

❌ Don’t use static as global variables

---

## **4. Properties**

## 📌 What problem does this solve?

Properties provide **controlled access** to object data.

They solve:

- Direct field exposure (bad encapsulation)
- Validation logic scattered across code
- The need for immutability in data models

> Properties sit between fields (data) and methods (behavior).
> 

---

## 🧠 Intuition (Plain English)

> “Let others read or write my data — but only on my terms.”
> 

Properties look like fields, but behave like methods.

---

## 🔍 Types of Properties

---

### 🔹 Auto-Properties

- Compiler generates the **backing field**
- Minimal boilerplate
- Best when no validation is required

```csharp
public int Age { get; set; }
```

🧠 Think:

> “Just store the value — nothing fancy.”
> 

---

### 🔹 Properties with Backing Field

- Explicit private field
- Full control over `get` / `set` logic
- Used for validation, logging, lazy loading

```csharp
private int _age;
public int Age
{
		get => _age;
		set => _age = value > 0 ? value : 0;
}
```

🧠 Think:

> “Intercept reads and writes.”
> 

---

### 🔹 Init-only Properties

- Introduced in **C# 9**
- Can be set **only during object initialization**
- Immutable after construction

```csharp
public string Name { get; init; }
```

🧠 Think:

> “Write once, read forever.”
> 

Perfect for:

- Records
- DTOs
- Immutable models

---

## ❗ Common Interview Traps

1. ❌ *“Auto-properties have no backing field”*
    
    → Compiler **creates one automatically**
    
2. ❌ *“init is same as private set”*
    
    → `init` allows assignment **only during initialization**
    
3. ❌ *“Properties are slower than fields”*
    
    → JIT usually **inlines** them
    

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;

class Person
{
    // -------- AUTO-PROPERTY --------
    public int Id { get; set; }

    // -------- BACKING FIELD --------
    private int _age;
    public int Age
    {
        get => _age;
        set => _age = value > 0 ? value : 0;
    }

    // -------- INIT-ONLY --------
    public string Name { get; init; }
}

class Program
{
    static void Main()
    {
        var p = new Person
        {
            Id = 1,
            Age = -5, // corrected to 0
            Name = "John"
        };

        // p.Name = "Mike"; // ❌ compile-time error (init-only)

        Console.WriteLine($"{p.Name}, Age: {p.Age}");
    }
}
```

---

## 🆚 `set` vs `init`

| Feature | `set` | `init` |
| --- | --- | --- |
| Mutability | Mutable | Immutable after init |
| When assignable | Anytime | Only during init |
| Use case | Business state | DTOs / models |
| Thread safety | ❌ | ✅ Better |

---

## 🎯 Interview One-Liners

- **Why use properties instead of fields?**
    
    → “To enforce encapsulation and validation.”
    
- **When to use init-only?**
    
    → “For immutable data models.”
    
- **Auto vs backing field?**
    
    → “Auto for simplicity, backing field for logic.”
    

---

## 🚨 Real-World Best Practices

✅ Prefer auto-properties by default

✅ Use backing fields only when logic is needed

✅ Use `init` for DTOs & records

❌ Avoid public fields

❌ Avoid heavy logic inside getters

---

## **5. Indexers**

## 📌 What problem does this solve?

Some classes **represent collections or containers**, but exposing them only through methods like:

```csharp
GetItem(int index)
SetItem(int index, value)

```

makes code:

- Verbose
- Less intuitive
- Unlike built-in collections

**Indexers** allow objects to be accessed using **array-like syntax**:

```csharp
myObject[index]
```

---

## 🧠 Intuition (Plain English)

> “This object behaves like a collection — let me access it using [ ].”
> 

Indexers make **custom types feel like arrays or dictionaries**.

---

## 🧩 How Indexers Work Internally

- Indexers are **special instance properties**
- Use the `this` keyword
- Accept **one or more parameters**
- Can have `get` and/or `set`

```csharp
public string this[int index] { get; set; }
```

🧠 Think:

> “A property that takes parameters.”
> 

---

## 🔍 Key Characteristics of Indexers

| Feature | Details |
| --- | --- |
| Syntax | `this[ ]` |
| Parameters | At least **one required** |
| Static | ❌ Not allowed |
| Overloading | ✅ Allowed |
| Access modifiers | On indexer or get/set |
| Supported in | Classes, structs, records, interfaces |

---

## ❗ Common Interview Traps

1. ❌ *“Indexers are methods”*
    
    → They are **properties**, not methods
    
2. ❌ *“Indexers must use int”*
    
    → Any type (`int`, `string`, `Guid`, etc.)
    
3. ❌ *“Indexers can be static”*
    
    → ❌ Only instance members
    

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;
using System.Collections.Generic;

class Library
{
    private List<string> _books = new List<string>
    {
        "The Hitchhiker's Guide to the Galaxy",
        "The Lord of the Rings",
        "Dune"
    };

    // -------- INDEXER (int) --------
    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= _books.Count)
                throw new IndexOutOfRangeException();

            return _books[index];
        }
        set
        {
            if (index < 0 || index >= _books.Count)
                throw new IndexOutOfRangeException();

            _books[index] = value;
        }
    }

    // -------- INDEXER OVERLOAD (string) --------
    public string this[string title]
    {
        get => _books.Find(b => b == title);
    }
}

class Program
{
    static void Main()
    {
        var lib = new Library();

        Console.WriteLine(lib[0]); // Access by index
        lib[0] = "Updated Book";
        Console.WriteLine(lib[0]);

        Console.WriteLine(lib["Dune"]); // Access by key
    }
}
```

---

## 🔁 Indexer Overloading

You can define **multiple indexers** with different parameter types.

```csharp
public int this[int index] { get; }
public int this[string key] { get; }
```

🧠 Think:

> “Different ways to look up the same data.”
> 

Similar to `Dictionary<TKey, TValue>`.

---

## 🆚 Indexer vs Method

| Aspect | Indexer | Method |
| --- | --- | --- |
| Syntax | `obj[key]` | `obj.Get(key)` |
| Readability | High | Medium |
| Use case | Collection-like access | Operations / actions |

---

## 🎯 Interview One-Liners

- **What is an indexer?**
    
    → “A property that lets objects be accessed like arrays.”
    
- **Why use indexers?**
    
    → “To provide intuitive, collection-style access.”
    
- **Can indexers be static?**
    
    → “No, they’re instance members.”
    
- **Can indexers be overloaded?**
    
    → “Yes, by parameter type.”
    

---

## 🚨 Real-World Best Practices

✅ Use indexers for collection-like types

✅ Add bounds validation

❌ Don’t hide expensive operations behind indexers

❌ Avoid complex logic in getters

---

## **6. Extension Methods**

## 📌 What problem does this solve?

Sometimes you want to **add behavior to an existing type** but you cannot:

- Modify its source code (framework / third-party types)
- Recompile it
- Create a derived class (sealed classes, structs, interfaces)

**Extension methods** solve this by letting you **add methods externally** while keeping **clean, readable syntax**.

---

## 🧠 Intuition (Plain English)

> “I want this method to look like it belongs to this type — without actually changing it.”
> 

That’s exactly how **LINQ** works.

---

## 🧩 How Extension Methods Work Internally

- An extension method is just a **static method**
- The compiler **rewrites** the call

```csharp
sentence.GetWordCount();
```

Becomes internally:

```csharp
StringHelperExtensions.GetWordCount(sentence);
```

🧠 Think:

> “Instance syntax over a static method.”
> 

---

## 🔍 Rules for Extension Methods (MUST KNOW)

To define an extension method:

1. Must be inside a **static class**
2. Method itself must be **static**
3. First parameter must use the **`this` keyword**
4. Namespace must be **imported** with `using`

```csharp
public static int GetWordCount(this string text)
```

---

## ❗ Common Interview Traps

1. ❌ *“Extension methods are real instance methods”*
    
    → ❌ They’re resolved at **compile time**
    
2. ❌ *“Extension methods can override methods”*
    
    → ❌ Instance methods always win
    
3. ❌ *“Extension methods can access private fields”*
    
    → ❌ Only public members
    

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;
using System.Collections.Generic;

namespace Extensions
{
    // -------- EXTENSION CLASS --------
    public static class StringExtensions
    {
        // Extends string
        public static int WordCount(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            return text.Split(
                new[] { ' ', '.', '!' },
                StringSplitOptions.RemoveEmptyEntries
            ).Length;
        }
    }

    public static class EnumerableExtensions
    {
        // Extends IEnumerable<T> (LINQ-style)
        public static void PrintAll<T>(this IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                Console.WriteLine(item);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        using Extensions;

        string sentence = "Extension methods feel like magic";
        Console.WriteLine(sentence.WordCount()); // 5

        var numbers = new List<int> { 1, 2, 3 };
        numbers.PrintAll();
    }
}
```

---

## ⭐ Advanced Usage (LINQ Style)

- LINQ methods (`Where`, `Select`, `OrderBy`) are **extension methods**
- Defined on `IEnumerable<T>`
- Enable **fluent chaining**

```csharp
numbers
    .Where(n => n > 1)
    .Select(n => n * 2);
```

🧠 This works because:

> “Every collection implements IEnumerable<T>.”
> 

---

## 🚫 Key Limitations (Interview Favorites)

### 1️⃣ Cannot access private members

```csharp
// ❌ Not allowed
this._privateField
```

### 2️⃣ Cannot override instance methods

```csharp
obj.ToString();// instance method always wins
```

### 3️⃣ Cannot extend static classes

```csharp
// ❌ Not allowed
static class Math
```

---

## 🆚 Extension Method vs Utility Class

| Aspect | Extension Method | Utility Method |
| --- | --- | --- |
| Syntax | `obj.Method()` | `Util.Method(obj)` |
| Readability | High | Medium |
| Discoverability | IntelliSense | Lower |

---

## 🎯 Interview One-Liners

- **What are extension methods?**
    
    → “Static methods that appear as instance methods.”
    
- **How does LINQ work?**
    
    → “Via extension methods on `IEnumerable<T>`.”
    
- **Can extension methods override instance methods?**
    
    → “No, instance methods take precedence.”
    

---

## 🚨 Real-World Best Practices

✅ Use for **cross-cutting utilities**

✅ Use for fluent APIs

❌ Avoid business logic in extensions

❌ Avoid polluting namespaces

---

## 7. Four Pillars of OOP in C#

## 1. Encapsulation (Data Hiding)

**Encapsulation** is the principle of bundling the data (fields) and methods that operate on that data within a single unit (a class). It involves restricting direct access to some of an object's components, typically using access modifiers and properties.

**Keywords / Concepts**

- `public`
- `private`
- `protected`
- `internal`
- Properties

**Interviewer Point**

> "Encapsulation guarantees that internal state is protected from unauthorized outside access."
> 

### C# Syntax Example

```csharp
public class BankAccount
{
    // Private field: the data is hidden
    private decimal _balance;

    // Public Property: controlled access to the data (encapsulated)
    public decimal Balance
    {
        get { return _balance; }
        // We can add validation logic here before setting the value
        private set
        {
            if (value >= 0)
            {
                _balance = value;
            }
        }
    }

    // Method to modify the balance safely
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }
}
```

---

## 2. Inheritance

**Inheritance** is a mechanism that allows a new class (derived class or subclass) to inherit properties and methods from an existing class (base class or superclass). This promotes code reuse and models a **"is-a"** relationship.

**Keywords / Concepts**

- `:` (colon for inheritance)
- `base`
- `sealed`

**Interviewer Point**

> "Inheritance helps establish an 'is-a' relationship, where a Dog is an Animal."
> 

### C# Syntax Example

```csharp
// Base Class
public class Animal
{
    public string Name { get; set; }

    public void Eat()
    {
        Console.WriteLine($"{Name} is eating.");
    }
}

// Derived Class: Uses the colon syntax for inheritance
public class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine($"{Name} is barking 'Woof!'");
    }
}

// Usage:
// Dog myDog = new Dog { Name = "Fido" };
// myDog.Eat();   // Inherited from Animal
// myDog.Bark();  // Specific to Dog
```

---

## 3. Polymorphism

**Polymorphism** literally means **"many forms."**

It allows objects of different classes that are related by inheritance to be treated as objects of a common base class.

In C#, this is achieved through:

- Method Overloading
- Method Overriding

**Keywords / Concepts**

- `virtual`
- `override`
- Method Overloading

**Interviewer Point**

> "Polymorphism lets a single interface represent different underlying forms, allowing us to treat derived classes as their base type at runtime."
> 

### C# Syntax Example

**(Runtime Polymorphism via Overriding)**

```csharp
public class Vehicle
{
    // Mark the base method as 'virtual' to allow derived classes to override it
    public virtual void StartEngine()
    {
        Console.WriteLine("Vehicle engine starting.");
    }
}

public class Car : Vehicle
{
    // Use 'override' to provide a specific implementation for the Car class
    public override void StartEngine()
    {
        Console.WriteLine("Car engine starting quietly.");
    }
}

public class Motorcycle : Vehicle
{
    // Use 'override' to provide a different specific implementation
    public override void StartEngine()
    {
        Console.WriteLine("Motorcycle engine starting loud!");
    }
}

// Usage: A list of the base type (Vehicle) handles all derived types differently
List<Vehicle> vehicles = new List<Vehicle>
{
    new Car(),
    new Motorcycle()
};

foreach (var vehicle in vehicles)
{
    // Calls the correct overridden method at runtime
    vehicle.StartEngine();
}
```

---

## 4. Abstraction

**Abstraction** is the concept of hiding complex implementation details and showing only the necessary features of an object.

This is achieved using:

- Abstract classes
- Interfaces

They define a **contract** without providing full implementation.

**Keywords / Concepts**

- `abstract`
- `interface`

**Interviewer Point**

> "Abstraction defines the 'what' without specifying the 'how', creating a clear contract for implementation."
> 

### C# Syntax Example

**(Using Abstract Class)**

```csharp
// The 'abstract' class cannot be instantiated itself
public abstract class Shape
{
    // Can contain implemented methods
    public abstract double CalculateArea(); // Abstract method (no body)

    public void Display()
    {
        Console.WriteLine($"This is a shape with Area: {CalculateArea()}");
    }
}

public class Circle : Shape
{
    public double Radius { get; set; }

    // Must implement the abstract method
    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}
```

---

## Other Key C# OOP Concepts for Interviews

| Concept | Purpose | C# Syntax / Keywords |
| --- | --- | --- |
| Interface | Defines a contract that classes must adhere to. A class can implement multiple interfaces. | `interface ILogger { void Log(string msg); }` |
| Constructor | Special method called when an object instance is created. Used for initialization. | `public ClassName() { ... }` |
| Struct | A value type (stored on the stack). Lightweight alternative to classes for small data sets. | `public struct Point { ... }` |
| Sealed | Prevents a class from being inherited by any other class. | `public sealed class FinalConfig { ... }` |

---

# D. Advanced C#

## 1. LINQ — Deffered Execution

Language Integrated Query (**LINQ**) is a powerful set of features introduced in C# 3.0 that provides a standardized way to query data from various sources (databases, XML documents, in-memory collections like arrays and lists) directly within C# code.

This deep dive focuses on **Method Syntax**, which is highly prevalent in the industry due to its flexibility and composability with lambda expressions.

---

### What is LINQ?

LINQ operates primarily on types that implement the `IEnumerable<T>` interface. All modern C# collections (List, Array, Dictionary, etc.) support this, making LINQ applicable almost everywhere.

When you use LINQ, you are essentially calling extension methods defined within the `System.Linq` namespace.

---

### Method Syntax vs. Query Syntax

While C# offers two ways to write LINQ—Query Syntax (SQL-like) and Method Syntax (fluent/dot-notation)—Method Syntax is generally preferred in industry standard C# for its superior flexibility and ability to chain complex operations seamlessly.

| Feature | Method Syntax (Fluent API) | Query Syntax (SQL-like) |
| --- | --- | --- |
| Readability | Good for complex chains | Good for simple `from...where...select` |
| Flexibility | Highly flexible (can use lambdas) | Less flexible |
| Industry Usage | Very High (standard practice) | Low (often converts to method syntax internally) |

**We will focus entirely on Method Syntax below.**

---

## Core LINQ Methods Used in the Industry

These are the most frequently used LINQ methods in professional C# projects.

---

### Setup Example Data

We will use a simple list of `Product` objects for all examples:

```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool InStock { get; set; }
}

List<Product> products = new List<Product>
{
    new Product { Id = 1, Name = "Laptop", Price = 999.99m, InStock = true },
    new Product { Id = 2, Name = "Mouse", Price = 19.99m, InStock = true },
    new Product { Id = 3, Name = "Keyboard", Price = 45.50m, InStock = false },
    new Product { Id = 4, Name = "Monitor", Price = 250.00m, InStock = true },
};

```

---

### 1. Filtering Data (`Where`)

Filters a sequence of values based on a predicate (a condition you provide).

```csharp
// Get products that are in stock and cost less than $100
var affordableInStock = products.Where(p => p.InStock && p.Price < 100m);

foreach (var p in affordableInStock)
{
    // Output: Mouse, Keyboard (Wait, keyboard isn't in stock. Mouse only.)
    // Output: Name: Mouse, Price: 19.99
}
```

---

### 2. Projecting / Transforming Data (`Select`)

Transforms elements of a sequence into a new form (projects from one shape to another).

```csharp
// Get just the names of all products as a list of strings
IEnumerable<string> productNames = products.Select(p => p.Name);

// Get a new anonymous type containing just the name and ID
var nameAndIdList = products.Select(p => new { p.Name, p.Id });
```

---

### 3. Ordering Data (`OrderBy`, `OrderByDescending`, `ThenBy`)

Sorts the elements of a sequence. `ThenBy` is used for secondary sorting criteria.

```csharp
// Sort by price in ascending order, then by name alphabetically if prices are equal
var sortedProducts = products
    .OrderBy(p => p.Price)
    .ThenBy(p => p.Name);

```

---

### 4. Element Operators (`First`, `FirstOrDefault`, `Single`, `SingleOrDefault`)

These are used to extract a single element from the sequence.

- `First()` – Returns the first item matching the criteria. Throws an exception if no match found.
- `FirstOrDefault()` – Returns the first item matching the criteria, or `null` (or `default(T)`) if no match found. **(Highly Used in Industry)**
- `Single()` – Returns the only item matching the criteria. Throws an exception if *zero* or *more than one* match found.
- `SingleOrDefault()` – Returns the only item, or `null` if zero items. Throws an exception if *more than one* match found.

```csharp
// Safe retrieval of the first in-stock item
Product firstInStock = products.FirstOrDefault(p => p.InStock == true);
// firstInStock is the Laptop

// Trying to find a product that does not exist
Product nonExistent = products.FirstOrDefault(p => p.Id == 99);
// nonExistent is null, no exception is thrown.
```

---

### 5. Quantifiers (`Any`, `All`, `Contains`)

These methods return a boolean result based on the collection's contents.

```csharp
// Any: Check if at least one element meets the condition
bool anyExpensiveItems = products.Any(p => p.Price > 500m); // True (Laptop)

// All: Check if every element meets the condition
bool allInStock = products.All(p => p.InStock == true); // False (Keyboard is out)

// Contains: Check if a specific item is in the list
bool hasMouse = productNames.Contains("Mouse"); // True
```

---

### 6. Aggregation Methods (`Count`, `Sum`, `Average`, `Max`, `Min`)

Performs calculations on the entire collection.

```csharp
int totalProducts = products.Count();
decimal maxPrice = products.Max(p => p.Price);
decimal averagePrice = products.Average(p => p.Price);

// Sum only the prices of in-stock items
decimal totalInStockValue = products
    .Where(p => p.InStock)
    .Sum(p => p.Price);
```

---

### 7. Grouping Data (`GroupBy`)

Organizes data into groups based on a key selector function. This is essential for reporting and data organization tasks.

```csharp
// Group products by their InStock status (true / false)
var groupedByStockStatus = products.GroupBy(p => p.InStock);

foreach (var group in groupedByStockStatus)
{
    Console.WriteLine($"Status Key: {group.Key} (Count: {group.Count()})");
    foreach (var product in group)
    {
        Console.WriteLine($"  - {product.Name}");
    }
}
```

---

## Deep Dive Concept: Deferred Execution

This is the most critical concept in understanding LINQ's performance behavior.

Most LINQ methods do not execute the query immediately when you define it. They return a query object that *defers* execution until the results are actually needed (for example, when you loop through the results using `foreach`, call `ToList()`, `ToArray()`, `Count()`, or use one of the Element Operators).

**This allows you to chain many operations efficiently.**

```csharp
// DEFERRED EXECUTION: The query is defined but not run yet.
var query = products.Where(p => p.Price > 50m);
Console.WriteLine("Query defined, no loop started yet.");

// EXECUTION TRIGGERS HERE: The results are pulled the first time we loop.
foreach (var p in query)
{
    Console.WriteLine($"Result 1: {p.Name}");
}

// EXECUTION TRIGGERS AGAIN HERE: The logic runs from the start a second time.
var count = query.Count();
Console.WriteLine($"Count: {count}");
```

Methods that trigger immediate execution are called **Eager** or **Buffering** methods (`ToList()`, `ToArray()`, `Sum()`, `First()`, etc.).

Methods that defer execution are called **Lazy** methods (`Where()`, `Select()`, `OrderBy()`, `GroupBy()`).

For extensive documentation and examples of all standard query operators, refer to the Microsoft Learn LINQ documentation.

---

## 2. Delegates

## 📌 What problem does this solve?

Before delegates:

- Methods could **not be treated as data**
- You couldn’t:
    - Pass behavior as a parameter
    - Store methods in variables
    - Implement callbacks cleanly

Delegates solve this by allowing **methods to be passed around like values**.

---

## 🧠 Intuition (Plain English)

> “A delegate is a variable that can point to a method.”
> 

Just like:

- `int x = 10;` → variable points to data
- `MyDelegate d = Method;` → variable points to **code**

This enables:

- Callbacks
- Event handling
- Strategy pattern
- LINQ & lambdas

---

## 🧩 How Delegates Work Internally

- A delegate is a **type-safe function pointer**
- It stores:
    1. Reference to a method
    2. (Optionally) reference to a target object (for instance methods)

At runtime:

- Invoking a delegate = invoking the method it points to
- Compiler ensures **signature match**

---

## 🔍 Delegate Anatomy

```csharp
public delegate int MathOperation(int a, int b);
```

Breakdown:

- `delegate` → keyword
- `MathOperation` → delegate type name
- `(int a, int b)` → method signature it can point to
- `int` → return type

📌 Only methods with **exact same signature** are allowed.

---

## ❗ Common Interview Traps

1. ❌ *“Delegate is like object”*
    
    → No. It’s a **type-safe function reference**
    
2. ❌ *“Delegates are slow”*
    
    → Delegate invocation is **highly optimized**
    
3. ❌ *“Delegates can point to any method”*
    
    → Signature **must match exactly**
    
4. ❌ *“Delegates are replaced by lambdas”*
    
    → Lambdas **compile into delegates**
    

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;

// -------- DELEGATE DECLARATION --------
public delegate int MathOperation(int a, int b);

class Calculator
{
    // -------- METHODS MATCHING SIGNATURE --------
    public static int Add(int x, int y) => x + y;
    public static int Multiply(int x, int y) => x * y;
}

class Program
{
    static void Main()
    {
        // -------- ASSIGN METHOD TO DELEGATE --------
        MathOperation operation = Calculator.Add;

        // Invoke delegate → calls Add
        int result1 = operation(10, 5);
        Console.WriteLine(result1); // 15

        // Reassign delegate to another method
        operation = Calculator.Multiply;

        int result2 = operation(10, 5);
        Console.WriteLine(result2); // 50
    }
}

```

---

## 🔁 Multicast Delegates (Important)

Delegates can point to **multiple methods**.

```csharp
Action log = () => Console.WriteLine("Log 1");
log += () => Console.WriteLine("Log 2");

log();// Invokes both methods

```

📌 Return value:

- Only **last method’s return value** is preserved

---

## 🆚 Delegate vs Method Call

| Aspect | Direct Method | Delegate |
| --- | --- | --- |
| Flexibility | Fixed | Dynamic |
| Can pass as parameter | ❌ | ✅ |
| Runtime binding | ❌ | ✅ |
| Used in events | ❌ | ✅ |

---

## 🎯 Interview One-Liners

- **What is a delegate?**
    
    → “A type-safe reference to a method.”
    
- **Why delegates exist?**
    
    → “To pass behavior as data.”
    
- **How are lambdas related to delegates?**
    
    → “Lambdas compile into delegate instances.”
    
- **Can delegates hold multiple methods?**
    
    → “Yes, multicast delegates.”
    

---

## 🚨 Real-World Usage

✅ Events & event handlers

✅ Callbacks

✅ Strategy pattern

✅ LINQ (`Func<>`, `Action<>`, `Predicate<>`)

✅ Async continuations

---

## **3. Func & Action**

## 📌 What problem does this solve?

Before `Func<>` and `Action<>`:

- Developers had to **declare custom delegate types** for every method signature
- Code became noisy and repetitive
- Harder to read and maintain

`Func` and `Action` solve this by providing **ready-made generic delegates**.

---

## 🧠 Intuition (Plain English)

- **Func** → “Calculate something and return a value”
- **Action** → “Perform something, no return value”

Think of them as **delegate shortcuts**.

---

## 🧩 How They Work Internally

- Both are **generic delegates**
- Defined in `System` namespace
- They compile down to **delegate types**
- Commonly used with **lambdas** and **LINQ**

---

## 🔍 Func<T>

### What it is

- Represents a method that **returns a value**
- Last generic type is always the **return type**

```csharp
Func<int,int,int> add = (a, b) => a + b;
```

Meaning:

```
(int,int) → int
```

---

## 🔍 Action<T>

### What it is

- Represents a method that **returns void**

```csharp
Action<string> print = msg => Console.WriteLine(msg);
```

Meaning:

```
(string) → void
```

---

## ❗ Common Interview Traps

1. ❌ *“Func and Action are keywords”*
    
    → No, they are **delegate types**
    
2. ❌ *“Func cannot be void”*
    
    → Correct — use `Action` instead
    
3. ❌ *“They replace delegates completely”*
    
    → No, custom delegates are still needed for:
    
    - Named intent
    - Events
    - Domain-specific meaning

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;

class Program
{
    static void Main()
    {
        // -------- FUNC --------
        Func<int, int, int> add = (x, y) => x + y;
        Console.WriteLine(add(10, 20)); // 30

        // -------- ACTION --------
        Action<string> log = message =>
        {
            Console.WriteLine($"Log: {message}");
        };

        log("Operation completed");
    }
}
```

---

## 🧠 ⭐ VERY IMPORTANT INTERVIEW QUESTION

### **List<Action> – “Why does it print same value?”**

### ❓ Question

```csharp
List<Action> actions = new List<Action>();

for (int i = 0; i < 5; i++)
{
    actions.Add(() => Console.WriteLine(i));
}

foreach (var action in actions)
{
    action();
}
```

### ❗ Interviewer asks:

> “What will be the output?”
> 

### ❌ Expected (Wrong) Answer

```
0
1
2
3
4
```

### ✅ Actual Output

```
5
5
5
5
5

```

---

## 🧩 Why does this happen? (CORE CONCEPT)

- Lambdas **capture variables, not values**
- `i` is a **single variable**
- By the time actions execute, loop has ended
- `i == 5`

This is called **closure over loop variable**.

---

## ✅ Correct Fix (Interview-Expected)

```csharp
for (int i =0; i <5; i++)
{
		int localCopy = i;// new variable per iteration
    actions.Add(() => Console.WriteLine(localCopy));
}
```

### ✅ Output

```
0
1
2
3
4
```

---

## 🎯 Interview One-Liners (HIGH ROI)

- **Why does List<Action> print same value?**
    
    → “Because lambdas capture variables, not values.”
    
- **How to fix it?**
    
    → “Create a local copy inside the loop.”
    
- **Is this related to Func/Action?**
    
    → “Yes, both are delegates and follow closure rules.”
    

---

## 🆚 Func vs Action vs Delegate

| Feature | Func | Action | Custom Delegate |
| --- | --- | --- | --- |
| Return value | ✅ | ❌ | Optional |
| Generic | ✅ | ✅ | ❌ |
| Common in LINQ | ✅ | ❌ | ❌ |
| Closure behavior | ✅ | ✅ | ✅ |

---

## 🚨 Real-World Usage

✅ LINQ pipelines

✅ Event handlers

✅ Background tasks

✅ Retry / logging logic

✅ Middleware chains

---

## 🔥 Final Interview Tip

If interviewer asks about **Func/Action**,

**ALWAYS mention closures** — that’s where most candidates fail.

---

## **4. Events**

## 📌 What problem does this solve?

Delegates allow **anyone** holding a reference to invoke them.

This is dangerous because:

- External code can trigger callbacks arbitrarily
- Violates encapsulation
- Breaks publisher–subscriber contracts

**Events solve this by wrapping delegates with safety rules.**

---

## 🧠 Intuition (Plain English)

> “Publishers notify subscribers — subscribers cannot notify themselves.”
> 
- **Publisher** → raises the event
- **Subscriber** → listens to the event
- Only the **publisher** controls invocation

---

## 🧩 How Events Work Internally

- An `event` is a **restricted multicast delegate**
- Compiler enforces:
    - `+=` allowed (subscribe)
    - `=` allowed (unsubscribe)
    - Direct invocation ❌ blocked from outside

Internally:

```csharp
private EventHandler _click;
```

But exposed as:

```csharp
public event EventHandler Click;
```

---

## 🔍 Basic Event Syntax

```csharp
button.Click += OnClick;
```

Meaning:

- `Click` → event
- `OnClick` → subscriber method
- `+=` → subscribe safely

---

## ❗ Why `event` Keyword Exists (Interview Favorite)

Without `event`:

```csharp
public Action Click;
```

External code can do:

```csharp
button.Click();// ❌ BAD
button.Click =null;// ❌ Dangerous
```

With `event`:

```csharp
public event Action Click;
```

External code:

- ❌ Cannot invoke
- ❌ Cannot overwrite
- ✅ Can only subscribe/unsubscribe

🎯 **Interview Answer**

> “The event keyword restricts delegate invocation and enforces encapsulation.”
> 

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;

class Button
{
    // -------- EVENT DECLARATION --------
    public event Action Click;

    public void SimulateClick()
    {
        // Only publisher can invoke
        Click?.Invoke();
    }
}

class Program
{
    static void Main()
    {
        Button button = new Button();

        // -------- SUBSCRIBE --------
        button.Click += OnButtonClick;

        button.SimulateClick();
    }

    static void OnButtonClick()
    {
        Console.WriteLine("Button clicked!");
    }
}
```

---

## 🔁 Events Are Multicast

```csharp
button.Click += () => Console.WriteLine("Handler 1");
button.Click += () => Console.WriteLine("Handler 2");
```

Invocation order:

- Subscription order
- All handlers invoked

📌 If one handler throws → chain breaks (unless handled)

---

## ❗ Common Interview Traps

1. ❌ *“Events are delegates”*
    
    → Events **use** delegates, but add restrictions
    
2. ❌ *“Subscribers can invoke events”*
    
    → ❌ Only publisher can
    
3. ❌ *“Events are thread-safe by default”*
    
    → ❌ Need null-check or local copy
    

---

## 🧠 Standard .NET Event Pattern (Important)

```csharp
public event EventHandler<MyEventArgs> DataProcessed;
```

Why?

- `sender` → who raised event
- `EventArgs` → event data
- Consistent .NET design

---

## 🆚 Delegate vs Event

| Feature | Delegate | Event |
| --- | --- | --- |
| Invocation control | ❌ Anyone | ✅ Publisher only |
| Multicast | ✅ | ✅ |
| Encapsulation | ❌ | ✅ |
| Used for | Callbacks | Notifications |

---

## 🎯 Interview One-Liners

- **What is an event?**
    
    → “A safe wrapper over a multicast delegate.”
    
- **Why event keyword?**
    
    → “To prevent external invocation and overwriting.”
    
- **Who raises an event?**
    
    → “Only the publisher.”
    

---

## 🚨 Real-World Usage

✅ UI frameworks (Button.Click)

✅ Domain events

✅ Messaging systems

✅ Observer pattern

---

## **5. Lambda Expressions**

## 📌 What problem does this solve?

Before lambdas:

- Code relied on **named methods** everywhere
- Simple logic required extra boilerplate
- Hard to pass small pieces of behavior inline

Lambda expressions solve this by allowing **inline, anonymous functions**.

---

## 🧠 Intuition (Plain English)

> “Functions created on the fly.”
> 
- Short-lived
- Often used once
- Passed as data (to LINQ, delegates, events)

---

## 🧩 How Lambdas Work Internally

- Lambdas **compile into delegates**
- Or into **expression trees** (for `IQueryable`)
- They can **capture variables** from outer scope → *closures*

```csharp
x => x * 2
```

Becomes:

```csharp
Func<int,int>
```

---

## 🔍 Lambda Syntax Variations

```csharp
// Single parameter
x => x * 2

// Multiple parameters
(x, y) => x + y

// Block body
x =>
{
		int result = x *2;
		return result;
}
```

Rules:

- Expression body → implicit return
- Block body → explicit return

---

## ❗ Closures (VERY IMPORTANT)

Lambdas **capture variables, not values**.

```csharp
int x = 10;
Func<int> f = () => x;

x = 20;
Console.WriteLine(f());// 20
```

🧠 Why?

- Lambda holds reference to `x`
- Not a snapshot

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int threshold = 100;

        // Lambda capturing outer variable (closure)
        var expensiveProducts = new List<int> { 50, 150, 200 }
            .Where(price => price > threshold);

        threshold = 180;

        // Uses updated value due to closure
        foreach (var price in expensiveProducts)
        {
            Console.WriteLine(price); // 200
        }
    }
}
```

---

## ❗ Common Interview Traps

1. ❌ *“Lambda is just syntax sugar”*
    
    → ❌ It introduces **closures and scope capture**
    
2. ❌ *“Lambdas are always delegates”*
    
    → ❌ Can be **Expression Trees**
    
3. ❌ *“Closures copy values”*
    
    → ❌ They capture **variables**
    

---

## 🆚 Lambda vs Anonymous Method

| Feature | Lambda | Anonymous Method |
| --- | --- | --- |
| Syntax | Compact | Verbose |
| Type inference | ✅ | ❌ |
| Readability | High | Low |
| Modern usage | ✅ | Rare |

---

## 🎯 Interview One-Liners

- **What is a lambda?**
    
    → “An inline anonymous function.”
    
- **What is a closure?**
    
    → “Captured variables from outer scope.”
    
- **Why lambdas are powerful?**
    
    → “They enable functional programming patterns.”
    

---

## 🚨 Real-World Usage

✅ LINQ queries

✅ Event handlers

✅ Callbacks

✅ Async continuations

✅ Middleware pipelines

---

## **6. Anonymous Methods**

## 📌 What problem does this solve?

Before anonymous methods:

- Only **named methods** could be passed as delegates
- Even tiny one-line logic required a separate method
- Code became verbose and harder to follow

Anonymous methods introduced a way to write **inline unnamed methods**, paving the way for lambdas.

---

## 🧠 Intuition (Plain English)

> “A method without a name, written right where it’s used.”
> 

They were the **first step toward functional programming** in C#.

---

## 🧩 How Anonymous Methods Work Internally

- Compiled into **delegate instances**
- Can capture **outer variables** (closures)
- Use the `delegate` keyword instead of `=>`

```csharp
delegate(int x) { return x * x; }
```

This compiles into:

```csharp
Func<int,int>
```

---

## 🔍 Syntax Breakdown

```csharp
Func<int,int> square = delegate(int x)
{
		return x * x;
};
```

Key points:

- No method name
- Parameter types **must be specified**
- Return type inferred from delegate

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;

class Program
{
    static void Main()
    {
        // Anonymous method assigned to a delegate
        Func<int, int> square = delegate (int x)
        {
            return x * x;
        };

        Console.WriteLine(square(5)); // 25
    }
}
```

---

## 🆚 Anonymous Methods vs Lambdas

| Feature | Anonymous Method | Lambda |
| --- | --- | --- |
| Syntax | Verbose | Compact |
| Introduced in | C# 2.0 | C# 3.0 |
| Parameter type inference | ❌ | ✅ |
| Modern usage | Rare | Standard |

📌 **Lambdas replaced anonymous methods in practice**, but anonymous methods still exist for backward compatibility.

---

## ❗ Common Interview Traps

1. ❌ *“Anonymous methods are obsolete”*
    
    → ❌ Still supported, just rarely used
    
2. ❌ *“Anonymous methods cannot capture variables”*
    
    → ❌ They support closures
    
3. ❌ *“Anonymous methods are faster than lambdas”*
    
    → ❌ Same runtime behavior
    

---

## 🎯 Interview One-Liners

- **What is an anonymous method?**
    
    → “An unnamed inline method assigned to a delegate.”
    
- **Why were they introduced?**
    
    → “To reduce boilerplate before lambdas existed.”
    
- **Why lambdas replaced them?**
    
    → “Cleaner syntax and type inference.”
    

---

## 🚨 Real-World Usage (Today)

✅ Legacy codebases

✅ Understanding older frameworks

❌ New code (prefer lambdas)

---

## **7. Generics**

- Provide type safety.
- Avoid boxing/unboxing.
- Improve performance.

### **Covariance (`out`)**

You can return more derived type.

### **Contravariance (`in`)**

You can accept base type.

### **List<object> vs List<string>**

- They are **invariant** → no automatic conversion.

### **Intuition**

- If allowed, you could add a `new object()` to `List<string>` — unsafe.

# **Commonly Used Generic Collections in C# — Interview Notes**

Here is a further elaboration on the most commonly used generic collections in C#, detailing their essential properties and methods.

---

## **1. List<T>**

The `List<T>` is the most versatile and frequently used collection, ideal for general-purpose lists where you need **ordered storage and indexed access**.

### 🧠 Intuition (Plain English)

> “A resizable array with fast indexed access.”
> 
- Maintains **insertion order**
- Allows duplicates
- Automatically grows when capacity is exceeded

---

### **Properties**

| Name | Description |
| --- | --- |
| Count | Gets the total number of elements in the `List<T>`. |
| Capacity | Gets or sets the number of elements the `List<T>` can hold before resizing. |

---

### **Methods**

| Name | Description |
| --- | --- |
| Add(T item) | Adds an object to the end of the list. |
| AddRange(IEnumerable<T>) | Adds multiple elements at once. |
| Remove(T item) | Removes first occurrence. |
| RemoveAt(int index) | Removes element at index. |
| Contains(T item) | Checks existence. |
| Clear() | Removes all elements. |
| IndexOf(T item) | Returns index of first match. |
| Sort() | Sorts using default comparer. |

---

### 🧩 Code Example

```csharp
List<int> numbers =new List<int>();

numbers.Add(10);
numbers.AddRange(new[] {20,30 });

Console.WriteLine(numbers[1]);// 20
Console.WriteLine(numbers.Count);// 3

numbers.Remove(20);
numbers.Sort();

```

---

### 🎯 Interview Questions

- **Why is List<T> faster than ArrayList?**
    
    → Strongly typed, no boxing/unboxing.
    
- **What happens when capacity is exceeded?**
    
    → Internal array is resized (usually doubled).
    
- **Time complexity of index access?**
    
    → O(1)
    

---

## **2. Dictionary<TKey, TValue>**

Optimized for **key-based lookups**, offering near **O(1)** average time complexity.

---

### 🧠 Intuition

> “A phonebook — find value instantly using a key.”
> 
- Keys must be **unique**
- Order is **not guaranteed**
- Backed by **hash tables**

---

### **Properties**

| Name | Description |
| --- | --- |
| Count | Number of key/value pairs. |
| Keys | Collection of keys. |
| Values | Collection of values. |

---

### **Methods**

| Name | Description |
| --- | --- |
| Add(key, value) | Adds new key-value pair. |
| ContainsKey(key) | Checks if key exists. |
| Remove(key) | Removes entry by key. |
| TryGetValue(key, out value) | Safe lookup without exception. |
| Clear() | Removes all entries. |

---

### 🧩 Code Example

```csharp
Dictionary<int,string> users =new();

users.Add(1,"Alice");

if (users.TryGetValue(1,outstring name))
{
    Console.WriteLine(name);// Alice
}

```

---

### 🎯 Interview Questions

- **Why prefer TryGetValue over indexer?**
    
    → Avoids `KeyNotFoundException`.
    
- **What determines dictionary performance?**
    
    → Good `GetHashCode()` and `Equals()`.
    
- **Can Dictionary contain null keys?**
    
    → ❌ No (values can be null).
    

---

## **3. Queue<T> (FIFO)**

Processes items in the **order they arrive**.

---

### 🧠 Intuition

> “Standing in a queue — first come, first served.”
> 

---

### **Properties**

| Name | Description |
| --- | --- |
| Count | Number of elements in the queue. |

---

### **Methods**

| Name | Description |
| --- | --- |
| Enqueue(T) | Adds item to end. |
| Dequeue() | Removes item from front. |
| Peek() | Views front item without removing. |
| Clear() | Removes all items. |

---

### 🧩 Code Example

```csharp
Queue<string> tasks =new();

tasks.Enqueue("Task1");
tasks.Enqueue("Task2");

Console.WriteLine(tasks.Dequeue());// Task1
Console.WriteLine(tasks.Peek());// Task2

```

---

### 🎯 Interview Questions

- **What happens if Dequeue is called on empty queue?**
    
    → Throws `InvalidOperationException`.
    
- **Real-world usage?**
    
    → Job processing, request handling.
    

---

## **4. Stack<T> (LIFO)**

Accesses the **most recently added item first**.

---

### 🧠 Intuition

> “Stack of plates — last one on top is removed first.”
> 

---

### **Properties**

| Name | Description |
| --- | --- |
| Count | Number of elements in the stack. |

---

### **Methods**

| Name | Description |
| --- | --- |
| Push(T) | Adds item to top. |
| Pop() | Removes and returns top item. |
| Peek() | Views top item without removing. |
| Clear() | Removes all items. |

---

### 🧩 Code Example

```csharp
Stack<int> history =new();

history.Push(1);
history.Push(2);

Console.WriteLine(history.Pop());// 2
Console.WriteLine(history.Peek());// 1

```

---

### 🎯 Interview Questions

- **Where is Stack<T> used internally?**
    
    → Method calls, recursion.
    
- **Pop vs Peek?**
    
    → Pop removes, Peek does not.
    

---

## **5. HashSet<T>**

Stores **unique elements only**, optimized for fast lookups and set operations.

---

### 🧠 Intuition

> “A bag where duplicates are automatically rejected.”
> 

---

### **Properties**

| Name | Description |
| --- | --- |
| Count | Number of unique elements. |

---

### **Methods**

| Name | Description |
| --- | --- |
| Add(T) | Adds if not present. |
| Remove(T) | Removes element. |
| Contains(T) | Very fast lookup. |
| UnionWith() | Combines sets. |
| IntersectWith() | Keeps common elements. |

---

### 🧩 Code Example

```csharp
HashSet<int>set =new();

set.Add(1);
set.Add(1);// Ignored

Console.WriteLine(set.Count);// 1
Console.WriteLine(set.Contains(1));// True

```

---

### 🎯 Interview Questions

- **Difference between HashSet and List?**
    
    → HashSet enforces uniqueness.
    
- **Time complexity of Contains?**
    
    → O(1) average.
    
- **What happens on hash collision?**
    
    → Uses buckets + equality checks.
    

---

## 🧠 Final Interview Comparison Summary

| Collection | Order | Duplicates | Lookup Speed | Use Case |
| --- | --- | --- | --- | --- |
| List<T> | ✅ | ✅ | O(n) | General-purpose |
| Dictionary<TKey,TValue> | ❌ | ❌ (keys) | O(1) | Key-based access |
| Queue<T> | FIFO | ✅ | O(1) | Scheduling |
| Stack<T> | LIFO | ✅ | O(1) | Undo, recursion |
| HashSet<T> | ❌ | ❌ | O(1) | Uniqueness |

---

## 🎯 High-Impact Interview One-Liners

- **Why generics?**
    
    → “Type safety + performance (no boxing).”
    
- **When not to use List<T>?**
    
    → “When uniqueness or fast lookup is required.”
    
- **Why HashSet over List for Contains()?**
    
    → “O(1) vs O(n).”
    

---

## **8. Exceptions**

## 📌 What problem does this solve?

Exceptions provide a **structured error-signaling mechanism** when:

- Normal execution **cannot continue**
- An operation **fails unexpectedly**
- Responsibility must move **up the call stack**

Without exceptions:

- Errors are silently ignored
- Code becomes defensive and unreadable
- Bugs leak into production

---

## 🧠 Intuition (Plain English)

> “This is not a valid outcome — someone higher must decide what to do.”
> 

Exceptions are **signals**, not control statements.

---

## 🧩 How Exceptions Work Internally

- Every exception:
    - Inherits from `System.Exception`
    - Contains:
        - Message
        - StackTrace
        - InnerException
- When `throw` executes:
    - CLR **unwinds the stack**
    - Looks for nearest compatible `catch`
    - If none → process terminates

---

## 🔍 Basic Exception Flow

```csharp
try
{
		// Risky code
}
catch (SpecificException ex)
{
		// Handle
}
finally
{
		// Cleanup (always runs)
}
```

---

## ✅ Core Best Practices (Interview Must)

- Catch **specific exceptions**
- Never swallow exceptions
- Preserve stack trace using `throw;`
- Exceptions are for **exceptional cases only**
- Log exceptions at **application boundaries**

---

# 🔹 1️⃣ Custom Exceptions (VERY IMPORTANT)

### 📌 Why Custom Exceptions Exist

Generic exceptions (`Exception`, `ArgumentException`) don’t express **domain meaning**.

Custom exceptions:

- Make intent explicit
- Improve readability
- Help centralized handling

---

### 🧠 Intuition

> “This error is part of my business domain.”
> 

---

### 🧩 How to Create a Custom Exception

Rules:

- Inherit from `Exception`
- End name with `Exception`
- Provide meaningful constructors

```csharp
public class PaymentFailedException : Exception
{
		public PaymentFailedException(string message)
        : base(message) { }

		public PaymentFailedException(string message, Exception inner)
        :base(message, inner) { }
}
```

---

### ✅ Usage Example

```csharp
if (!paymentSuccess)
{
		throw new PaymentFailedException("Payment gateway timeout");
}
```

🎯 **Interview Insight**

> Custom exceptions are semantic markers, not technical ones.
> 

---

# 🔹 2️⃣ Exception Handling in `async / await`

### 📌 Why This Is Tricky

Async code:

- Does not throw immediately
- Wraps exceptions inside `Task`

---

### 🧠 Key Rule

> Exceptions in async methods are thrown when awaited, not when created.
> 

---

### 🧩 Correct Handling

```csharp
try
{
		await ProcessPaymentAsync();
}
catch (HttpRequestException ex)
{
    Console.WriteLine("Network failure");
}
```

---

### ❌ Common Async Trap

```csharp
var task = ProcessPaymentAsync();
// Exception NOT thrown yet
```

Exception is thrown only here:

```csharp
await task;
```

---

### 🎯 Interview One-Liner

> “Async exceptions surface at the await boundary.”
> 

---

# 🔹 3️⃣ Global Exception Handling (Application Boundary)

### 📌 Why Global Handling Is Needed

You **cannot** wrap try-catch everywhere.

Global handling:

- Catches unhandled exceptions
- Prevents app crashes
- Centralizes logging

---

### 🧠 Intuition

> “Last line of defense before the app dies.”
> 

---

### 🧩 ASP.NET Core Example (Middleware)

```csharp
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
				await context.Response.WriteAsync("Something went wrong");
    });
});
```

---

### 🧩 Console / Background App

```csharp
AppDomain.CurrentDomain.UnhandledException += (s, e) =>
{
    Console.WriteLine("Fatal error occurred");
		};
```

---

### 🎯 Interview Insight

- Catch locally → **handle**
- Catch globally → **log + translate**
- Never hide global failures

---

# 🔹 4️⃣ Retry & Resiliency Patterns

### 📌 Why Retry Exists

Some failures are **transient**:

- Network glitches
- Timeouts
- Temporary DB issues

Retry ≠ ignoring errors.

---

### 🧠 Intuition

> “This failed now — but might succeed in a moment.”
> 

---

### 🧩 Simple Retry Pattern

```csharp
int retries = 3;

while (true)
{
		try
    {
        CallRemoteService();
				break;
    }
		catch (TimeoutException) when (retries --> 0)
    {
        Thread.Sleep(500);
    }
}
```

---

### ❗ Interview Trap

❌ Retrying on **all exceptions**

✅ Retry only on **transient exceptions**

---

### 💼 Industry Standard

- Use **Polly** (retry, circuit breaker, fallback)
- Never roll your own blindly

---

## ❗ Common Exception Anti-Patterns

```csharp
catch (Exception) { }// ❌ Swallowed
catch (Exception ex) {throw ex; }// ❌ Stack lost
thrownew Exception("Error");// ❌ Loses context
```

---

## 🆚 `throw` vs `throw ex`

| Syntax | Stack Trace |
| --- | --- |
| `throw;` | ✅ Preserved |
| `throw ex;` | ❌ Lost |

---

## 🎯 Interview One-Liners (High Impact)

- **Why custom exceptions?**
    
    → “To express domain failures clearly.”
    
- **How async exceptions behave?**
    
    → “They surface when awaited.”
    
- **Where to log exceptions?**
    
    → “At application boundaries.”
    
- **When to retry?**
    
    → “Only for transient failures.”
    

---

## 🚨 Final Best Practices Summary

✅ Throw early, catch late

✅ Use domain-specific exceptions

✅ Preserve stack traces

✅ Centralize logging

❌ Don’t use exceptions for flow control

❌ Don’t blanket-catch `Exception`

---

# E. Memory & Internals

## **1. Stack vs Heap**

## 📌 What problem does this solve?

Understanding **where data lives in memory** explains:

- Performance differences
- Why some bugs exist (unexpected mutation)
- Why boxing, closures, and GC matter
- Why value vs reference types behave differently

This topic is a **core interview filter**.

---

## 🧠 Intuition (Plain English)

> “Stack is fast and temporary. Heap is flexible and long-lived.”
> 
- **Stack** → execution-time workspace
- **Heap** → shared memory for objects

---

## 🧩 Stack

### Key Characteristics

- **Fast** allocation & deallocation
- **Value types** stored directly (usually)
- **Static size** (per thread)
- **Function-scope lifetime**
- Automatically cleaned up when method returns

### What lives on Stack?

- Local value types (`int`, `struct`)
- Method parameters
- Return addresses
- References (pointers) to heap objects

```csharp
void Foo()
{
		int x = 10;// value on stack
    Person p = new();// reference on stack, object on heap
}
```

---

## 🧩 Heap

### Key Characteristics

- Stores **reference type objects**
- Managed by **Garbage Collector (GC)**
- **Slower** allocation than stack
- Objects live **until GC collects them**

### What lives on Heap?

- Objects (`class`, `array`, `string`)
- Boxed value types
- Captured variables (closures)

```csharp
Person p = new Person();// object on heap
```

---

## 🔍 Why Heap Is Slower

- Allocation requires GC bookkeeping
- Deallocation is **non-deterministic**
- Memory fragmentation possible

---

## ⚠️ Structs Can Be on Heap When:

### 1️⃣ Part of a Reference Type

```csharp
class Order
{
		public DateTime CreatedAt;// struct inside class → heap
}
```

---

### 2️⃣ Boxed

```csharp
int x = 10;
object o = x;// boxing → heap allocation
```

---

### 3️⃣ Captured in a Closure

```csharp
int x =10;
Action a = () => Console.WriteLine(x);
// x lifted to heap
```

---

## 🧠 Important Clarification (Interview Gold)

❌ *“Value types always live on stack”*

✅ **False**

❌ *“Reference types always live on heap”*

✅ **Mostly true**, but references themselves live on stack

---

## 🆚 Stack vs Heap Comparison

| Feature | Stack | Heap |
| --- | --- | --- |
| Speed | Very fast | Slower |
| Size | Limited | Large |
| Lifetime | Method scope | GC-controlled |
| Managed by | CPU | CLR (GC) |
| Thread-safe | Yes (per thread) | No (shared) |

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;

class Person
{
		public int Age;
}

class Program
{
		static void Main()
    {
				int a = 5;// stack
        Person p = new();// p on stack, object on heap

        Modify(a, p);

        Console.WriteLine(a);// 5
        Console.WriteLine(p.Age);// 30
    }

		static void Modify(int x, Person person)
    {
        x = 20;// modifies copy
        person.Age = 30;// modifies heap object
    }
}
```

---

## ❗ Common Interview Traps

1. ❌ *“GC cleans stack memory”*
    
    → ❌ Stack is cleaned automatically
    
2. ❌ *“Heap objects die when method ends”*
    
    → ❌ Only references die
    
3. ❌ *“Stack overflow means heap is full”*
    
    → ❌ Stack overflow = deep recursion
    

---

## 🎯 Interview One-Liners

- **Why is stack faster?**
    
    → “Simple pointer movement, no GC.”
    
- **Where does a reference live?**
    
    → “Reference on stack, object on heap.”
    
- **When does struct go to heap?**
    
    → “Boxing, closures, or inside reference types.”
    

---

## 🚨 Real-World Best Practices

✅ Prefer value types for small, immutable data

✅ Avoid unnecessary boxing

✅ Be cautious with closures

❌ Don’t optimize prematurely

❌ Don’t assume stack/heap placement blindly

---

## **2. GC Generations**

## 📌 What problem does this solve?

Garbage Collection (GC) exists to:

- Automatically manage memory
- Prevent memory leaks
- Free developers from manual `malloc/free`

But **scanning the entire heap every time is slow**.

👉 **Generations solve this performance problem.**

---

## 🧠 Intuition (Plain English)

> “Most objects die young — so clean young objects more often.”
> 

Instead of scanning everything:

- GC focuses first on **short-lived objects**
- Older objects are assumed to be **still useful**

This dramatically improves performance.

---

## 🧩 How GC Generations Work Internally

The managed heap is divided into **generations**:

| Generation | Description |
| --- | --- |
| Gen 0 | Newly allocated, short-lived objects |
| Gen 1 | Survivors of Gen 0 |
| Gen 2 | Long-lived objects |
| LOH | Large Object Heap (special case) |

Objects are **promoted** as they survive collections.

---

## 🔹 Generation 0 (Gen 0)

### Characteristics

- Holds **new objects**
- Smallest generation
- Collected **very frequently**
- Fastest to clean

```csharp
var obj = new object();// Gen 0
```

🧠 Most allocations happen here.

---

## 🔹 Generation 1 (Gen 1)

### Characteristics

- Acts as a **buffer** between Gen 0 and Gen 2
- Holds objects that survived **one GC**
- Collected less frequently than Gen 0

🧠 Helps prevent promoting short-lived objects too quickly.

---

## 🔹 Generation 2 (Gen 2)

### Characteristics

- Holds **long-lived objects**
- Collected **rarely**
- Most expensive to clean

Examples:

- Caches
- Static data
- Singleton objects

🧠 Gen 2 collection often causes **noticeable pauses**.

---

## 🔹 Large Object Heap (LOH) — Interview Favorite

### What qualifies?

- Objects **≥ 85 KB**
- Large arrays
- Large strings

```csharp
byte[] buffer = new byte[100_000];// LOH
```

### Key Points

- Allocated directly into LOH
- Collected only during **Gen 2 GC**
- Historically **not compacted** (fragmentation risk)

---

## 🧠 Object Promotion Flow

```
Allocate → Gen 0
Survive → Gen 1
Survive again → Gen 2
```

Once in Gen 2:

- Object stays there until collected
- Promotion is **one-way**

---

## 🧩 ONE Consolidated Code Example

```csharp
class Program
{
    static void Main()
    {
        CreateShortLivedObjects();
        CreateLongLivedObject();

        GC.Collect(); // For demonstration only (NOT recommended)
    }

    static void CreateShortLivedObjects()
    {
        for (int i = 0; i < 1000; i++)
        {
            var temp = new object(); // Gen 0, dies quickly
        }
    }

    static object longLived;

    static void CreateLongLivedObject()
    {
        longLived = new object(); // Promoted to Gen 2
    }
}
```

---

## ❗ Common Interview Traps

1. ❌ *“GC runs when memory is full”*
    
    → ❌ GC runs based on **allocation pressure**
    
2. ❌ *“GC collects Gen 0 only”*
    
    → ❌ Gen 2 collection includes **all generations**
    
3. ❌ *“Calling GC.Collect improves performance”*
    
    → ❌ Almost always **worsens performance**
    

---

## 🆚 GC Collection Types

| Collection Type | What it Cleans |
| --- | --- |
| Gen 0 GC | Gen 0 only |
| Gen 1 GC | Gen 0 + Gen 1 |
| Gen 2 GC | Gen 0 + Gen 1 + Gen 2 + LOH |

---

## 🎯 Interview One-Liners

- **Why generations?**
    
    → “To reduce GC pause time by focusing on young objects.”
    
- **Why is Gen 2 expensive?**
    
    → “Large heap scan + long-lived objects.”
    
- **What is LOH?**
    
    → “Heap for objects ≥ 85 KB, collected with Gen 2.”
    

---

## 🚨 Real-World Best Practices

✅ Prefer short-lived objects

✅ Reuse large buffers (ArrayPool)

✅ Avoid unnecessary allocations

❌ Don’t force GC

❌ Don’t allocate huge objects repeatedly

---

## **3. IDisposable & using**

## 📌 What problem does this solve?

The **Garbage Collector (GC)** only manages **managed memory**.

It **cannot** automatically clean up **unmanaged resources** such as:

- File handles
- Database connections
- Network sockets
- OS-level handles
- Native memory (C/C++ interop)

Without explicit cleanup:

- Files remain locked
- DB connections leak
- System resources exhaust

👉 **`IDisposable` + `using` solve this problem.**

---

## 🧠 Intuition (Plain English)

> “GC cleans memory.
> 
> 
> `Dispose()` cleans real-world resources.”
> 

You must **tell .NET explicitly**:

- *How* to clean the resource
- *When* to clean it

---

## 🧩 IDisposable Interface

### Definition

`IDisposable` is a contract that tells .NET:

> “This object owns unmanaged resources and knows how to release them.”
> 

```csharp
public interface IDisposable
{
	void Dispose();
}
```

### Responsibilities of `Dispose()`

- Close files
- Close database connections
- Release sockets / handles
- Free native resources
- Make object unusable afterward

---

## 🧩 `using` Statement (Syntactic Sugar)

### What `using` Guarantees

- Calls `Dispose()` **automatically**
- Works **even if an exception occurs**
- Prevents **resource leaks**

```csharp
using (var resource =new Resource())
{
		// use resource
}// Dispose() ALWAYS called
```

🧠 **Key Insight (Interview Favorite)**

`using` is **syntactic sugar over `try/finally`**.

---

## 🧩 How `using` Works Internally

This:

```csharp
using (var r = new Resource())
{
    r.DoWork();
}
```

Compiles to:

```csharp
var r = new Resource();
try
{
    r.DoWork();
}
finally
{
    r.Dispose();
}
```

---

# 🔹 Industry Form Code Examples

---

## ✅ Example 1: File Handling (Standard Industry Practice)

**Why this matters**

- Files are OS-level resources
- Leaving them open causes:
    - File locks
    - Data corruption
    - Production bugs

```csharp
using System;
using System.IO;

public class FileProcessor
{
    public void WriteDataToFile(string filePath, string data)
    {
        Console.WriteLine($"Attempting to write data to {filePath}");

        try
        {
            // 'using' guarantees Dispose() → file handle closed
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.WriteLine(data);
                Console.WriteLine("Data written successfully.");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
    }

    // C# 8.0+ using declaration
    public string ReadDataFromFile(string filePath)
    {
        using StreamReader streamReader = new StreamReader(filePath);
        return streamReader.ReadToEnd();
        // Dispose() called when method exits
    }
}
```

🎯 **Interview Insight**

> File streams wrap unmanaged OS handles → must be disposed deterministically.
> 

---

## ✅ Example 2: Database Connections (CRITICAL FOR INTERVIEWS)

**Why this matters**

- DB connections are **expensive**
- Leaking connections = **production outage**
- `Dispose()` returns connection to **connection pool**

```csharp
using System;
using System.Data.SqlClient;

public class DataAccessLayer
{
    private readonly string _connectionString = "YourActualConnectionStringHere";

    public int GetUserCount()
    {
        int count = 0;

        // Connection must ALWAYS be disposed
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            // Command also owns unmanaged resources
            using (SqlCommand command =
                   new SqlCommand("SELECT COUNT(*) FROM Users", connection))
            {
                connection.Open();
                count = (int)command.ExecuteScalar();
            }
        } // connection.Dispose() → returned to pool

        return count;
    }
}
```

🎯 **Interview One-Liner**

> “Dispose doesn’t destroy DB connections — it returns them to the pool.”
> 

---

## ✅ Example 3: Creating Your Own Disposable Class

**When do you do this?**

- Wrapping native libraries
- Managing sockets
- Interop with C/C++
- Owning unmanaged handles

```csharp
public class NetworkClient : IDisposable
{
    private bool _isConnectionOpen = false;

    public NetworkClient()
    {
        Console.WriteLine("Opening unmanaged connection.");
        _isConnectionOpen = true;
    }

    public void Dispose()
    {
        Console.WriteLine("Disposing network connection.");
        CloseConnection();

        // Prevent finalizer from running
        GC.SuppressFinalize(this);
    }

    private void CloseConnection()
    {
        if (_isConnectionOpen)
        {
            _isConnectionOpen = false;
        }
    }
}
```

### Usage

```csharp
using (var client = new NetworkClient())
{
		// Use network client
}// Dispose() guaranteed
```

---

## ❗ Common Interview Traps

1. ❌ *“GC automatically calls Dispose”*
    
    → ❌ **False**
    
2. ❌ *“Finalize and Dispose are same”*
    
    → ❌ Finalize is non-deterministic
    
3. ❌ *“using is optional for DB connections”*
    
    → ❌ Production bug waiting to happen
    

---

## 🆚 Dispose vs Finalize

| Aspect | Dispose | Finalize |
| --- | --- | --- |
| Called by | Developer / using | GC |
| Deterministic | ✅ | ❌ |
| Performance | Fast | Slow |
| Recommended | ✅ | Rare |

---

## 🎯 Interview One-Liners

- **Why IDisposable?**
    
    → “To deterministically release unmanaged resources.”
    
- **Why using?**
    
    → “Ensures Dispose even during exceptions.”
    
- **Does Dispose free memory?**
    
    → “No — it frees unmanaged resources.”
    

---

## 🚨 Real-World Best Practices

✅ Always wrap `IDisposable` in `using`

✅ Dispose DB connections ASAP

✅ Prefer `using var` (C# 8+)

❌ Never rely on GC for cleanup

❌ Never ignore Dispose warnings

---

## **4. Finalizers**

## 📌 What problem does this solve?

Finalizers exist to provide a **last-chance cleanup mechanism** for unmanaged resources **if the developer forgets to call `Dispose()`**.

They are **not** meant for normal resource management.

---

## 🧠 Intuition (Plain English)

> “A backup cleanup plan — slow, unreliable, and should almost never be needed.”
> 
- `Dispose()` → **primary cleanup**
- Finalizer → **emergency fallback**

---

## 🧩 What Is a Finalizer?

A finalizer is a special method:

- Defined using a **destructor syntax**
- Executed by the **GC**, not the developer
- Runs **at an unknown time in the future**

```csharp
~MyClass()
{
		// Cleanup logic
}
```

---

## 🧩 How Finalizers Work Internally

When an object has a finalizer:

1. Object becomes unreachable
2. GC **does NOT immediately free memory**
3. Object is placed on **finalization queue**
4. Finalizer thread executes `~MyClass()`
5. Object survives **one extra GC cycle**
6. Memory is finally reclaimed later

⚠️ This makes finalizers **expensive**.

---

## ❗ Why Finalizers Slow Down GC

- Objects with finalizers:
    - Live longer
    - Survive at least one GC
    - Cannot be reclaimed immediately
- Finalizer thread runs **serially**

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;

class ResourceHolder
{
    private bool _disposed;

    // Finalizer (destructor syntax)
    ~ResourceHolder()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); // Prevent finalizer
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
            // Free managed resources
        }

        // Free unmanaged resources
        _disposed = true;
    }
}
```

🎯 **Interview Insight**

> Finalizers exist only to support the Dispose pattern.
> 

---

## 🆚 Finalizer vs Dispose

| Feature | Dispose | Finalizer |
| --- | --- | --- |
| Triggered by | Developer | GC |
| Deterministic | ✅ | ❌ |
| Performance | Fast | Slow |
| Runs immediately | ✅ | ❌ |
| Recommended | ✅ | ❌ (rare) |

---

## ❗ Common Interview Traps

1. ❌ *“Finalizers clean memory faster”*
    
    → ❌ They delay cleanup
    
2. ❌ *“Finalizers are guaranteed to run”*
    
    → ❌ App shutdown can skip them
    
3. ❌ *“Every IDisposable needs a finalizer”*
    
    → ❌ Only if unmanaged resources exist
    

---

## 🧠 When SHOULD You Use a Finalizer?

✅ Only if your class:

- Directly owns **unmanaged resources**
- Does **not** rely solely on managed objects

❌ Do NOT use finalizers for:

- Logging
- Managed resources
- Normal cleanup

---

## 🎯 Interview One-Liners

- **Why finalizers exist?**
    
    → “Last-chance cleanup if Dispose isn’t called.”
    
- **Why are they slow?**
    
    → “Objects survive extra GC cycle.”
    
- **How to avoid finalizers?**
    
    → “Use Dispose + GC.SuppressFinalize.”
    

---

## 🚨 Real-World Best Practices

✅ Prefer `IDisposable`

✅ Suppress finalization when disposed

❌ Avoid finalizers unless absolutely required

❌ Never rely on finalizers for correctness

---

## **5. Boxing & Unboxing**

## 📌 What problem does this solve?

C# needs a way to treat **value types** (`int`, `struct`) as **reference types** (`object`, interfaces).

Boxing & unboxing provide this bridge — **but at a cost**.

---

## 🧠 Intuition (Plain English)

> “Wrap a value in a box (heap object), then unwrap it later.”
> 
- **Boxing** → value type copied to heap
- **Unboxing** → value copied back to stack with type check

⚠️ Both operations are **expensive**.

---

## 🧩 How Boxing & Unboxing Work Internally

### 🔹 Boxing

```csharp
int x = 10;
object o = x;
```

What happens:

1. Memory allocated on **heap**
2. Value `10` copied into heap object
3. Reference stored in `o`

---

### 🔹 Unboxing

```csharp
int y = (int)o;
```

What happens:

1. Runtime checks the **actual type**
2. Value copied from heap to stack
3. Invalid cast → exception

---

## 🧠 Important Clarification (Interview Gold)

❌ *“Unboxing modifies the boxed value”*

→ ❌ False — it creates a **copy**

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;
using System.Collections;

class Program
{
    static void Main()
    {
        int a = 5;

        // -------- BOXING --------
        object boxed = a;

        // -------- UNBOXING --------
        int b = (int)boxed;

        Console.WriteLine(b); // 5
    }
}
```

---

## ❗ Common Boxing Scenarios (VERY IMPORTANT)

### 1️⃣ Using non-generic collections

```csharp
ArrayList list = new ArrayList();
list.Add(10);// Boxing
int x = (int)list[0];// Unboxing
```

---

### 2️⃣ Casting value types to interfaces

```csharp
struct S : IDisposable
{
		public void Dispose() { }
}

IDisposable d =new S();// Boxing
```

---

### 3️⃣ Nullable boxing behavior (Interview Favorite)

```csharp
int? x = 10;
object o1 = x;// Boxes int
int? y = null;
object o2 = y;// null
```

---

## 🆚 Boxing vs No Boxing (Generics)

```csharp
List<int> list = new List<int>();// No boxing
list.Add(10);
```

vs

```csharp
ArrayList list =new ArrayList();// Boxing
list.Add(10);
```

---

## ❗ Common Interview Traps

1. ❌ *“Boxing modifies original value”*
    
    → ❌ Copy is created
    
2. ❌ *“Unboxing is cheap”*
    
    → ❌ Includes type checking + copy
    
3. ❌ *“Generics still box value types”*
    
    → ❌ Generics avoid boxing
    

---

## 🆚 Boxing vs Reference Assignment

| Feature | Boxing | Reference |
| --- | --- | --- |
| Heap allocation | ✅ | ❌ |
| Copy occurs | ✅ | ❌ |
| GC pressure | High | Low |
| Performance | Slow | Fast |

---

## 🎯 Interview One-Liners

- **What is boxing?**
    
    → “Copying a value type to heap as object.”
    
- **Why avoid boxing?**
    
    → “Heap allocation + GC overhead.”
    
- **How to avoid boxing?**
    
    → “Use generics.”
    

---

## 🚨 Real-World Best Practices

✅ Use generic collections

✅ Avoid value-to-object casts

✅ Be careful with interfaces on structs

❌ Don’t box inside loops

❌ Don’t ignore GC impact

---

# F. Multithreading & Concurrency

## 1. async/ await

## 📌 What problem does this solve?

Without `async / await`:

- Threads get **blocked** waiting for I/O
- Server apps **stop scaling**
- UI apps **freeze**

👉 `async / await` allows **non-blocking asynchronous execution** while keeping code readable.

---

## 🧠 Intuition (Chef Analogy 🍳)

### Without async (Blocking)

> One chef cooks rice and stands idle for 20 minutes.
> 
- Thread is blocked
- No other work can be done

---

### With async (Non-Blocking)

> Chef starts rice, sets a timer, and cooks vegetables meanwhile.
> 
- Chef is free
- Kitchen is efficient

🧠 **Chef = Thread**

🧠 **Dish = Task**

🧠 **Timer callback = await continuation**

---

## 🧩 What `async` REALLY Means

```csharp
async Task<int>GetDataAsync()
```

- `async` **does NOT create a thread**
- It allows:
    - `await` keyword inside
    - Compiler to generate a **state machine**

🎯 **Interview Gold**

> “async is a compiler instruction, not a threading instruction.”
> 

---

## 🧩 What `await` REALLY Does

```csharp
int result =await GetDataAsync();
```

`await`:

1. Checks if task is complete
2. If complete → continue synchronously
3. If not complete:
    - Saves current state
    - Returns control to caller
    - Registers continuation
    - Resumes later

🧠 **Thread is released back to pool**

---

## 🧩 How async/await Works Internally

### Step-by-step

```csharp
async Task CookDinnerAsync()
{
		await CookRiceAsync();
    CookVegetables();
}
```

Internally becomes:

```csharp
Task CookDinnerAsync()
{
		var stateMachine =new StateMachine();
    stateMachine.MoveNext();
}
```

### State Machine Behavior

- Local variables stored in heap
- Execution split into **states**
- Continuation scheduled after await completes

---

## 🧩 ONE Consolidated Code Example (Chef Analogy)

```csharp
using System;
using System.Threading.Tasks;

class Kitchen
{
    static async Task Main()
    {
        Console.WriteLine("Chef starts dinner");

        Task riceTask = CookRiceAsync(); // start rice
        CookVegetables();               // do other work

        await riceTask; // wait when needed

        Console.WriteLine("Dinner ready");
    }

    static async Task CookRiceAsync()
    {
        Console.WriteLine("Rice started");
        await Task.Delay(2000); // simulate waiting
        Console.WriteLine("Rice done");
    }

    static void CookVegetables()
    {
        Console.WriteLine("Cooking vegetables");
    }
}
```

### Output Order (Important!)

```
Chef starts dinner
Rice started
Cooking vegetables
Rice done
Dinner ready
```

---

## 🧠 Important Internal Truths (Interview Must)

- `await` **does not block**
- Thread returns to pool
- Continuation may resume on:
    - Same thread
    - Different thread
- Depends on **SynchronizationContext**

---

## ❗ async Return Types

| Return Type | When to Use |
| --- | --- |
| `Task` | Async operation, no result |
| `Task<T>` | Async operation with result |
| `void` | ❌ Only for event handlers |

```csharp
async Task<int>GetCountAsync() { }
```

---

## ❌ Common Interview Traps

### 1️⃣ Deadlock Trap

```csharp
var result = GetDataAsync().Result;// ❌
```

Why?

- UI thread blocks
- Continuation waits for UI thread
- Deadlock

🎯 One-liner:

> “Never block on async code.”
> 

---

### 2️⃣ async without await

```csharp
async TaskFoo()
{
    Console.WriteLine("Runs synchronously");
}
```

- No async behavior
- Compiler warning

---

### 3️⃣ Fire-and-forget

```csharp
_ = DoWorkAsync();// ❌ dangerous
```

- Exceptions lost
- No lifecycle control

---

## 🧠 CPU-bound vs I/O-bound

### I/O-bound (use async)

```csharp
await httpClient.GetAsync(url);
```

### CPU-bound (use Task.Run)

```csharp
await Task.Run(() => Compute());
```

---

## 🧠 Does async create new threads?

❌ **NO**

- Uses existing thread pool
- Async = **non-blocking**, not multi-threading

---

## 🎯 Interview One-Liners

- **What does async do?**
    
    → “Enables await and generates a state machine.”
    
- **What does await do?**
    
    → “Suspends execution without blocking a thread.”
    
- **Why async scales?**
    
    → “Threads are released during I/O waits.”
    

---

## 🚨 Real-World Best Practices

✅ Use async all the way

✅ Avoid `.Result` / `.Wait()`

✅ Prefer `Task` over `void`

❌ Don’t mix sync & async

❌ Don’t block thread pool

---

## **2. Task vs Thread**

## 📌 What problem does this solve?

Modern applications must:

- Run work **concurrently**
- Scale efficiently
- Avoid wasting OS resources

Creating raw threads for every unit of work is **slow, expensive, and unscalable**.

👉 **Tasks exist to abstract work from threads.**

---

## 🧠 Intuition (Plain English)

> “A thread is a worker.
> 
> 
> A task is a job handed to any available worker.”
> 
- **Thread** → execution unit
- **Task** → unit of work

---

## 🧩 Threads

### Characteristics

- OS-level construct
- Heavyweight
- Manual lifecycle management
- Expensive creation & teardown

```csharp
var thread = new Thread(() =>
{
    Console.WriteLine("Running on thread");
});
thread.Start();
```

🧠 Each thread consumes:

- Stack memory
- OS scheduling resources

---

## 🧩 Tasks

### Characteristics

- Lightweight abstraction
- Uses **Thread Pool**
- Managed by **Task Scheduler**
- Optimized for scalability

```csharp
Task.Run(() =>
{
    Console.WriteLine("Running on task");
});
```

🧠 Task does **not guarantee** a dedicated thread.

---

## 🧠 How Tasks Work Internally

1. Task is created
2. Task Scheduler queues work
3. Thread pool thread picks it up
4. Task completes
5. Thread returned to pool

---

## 🆚 Task vs Thread (Expanded)

| Feature | Thread | Task |
| --- | --- | --- |
| Level | OS | CLR |
| Creation cost | High | Low |
| Scheduling | OS Scheduler | Task Scheduler |
| Reuse | ❌ | ✅ |
| Return value | ❌ | ✅ |
| Exception handling | Manual | Built-in |
| Cancellation | Hard | Built-in |

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        // -------- THREAD --------
        Thread thread = new Thread(() =>
        {
            Console.WriteLine("Thread work");
        });
        thread.Start();

        // -------- TASK --------
        Task task = Task.Run(() =>
        {
            Console.WriteLine("Task work");
        });

        task.Wait();
    }
}
```

---

## ❗ Common Interview Traps

1. ❌ *“Task always creates a new thread”*
    
    → ❌ Uses thread pool
    
2. ❌ *“Threads are faster”*
    
    → ❌ They’re heavier
    
3. ❌ *“Tasks replace threads completely”*
    
    → ❌ Threads still exist underneath
    

---

## 🧠 When to Use What?

### Use **Thread** when:

- You need long-running, dedicated thread
- You control thread lifetime explicitly
- Thread-local state is critical

```csharp
new Thread(Work) { IsBackground =true }.Start();
```

---

### Use **Task** when:

- Parallelizing work
- I/O-bound operations
- CPU-bound short tasks
- Async/await

✅ **90% of modern code**

---

## 🎯 Interview One-Liners

- **Why Task over Thread?**
    
    → “Better scalability and lower cost.”
    
- **Does Task guarantee a thread?**
    
    → “No.”
    
- **Who schedules tasks?**
    
    → “Task Scheduler over thread pool.”
    

---

## 🚨 Real-World Best Practices

✅ Prefer Task

✅ Avoid creating raw threads

✅ Use async/await

❌ Don’t block thread pool threads

❌ Don’t over-parallelize

---

## **3. Parallel.ForEach — When it becomes slow**

## 📌 What problem does this solve?

`Parallel.ForEach` is designed to:

- Speed up **CPU-bound work**
- Split large workloads across **multiple cores**
- Automatically manage threads via the **ThreadPool**

However, **parallelism is not free**.

When misused, it can be **slower than a normal `foreach`**.

---

## 🧠 Intuition (Plain English)

> “Parallelism only pays off when the work is big enough.”
> 

If the **coordination cost** is higher than the **actual work**, performance drops.

---

## 🧩 How `Parallel.ForEach` Works Internally

1. Input collection is **partitioned**
2. Chunks are scheduled on **ThreadPool threads**
3. Work items are balanced dynamically
4. Threads synchronize at completion

Each step has **overhead**.

---

## ❌ Scenarios Where `Parallel.ForEach` Becomes Slow

---

### 1️⃣ Workload Is Tiny

```csharp
Parallel.ForEach(numbers, n =>
{
		int x = n +1;// trivial work
});
```

❌ Cost of:

- Thread scheduling
- Context switching
- Partitioning

> outweighs the computation
> 

🧠 **Interview Line**

> “Parallel overhead dominates small tasks.”
> 

---

### 2️⃣ Heavy I/O Inside Loop

```csharp
Parallel.ForEach(files,file =>
{
    File.ReadAllText(file);// I/O bound
});
```

❌ Problems:

- Threads block waiting for I/O
- ThreadPool starvation
- Poor scalability

✅ Better approach:

```csharp
await Task.WhenAll(files.Select(File.ReadAllTextAsync));
```

---

### 3️⃣ Locking Inside Loop

```csharp
Parallel.ForEach(items, item =>
{
		lock (_lock)
    {
        sharedList.Add(item);
    }
});
```

❌ Why slow?

- Threads **serialize on lock**
- Parallelism collapses
- Lock contention skyrockets

🧠 **Parallel code + lock = red flag**

---

### 4️⃣ Scheduling Overhead > Actual Work

Each iteration involves:

- Task partitioning
- Work stealing
- Synchronization

If work < overhead → **slower than single thread**

---

## 🧩 ONE Consolidated Comparison Example

```csharp
// ❌ Parallel (slower)
Parallel.ForEach(data, x =>
{
    x++;
});

// ✅ Sequential (faster)
foreach (var xin data)
{
    x++;
}
```

---

## 🆚 Parallel.ForEach vs Async

| Scenario | Use |
| --- | --- |
| CPU-bound heavy work | Parallel.ForEach |
| I/O-bound work | async / await |
| Small loops | foreach |
| Shared mutable state | Sequential |

---

## ❗ Common Interview Traps

1. ❌ *“Parallel is always faster”*
    
    → ❌ Depends on workload
    
2. ❌ *“Parallel helps I/O”*
    
    → ❌ Async helps I/O
    
3. ❌ *“Locks are fine in parallel loops”*
    
    → ❌ Destroys scalability
    

---

## 🎯 Interview One-Liners

- **Why Parallel.ForEach can be slow?**
    
    → “Overhead exceeds work.”
    
- **When should you avoid it?**
    
    → “Small, I/O-bound, or lock-heavy workloads.”
    
- **What is better for I/O?**
    
    → “Async/await.”
    

---

## 🚨 Real-World Best Practices

✅ Use for **CPU-heavy, independent work**

✅ Benchmark before and after

✅ Avoid shared state

❌ Don’t parallelize blindly

❌ Don’t mix locks + parallel

---

## **4. CancellationToken**

## 📌 What problem does this solve?

In .NET, **tasks and async operations cannot be forcefully stopped** safely.

- Killing threads is dangerous
- Forced termination can corrupt state
- Resources may not be released

👉 **CancellationToken enables *cooperative cancellation***.

---

## 🧠 Intuition (Plain English)

> “Please stop when you reach a safe point.”
> 
- Caller **requests** cancellation
- Callee **decides** when and how to stop
- No force, no corruption

🧠 Think of it as a **polite stop signal**, not a kill switch.

---

## 🧩 Core Components

Cancellation in .NET has **three parts**:

| Component | Role |
| --- | --- |
| `CancellationTokenSource` | Issues cancellation |
| `CancellationToken` | Passed to methods |
| Consumer code | Checks token & stops |

---

## 🧩 Basic Cancellation Flow

```csharp
var cts = new CancellationTokenSource();
CancellationToken token = cts.Token;

// Request cancellation
cts.Cancel();
```

---

## 🧩 How CancellationToken Works Internally

- `CancellationToken` is a **struct**
- It references a shared **CancellationTokenSource**
- `IsCancellationRequested` checks a flag
- `ThrowIfCancellationRequested()` throws `OperationCanceledException`

⚠️ **No thread is stopped automatically**

---

## 🧩 ONE Consolidated Code Example

```csharp
using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var cts = new CancellationTokenSource();

        Task work = DoWorkAsync(cts.Token);

        // Cancel after 2 seconds
        await Task.Delay(2000);
        cts.Cancel();

        try
        {
            await work;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Work cancelled safely");
        }
    }

    static async Task DoWorkAsync(CancellationToken token)
    {
        for (int i = 0; i < 10; i++)
        {
            token.ThrowIfCancellationRequested();
            Console.WriteLine($"Working... {i}");
            await Task.Delay(500);
        }
    }
}
```

---

## 🧠 Key Cancellation APIs

| API | Purpose |
| --- | --- |
| `IsCancellationRequested` | Check without throwing |
| `ThrowIfCancellationRequested()` | Throw & exit |
| `Register()` | Callback on cancellation |
| `Cancel()` | Request cancellation |

---

## 🔹 Manual Check vs Throw

```csharp
if (token.IsCancellationRequested)
{
		return;
}
```

vs

```csharp
token.ThrowIfCancellationRequested();
```

🎯 **Interview Insight**

> Use ThrowIfCancellationRequested() when cancellation is an exceptional exit.
> 

---

## 🔹 Cancellation in async APIs

Many built-in APIs **honor tokens automatically**:

```csharp
await Task.Delay(5000, token);
await httpClient.GetAsync(url, token);
```

🧠 Cancellation propagates **through awaits**.

---

## 🔹 Linked Cancellation Tokens

Used when cancellation can come from **multiple sources**.

```csharp
var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(
    token1, token2
);
```

🎯 Common in:

- ASP.NET request + timeout
- UI cancel + system shutdown

---

## ❗ Common Interview Traps

1. ❌ *“CancellationToken stops threads”*
    
    → ❌ Cooperative only
    
2. ❌ *“Cancel kills the task”*
    
    → ❌ Task must observe token
    
3. ❌ *“Cancellation is free”*
    
    → ❌ Requires explicit checks
    

---

## 🆚 Cancellation vs Exception

| Aspect | Cancellation | Exception |
| --- | --- | --- |
| Intent | Normal stop | Error |
| Flow | Expected | Unexpected |
| Exception type | `OperationCanceledException` | Any |

🎯 Cancellation is **controlled termination**, not failure.

---

## 🎯 Interview One-Liners

- **What is CancellationToken?**
    
    → “A cooperative cancellation signal.”
    
- **Does it stop threads?**
    
    → “No, code must observe it.”
    
- **Why cooperative?**
    
    → “To avoid corruption and leaks.”
    

---

## 🚨 Real-World Best Practices

✅ Always pass tokens down the call chain

✅ Check tokens in loops

✅ Let framework APIs handle cancellation

❌ Don’t ignore cancellation

❌ Don’t swallow `OperationCanceledException`

---

## **5. Deadlocks**

## 📌 What problem does this solve?

Deadlocks occur when:

- A thread is **blocked**
- While the continuation **needs that same thread**
- Result: **no one can proceed**

This is one of the **most common real-world async bugs** in C#.

---

## 🧠 Intuition (Chef Analogy 🍳)

> “The chef starts cooking rice, then sits down and waits,
> 
> 
> but the timer alarm also needs the chef to respond.”
> 

🧠 **Chef = Thread**

🧠 **Rice = Async Task**

🧠 **Timer callback = await continuation**

➡️ **Chef waits for rice**

➡️ **Rice completion waits for chef**

➡️ **Deadlock**

---

## 🧩 The Root Cause

### ❌ Blocking async code:

```csharp
var result = GetDataAsync().Result;
```

or

```csharp
GetDataAsync().Wait();
```

### Why this deadlocks

1. UI / ASP.NET thread calls async method
2. Thread is **blocked** by `.Wait()` / `.Result()`
3. Async method completes
4. Continuation tries to resume on **same thread**
5. Thread is blocked → **deadlock**

🎯 **Interview Gold Line**

> “The continuation needs the thread that is blocked.”
> 

---

## 🧩 Visual Flow (Very Important)

```
Thread ──► calls async method
Thread ──► blocks on .Result()

Async operation completes
Continuation tries to resume on same thread
Thread is blocked
💥 DEADLOCK
```

---

## 🧩 ONE Consolidated Deadlock Example

```csharp
using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        // ❌ DEADLOCK in UI / ASP.NET context
        string data = GetDataAsync().Result;
        Console.WriteLine(data);
    }

    static async Task<string> GetDataAsync()
    {
        await Task.Delay(1000);
        return "Data ready";
    }
}
```

🧠 Works in Console? **Sometimes**

🧠 Deadlocks in UI / ASP.NET? **Yes**

---

## 🧩 Why UI / ASP.NET Are Special

They have a **SynchronizationContext**:

- UI thread → must update UI
- ASP.NET → request context

By default:

```csharp
await SomethingAsync();
```

➡️ Captures context

➡️ Resumes on same thread

---

## 🧩 The Fix (Primary)

### ✅ **Async All the Way**

```csharp
static async TaskMain()
{
		string data = await GetDataAsync();
    Console.WriteLine(data);
}
```

🎯 **Rule**

> Never mix sync blocking with async code.
> 

---

## 🧩 The Fix (Advanced / Library Code)

### `ConfigureAwait(false)`

```csharp
await Task.Delay(1000).ConfigureAwait(false);
```

What it does:

- Does **NOT** capture context
- Continuation can run on any thread

🧠 Useful in:

- Libraries
- Lower-level infrastructure code

❌ Avoid in UI code unless you know what you're doing

---

## 🆚 Blocking vs Awaiting

| Approach | Result |
| --- | --- |
| `.Wait()` / `.Result()` | ❌ Deadlock risk |
| `await` | ✅ Safe |
| `ConfigureAwait(false)` | ✅ Avoids context |

---

## ❗ Common Interview Traps

1. ❌ *“Deadlocks only happen in multithreading”*
    
    → ❌ Happens in async too
    
2. ❌ *“Console apps never deadlock”*
    
    → ❌ They can, but less likely
    
3. ❌ *“ConfigureAwait(false) everywhere”*
    
    → ❌ Breaks UI logic
    

---

## 🎯 Interview One-Liners (Must Memorize)

- **Why does .Result cause deadlock?**
    
    → “It blocks the thread needed for continuation.”
    
- **Best fix?**
    
    → “Async all the way.”
    
- **When to use ConfigureAwait(false)?**
    
    → “Library / non-UI code.”
    

---

## 🚨 Real-World Best Practices

✅ Use async end-to-end

✅ Avoid blocking calls

✅ Understand SynchronizationContext

❌ Never mix `.Wait()` with `await`

❌ Don’t ignore deadlock warnings

---