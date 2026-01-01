# ☠️ Failure Handling Anti-Patterns — Sample Output

---

## 🔴 Scenario 1 — Swallowed Exception

Swallowed exception and continued

➡️ Failure occurred  
➡️ Caller never knows  
➡️ Data may be lost silently  

---

## 🔴 Scenario 2 — Fake Success

Failed, but reporting success anyway  
Operation reported as SUCCESS

➡️ System lies  
➡️ Data integrity destroyed  

---

## 🔴 Scenario 3 — Infinite Retry

Retrying forever...  
Retrying forever...  
Retrying forever...

➡️ CPU wasted  
➡️ System stuck  
➡️ No progress made  