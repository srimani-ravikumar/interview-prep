# 🛡️ Building Resilient Systems — Fundamentals & Patterns

## 🚄 Introduction

Modern distributed systems must behave like a high-speed train:
even if one module breaks, **the system keeps running gracefully** through fallback mechanisms.

Resilience ensures:

* consistent user experience
* reduced downtime
* graceful behavior under failure
* continued reliability even during outages

This document builds strong fundamentals by covering:

* Key Terminologies
* Robust vs Brittle Systems
* Graceful Degradation
* Retry Strategies
* DDoS risks from retry
* Circuit Breaker Pattern
* Timeout & Failover
* Final Engineering Checklist

---

## 📘 Key Terminologies

### 🔧 Error Handling

Mechanisms that detect and handle failures **without crashing the system**.

A good system must:

* capture & log errors
* provide meaningful feedback
* continue operating with fallback mechanisms

---

### 🛡️ Resilience

Resilience = **ability of a system to absorb failure & still function**.

Not avoiding failure, but surviving it:

* degrade gracefully
* recover quickly
* maintain stability

Used heavily in:

* fintech
* healthcare
* e-commerce
* large distributed systems

---

## 🏋️‍♂️ Robust System vs Brittle System

| Characteristic  | Robust System                   | Brittle System                         |
| --------------- | ------------------------------- | -------------------------------------- |
| Behavior        | Continues gracefully            | Crashes or freezes                     |
| Error Handling  | Uses cached data / fallback     | Entire system halts                    |
| Example         | Netflix shows cached shows      | Amazon checkout fails if payment fails |
| User Experience | Minimal disruption              | Major disruption                       |
| Recovery        | Partial functionality continues | Full failure                           |

### 🛒 Real-world example: Amazon Checkout

* **Brittle:** Payment service down → checkout crashes
* **Robust:** Hides recommendations / allows retry → checkout survives

---

# 🌤️ Graceful Degradation Strategies

## 1️⃣ Return Cached Data

When live data is unavailable → system falls back to **cached/stale data**.

```java
class RecommendationService {
    public List<String> getRecommendedItems(String userId) {
        try {
            // Attempt to fetch live recommendations
            return recommendationService.fetchLiveRecommendations(userId);
        } catch (Exception ex) {
            // If the live service fails, log the error and fall back to cache
            log.warn("Live service failed, falling back to cache");
            return cacheService.getCachedRecommendations(userId);  // Fallback to cached data
        }
    }

    public List<String> fetchLiveRecommendations(String userId) {
        return List.of("movie-1", "movie-2");  // Simulated live recommendation data
    }
}
```

Used for:

* Recommendations
* Product details
* News data
* Any content that can tolerate stale values

---

## 2️⃣ Show Fallback UI

If a service fails → show a **degraded but meaningful** UI.

```java
// Show fallback UI
public Menu getMenu(String restaurantId) {
    try {
        // Attempt to fetch the live menu
        return menuService.fetchMenu(restaurantId);
    } catch (Exception e) {
        // If the live menu is unavailable, show a fallback message in the UI
        return new Menu("Menu currently unavailable. Please try again later.");
    }
}
```

Examples:

* “Menu unavailable. Try again later.”
* Static UI blocks
* Placeholder content

---

## 3️⃣ Queue Requests

For high-load or temporarily down services → queue the request & retry later.

```java
// Queue request's
public void placeOrder(Order order) {
    try {
        // Attempt to charge the payment
        paymentService.charge(order);
    } catch (Exception e) {
        // If payment fails, queue the order for retry
        orderRetryQueue.enqueue(order);
        log.warn("Payment failed. Queued for retry.");
    }
}
```

Useful for:

* payment processing
* inventory updates
* notifications
* background jobs

---

# 🔁 Retry Mechanisms

Retries boost reliability but must be used carefully.

---

## 1️⃣ Naive Retry

Retry X times with no delay.

