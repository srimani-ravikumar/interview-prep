// Demonstrates switch-case control flow
// Focus: cleaner alternative to multiple if-else conditions
// Use switch when comparing one variable against known constants.

namespace Basics.ControlFlow
{
    public class SwitchCaseExamples
    {
        public static int Main()
        {
            Console.WriteLine("Enter a number between 1 and 7:");
            int dayNumber;

            // Validate input
            while (!int.TryParse(Console.ReadLine(), out dayNumber))
            {
                Console.WriteLine("Please enter a valid numeric value.");
            }

            // switch-case for decision branching
            switch (dayNumber)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;

                case 2:
                    Console.WriteLine("Tuesday");
                    break;

                case 3:
                    Console.WriteLine("Wednesday");
                    break;

                case 4:
                    Console.WriteLine("Thursday");
                    break;

                case 5:
                    Console.WriteLine("Friday");
                    break;

                case 6:
                    Console.WriteLine("Saturday");
                    break;

                case 7:
                    Console.WriteLine("Sunday");
                    break;

                default:
                    Console.WriteLine("Invalid day number.");
                    break;
            }

            return 0;
        }
    }
}