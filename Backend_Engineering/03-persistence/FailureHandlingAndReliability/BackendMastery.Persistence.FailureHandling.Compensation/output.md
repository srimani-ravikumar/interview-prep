# 🔄 Partial Failures & Compensation — Sample Output

⚠️ Output varies due to randomized failures.

---

## 🟢 Scenario 1 — Clean Success

Payment charged: 500  
Inventory reserved  
Order placed SUCCESSFULLY  

---

## 🟠 Scenario 2 — Partial Failure

Attempt 1:
Payment charged: 750  
FAILURE during order placement: Inventory reservation failed  
COMPENSATION: Payment refunded: 750  
COMPENSATION: Inventory released  
[COMPENSATION LOG] Order 8a3c... compensated after partial failure  

Attempt 2:
Payment charged: 750  
Inventory reserved  
Order placed SUCCESSFULLY  

---

## 🔴 Scenario 3 — Repeated Compensation

Payment charged: 1000  
FAILURE during order placement: Inventory reservation failed  
COMPENSATION: Payment refunded: 1000  
COMPENSATION: Inventory released  
[COMPENSATION LOG] Order f21b... compensated after partial failure