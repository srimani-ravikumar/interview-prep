# ☠️ Poison Data & Dead Records — Sample Output

---

## 🟢 Scenario 1 — Healthy Messages

Processing message M1  
Message M1 processed successfully  

Processing message M2  
Message M2 processed successfully  

---

## 🟠 Scenario 2 — Poison Message

Processing message M3  
Failure processing message M3: Invalid payload format  
Message M3 will be retried  

Processing message M3  
Failure processing message M3: Invalid payload format  
Message M3 will be retried  

Processing message M3  
Failure processing message M3: Invalid payload format  
[DLQ] Message M3 moved to Dead Letter Queue  

Processing message M3  
Failure processing message M3: Invalid payload format  
[DLQ] Message M3 moved to Dead Letter Queue  

---

## 🟢 Scenario 3 — Healthy Message After Poison

Processing message M4  
Message M4 processed successfully  