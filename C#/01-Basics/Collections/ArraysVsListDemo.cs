// Demonstrates the difference between Array and List<T>
// Focus: size, flexibility, usage scenarios
// Array = fixed size, faster
// List = flexible, easier APIs

namespace Basics.Collections
{
    public class ArraysVsListDemo
    {
        public static int Main()
        {
            // Array has fixed size
            int[] numbersArray = new int[3];
            numbersArray[0] = 10;
            numbersArray[1] = 20;
            numbersArray[2] = 30;

            Console.WriteLine("Array elements:");
            for (int i = 0; i < numbersArray.Length; i++)
            {
                Console.WriteLine(numbersArray[i]);
            }

            // List has dynamic size
            List<int> numbersList = new List<int>();
            numbersList.Add(10);
            numbersList.Add(20);
            numbersList.Add(30);
            numbersList.Add(40); // Can grow dynamically

            Console.WriteLine("\nList elements:");
            foreach (int number in numbersList)
            {
                Console.WriteLine(number);
            }

            return 0;
        }
    }
}