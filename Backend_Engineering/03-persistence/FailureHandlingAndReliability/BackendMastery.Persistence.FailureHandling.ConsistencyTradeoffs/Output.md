# ⚖️ Consistency vs Availability — Sample Output

⚠️ Output varies due to simulated partitions.

---

## 🟢 Scenario 1 — Strong Consistency

Mode: STRONG CONSISTENCY  
Balance: 1000  

---

## 🟠 Scenario 2 — High Availability

Mode: HIGH AVAILABILITY  
⚠️ Returning potentially stale data  
Balance (maybe stale): 1000  

---

## 🔴 Scenario 3 — Partition Impact

Attempt 1:
Mode: STRONG CONSISTENCY  
BLOCKED: Partition: cannot guarantee consistency  

Attempt 2:
Mode: STRONG CONSISTENCY  
Balance: 1000  

Attempt 3:
Mode: STRONG CONSISTENCY  
BLOCKED: Partition: cannot guarantee consistency  