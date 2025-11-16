import java.util.*;

abstract class Account {
    private static int idCounter = 1;

    private final int accountId;
    private String holderName;
    protected double balance;

    public Account(String holderName, double initialBalance) {
        this.accountId = idCounter++;
        this.holderName = holderName;
        this.balance = initialBalance;
    }

    public int getAccountId() { return accountId; }
    public String getHolderName() { return holderName; }
    public double getBalance() { return balance; }

    public void deposit(double amount) {
        balance += amount;
        System.out.println(holderName + " deposited ₹" + amount + ". Current balance: ₹" + balance);
    }

    public boolean withdraw(double amount) {
        if (amount > balance) {
            System.out.println("❌ Insufficient balance for " + holderName);
            return false;
        }
        balance -= amount;
        System.out.println(holderName + " withdrew ₹" + amount + ". Current balance: ₹" + balance);
        return true;
    }

    public abstract void displayAccountType();
}

// Savings Account
class SavingsAccount extends Account {
    public SavingsAccount(String holderName, double initialBalance) {
        super(holderName, initialBalance);
    }

    @Override
    public void displayAccountType() {
        System.out.println(getHolderName() + " has a Savings Account.");
    }
}

// Current Account
class CurrentAccount extends Account {
    public CurrentAccount(String holderName, double initialBalance) {
        super(holderName, initialBalance);
    }

    @Override
    public void displayAccountType() {
        System.out.println(getHolderName() + " has a Current Account.");
    }
}

// ===================== Loan System =====================
abstract class Loan {
    private static int loanCounter = 1;
    
    protected final int loanId;
    protected double principal;
    protected double interestRate; // per year
    protected int tenureMonths;
    protected Account linkedAccount;

    protected double amountPaid = 0;

    public Loan(Account account, double principal, double interestRate, int tenureMonths) {
        this.loanId = loanCounter++;
        this.linkedAccount = account;
        this.principal = principal;
        this.interestRate = interestRate;
        this.tenureMonths = tenureMonths;
    }

    public abstract double calculateEMI();

    public void payEMI(double amount) {
        if (amount > linkedAccount.getBalance()) {
            System.out.println("❌ Not enough balance to pay EMI.");
            return;
        }
        linkedAccount.withdraw(amount);
        amountPaid += amount;
        System.out.println("EMI of ₹" + amount + " paid for Loan #" + loanId + ". Total paid: ₹" + amountPaid);
    }

    public double getOutstandingAmount() {
        double totalPayable = calculateEMI() * tenureMonths;
        return Math.max(0, totalPayable - amountPaid);
    }

    public int getLoanId() { return loanId; }
    public Account getLinkedAccount() { return linkedAccount; }

    public void printLoanDetails() {
        System.out.println("Loan ID: " + loanId + " | Principal: ₹" + principal + " | Interest Rate: " + interestRate + "% | Tenure: " + tenureMonths + " months");
        System.out.println("Outstanding Amount: ₹" + getOutstandingAmount());
    }
}

// Personal Loan
class PersonalLoan extends Loan {
    public PersonalLoan(Account account, double principal, int tenureMonths) {
        super(account, principal, 12.0, tenureMonths); // 12% interest
    }

    @Override
    public double calculateEMI() {
        double monthlyRate = interestRate / (12 * 100);
        return (principal * monthlyRate * Math.pow(1 + monthlyRate, tenureMonths)) / (Math.pow(1 + monthlyRate, tenureMonths) - 1);
    }
}

// Home Loan
class HomeLoan extends Loan {
    public HomeLoan(Account account, double principal, int tenureMonths) {
        super(account, principal, 8.5, tenureMonths);
    }

    @Override
    public double calculateEMI() {
        double monthlyRate = interestRate / (12 * 100);
        return (principal * monthlyRate * Math.pow(1 + monthlyRate, tenureMonths)) / (Math.pow(1 + monthlyRate, tenureMonths) - 1);
    }
}

// Vehicle Loan
class VehicleLoan extends Loan {
    public VehicleLoan(Account account, double principal, int tenureMonths) {
        super(account, principal, 10.5, tenureMonths);
    }

    @Override
    public double calculateEMI() {
        double monthlyRate = interestRate / (12 * 100);
        return (principal * monthlyRate * Math.pow(1 + monthlyRate, tenureMonths)) / (Math.pow(1 + monthlyRate, tenureMonths) - 1);
    }
}

// ===================== Simulation =====================
public class BankApp {
    public static void main(String[] args) {
        System.out.println("🏦 Banking System Simulation Started\n");

        // Srimani creates a savings account
        Account srimaniAccount = new SavingsAccount("Srimani", 50000);
        srimaniAccount.displayAccountType();

        // Deposit and Withdraw
        srimaniAccount.deposit(20000);
        srimaniAccount.withdraw(15000);

        // Srimani applies for a Personal Loan
        Loan personalLoan = new PersonalLoan(srimaniAccount, 100000, 12); // 1-year loan
        personalLoan.printLoanDetails();

        // Pay first EMI
        double emi = personalLoan.calculateEMI();
        System.out.println("\nCalculated EMI: ₹" + Math.round(emi));
        personalLoan.payEMI(Math.round(emi));

        // Show updated account and loan
        System.out.println("\nAccount Balance: ₹" + srimaniAccount.getBalance());
        personalLoan.printLoanDetails();
    }
}