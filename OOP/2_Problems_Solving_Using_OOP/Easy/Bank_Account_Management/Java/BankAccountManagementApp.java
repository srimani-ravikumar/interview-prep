import java.util.*;

// ---------------------------- BASE ACCOUNT ----------------------------
abstract class BankAccount {
    private final UUID accountNumber;
    private final String accountHolder;
    protected double balance; // protected → subclasses can use it

    public BankAccount(String accountHolder, double openingBalance) {
        this.accountNumber = UUID.randomUUID();
        this.accountHolder = accountHolder;
        this.balance = openingBalance;
    }

    public UUID getAccountNumber() {
        return accountNumber;
    }

    public String getAccountHolder() {
        return accountHolder;
    }

    public double getBalance() {
        return balance;
    }

    public void deposit(double amount) {
        if (amount <= 0) {
            System.out.println("❌ Deposit amount must be positive.");
            return;
        }
        balance += amount;
        System.out.println("💰 Deposited ₹" + amount + ". New Balance: ₹" + balance);
    }

    // abstract → different accounts have different withdrawal rules
    public abstract void withdraw(double amount);
}

// ---------------------------- SAVINGS ACCOUNT ----------------------------
// Rules: Minimum balance = ₹1000
class SavingsAccount extends BankAccount {
    private static final double MIN_BALANCE = 1000;

    public SavingsAccount(String accountHolder, double openingBalance) {
        super(accountHolder, openingBalance);
    }

    @Override
    public void withdraw(double amount) {
        if (amount <= 0) {
            System.out.println("❌ Invalid withdrawal amount.");
            return;
        }

        if (balance - amount < MIN_BALANCE) {
            System.out.println("❌ Cannot withdraw ₹" + amount +
                    ". Min Balance of ₹" + MIN_BALANCE + " must be maintained.");
            return;
        }

        balance -= amount;
        System.out.println("🟢 Withdrawn: ₹" + amount + ". Remaining Balance: ₹" + balance);
    }
}

// ---------------------------- CURRENT ACCOUNT ----------------------------
// Rules: Allows overdraft up to ₹10,000
class CurrentAccount extends BankAccount {
    private static final double OVERDRAFT_LIMIT = -10000;

    public CurrentAccount(String accountHolder, double openingBalance) {
        super(accountHolder, openingBalance);
    }

    @Override
    public void withdraw(double amount) {
        if (amount <= 0) {
            System.out.println("❌ Invalid withdrawal amount.");
            return;
        }

        if (balance - amount < OVERDRAFT_LIMIT) {
            System.out.println("❌ Overdraft limit exceeded! Cannot withdraw ₹" + amount);
            return;
        }

        balance -= amount;
        System.out.println("🟡 Withdrawn: ₹" + amount + ". Balance is now: ₹" + balance);
    }
}

// ---------------------------- BANK ----------------------------
class Bank {
    private final String bankName;
    private final Map<UUID, BankAccount> accounts;

    public Bank(String name) {
        this.bankName = name;
        this.accounts = new HashMap<>();
        System.out.println("🏦 Bank \"" + name + "\" initialized.");
    }

    public void createAccount(BankAccount account) {
        accounts.put(account.getAccountNumber(), account);
        System.out.println("🆕 Account Created for: " + account.getAccountHolder() +
                " | Account No: " + account.getAccountNumber());
    }

    public BankAccount getAccount(UUID accNo) {
        return accounts.get(accNo);
    }
}

// ---------------------------- CLIENT CODE ----------------------------
public class BankAccountManagementApp {
    public static void main(String[] args) throws InterruptedException {

        Bank bank = new Bank("Indian National Bank");

        // Srimani opening accounts
        SavingsAccount savings = new SavingsAccount("Srimani", 5000);
        CurrentAccount current = new CurrentAccount("Srimani", 2000);

        bank.createAccount(savings);
        bank.createAccount(current);

        // Savings account — strict rules
        System.out.println("\n===== Savings Account Operations =====");
        savings.deposit(2000);
        savings.withdraw(1000); // allowed
        savings.withdraw(4500); // NOT allowed due to minimum balance rule

        // Current account — overdraft allowed
        System.out.println("\n===== Current Account Operations =====");
        current.deposit(3000);
        current.withdraw(4000); // allowed (balance goes negative)
        current.withdraw(15000); // overdraft limit exceeded

        // Simulating delay like your library story
        System.out.println("\n📆 Srimani is planning expenses... thinking...");
        Thread.sleep(3000);

        // Continue operations
        System.out.println("\n===== More Savings Account Actions =====");
        savings.withdraw(2000); // allowed

        System.out.println("\n✨ Banking session completed successfully!");
    }
}