```java
// Naive retry example
public String getETA() {
    int retries = 3;  // Maximum retry attempts
    while (retries-- > 0) {
        try {
            return etaService.getETA();  // Attempt to fetch ETA from service
        } catch (Exception e) {
            log.warn("Retrying ETA, attempts left: " + retries);
        }
    }
    return "ETA unavailable";  // Return message if all retries fail
}
```

Pros:

* simple to implement

Cons:

* can flood system
* causes cascading failures

---

## 2️⃣ Backoff Strategy (Exponential Backoff)

Retry with increasing delay → gives downstream service time to recover.

```java
// Backoff strategy
public String getETAWithBackoff() throws InterruptedException {
    int retries = 3;
    int delay = 1000; // Initial delay is 1 second
    while (retries-- > 0) {
        try {
            return etaService.getETA();  // Attempt to fetch ETA from service
        } catch (Exception e) {
            Thread.sleep(delay);  // Wait before retrying
            delay *= 2;  // Exponential backoff: double the delay each time
        }
    }
    return "ETA unavailable";  // Return message if all retries fail
}
```

Benefits:

* prevents retry storms
* reduces pressure on backend
* avoids cascading failures

---

# ⚠️ Retry-Induced DDoS

Poorly implemented retry systems can accidentally behave like a DDoS attack.

### Why?

* Thousands of clients retry at the same time
* No delay or minimal delay
* Causes request spikes → system collapses

### Solutions:

✔ exponential backoff
✔ cap retry count
✔ circuit breaker
✔ rate limiting

---

# 🔌 Circuit Breaker Pattern

Protects your system by **stopping calls to a failing service**.

### States:

1. **Closed** → service healthy
2. **Open** → service failing → stop sending calls
3. **Half-Open** → send limited test requests

---

## 🧩 1. Annotation-based Example

```java
@Service
class PaymentService {

    @CircuitBreaker(name = "paymentService", fallbackMethod = "paymentFallback")
    public String charge(String userId, double amount) {
        // real payment logic
        return externalPaymentApi.charge(userId, amount);
    }

    // Fallback method in case of failure
    public String paymentFallback(String userId, double amount, Throwable t) {
        log.error("Payment Service Down. Fallback triggered.");
        return "PAYMENT_FAILED";
    }
}
```

---

## 🧩 2. Java Config Customization

```java
@Bean
public Customizer<CircuitBreakerConfigCustomizer> paymentCircuitBreakerConfig() {
    return CircuitBreakerConfigCustomizer.of("paymentService", builder -> builder
        .slidingWindowSize(10)
        .failureRateThreshold(50)
        .waitDurationInOpenState(Duration.ofSeconds(10))
        .permittedNumberOfCallsInHalfOpenState(2)
        .automaticTransitionFromOpenToHalfOpenEnabled(true));
}

```

---

## 🧩 3. application.yml Configuration

### Placeholder for code

```yaml
resilience4j:
  circuitbreaker:
    instances:
      paymentService:
        registerHealthIndicator: true
        slidingWindowSize: 10
        slidingWindowType: COUNT_BASED
        minimumNumberOfCalls: 5
        failureRateThreshold: 50
        waitDurationInOpenState: 10s
        permittedNumberOfCallsInHalfOpenState: 2
        automaticTransitionFromOpenToHalfOpenEnabled: true
```

---

# 🔃 Failover & Timeout Strategies

## ⏱️ 1. Timeout

Prevents the caller from hanging forever.

Why important:

* prevents thread blocking
* enables fallback
* stops UI freeze

Example:
If backend API is slow → fail in 2 seconds → show fallback UI.

---

## 🔁 2. Failover

Switch to backup service when primary fails.

Examples:

* Razorpay → Stripe
* Primary DB → Secondary replica
* Primary region → DR region

Failover = **zero-downtime behavior during outages**

---

# ✅ Summary — Engineering Checklist

| Problem             | Solution                  |
| ------------------- | ------------------------- |
| Temporary Spike     | Retry with Backoff        |
| Persistent Failure  | Circuit Breaker           |
| Third-party Delay   | Timeouts                  |
| Degraded Experience | Fallback UI / Cached Data |
| Avoid Throttling    | Rate Limiting             |
| Critical Services   | Failover Setup            |