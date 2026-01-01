```
SCENARIO 1: Normal inventory reservation

Stock reserved: 2 units
[METRICS FALLBACK] Inventory reservation attempted
Result: SUCCESS

Attempt 1:
CRITICAL FAILURE — stopping operation
[METRICS FALLBACK] Inventory reservation attempted
Result: FAILURE → Inventory DB unavailable

Attempt 2:
Stock reserved: 1 units
[METRICS FALLBACK] Inventory reservation attempted
Result: SUCCESS

Attempt 3:
CRITICAL FAILURE — stopping operation
[METRICS FALLBACK] Inventory reservation attempted
Result: FAILURE → Failed to persist inventory update

SCENARIO 3: Business rule violation

CRITICAL FAILURE — stopping operation
[METRICS FALLBACK] Inventory reservation attempted
Result: FAILURE → Insufficient inventory

```