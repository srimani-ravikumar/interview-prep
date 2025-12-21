// Demonstrates async and await
// Focus: non-blocking asynchronous execution
// await frees the calling thread until task completes.

namespace Basics.Async
{
    public class AsyncAwaitBasics
    {
        public static async Task<int> Main()
        {
            Console.WriteLine("Starting async operation...");

            int result = await LongRunningOperationAsync();

            Console.WriteLine($"Result: {result}");
            return 0;
        }

        private static async Task<int> LongRunningOperationAsync()
        {
            await Task.Delay(2000); // Simulates async work
            return 42;
        }
    }
}