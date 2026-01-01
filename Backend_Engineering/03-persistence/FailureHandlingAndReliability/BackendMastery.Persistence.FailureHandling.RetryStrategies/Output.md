# 🔁 Retry Strategies — Sample Output

⚠️ Output varies due to randomized failures.

---

## 🟢 Scenario 1 — Clean Success

Attempt 1: Creating order  
Order persisted: 3c2e...  
Order creation SUCCESS  

---

## 🟠 Scenario 2 — Transient Failures

Attempt 1: Creating order  
Transient failure: Transient DB timeout  
Retrying...

Attempt 2: Creating order  
Order persisted: a91f...  
Order creation SUCCESS  

---

## 🔴 Scenario 3 — Permanent Failure

Attempt 1: Creating order  
Permanent failure: Permanent constraint violation  
Final Result: FAILURE → Permanent constraint violation  

---

## 🔴 Scenario 4 — Retry Limit Exceeded

Attempt 1: Creating order  
Transient failure: Transient DB timeout  
Retrying...

Attempt 2: Creating order  
Transient failure: Transient DB timeout  
Retrying...

Attempt 3: Creating order  
Transient failure: Transient DB timeout  
Retry limit reached — failing fast  
Order failed after retries