// Demonstrates Open/Closed Principle (OCP)
// Focus: add new behavior WITHOUT modifying existing code
// Open for extension, closed for modification
// Add new discounts → no changes to existing logic.

namespace Basics.SOLID
{
    // Base abstraction
    public abstract class Discount
    {
        public abstract decimal Calculate(decimal amount);
    }

    // Extension 1
    public class RegularCustomerDiscount : Discount
    {
        public override decimal Calculate(decimal amount)
        {
            return amount * 0.10m;
        }
    }

    // Extension 2
    public class PremiumCustomerDiscount : Discount
    {
        public override decimal Calculate(decimal amount)
        {
            return amount * 0.20m;
        }
    }

    public class SOLIDOpenClosedDemo
    {
        public static int Main()
        {
            Discount discount = new PremiumCustomerDiscount();
            decimal finalDiscount = discount.Calculate(1000);

            Console.WriteLine($"Discount applied: {finalDiscount}");
            return 0;
        }
    }
}