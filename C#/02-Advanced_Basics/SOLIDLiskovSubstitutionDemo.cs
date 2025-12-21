// Demonstrates Liskov Substitution Principle (LSP)
// Focus: derived classes must not break base behavior
// Child class must be usable wherever parent is expected
// If substitution breaks behavior → LSP violation.

namespace Basics.SOLID
{
    public class Bird
    {
        public virtual void Eat()
        {
            Console.WriteLine("Bird is eating.");
        }
    }

    public class Sparrow : Bird
    {
        public override void Eat()
        {
            Console.WriteLine("Sparrow is eating seeds.");
        }
    }

    public class SOLIDLiskovSubstitutionDemo
    {
        public static int Main()
        {
            Bird bird = new Sparrow(); // Substitution works safely
            bird.Eat();

            return 0;
        }
    }
}