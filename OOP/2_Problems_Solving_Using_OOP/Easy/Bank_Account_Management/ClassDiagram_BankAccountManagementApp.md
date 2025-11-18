```mermaid
---
title: Bank Account Management
---
classDiagram
direction TB
    class BankAccount {
	    - UUID accountNumber final
	    - String accountHolder final
	    # double balance
	    + getAccountNumber() UUID
	    + getAccountHolder() String
	    + getBalance() double
	    + deposit(double) void
	    + withdraw(double) void* 
    }
    class SavingsAccount {
	    - double MIN_BALANCE static
	    + withdraw(double) void*
    }
    class CurrentAccount {
	    - double OVERDRAFT_LIMIT static
	    + withdraw(double) void*
    }
    class Bank {
	    - String bankName
	    - Map~UUID, BankAccount~ accounts
	    + createAccount(BankAccount)
	    + getAccount(UUID) BankAccount
    }
    class BankAccountManagementApp {
	    + main(String [] args) void static
    }

	<<abstract>> BankAccount

    BankAccount <|-- SavingsAccount
    BankAccount <|-- CurrentAccount
    Bank "1" --> "*" BankAccount : manages
```
