// Demonstrates Single Responsibility Principle (SRP)
// Focus: one class, one responsibility
// SRP → change in one responsibility doesn’t break others.

namespace Basics.SOLID
{
    // Responsible only for data
    public class Invoice
    {
        public decimal Amount { get; set; }
    }

    // Responsible only for calculations
    public class InvoiceCalculator
    {
        public decimal CalculateTax(decimal amount)
        {
            return amount * 0.18m;
        }
    }

    // Responsible only for output
    public class InvoicePrinter
    {
        public void Print(decimal total)
        {
            Console.WriteLine($"Total amount: {total}");
        }
    }

    public class SOLIDSingleResponsibilityDemo
    {
        public static int Main()
        {
            Invoice invoice = new Invoice { Amount = 1000 };

            InvoiceCalculator calculator = new InvoiceCalculator();
            decimal tax = calculator.CalculateTax(invoice.Amount);

            InvoicePrinter printer = new InvoicePrinter();
            printer.Print(invoice.Amount + tax);

            return 0;
        }
    }
}